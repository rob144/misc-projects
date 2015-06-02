Public Class MessageThread

    Public Sub New()
        ThreadID = -1
        Subject = ""
        CreatedBy = -1
        DateCreated = New DateTime()
        Owner = -1
    End Sub

    Public Property ThreadID As Integer
    Public Property Subject As String
    Public Property CreatedBy As Integer
    Public Property DateCreated As DateTime
    Public Property Owner As Integer

End Class
