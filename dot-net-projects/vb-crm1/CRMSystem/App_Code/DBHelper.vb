Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.ArrayList

Public Module DBHelper

    Private conString As String = _
         "Server=ROBIN-MAC-WIN\SQLEXPRESS;" _
       & "Database=db_wiz_wealth;" _
       & "Trusted_Connection=True;"

    Private Function getConnection() As SqlConnection
        Return New SqlConnection(conString)
    End Function

    Public Function userExists(ByVal emailAddress As String, ByVal password As String) As Boolean

        Dim con As SqlConnection = getConnection()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()
        Dim result As Boolean = False

        da.SelectCommand = New SqlCommand("SELECT * FROM tbl_user WHERE dbo.TRIM(email_address) = @emailAddress" _
                                          & " AND dbo.TRIM(password) = @password", con)
        da.SelectCommand.Parameters.AddWithValue("@emailAddress", emailAddress)
        da.SelectCommand.Parameters.AddWithValue("@password", password)
        da.SelectCommand.CommandTimeout = 5

        Try
            con.Open()
            da.Fill(ds, "result")
            Dim dt As DataTable = ds.Tables(ds.Tables.IndexOf("result"))
            If dt.Rows.Count >= 1 Then
                result = True
            End If
            con.Close()
        Catch ex As Exception
        End Try

        Return result

    End Function

    Public Function userExists(ByVal userId As Integer) As Boolean

        Dim con As SqlConnection = getConnection()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()
        Dim result As Boolean = False

        da.SelectCommand = New SqlCommand("SELECT * FROM tbl_user WHERE id = @userId", con)
        da.SelectCommand.Parameters.AddWithValue("@userId", userId)
        da.SelectCommand.CommandTimeout = 5

        Try
            con.Open()
            da.Fill(ds, "result")
            Dim dt As DataTable = ds.Tables(ds.Tables.IndexOf("result"))
            If dt.Rows.Count >= 1 Then
                result = True
            End If
            con.Close()
        Catch ex As Exception
        End Try

        Return result

    End Function

    Public Function getUser(ByVal emailAddress As String) As User

        Dim con As SqlConnection = getConnection()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()
        Dim result As New User()

        da.SelectCommand = New SqlCommand("SELECT * FROM tbl_user WHERE email_address = @emailAddress", con)
        da.SelectCommand.Parameters.AddWithValue("@emailAddress", emailAddress)
        da.SelectCommand.CommandTimeout = 5

        Try
            con.Open()
            da.Fill(ds, "result")
            Dim dt As DataTable = ds.Tables(ds.Tables.IndexOf("result"))
            If dt.Rows.Count >= 1 Then
                result.UserID = dt.Rows(0)("id")
                'NOTE: Make the username the same as the email address for now.
                result.UserName = dt.Rows(0)("email_address")
                result.FirstMidName = dt.Rows(0)("firstmidname")
                result.LastName = dt.Rows(0)("lastname")
                result.EmailAddress = dt.Rows(0)("email_address")
                result.Password = dt.Rows(0)("password")
                result.Role = dt.Rows(0)("role")
            End If
            con.Close()
        Catch ex As Exception
        End Try

        Return result

    End Function

    Public Function getUser(ByVal userId As Integer) As User

        Dim con As SqlConnection = getConnection()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()
        Dim returnValue As New User()

        da.SelectCommand = New SqlCommand("SELECT * FROM tbl_user WHERE id = @userId", con)
        da.SelectCommand.Parameters.AddWithValue("@userId", userId)
        da.SelectCommand.CommandTimeout = 5

        Try
            con.Open()
            da.Fill(ds, "result")
            Dim dt As DataTable = ds.Tables(ds.Tables.IndexOf("result"))
            If dt.Rows.Count >= 1 Then
                returnValue.UserID = dt.Rows(0)("id")
                'NOTE: Make the username the same as the email address for now.
                returnValue.UserName = dt.Rows(0)("email_address")
                returnValue.FirstMidName = dt.Rows(0)("firstmidname")
                returnValue.LastName = dt.Rows(0)("lastname")
                returnValue.EmailAddress = dt.Rows(0)("email_address")
                returnValue.Password = dt.Rows(0)("password")
                returnValue.Role = dt.Rows(0)("role")
            End If
            con.Close()
        Catch ex As Exception
        End Try

        Return returnValue

    End Function

    Public Function addMessageThread(ByRef t As MessageThread) As Integer

        Dim con As SqlConnection = getConnection()
        Dim da As New SqlDataAdapter()
        Dim id As Integer

        con.Open()

        da.InsertCommand = New SqlCommand("INSERT INTO tbl_thread (subject, created_by, date_created)" _
                    & "VALUES (@subject, @createdBy, @dateCreated); SELECT CAST(scope_identity() AS int);", con)
        da.InsertCommand.Parameters.AddWithValue("@subject", t.Subject)
        da.InsertCommand.Parameters.AddWithValue("@createdBy", t.CreatedBy)
        da.InsertCommand.Parameters.AddWithValue("@dateCreated", t.DateCreated.ToString("MM-dd-yyyy hh:mm:ss"))
        da.InsertCommand.CommandTimeout = 5
        id = Convert.ToInt32(da.InsertCommand.ExecuteScalar())
        con.Close()

        t.ThreadID = id

        Return id

    End Function

    Public Function getMessageThread(ByVal threadId As Integer) As MessageThread

        Dim con As SqlConnection = getConnection()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()

        Dim returnValue As New MessageThread()

        da.SelectCommand = New SqlCommand("SELECT * FROM tbl_thread WHERE id = @threadId", con)
        da.SelectCommand.Parameters.AddWithValue("@threadId", threadId)
        da.SelectCommand.CommandTimeout = 5

        Try
            con.Open()
            da.Fill(ds, "result")
            Dim dt As DataTable = ds.Tables(ds.Tables.IndexOf("result"))
            If dt.Rows.Count >= 1 Then
                returnValue.ThreadID = dt.Rows(0)("id")
                returnValue.Subject = dt.Rows(0)("subject")
                returnValue.CreatedBy = dt.Rows(0)("created_by")
                returnValue.DateCreated = dt.Rows(0)("date_created")
            End If
            con.Close()
        Catch ex As Exception
        End Try

        Return returnValue

    End Function

    Public Sub updateMessageThread(ByVal thread As MessageThread)

        Dim con As SqlConnection = getConnection()
        Dim da As New SqlDataAdapter()

        Dim returnValue As New MessageThread()

        da.UpdateCommand = New SqlCommand("UPDATE tbl_thread SET owner = @owner WHERE id = @threadId", con)
        da.UpdateCommand.Parameters.AddWithValue("@owner", thread.Owner)
        da.UpdateCommand.Parameters.AddWithValue("@threadId", thread.ThreadID)
        da.UpdateCommand.CommandTimeout = 5

        Try
            con.Open()
            da.UpdateCommand.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
        End Try

    End Sub

    Public Function getClientMessageThreads(ByVal clientId As Integer) As List(Of MessageThread)

        Dim con As SqlConnection = getConnection()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()
        Dim returnValue As New List(Of MessageThread)

        da.SelectCommand = New SqlCommand("SELECT * FROM tbl_thread WHERE created_by = @clientId", con)
        da.SelectCommand.Parameters.AddWithValue("@clientId", clientId)
        da.SelectCommand.CommandTimeout = 5

        Try
            con.Open()
            da.Fill(ds, "result")
            Dim dt As DataTable = ds.Tables(ds.Tables.IndexOf("result"))

            If dt.Rows.Count >= 1 Then
                For Each row As DataRow In dt.Rows
                    Dim t As New MessageThread
                    t.ThreadID = row("id")
                    t.Subject = row("subject")
                    t.CreatedBy = row("created_by")
                    t.DateCreated = row("date_created")
                    returnValue.Add(t)
                Next
            End If
            con.Close()
        Catch ex As Exception
        End Try

        Return returnValue

    End Function

    Public Function gettMessageThreadsByOwner(ByVal ownerId As Integer) As List(Of MessageThread)

        Dim con As SqlConnection = getConnection()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()
        Dim returnValue As New List(Of MessageThread)

        da.SelectCommand = New SqlCommand("SELECT * FROM tbl_thread WHERE owner = @ownerId", con)
        da.SelectCommand.Parameters.AddWithValue("@ownerId", ownerId)
        da.SelectCommand.CommandTimeout = 5

        Try
            con.Open()
            da.Fill(ds, "result")
            Dim dt As DataTable = ds.Tables(ds.Tables.IndexOf("result"))

            If dt.Rows.Count >= 1 Then
                For Each row As DataRow In dt.Rows
                    Dim t As New MessageThread
                    t.ThreadID = row("id")
                    t.Subject = row("subject")
                    t.CreatedBy = row("created_by")
                    t.DateCreated = row("date_created")
                    t.Owner = row("owner")
                    returnValue.Add(t)
                Next
            End If
            con.Close()
        Catch ex As Exception
        End Try

        Return returnValue

    End Function

    Public Sub addMessage(m As Message)

        Dim con As SqlConnection = getConnection()
        Dim da As New SqlDataAdapter()

        con.Open()

        da.InsertCommand = New SqlCommand(
            "INSERT INTO tbl_message (message_content, created_by, date_created, thread_id)" _
                    & " VALUES (@content, @createdBy, @dateCreated , @threadId)", con)

        da.InsertCommand.Parameters.AddWithValue("@content", m.Content)
        da.InsertCommand.Parameters.AddWithValue("@createdBy", m.CreatedBy)
        da.InsertCommand.Parameters.AddWithValue("@dateCreated", m.DateCreated)
        da.InsertCommand.Parameters.AddWithValue("@threadId", m.ThreadID)

        da.InsertCommand.CommandTimeout = 5
        da.InsertCommand.ExecuteNonQuery()

        con.Close()

    End Sub

    Public Function getThreadMessages(ByVal threadId As Integer) As List(Of Message)

        Dim con As SqlConnection = getConnection()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()
        Dim returnValue As New List(Of Message)

        da.SelectCommand = New SqlCommand("SELECT * FROM tbl_message WHERE thread_id = @threadId", con)
        da.SelectCommand.Parameters.AddWithValue("@threadId", threadId)
        da.SelectCommand.CommandTimeout = 5

        Try
            con.Open()
            da.Fill(ds, "result")
            Dim dt As DataTable = ds.Tables(ds.Tables.IndexOf("result"))

            If dt.Rows.Count >= 1 Then
                For Each row As DataRow In dt.Rows
                    Dim m As New Message()
                    m.MessageID = row("id")
                    m.Content = row("message_content")
                    m.CreatedBy = row("created_by")
                    m.DateCreated = row("date_created")
                    m.ThreadID = row("thread_id")
                    returnValue.Add(m)
                Next
            End If
            con.Close()
        Catch ex As Exception
        End Try

        Return returnValue

    End Function

    Public Sub deleteMessages()

        Dim con As SqlConnection = getConnection()
        Dim cmd As New SqlCommand("DELETE FROM tbl_message")
        con.Open()
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()

    End Sub

    Public Sub deleteMessageThreads()

        Dim con As SqlConnection = getConnection()
        Dim cmd As New SqlCommand("DELETE FROM tbl_thread")
        con.Open()
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()

    End Sub

    Public Sub insertTestData()

        Dim con As SqlConnection = getConnection()
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter()

        con.Open()

        For i As Integer = 0 To 10
            da.InsertCommand = New SqlCommand(
                "INSERT INTO tbl_user (username, firstmidname, lastname, email_address, password)" _
                        & " VALUES ('user1', 'jack', 'jones', 'jj@email.com','1234abcd')", con)
            da.InsertCommand.CommandTimeout = 5
            da.InsertCommand.ExecuteNonQuery()
        Next
        con.Close()
    End Sub

End Module
