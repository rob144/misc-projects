@Imports VBAspProjectLog
@ModelType Project

@Code
    ViewData("Title") = "Details"
End Code

<h2>Project Details</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Home/Index">Project List</a></div>
</div>

<fieldset>
    <legend></legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Title):
    </div>

    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Title)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Description):
    </div>

    <div class="display-field">
        @Html.Raw(Model.Description.Replace(vbCrLf, "<br/>"))
    </div>

       <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Status):
    </div>

    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Status)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateCreated):
    </div>
    
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateCreated)
    </div>

    @If Model.Status = ProjectStatus.Finished Then
        @<div class="display-label">
            @Html.DisplayNameFor(Function(model) model.DateFinished):
        </div>
        @<div class="display-field">
            @Html.DisplayFor(Function(model) model.DateFinished)
        </div>
    End If

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Workers):
    </div>
                
    <div class="display-field">   
        @If Model.Workers.Count >= 1 Then
            @For Each w As VBAspProjectLog.Worker In Model.Workers
                @w.FullName @<br /> 
            Next
        Else
            @Html.Raw("No personel assigned.")
        End If
    </div>

</fieldset>

<p>@Html.ActionLink("Edit", "Edit", New With {.id = Model.ProjectID})</p>
