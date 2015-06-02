Imports System.ComponentModel.DataAnnotations

Public Enum ProjectStatus As Integer
    Not_Started = 0
    Started = 1
    Finished = 2
End Enum

Public Class Project

    Public Sub New()
        Me.Workers = New List(Of Worker)()
    End Sub

    Public Property ProjectID As Integer

    <MaxLength(100)>
    <Required>
    Public Property Title As String

    <MaxLength(1000)>
    <Required>
    Public Property Description As String

    Public Property Status As ProjectStatus

    <Display(Name:="Date Created")>
    <DataType(DataType.DateTime)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy hh:mm}")>
    Public Property DateCreated As Date

    <Display(Name:="Date Finished")>
    <DataType(DataType.DateTime)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy hh:mm}")>
    Public Property DateFinished As DateTime?

    <Display(Name:="Personel Assigned")>
    <UIHint("ProjectWorkers")>
    Public Overridable Property Workers As ICollection(Of Worker)

End Class
