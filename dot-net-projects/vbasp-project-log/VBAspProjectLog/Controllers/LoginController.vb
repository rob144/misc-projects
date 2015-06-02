Imports System.Web.Mvc
Imports System.Web.Mvc.HttpPostAttribute

Public Class LoginController
    Inherits System.Web.Mvc.Controller

    Private db As New ProjectLogContext()

    '
    ' GET: /Login
    Function Index() As ActionResult
        'This is the main login page where users go to enter credentials.
        Return View()
    End Function

    '
    ' POST: /Login
    <HttpPost()> _
    Function Index(ByVal action As String) As ActionResult

        If action = "logout" Then
            Session("UserIsAuthorized") = False
            Session.Remove("Username")
        End If

        Return View()
    End Function

    <HttpPost()> _
    Function Login(ByVal username As String, ByVal password As String) As ActionResult

        'Authenticate user via database
        Dim qUser As User = (From u In db.Users
                           Where u.UserName = username
                           Select u).FirstOrDefault()

        Dim authenticated As Boolean = False

        If (Not qUser Is Nothing) Then
            If password = qUser.Password Then
                Session.Add("UserIsAuthorized", True)
                Session.Add("Username", username)
                authenticated = True
            End If
        End If

        If authenticated Then Return RedirectToAction("Index", "Home")

        TempData("Message") = "The username and/or password were not recognised."

        Return RedirectToAction("Index")

    End Function

End Class