using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using UniversityLMS.Models;
using UniversityLMS.DAL;
using UniversityLMS.Filters;

namespace UniversityLMS.Controllers
{
    [RAuthorizeAttribute]
    public class StudentController : Controller
    {
        private LMSContext db = new LMSContext();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            student.EnrollmentDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult UploadImage(int id = 0)
        {
            ViewData["studentId"] = id;
            /*ToDo: write code to check if there is an image file uploaded 
              with the title "{id}_filename.ext" i.e. search the uploads folder 
             for a filename beginning {id}_, if exists, send the filename to the view.*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadImage(HttpPostedFileBase file, int studentId)
        {
            String fileName = "";

            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                String path = Path.Combine(Server.MapPath("~/Content/uploads"), "" + studentId + "_" + fileName);
                file.SaveAs(path);
            }

            ViewData["fileName"] = fileName;
            return View();
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewData["studentId"] = student.StudentID;
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5

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
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}