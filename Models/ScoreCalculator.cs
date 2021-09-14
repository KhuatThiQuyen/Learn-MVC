using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagerMVC.Models
{
    public class ScoreCalculator
    {
        //private school_managementEntities db;
        //public ScoreCalculator(double firstScore, double secondScore, double thirdScore,  Subject subject)
        //{
        //    this.firstScore = firstScore;
        //    this.secondScore = secondScore;
        //    this.thirdScore = thirdScore;  
        //    this.subject = subject;
        //    db = new school_managementEntities();

        //}
      
        public Subject subject { get; set; }

        public List<double> firstScore { get; set; }
        public List<double> secondScore { get; set; }
        public List<double> thirdScore { get; set; }
        public double finalScore { get; set; } // custom get method to return finalscore = 1 x fiS + 2 x seS + 3 x thS

    }
}