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
    /// 
    /// </summary>
    public class LearnProgressService
    {
        private DatabasePLAContext dbContext;
        private StatisticService statisticService;

        public LearnProgressService(DatabasePLAContext dbContext, StatisticService statisticService)
        {
            this.dbContext = dbContext;
            this.statisticService = statisticService;
        }

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

        public void SaveLearnProgress(LearnProgress learnProgress)
        {
            var isAlreadySaved = dbContext.LearnProgress.Any(e => e.Student_Id.Equals(learnProgress.Student_Id) && e.MultipleChoiceSet_Id.Equals(learnProgress.MultipleChoiceSet_Id));

            if (!isAlreadySaved)
            {
                dbContext.LearnProgress.Add(learnProgress);
                dbContext.SaveChanges();
            }
        }
        private void CheckIfAllWasShown(int studentId)
        {
            var dbLearnProgress = dbContext.LearnProgress.Where(e => e.Student_Id.Equals(studentId)).ToList();
            foreach (var learnProgress in dbLearnProgress)
            {
                if (learnProgress.WasShown == false)
                    return;
            }

            ResetWasShown(studentId);
        }

        private void ResetWasShown(int studentId)
        {
            var dbLearnProgress = dbContext.LearnProgress.Where(e => e.Student_Id.Equals(studentId)).ToList();
            foreach (var learnProgress in dbLearnProgress)
            {
                learnProgress.WasShown = false;
                dbContext.LearnProgress.Update(learnProgress);
            }

            dbContext.SaveChanges();
        }

        public void UpdateLearnProgress(LearnProgress learnProgress, Statistic statistic)
        {
            var dbLearnProgress = dbContext.LearnProgress.FirstOrDefault(e => e.Student_Id.Equals(learnProgress.Student_Id) && e.MultipleChoiceSet_Id.Equals(learnProgress.MultipleChoiceSet_Id));
            if (dbLearnProgress == null)
                return;

            dbLearnProgress.WasShown = true;
            CheckIfAllWasShown(learnProgress.Student_Id);

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

        public int GetNextMultipleChoiceSetIDToLearn(User user)
        {
            return dbContext.LearnProgress.Where(e => e.Student_Id.Equals(user.Id)).OrderBy(e => e.WasShown).ThenBy(e => e.Stage).FirstOrDefault().MultipleChoiceSet_Id;
        }

        public void InitiateLearnProgress(List<MultipleChoiceSet> multipleChoiceSetList, User user)
        {
            foreach (var set in multipleChoiceSetList)
            {
                SaveLearnProgress(new LearnProgress()
                {
                    Student_Id = user.Id,
                    MultipleChoiceSet_Id = set.Id
                });
            }
        }

        public int GetExamRipeness(User user)
        {
            var learnProgressEntries = dbContext.LearnProgress.Where(e => e.Student_Id.Equals(user.Id)).ToList();

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
