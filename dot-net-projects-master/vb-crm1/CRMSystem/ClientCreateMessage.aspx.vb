Public Class ClientCreateMessage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SessionHelper.checkUserLoggedIn(System.Web.HttpContext.Current)

        If Request.HttpMethod.ToString() = "POST" And _
            Trim(Request.Form("subject")) & "" <> "" And _
            Trim(Request.Form("content")) & "" <> "" Then

            Dim message As New Message()
            message.CreatedBy = CType(Session("UserID"), Integer)
            message.ThreadID = CType(Request.Form("threadId"), Integer)

            If message.ThreadID = -1 Then
                Dim t As New MessageThread()
                t.CreatedBy = message.CreatedBy
                t.Subject = Request.Form("subject")
                t.DateCreated = DateTime.Now
                DBHelper.addMessageThread(t)
                message.ThreadID = t.ThreadID
            End If

            message.Content = Request.Form("content")
            message.DateCreated = DateTime.Now
            DBHelper.addMessage(message)

            Response.Redirect("ClientViewThread.aspx?tid=" & message.ThreadID)

        End If

    End Sub

End Class