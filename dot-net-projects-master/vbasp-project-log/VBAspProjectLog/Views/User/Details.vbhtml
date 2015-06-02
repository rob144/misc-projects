@ModelType VBAspProjectLog.User

@Code
    ViewData("Title") = "Details"
End Code

<h2>User Details</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/User/Index">User List</a></div>
</div>

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
        **********
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.UserID})
</p>
