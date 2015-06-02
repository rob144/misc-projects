@ModelType VBAspProjectLog.Worker

@Code
    ViewData("Title") = "Create Worker"
End Code

<h2>Create Worker</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Worker/Index">Worker List</a></div>
</div>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend></legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.FirstName)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.FirstName)
            @Html.ValidationMessageFor(Function(model) model.FirstName)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.LastName)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.LastName)
            @Html.ValidationMessageFor(Function(model) model.LastName)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.EmailAddress)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.EmailAddress)
            @Html.ValidationMessageFor(Function(model) model.EmailAddress)
        </div>

        <p><input type="submit" value="Create" /></p>
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
