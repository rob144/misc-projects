Imports System.Web

Public Module SessionHelper

    Public Sub checkUserLoggedIn(ByVal context As HttpContext)
        If Not DBHelper.userExists(CType(context.Session("UserID"), Integer)) Then
            context.Response.Redirect("Login")
        End If
    End Sub

End Module
