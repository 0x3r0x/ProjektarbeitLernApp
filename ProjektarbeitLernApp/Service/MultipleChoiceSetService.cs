using Microsoft.EntityFrameworkCore;
using ProjektarbeitLernApp.Model.LearnApp;
using ProjektarbeitLernApp.PLAContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Service
{
    /// <summary>
    /// Bietet Dienste zur Verwaltung und Abfrage von Multiple-Choice-Fragen.
    /// Dieser Service interagiert mit der Datenbank, um Fragen für Lernzwecke bereitzustellen.
    /// </summary>
    public class MultipleChoiceSetService
    {
        private DatabasePLAContext dbContext { get; set; }

        /// <summary>
        /// Konstruktor für MultipleChoiceSetService.
        /// </summary>
        /// <param name="dbContext">Datenbankkontext für den Zugriff auf die Datenbank.</param>
        public MultipleChoiceSetService(DatabasePLAContext dbContext) { 
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Holt eine zufällige Multiple-Choice-Frage aus der Datenbank.
        /// </summary>
        /// <returns>Ein MultipleChoiceSet-Objekt, das eine zufällige Frage darstellt.</returns>
        public MultipleChoiceSet GetNewQuestion()
        {
            return dbContext.MultipleChoiceSet.AsNoTracking().OrderBy(r => EF.Functions.Random()).First();
        }

        /// <summary>
        /// Holt eine spezifische Multiple-Choice-Frage anhand ihrer ID.
        /// </summary>
        /// <param name="id">Die ID der Frage.</param>
        /// <returns>Das MultipleChoiceSet-Objekt der spezifischen Frage.</returns>
        public MultipleChoiceSet GetSpecificQuestion(int id)
        {
            return dbContext.MultipleChoiceSet.AsNoTracking().FirstOrDefault(e => e.Id.Equals(id));
        }

        /// <summary>
        /// Holt alle Multiple-Choice-Fragen aus der Datenbank.
        /// </summary>
        /// <returns>Eine Liste von MultipleChoiceSet-Objekten.</returns>
        public List<MultipleChoiceSet> GetAllQuestions()
        {
            return dbContext.MultipleChoiceSet.ToList();
        }

        /// <summary>
        /// Generiert eine Liste von Multiple-Choice-Fragen basierend auf der angegebenen Anzahl.
        /// </summary>
        /// <param name="numberOfQuestions">Die Anzahl der zu generierenden Fragen.</param>
        /// <returns>Eine Liste von MultipleChoiceSet-Objekten.</returns>
        public List<MultipleChoiceSet> GetMultipleChoiceSets(int numberOfQuestions)
        {
            var questions = new List<MultipleChoiceSet>();

            while(questions.Count < numberOfQuestions)
            {
                var question = GetNewQuestion();
                var alreadyInList = questions.Any(e => e.Question.Equals(question.Question));
                if(!alreadyInList)
                    questions.Add(question);
            }

            return questions;
        }

        /// <summary>
        /// Holt die Antworten zu einer spezifischen Frage anhand ihrer ID.
        /// </summary>
        /// <param name="id">Die ID der Frage.</param>
        /// <returns>Eine Liste von Answers-Objekten, die die Antworten zur Frage darstellen.</returns>
        public List<Answers> GetAnswers(int id)
        {
            var question = dbContext.MultipleChoiceSet.FirstOrDefault(e => e.Id.Equals(id));
            if (question == null)
                return null;
            return JsonSerializer.Deserialize<List<Answers>>(question.Answers);
        }

    }
}
