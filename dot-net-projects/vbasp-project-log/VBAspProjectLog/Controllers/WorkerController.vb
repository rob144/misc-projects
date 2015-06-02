Imports System.Data.Entity

<RAuthorizeAttribute()> _
Public Class WorkerController
    Inherits System.Web.Mvc.Controller

    Private db As New ProjectLogContext

    '
    ' GET: /Worker/

    Function Index() As ActionResult
        Return View(db.Workers.ToList())
    End Function

    '
    ' GET: /Worker/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim worker As Worker = db.Workers.Find(id)
        If IsNothing(worker) Then
            Return HttpNotFound()
        End If
        Return View(worker)
    End Function

    '
    ' GET: /Worker/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Worker/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal worker As Worker) As ActionResult
        If ModelState.IsValid Then
            db.Workers.Add(worker)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(worker)
    End Function

    '
    ' GET: /Worker/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim worker As Worker = db.Workers.Find(id)
        If IsNothing(worker) Then
            Return HttpNotFound()
        End If
        Return View(worker)
    End Function

    '
    ' POST: /Worker/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal worker As Worker) As ActionResult
        If ModelState.IsValid Then
            db.Entry(worker).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(worker)
    End Function

    '
    ' GET: /Worker/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim worker As Worker = db.Workers.Find(id)
        If IsNothing(worker) Then
            Return HttpNotFound()
        End If
        Return View(worker)
    End Function

    '
    ' POST: /Worker/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim worker As Worker = db.Workers.Find(id)
        db.Workers.Remove(worker)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class