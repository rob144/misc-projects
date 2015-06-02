using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityLMS.Models;
using UniversityLMS.DAL;
using UniversityLMS.Filters;

namespace UniversityLMS.Controllers
{
    [RAuthorizeAttribute]
    public class CourseController : Controller
    {
        private LMSContext db = new LMSContext();

        //
        // GET: /Course/

        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        //
        // GET: /Course/Details/5

        public ActionResult Details(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Course/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                course.DateCreated = DateTime.Now;
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        //
        // GET: /Course/View/5

        public ActionResult View(int id = 0)
        {
            Course course = db.Courses.Find(id);
            ViewBag.Instructors = db.Instructors;
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        public ActionResult Edit(int id = 0)
        {
            Course course = db.Courses.Find(id);
            ViewBag.Instructors = db.Instructors;
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /Course/View/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            string strInstructorIds = ((System.Collections.IEnumerable)ModelState["Instructors"].Value.RawValue)
                      .Cast<object>()
                      .Select(x => x.ToString())
                      .ToArray()[0];

            //Get the Instructor IDs which were posted from a hidden input on the HTML form.
            List<Int32> instructorIds = new String(strInstructorIds.ToCharArray())
                .Split(new Char[] {','}).Select(x => Convert.ToInt32(x)).ToList<Int32>();

            //Make sure we are starting with an empty list of Workers
            course.Instructors.Clear();

            //Validating the Workers manually so can ignore ModelState error for this field
            ModelState["Instructors"].Errors.Clear();

            foreach(int id in instructorIds){
                Instructor instr = db.Instructors.Find(id);
                if (instr != null) course.Instructors.Add(instr);
            }

            //Reload course with all instructors from db
            Course courseInDb = db.Courses
                .Where(c => c.CourseID == course.CourseID) 
                .Include(c => c.Instructors) 
                .FirstOrDefault();

            //Update scalar properties of the project
            db.Entry(courseInDb).CurrentValues.SetValues(course);

            //Check if instructors have been removed, if yes: remove from loaded course instructors
            foreach (Instructor instructorInDb in courseInDb.Instructors.ToList())
            {
                if(course.Instructors.Count(x => x.InstructorID == instructorInDb.InstructorID) <= 0)
                   courseInDb.Instructors.Remove(instructorInDb);
            }

            //Check if Workers have been added, if yes: add to loaded project Workers
            foreach(Instructor instr in course.Instructors)
            {
                 if(courseInDb.Instructors.Count(x => x.InstructorID == instr.InstructorID) <= 0)
                    courseInDb.Instructors.Add(instr);
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            //Pass the list of Workers to the view to populate select boxes
            ViewBag.Instructors = db.Instructors.ToList();

            return View(course);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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