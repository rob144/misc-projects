Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Form("action") <> "" Then
            If Request.Form("action").ToLower() = "logout" Then
                Session("UserID") = ""
                Session("UserRole") = ""
                Session("UserFirstMidName") = ""
            End If
        End If

        Dim username As String = ""
        Dim password As String = ""

        Try
            username = Request.Form("Username")
            password = Request.Form("Password")
        Catch ex As NullReferenceException
            'username or password not sent in the request
        End Try

        If Not IsNothing(username) And Not IsNothing(password) Then
            If DBHelper.userExists(username, password) Then
                Dim user As User = DBHelper.getUser(username)
                Session("UserID") = user.UserID
                Session("UserRole") = user.Role
                Session("UserFirstMidName") = user.FirstMidName
            End If
        End If

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