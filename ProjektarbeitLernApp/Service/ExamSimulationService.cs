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
        private LearnProgressService learnProgressService;
        private MultipleChoiceSetService multipleChoiceSetService;
        private List<MultipleChoiceSet> multipleChoiceSetList;
        private DatabasePLAContext dbContext;

        public ExamSimulationService(DatabasePLAContext dbContext, LearnProgressService learnProgressService, MultipleChoiceSetService multipleChoiceSetService)
        {
            this.learnProgressService = learnProgressService;
            this.multipleChoiceSetService = multipleChoiceSetService;
            this.dbContext = dbContext;
        }   

        public void CreateExamList(int numberOfQuestions)
        {
            this.multipleChoiceSetList = multipleChoiceSetService.GetMultipleChoiceSets(numberOfQuestions).ToList();
        }
        
        public List<MultipleChoiceSet> GetExamList()
        {
            return multipleChoiceSetList;
        }

        public void UpdateExamList(List<MultipleChoiceSet> multipleChoiceSetList) 
        {
            this.multipleChoiceSetList = multipleChoiceSetList;
        }

        public bool SaveExamSimulation(ExamSimulation examSimulation)
        {
            dbContext.ExamSimulation.Add(examSimulation);
            return dbContext.SaveChanges() == 1 ? true : false;
        }
    }
}
