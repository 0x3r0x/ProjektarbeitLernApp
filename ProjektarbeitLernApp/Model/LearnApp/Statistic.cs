using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Model.LearnApp
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int MultipleChoiceSet_Id { get; set; }
        public bool WasKnown { get; set; }
        public DateTime DateTime { get; set; }
    }
}
