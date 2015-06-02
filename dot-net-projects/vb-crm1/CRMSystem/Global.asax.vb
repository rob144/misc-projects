Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

    Public Sub Session_OnStart()

        Session("UserId") = -1
        Session("Username") = ""

        'InsertTestData()

    End Sub

    Private Sub InsertTestData()

        'Initialise some test data
        DBHelper.deleteMessages()
        DBHelper.deleteMessageThreads()

        'Threads
        Dim t1 As New MessageThread()
        t1.Subject = "TEST SUBJECT 1"
        t1.CreatedBy = 1
        t1.DateCreated = DateTime.Now
        Dim t2 As New MessageThread()
        t2.Subject = "TEST SUBJECT 2"
        t2.CreatedBy = 2
        t2.DateCreated = DateTime.Now
        DBHelper.addMessageThread(t1)
        DBHelper.addMessageThread(t2)

        'Messages
        Dim m1 As New Message()
        m1.ThreadID = t2.ThreadID
        m1.Content = "Message 1"
        m1.CreatedBy = 1
        m1.DateCreated = DateTime.Now
        DBHelper.addMessage(m1)

        Dim m2 As New Message()
        m2.ThreadID = t2.ThreadID
        m2.Content = "Message 2"
        m2.CreatedBy = 2
        m2.DateCreated = DateTime.Now
        DBHelper.addMessage(m2)

    End Sub

End Class