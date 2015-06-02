Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        SessionHelper.checkUserLoggedIn(System.Web.HttpContext.Current)

        If Not IsNothing(Session("UserRole")) Then
            If Session("UserRole") & "" <> "" Then

                'If user is logged in don't show the login page, send to home page instead.
                If Session("UserRole") = CRMSystem.UserRole.Client Then
                    Response.Redirect("/ClientHome")
                End If

                'If user is a worker, show the worker view or redirect to a worker page
                If Session("UserRole") = CRMSystem.UserRole.Worker Then
                    Response.Redirect("/SupportHome")
                End If

                'if user is an admin, show the admin view or redirect to an admin page -->
                If Session("UserRole") = CRMSystem.UserRole.Admin Then
                    Response.Redirect("/AdminHome")
                End If

            End If
        End If

    End Sub
End Class