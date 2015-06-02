using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Web.Mvc;
using UniversityLMS.DAL;

public class LoginController : System.Web.Mvc.Controller
{
    private LMSContext db = new LMSContext();
    //
    // GET: /Login
    public ActionResult Index()
    {
        //This is the main login page where users go to enter credentials.
        return View();
    }

    //
    // POST: /Login
    [HttpPost()]
    public ActionResult Index(string action)
    {
        if (action == "logout")
        {
            Session["UserIsAuthorized"] = false;
            Session.Remove("Username");
        }

        return View();
    }

    [HttpPost()]
    public ActionResult Login(string username, string password)
	{

		//Authenticate user via database
		User qUser = (from u in db.Users where u.UserName == username select u).FirstOrDefault();

		bool authenticated = false;

		if (((qUser != null))) {
			if (password == qUser.Password) {
				Session.Add("UserIsAuthorized", true);
				Session.Add("Username", username);
				authenticated = true;
			}
		}

		if (authenticated)
			return RedirectToAction("Index", "Home");

		TempData["Message"] = "The username and/or password were not recognised.";
        
		return RedirectToAction("Index");
        
	}

}
