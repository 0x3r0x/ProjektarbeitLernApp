using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Model.LearnApp
{
    public class LearnProgress
    {
        [Key]
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int MultipleChoiceSet_Id { get; set; }
        public int Stage { get; set; }
        public bool WasShown { get; set; }
    }
}
