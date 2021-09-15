using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using StudentManagerMVC.Service;
using PagedList;
using System.Web.Mvc;
using StudentManagerMVC.Models;


namespace StudentManagerMVC.Controllers
{
    public class StudentsController : Controller
    {
        private school_managementEntities db = new school_managementEntities();

        // GET: Students
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {  
            //search
            //var links = from l in db.Students select l;// lấy toàn bộ liên kết

            //if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            //{
            //    links = links.Where(s => (s.Name.Contains(searchString))); //lọc theo chuỗi tìm kiếm
            //}
            //paging
            

            ViewBag.CurrentSort = sortOrder;
           
            //Sort 
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            //Paging 
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            //Searching Name or class of Student
            var students = db.Students.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString)
                                       || s.Class.Name.Contains(searchString));
            }

            //sort name, class, age of Student
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.Name);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.Age);
                    break;
                default:
                    students = students.OrderBy(s => s.Age);
                    break;
                case "class_desc":
                    students = students.OrderByDescending(s => s.Class.Name);
                    break;
            }

            //pageSize: so luong Student trong 1 page
            //PageNumber: so luong page
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));

        }

       


        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ScoreService service = new ScoreService(student, db);
           // service.CalculatorScore();
            StudentSubjectScore studentSubjectScore = service.CalculatorScore();
           
            return View(studentSubjectScore);
            
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,ClassID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", student.ClassID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", student.ClassID);
            return View(student);

            
        }
       
        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age,ClassID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", student.ClassID);
            return View(student);

        }
        
        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
