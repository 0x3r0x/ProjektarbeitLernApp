using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeitLernApp.Model.LearnApp
{
    public class MultipleChoiceSet
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answers { get; set; }

    }
}
