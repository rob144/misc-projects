<RAuthorizeAttribute()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As New ProjectLogContext

    '
    ' GET: /Home

    Function Index() As ActionResult

        'Get the projects data and feed into the view
        ViewBag.Projects = db.Projects.ToList()
        Return View()

    End Function

End Class