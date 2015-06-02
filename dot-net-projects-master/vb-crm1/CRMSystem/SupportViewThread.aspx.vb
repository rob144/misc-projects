Public Class SupportViewThread
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SessionHelper.checkUserLoggedIn(System.Web.HttpContext.Current)

        'Because we are using a site master template with asp content 
        'place holders, the form value names are prefixed with other id info
        Dim threadId As Integer = -1
        For Each key As String In Request.Form.AllKeys
            If key.ToLower().Contains("threadid") Then
                threadId = CType(Request.Form(key), Integer)
            End If
        Next

        'Check if user is adding a new message
        If Request.HttpMethod.ToString() = "POST" And _
           Trim(Request.Form("content")) & "" <> "" Then

            Dim t As MessageThread = New MessageThread()
            t = DBHelper.getMessageThread(threadId)
            Dim message As New Message()
            message.CreatedBy = CType(Session("UserID"), Integer)
            message.ThreadID = t.ThreadID
            message.Content = Request.Form("content")
            message.DateCreated = DateTime.Now
            DBHelper.addMessage(message)

        End If

        If threadId <= 0 Then threadId = CType(Request("tid"), Integer)

        'Fetch the thread and display the messages
        Dim thread As MessageThread
        thread = DBHelper.getMessageThread(threadId)
        Dim messages As List(Of Message)
        messages = DBHelper.getThreadMessages(thread.ThreadID)

        messageThreadTitle.InnerText += thread.Subject
        hidThreadId.Value = thread.ThreadID

        'Display the messages in the chosen thread
        For Each m As Message In messages

            Dim u As User = DBHelper.getUser(m.CreatedBy)

            messageThreadContainer.InnerHtml += _
               "<div class='message-container'>" _
              & "<div class='message-left'>" _
              & "<div class='message-owner-portrait'><img class='user-portrait' alt='user portrait' src='/Content/user-portrait.jpg' /></div>" _
              & "</div>" _
              & "<div class='message-right'>" _
              & "<div class='message-content message-user-" & u.Role & "'>" & m.Content & "</div>" _
              & "<div class='message-owner-name'>From " & u.FirstMidName & " on " & m.DateCreated & "</div>" _
              & "</div>" _
              & "</div>"
        Next

    End Sub

End Class