@Imports VBAspProjectLog
@ModelType Project

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit Project</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Home/Index">Projects Home</a></div>
</div>

<form action="/Project/Edit/@Model.ProjectID" method="POST">
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    <fieldset>
        <legend></legend>

            @Html.HiddenFor(Function(model) model.ProjectID)

            <div class="editor-row">
                <div class="editor-label">
                    @Html.LabelFor(Function(model) model.Title):
                </div>
                <div class="editor-field">
                    @Html.EditorFor(Function(model) model.Title)
                    @Html.ValidationMessageFor(Function(model) model.Title)
                </div>
            </div>

            <div class="editor-row-status">
                <div class="editor-label">
                    @Html.LabelFor(Function(model) model.Status):
                </div>
                <div class="editor-field">
                    @Code
                        Dim statusNames() As String = System.Enum.GetNames(GetType(VBAspProjectLog.ProjectStatus))
                        Dim statusValues() As Integer = System.Enum.GetValues(GetType(VBAspProjectLog.ProjectStatus))
                        For i As Integer = 0 To statusValues.Length - 1
                            Dim checked As String = ""
                            If Model.Status = statusValues(i) Then checked = "checked"
                            @:<input type="radio" name="Status" value="@statusValues(i)" @checked />
                              @Replace(statusNames(i),"_"," ")
                        Next
                    End Code 
                </div>
            </div>

            <div class="editor-row">
                <div class="editor-label">
                    @Html.LabelFor(Function(model) model.Description):
                </div>
                <div class="editor-field">
                    @Html.TextAreaFor(Function(model) model.Description, 20, 50, New With {.class = ""})
                    @Html.ValidationMessageFor(Function(model) model.Description)
                </div>
            </div>

            <div class="editor-row">
                <div class="editor-label">
                    @Html.LabelFor(Function(model) model.DateCreated):
                </div>
                <div class="editor-field">
                    <input id="DateCreated-disabled" name="DateCreated-disabled" type="text" value="@Model.DateCreated" disabled="disabled"/>
                    <input id="DateCreated" name="DateCreated" type="hidden" value="@Model.DateCreated" />
                </div>
            </div>

            @If Model.Status = ProjectStatus.Finished Then
                @<div class="editor-label">
                    @Html.DisplayNameFor(Function(model) model.DateFinished):
                </div>
                @<div class="editor-field">
                    <input id="DateFinished-disabled" name="DateFinished-disabled" type="text" value="@Model.DateFinished" disabled="disabled"/>
                    <input id="DateFinished" name="DateFinished" type="hidden" value="@Model.DateFinished" />
                </div>
            End If

            <div class="editor-row"> 
                <div class="editor-label">
                    Personel:
                </div>
                <div id="edit-project-personel" class="editor-field">
                   @Html.EditorFor(Function(model) model.Workers)
                </div>
            </div>

    </fieldset>
    <p><input id="submit" class="btnSubmit" type="submit" value="Save" /></p>
</form>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
