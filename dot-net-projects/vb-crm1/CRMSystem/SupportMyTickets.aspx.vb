Public Class SupportMyTickets
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Get the un-owned threads
        Dim threads As List(Of MessageThread)
        threads = DBHelper.gettMessageThreadsByOwner(CType(Session("UserID"), Integer))

        'Display the  threads
        For Each t As MessageThread In threads
            Dim r As New HtmlTableRow()
            Dim c2 As New HtmlTableCell()
            c2.InnerHtml = "<a href='/SupportViewThread.aspx?tid=" & t.ThreadID & "'>" & t.Subject & "</a>"
            Dim c3 As New HtmlTableCell()
            c3.InnerHtml = t.DateCreated
            r.Cells.Add(c2)
            r.Cells.Add(c3)
            tblMessageThreads.Rows.Add(r)
        Next

    End Sub

End Class