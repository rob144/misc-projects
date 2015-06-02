Public Class ClientView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SessionHelper.checkUserLoggedIn(System.Web.HttpContext.Current)

        Dim threads As List(Of MessageThread)
        threads = DBHelper.getClientMessageThreads(CType(Session("UserID"), Integer))

        'Display the message threads for this user
        For Each t As MessageThread In threads
            Dim r As New HtmlTableRow()
            Dim c1 As New HtmlTableCell()
            c1.InnerHtml = "<a href='/ClientViewThread.aspx?tid=" & t.ThreadID & "'>" & t.Subject & "</a>"
            Dim c2 As New HtmlTableCell()
            c2.InnerHtml = t.DateCreated
            r.Cells.Add(c1)
            r.Cells.Add(c2)
            tblMessageThreads.Rows.Add(r)
        Next

    End Sub

End Class