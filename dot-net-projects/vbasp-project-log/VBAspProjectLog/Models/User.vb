Imports System.ComponentModel.DataAnnotations

Public Class User

    Public Sub New()
    End Sub

    Public Property UserID As Integer

    <Display(Name:="User Name")>
    <MaxLength(20)>
    <Required>
    Public Property UserName As String

    <Display(Name:="Email Address")>
    <DataType(DataType.EmailAddress)>
    <MaxLength(100)>
    <Required>
    Public Property EmailAddress As String

    <Display(Name:="Password")>
    <DataType(DataType.Password)>
    <MaxLength(20)>
    <Required>
    Public Property Password As String

End Class
