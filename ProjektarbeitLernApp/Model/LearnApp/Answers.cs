using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Model.LearnApp
{
    public class Answers
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool CorrectAnswer { get; set; }
        public bool GivenAnswer { get; set; }
    }
}
