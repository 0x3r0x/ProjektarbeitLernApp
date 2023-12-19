using ProjektarbeitLernApp.Model.Auth;
using ProjektarbeitLernApp.Model.LearnApp;
using ProjektarbeitLernApp.PLAContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Service
{
    /// <summary>
    /// Verwaltet den Lernfortschritt der Benutzer. Dieser Service interagiert mit der Datenbank und dem Statistik-Service.
    /// </summary>
    public class LearnProgressService
    {
        private DatabasePLAContext dbContext;
        private StatisticService statisticService;

        /// <summary>
        /// Konstruktor für LearnProgressService.
        /// </summary>
        /// <param name="dbContext">Datenbankkontext für den Zugriff auf die Datenbank.</param>
        /// <param name="statisticService">Service für die Verwaltung von Benutzerstatistiken.</param>
        public LearnProgressService(DatabasePLAContext dbContext, StatisticService statisticService)
        {
            this.dbContext = dbContext;
            this.statisticService = statisticService;
        }

        /// <summary>
        /// Überprüft, ob die gegebenen Antworten korrekt sind.
        /// </summary>
        /// <param name="givenAnswer">Liste der gegebenen Antworten.</param>
        /// <returns>True, wenn alle Antworten korrekt sind, sonst False.</returns>
        public bool ValidateAnswer(List<Answers> givenAnswer)
        {
            if (givenAnswer == null)
                return false;

            foreach (Answers answer in givenAnswer)
            {
                if (answer.GivenAnswer != answer.CorrectAnswer)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Speichert den Lernfortschritt eines Benutzers.
        /// </summary>
        /// <param name="learnProgress">Lernfortschrittsdaten, die gespeichert werden sollen.</param>
        public void SaveLearnProgress(LearnProgress learnProgress)
        {
            var isAlreadySaved = dbContext.LearnProgress.Any(e => e.User_Id.Equals(learnProgress.User_Id) && e.MultipleChoiceSet_Id.Equals(learnProgress.MultipleChoiceSet_Id));

            if (!isAlreadySaved)
            {
                dbContext.LearnProgress.Add(learnProgress);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Überprüft, ob alle Multiple-Choice-Sets einem Studenten bereits gezeigt wurden.
        /// </summary>
        /// <param name="studentId">Die ID des Studenten.</param>
        private void CheckIfAllWasShown(int studentId)
        {
            var dbLearnProgress = dbContext.LearnProgress.Where(e => e.User_Id.Equals(studentId)).ToList();
            foreach (var learnProgress in dbLearnProgress)
            {
                if (learnProgress.WasShown == false)
                    return;
            }

            ResetWasShown(studentId);
        }

        /// <summary>
        /// Setzt das "WasShown"-Attribut für alle Lernfortschritte eines Studenten zurück.
        /// </summary>
        /// <param name="studentId">Die ID des Studenten.</param>
        private void ResetWasShown(int studentId)
        {
            var dbLearnProgress = dbContext.LearnProgress.Where(e => e.User_Id.Equals(studentId)).ToList();
            foreach (var learnProgress in dbLearnProgress)
            {
                learnProgress.WasShown = false;
                dbContext.LearnProgress.Update(learnProgress);
            }

            dbContext.SaveChanges();
        }

        /// <summary>
        /// Aktualisiert den Lernfortschritt eines Benutzers basierend auf gegebenen Antworten und Statistiken.
        /// </summary>
        /// <param name="learnProgress">Das Objekt des Lernfortschritts.</param>
        /// <param name="statistic">Das Objekt der Statistik, die aktualisiert werden soll.</param>
        public void UpdateLearnProgress(LearnProgress learnProgress, Statistic statistic)
        {
            var dbLearnProgress = dbContext.LearnProgress.FirstOrDefault(e => e.User_Id.Equals(learnProgress.User_Id) && e.MultipleChoiceSet_Id.Equals(learnProgress.MultipleChoiceSet_Id));
            if (dbLearnProgress == null)
                return;

            dbLearnProgress.WasShown = true;
            CheckIfAllWasShown(learnProgress.User_Id);

            if (statistic.WasKnown && dbLearnProgress.Stage < 6)
            {
                dbLearnProgress.Stage++;
            }
            else if (!statistic.WasKnown && dbLearnProgress.Stage > 0)
            {
                dbLearnProgress.Stage--;
            }

            statisticService.Insert(statistic);

            dbContext.LearnProgress.Update(dbLearnProgress);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Ermittelt die ID des nächsten Multiple-Choice-Sets, das ein Benutzer lernen sollte.
        /// </summary>
        /// <param name="user">Das Benutzerobjekt.</param>
        /// <returns>Die ID des nächsten Multiple-Choice-Sets.</returns>
        public int GetNextMultipleChoiceSetIDToLearn(User user)
        {
            return dbContext.LearnProgress.Where(e => e.User_Id.Equals(user.Id)).OrderBy(e => e.WasShown).ThenBy(e => e.Stage).FirstOrDefault().MultipleChoiceSet_Id;
        }

        /// <summary>
        /// Initialisiert den Lernfortschritt für einen Benutzer mit einer Liste von Multiple-Choice-Sets.
        /// </summary>
        /// <param name="multipleChoiceSetList">Liste von Multiple-Choice-Sets.</param>
        /// <param name="user">Das Benutzerobjekt.</param>
        public void InitiateLearnProgress(List<MultipleChoiceSet> multipleChoiceSetList, User user)
        {
            foreach (var set in multipleChoiceSetList)
            {
                SaveLearnProgress(new LearnProgress()
                {
                    User_Id = user.Id,
                    MultipleChoiceSet_Id = set.Id
                });
            }
        }

        /// <summary>
        /// Berechnet die Prüfungsreife eines Benutzers als prozentualen Wert.
        /// </summary>
        /// <param name="user">Das Benutzerobjekt.</param>
        /// <returns>Die Prüfungsreife des Benutzers als prozentualer Wert.</returns>
        public int GetExamRipeness(User user)
        {
            var learnProgressEntries = dbContext.LearnProgress.Where(e => e.User_Id.Equals(user.Id)).ToList();

            if (!learnProgressEntries.Any())
                return 0;

            double weightedSum = 0;
            int totalWeight = 0;

            foreach (var entry in learnProgressEntries)
            {
                weightedSum += entry.Stage;
                totalWeight += 6; 
            }

            double ripenessPercentage = (weightedSum / totalWeight) * 100;

            return (int)ripenessPercentage;
        }

    }
}
