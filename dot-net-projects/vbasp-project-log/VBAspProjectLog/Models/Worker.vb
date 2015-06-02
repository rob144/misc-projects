Imports System.ComponentModel.DataAnnotations

Public Class Worker

    Public Sub New()
        Me.Projects = New List(Of Project)()
    End Sub

    Public Property WorkerID As Integer

    <Display(Name:="First Name")>
    <StringLength(50, MinimumLength:=1)>
    <MaxLength(50)>
    <Required>
    Public Property FirstName As String

    <Display(Name:="Last Name")>
    <StringLength(50, MinimumLength:=1)>
    <MaxLength(50)>
    <Required>
    Public Property LastName As String

    <Display(Name:="Email Address")>
    <MaxLength(100)>
    <Required>
    Public Property EmailAddress As String

    Public Overridable Property Projects As ICollection(Of Project)

    Public Function FullName() As String
        Return Me.FirstName & " " & Me.LastName
    End Function

End Class
