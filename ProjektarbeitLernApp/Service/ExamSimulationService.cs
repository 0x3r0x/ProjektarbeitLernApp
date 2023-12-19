using ProjektarbeitLernApp.Model.LearnApp;
using ProjektarbeitLernApp.PLAContext;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Service
{
    /// <summary>
    /// Diese Klasse benutzt den MultipleChoiceSetService um ein Set von Fragen zu generieren
    /// und den LearnProgressService um Fragen und Antworten zu validieren
    /// </summary>
    public class ExamSimulationService
    {
        private MultipleChoiceSetService multipleChoiceSetService;
        private List<MultipleChoiceSet> multipleChoiceSetList;
        private DatabasePLAContext dbContext;

        /// <summary>
        /// Konstruktor für ExamSimulationService.
        /// </summary>
        /// <param name="multipleChoiceSetService">Der Service für Multiple-Choice-Fragen-Sets.</param>
        /// <param name="dbContext">Der Datenbankkontext für Datenbankoperationen.</param>
        public ExamSimulationService(DatabasePLAContext dbContext,MultipleChoiceSetService multipleChoiceSetService)
        {
            this.multipleChoiceSetService = multipleChoiceSetService;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Erstellt eine Liste von Prüfungsfragen basierend auf der angegebenen Anzahl.
        /// </summary>
        /// <param name="numberOfQuestions">Die Anzahl der Fragen, die in der Prüfung enthalten sein sollen.</param>
        public void CreateExamList(int numberOfQuestions)
        {
            this.multipleChoiceSetList = multipleChoiceSetService.GetMultipleChoiceSets(numberOfQuestions).ToList();
        }

        /// <summary>
        /// Gibt die aktuelle Liste der Prüfungsfragen zurück.
        /// </summary>
        /// <returns>Eine Liste von Multiple-Choice-Fragen-Sets.</returns>
        public List<MultipleChoiceSet> GetExamList()
        {
            return multipleChoiceSetList;
        }

        /// <summary>
        /// Aktualisiert die Liste der Prüfungsfragen.
        /// </summary>
        /// <param name="multipleChoiceSetList">Die neue Liste von Multiple-Choice-Fragen-Sets.</param>
        public void UpdateExamList(List<MultipleChoiceSet> multipleChoiceSetList) 
        {
            this.multipleChoiceSetList = multipleChoiceSetList;
        }

        /// <summary>
        /// Speichert eine Prüfungssimulation in der Datenbank.
        /// </summary>
        /// <param name="examSimulation">Das Objekt der Prüfungssimulation, das gespeichert werden soll.</param>
        /// <returns>True, wenn das Speichern erfolgreich war, andernfalls False.</returns>
        public bool SaveExamSimulation(ExamSimulation examSimulation)
        {
            dbContext.ExamSimulation.Add(examSimulation);
            return dbContext.SaveChanges() == 1 ? true : false;
        }
    }
}
