using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using StudentManagerMVC.Models;


namespace StudentManagerMVC.Service
{
    public class ScoreService
    {
        Student _std;
        school_managementEntities _db;
       public ScoreService(Student std, school_managementEntities db)
        {
            _std = std;
            _db = db;
       }
        
        public StudentSubjectScore CalculatorScore()
        {
            var StudentSubjectScore = new StudentSubjectScore();
            StudentSubjectScore.student = _std;
            List<ScoreCalculator> listScoreCalculator = new List<ScoreCalculator>();
            var scoreBySubjs = _db.Students.Find(_std.ID).Scores.GroupBy(sc => sc.SubjectID);
            StudentSubjectScore.scoreCalculators = listScoreCalculator;
            foreach (var scoreSubject in scoreBySubjs)
            {
                Console.WriteLine(scoreSubject);
                int? subjectID = scoreSubject.Key;
                Subject subject = _db.Subjects.Find(subjectID ?? 1);
                List<double> firstScore = new List<double>();
                List<double> secondScore = new List<double>();
                List<double> thirdScore = new List<double>();
                foreach(var sc in scoreSubject)
                {
                   if(sc.ScoreTypeID ==1 ||sc.ScoreTypeID == 2)
                    {
                        firstScore.Add(sc.ScoreNumber ?? 0);
                    }
                   if(sc.ScoreTypeID == 3)
                    {
                        secondScore.Add(sc.ScoreNumber ?? 0);
                    }
                   if(sc.ScoreTypeID == 4)
                    {
                        thirdScore.Add(sc.ScoreNumber ?? 0);
                    }
                }
                //tinh diem trung binh 
                int count = firstScore.Count + secondScore.Count * 2 + thirdScore.Count * 3;
                double finalsc = (firstScore.Sum() + secondScore.Sum() * 2 + thirdScore.Sum() * 3) / count;
                ScoreCalculator subjectSc = new ScoreCalculator();
                subjectSc.finalScore = finalsc;
                subjectSc.subject = subject;
                subjectSc.firstScore = firstScore;
                subjectSc.secondScore = secondScore;
                subjectSc.thirdScore = thirdScore;
                listScoreCalculator.Add(subjectSc);

            }
            return StudentSubjectScore;
        }
     
    }
}