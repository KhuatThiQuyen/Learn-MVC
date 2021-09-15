using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_management_crud.Models
{
    public class StudentSubjectScore
    {
        private school_managementEntities db;

        public StudentSubjectScore(List<double> firstScore, List<double> secondScore, List<double> thirdScore, Student student, Subject subject)
        {
            this.firstScore = firstScore;
            this.secondScore = secondScore;
            this.thirdScore = thirdScore;
            this.student = student;
            this.subject = subject;
            db = new school_managementEntities();


        }
        public Student student { get; set; }
        public Subject subject { get; set; }

        public List<double> firstScore { get; set; }
        public List<double> secondScore { get; set; }
        public List<double> thirdScore { get; set; }
        public double finalScore { get; set; } // custom get method to return finalscore = 1 x fiS + 2 x seS + 3 x thS

        public static StudentSubjectScore getScore(int studentId, int subjectId) 
        {
            List<double> demoSc = new List<double> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // query score and handle it to return StudentSubjectScore
            return new StudentSubjectScore(demoSc, demoSc, demoSc, new Student(), new Subject());
        }


    }
}