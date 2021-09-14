using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagerMVC.Models
{
    public class StudentSubjectScore
    {
        
        public Student student { get; set; }
        
        public List<ScoreCalculator> scoreCalculators { get;set; }
    }

}
