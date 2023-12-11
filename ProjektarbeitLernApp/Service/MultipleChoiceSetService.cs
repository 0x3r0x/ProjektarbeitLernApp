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

        public MultipleChoiceSetService(DatabasePLAContext dbContext) { 
            this.dbContext = dbContext;
        }

        public MultipleChoiceSet GetNewQuestion()
        {
            return dbContext.MultipleChoiceSet.OrderBy(r => EF.Functions.Random()).First();
        }

        public MultipleChoiceSet GetSpecificQuestion(int id)
        {
            return dbContext.MultipleChoiceSet.FirstOrDefault(e => e.Id.Equals(id));
        }

        public List<MultipleChoiceSet> GetAllQuestions()
        {
            return dbContext.MultipleChoiceSet.ToList();
        }

        public List<MultipleChoiceSet> GetMultipleChoiceSets(int numberOfQuestions)
        {
            var questions = new List<MultipleChoiceSet>();

            while(questions.Count < numberOfQuestions)
            {
                var question = GetNewQuestion();
                if(!questions.Contains(question))
                    questions.Add(question);
            }

            return questions;
        }

        public List<Answers> GetAnswers(int id)
        {
            var question = dbContext.MultipleChoiceSet.FirstOrDefault(e => e.Id.Equals(id));
            if (question == null)
                return null;
            return JsonSerializer.Deserialize<List<Answers>>(question.Answers);
        }

    }
}
