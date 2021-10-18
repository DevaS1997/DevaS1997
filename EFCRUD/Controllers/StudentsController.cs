using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFCRUD.Models;

namespace EFCRUD.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private CourseDbContext db = new CourseDbContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.City).Include(s => s.Country).Include(s => s.Course).Include(s => s.State);
            ViewData["table"] = "Student Table";
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            ViewData["table"] = "Student Table";
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

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewData["table"] = "Student Table";
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName");
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName");
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Dob,MobileNo,Email,AddressLine1,AddressLine2,CityId,StateId,CountryId,CourseId,Zipcode,Qualification,PassedOut")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", student.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", student.CountryId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", student.CourseId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", student.StateId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewData["table"] = "Student Table";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", student.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", student.CountryId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", student.CourseId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", student.StateId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Dob,MobileNo,Email,AddressLine1,AddressLine2,CityId,StateId,CountryId,CourseId,Zipcode,Qualification,PassedOut")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", student.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", student.CountryId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", student.CourseId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", student.StateId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewData["table"] = "Student Table";
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
