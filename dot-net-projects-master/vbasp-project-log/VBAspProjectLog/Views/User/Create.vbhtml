@ModelType VBAspProjectLog.User

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create User</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/User/Index">User List</a></div>
</div>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend></legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.UserName)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.UserName)
            @Html.ValidationMessageFor(Function(model) model.UserName)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.EmailAddress)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.EmailAddress)
            @Html.ValidationMessageFor(Function(model) model.EmailAddress)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Password)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Password)
            @Html.ValidationMessageFor(Function(model) model.Password)
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
