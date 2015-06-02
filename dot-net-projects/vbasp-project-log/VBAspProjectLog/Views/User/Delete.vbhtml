@ModelType VBAspProjectLog.User

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete User</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/User/Index">User List</a></div>
</div>

<h3>Are you sure you want to delete this User?</h3>
<fieldset>
    <legend></legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.UserName)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.UserName)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.EmailAddress)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.EmailAddress)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Password)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Password)
    </div>
</fieldset>
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p>
        <input type="submit" value="Delete" />
    </p>
End Using
