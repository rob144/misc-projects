using System;
using System.Web.Mvc;

namespace UniversityLMS.Filters
{
    public class RAuthorizeAttribute: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            bool authorized = Convert.ToBoolean(filterContext.HttpContext.Session["UserIsAuthorized"]);

            if ((!authorized))
            {
                // Not logged in so send user to the login page
                filterContext.HttpContext.Response.Redirect("/Login");
            }
            else
            {
                filterContext.Controller.TempData["Username"] = filterContext.HttpContext.Session["Username"];
            }
        }
    }

}