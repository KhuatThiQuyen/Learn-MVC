using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagerMVC.Models
{
    public class ScoreCalculator
    {
        //private school_managemententities db;
        //public scorecalculator(double firstscore, double secondscore, double thirdscore, subject subject)
        //{
        //    this.firstscore = firstscore;
        //    this.secondscore = secondscore;
        //    this.thirdscore = thirdscore;
        //    this.subject = subject;
        //    db = new school_managemententities();

        //}

        public Subject subject { get; set; }
        public List<double> firstScore { get; set; }
        public List<double> secondScore { get; set; }
        public List<double> thirdScore { get; set; }
        public double finalScore { get; set; } // custom get method to return finalscore = 1 x fiS + 2 x seS + 3 x thS

        
    }
}