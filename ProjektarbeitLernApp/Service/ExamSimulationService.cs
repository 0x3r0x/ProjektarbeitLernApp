using ProjektarbeitLernApp.Model.LearnApp;
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

        public ExamSimulationService(LearnProgressService learnProgressService, MultipleChoiceSetService multipleChoiceSetService)
        {
            this.learnProgressService = learnProgressService;
            this.multipleChoiceSetService = multipleChoiceSetService;
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
    }
}
