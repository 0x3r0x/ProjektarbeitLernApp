using ProjektarbeitLernApp.Model.LearnApp;
using ProjektarbeitLernApp.PLAContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Service
{
    public class LearnProgressService
    {
        private DatabasePLAContext dbContext;

        public LearnProgressService(DatabasePLAContext dbContext) {
            this.dbContext = dbContext;    
        }

        public bool ValidateAnswers(MultipleChoiceSet multipleChoiceSet, Answers answers)
        {
            return true;
        }

    }
}
