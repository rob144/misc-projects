@Imports VBAspProjectLog
@ModelType Project
@Code
    ViewData("Title") = "Delete Project"
End Code

<h2>Delete Project</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Home/Index">Projects Home</a></div>
</div>

<h3>Are you sure you want to delete this Project?</h3>
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
        @Html.DisplayFor(Function(model) model.Description)
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

</fieldset>
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p><input type="submit" value="Delete" /></p>
End Using
