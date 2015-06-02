Public Enum UserRole As Integer
    Unknown = 0
    Worker = 1
    Client = 2
    Admin = 3
End Enum

Public Class User

    Public Sub New()
        UserID = -1
        UserName = ""
        EmailAddress = ""
        Password = ""
        FirstMidName = ""
        LastName = ""
        Role = UserRole.Unknown
    End Sub

    Public Property UserID As Integer
    Public Property UserName As String
    Public Property EmailAddress As String
    Public Property Password As String

    Public Property FirstMidName As String
    Public Property LastName As String

    Public Property Role As UserRole

End Class
