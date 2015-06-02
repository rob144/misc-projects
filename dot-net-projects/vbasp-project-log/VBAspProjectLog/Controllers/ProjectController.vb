Imports System.Data.Entity

<RAuthorizeAttribute()>
Public Class ProjectController
    Inherits System.Web.Mvc.Controller

    Private db As New ProjectLogContext()

    '
    ' GET: /Project
    Function Index() As ActionResult
        Return RedirectToAction("Index", "Home")
    End Function

    '
    ' GET: /Project/Details/x
    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim project As Project = db.Projects.Find(id)
        If IsNothing(project) Then
            Return HttpNotFound()
        End If
        Return View(project)
    End Function

    '
    ' GET: /Project/Create
    Function Create() As ActionResult
        ViewBag.Workers = db.Workers.ToList()
        Return View()
    End Function

    '
    ' POST: /Project/Create
    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal project As Project) As ActionResult

        project.DateCreated = Date.Now()
        project.Status = ProjectStatus.Not_Started

        'Get the Worker IDs which were posted from a hidden input on the HTML form.
        Dim strWorkerIds() As String = Split(ModelState.Item("Workers").Value.RawValue(0), ",")

        'Make sure we are starting with an empty list of Workers
        project.Workers.Clear()

        'Validating the Workers manually so can ignore ModelState error for this field
        ModelState("Workers").Errors.Clear()

        For i As Integer = LBound(strWorkerIds) To UBound(strWorkerIds)
            Dim workerId As Integer
            If Integer.TryParse(Trim(strWorkerIds(i)), workerId) Then
                Dim worker As Worker = db.Workers.Find(workerId)
                If Not worker Is Nothing Then
                    project.Workers.Add(worker)
                End If
            End If
        Next

        If ModelState.IsValid Then
            db.Projects.Add(project)
            db.SaveChanges()
            Return RedirectToAction("Index", "Home")
        End If

        Return View(project)
    End Function

    '
    ' GET: /Project/Edit/x
    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult

        Dim project As Project = db.Projects.Find(id)
        ViewBag.Workers = db.Workers.ToList()

        If IsNothing(project) Then
            Return HttpNotFound()
        End If

        Return View(project)

    End Function

    '
    ' POST: /Project/Edit/x
    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal project As Project) As ActionResult

        'Get the Worker IDs which were posted from a hidden input on the HTML form.
        Dim strWorkerIds() As String = Split(ModelState.Item("Workers").Value.RawValue(0), ",")

        'Make sure we are starting with an empty list of Workers
        project.Workers.Clear()

        'Validating the Workers manually so can ignore ModelState error for this field
        ModelState("Workers").Errors.Clear()

        For i As Integer = LBound(strWorkerIds) To UBound(strWorkerIds)
            Dim workerId As Integer
            If Integer.TryParse(Trim(strWorkerIds(i)), workerId) Then
                Dim worker As Worker = db.Workers.Find(workerId)
                If Not worker Is Nothing Then
                    project.Workers.Add(worker)
                End If
            End If
        Next

        ' Reload project with all Workers from db
        Dim projectInDb = db.Projects.Include(Function(p) p.Workers).[Single](Function(p) p.ProjectID = project.ProjectID)

        If (projectInDb.Status <> project.Status And project.Status = ProjectStatus.Finished) Then
            project.DateFinished = Date.Now()
        End If

        ' Update scalar properties of the project
        db.Entry(projectInDb).CurrentValues.SetValues(project)

        ' Check if Workers have been removed, if yes: remove from loaded project Workers
        For Each workerInDb As Worker In projectInDb.Workers.ToList()
            If Not project.Workers.Any(Function(w) w.WorkerID = workerInDb.WorkerID) Then
                projectInDb.Workers.Remove(workerInDb)
            End If
        Next

        ' Check if Workers have been added, if yes: add to loaded project Workers
        For Each worker As Worker In project.Workers
            If Not projectInDb.Workers.Any(Function(w) w.WorkerID = worker.WorkerID) Then
                projectInDb.Workers.Add(worker)
            End If
        Next

        If ModelState.IsValid Then
            db.SaveChanges()
            Return RedirectToAction("Index", "Home")
        End If

        'Pass the list of Workers to the view to populate select boxes
        ViewBag.Workers = db.Workers.ToList()

        Return View(project)

    End Function

    '
    ' GET: /Project/Delete/5
    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim project As Project = db.Projects.Find(id)
        If IsNothing(project) Then
            Return HttpNotFound()
        End If
        Return View(project)
    End Function

    '
    ' POST: /Project/Delete/5
    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim project As Project = db.Projects.Find(id)
        db.Projects.Remove(project)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class