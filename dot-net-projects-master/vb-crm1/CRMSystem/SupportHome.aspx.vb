Public Class SupportView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SessionHelper.checkUserLoggedIn(System.Web.HttpContext.Current)

        If Request.HttpMethod.ToString() = "POST" Then

            Try
                Dim tickets As String() = Request.Form("tickets").Split(",")
                For Each id As String In tickets
                    Dim t As MessageThread = DBHelper.getMessageThread(id)
                    t.Owner = CType(Session("UserID"), Integer)
                    DBHelper.updateMessageThread(t)
                Next
            Catch ex As NullReferenceException
                'No tickets selected
            End Try
        End If

        'Get the un-owned threads
        Dim threads As List(Of MessageThread)
        threads = DBHelper.gettMessageThreadsByOwner(-1)

        'Display the un-owned threads
        For Each t As MessageThread In threads
            Dim r As New HtmlTableRow()
            Dim c1 As New HtmlTableCell()
            c1.InnerHtml = "<input type='checkbox' name='tickets' value='" & t.ThreadID & "'>"
            Dim c2 As New HtmlTableCell()
            c2.InnerHtml = "<a href='/SupportViewThread.aspx?tid=" & t.ThreadID & "'>" & t.Subject & "</a>"
            Dim c3 As New HtmlTableCell()
            c3.InnerHtml = t.DateCreated
            r.Cells.Add(c1)
            r.Cells.Add(c2)
            r.Cells.Add(c3)
            tblMessageThreads.Rows.Add(r)
        Next

    End Sub

End Class