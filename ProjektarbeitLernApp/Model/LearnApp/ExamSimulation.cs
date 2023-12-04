using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Model.LearnApp
{
    public class ExamSimulation
    {
        [Key]
        public int Id { get; set; }
        public int Sutdent_Id { get; set; }
        public string MultipleChoiceList { get; set; }
        public bool HasPassed { get; set; }
    }
}
