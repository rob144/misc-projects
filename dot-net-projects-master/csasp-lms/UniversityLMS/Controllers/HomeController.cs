using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityLMS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            try { TempData["UserName"] = Session["UserName"]; }
            catch (NullReferenceException ex) { /* No username set. */}
            return View();
        }
    }
}
