@ModelType VBAspProjectLog.Worker

@Code
    ViewData("Title") = "Delete Worker"
End Code

<h2>Delete Worker</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Worker/Index">Worker List</a></div>
</div>

<h3>Are you sure you want to delete this Worker?</h3>

<fieldset>
    <legend></legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.FirstName)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.FirstName)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.LastName)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.LastName)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.EmailAddress)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.EmailAddress)
    </div>
</fieldset>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p><input type="submit" value="Delete" /></p>
End Using
