@ModelType VBAspProjectLog.Project

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create Project</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Home/Index">Projects Home</a></div>
</div>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Project</legend>

        <div class="editor-row">
            <div class="editor-label">
                @Html.LabelFor(Function(model) model.Title)
            </div>
            <div class="editor-field">
                @Html.EditorFor(Function(model) model.Title)
                @Html.ValidationMessageFor(Function(model) model.Title)
            </div>
        </div>

        <div class="editor-row">
            <div class="editor-label">
                @Html.LabelFor(Function(model) model.Description)
            </div>
            <div class="editor-field">
                @Html.TextAreaFor(Function(model) model.Description, 20, 50, New With {.class = ""})
                @Html.ValidationMessageFor(Function(model) model.Description)
            </div>
        </div>

        <div class="editor-row">
                <div class="editor-label">
                    Personel
                </div>
                <div id="edit-project-personel" class="editor-field">
                    @Html.EditorFor(Function(model) model.Workers)
                </div>
            </div>

        <p><input id="submit" type="submit" value="Create" /></p>

    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
