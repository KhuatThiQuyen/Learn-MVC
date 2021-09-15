using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_management_crud.Models
{
    public class StudentModel
    {
        private school_managementEntities db;

        public StudentModel() 
        {
            db = new school_managementEntities();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ClassID { get; set; }

        public Student getStudentByID(int id)
        {
            return db.Students.Find(id);

        }
        //public  getScoreBySubject(int id)
        //{
        //    return 
        //}
    }
}