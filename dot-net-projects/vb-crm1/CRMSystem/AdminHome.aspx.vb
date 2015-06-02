Public Class AdminView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SessionHelper.checkUserLoggedIn(System.Web.HttpContext.Current)
    End Sub

End Class