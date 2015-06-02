Imports System.Web.Mvc

Public Class RAuthorizeAttribute

    Inherits ActionFilterAttribute

    Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
        MyBase.OnActionExecuting(filterContext)

        Dim authorized As Boolean = Convert.ToBoolean( _
            filterContext.HttpContext.Session("UserIsAuthorized"))

        If (Not authorized) Then
            ' Not logged in so send user to the login page
            filterContext.HttpContext.Response.Redirect("/Login")
        Else
            filterContext.Controller.TempData("Username") = _
                filterContext.HttpContext.Session("Username")
        End If

    End Sub


End Class
