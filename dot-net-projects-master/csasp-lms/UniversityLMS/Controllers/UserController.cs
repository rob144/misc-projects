﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using UniversityLMS.DAL;
using UniversityLMS.Filters;

namespace UniversityLMS.Controllers
{
    [RAuthorizeAttribute()]
    public class UserController : System.Web.Mvc.Controller
    {
        private LMSContext db = new LMSContext();
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if ((user == null))
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if ((user == null))
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if ((user == null))
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost()]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken()]
        public RedirectToRouteResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
