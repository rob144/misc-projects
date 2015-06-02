@ModelType VBAspProjectLog.Worker

@Code
    ViewData("Title") = "Details"
End Code

<h2>Worker Details</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Worker/Index">Worker List</a></div>
</div>

<fieldset>
    <legend></legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.FirstName):
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.FirstName)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.LastName):
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.LastName)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.EmailAddress):
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.EmailAddress)
    </div>
</fieldset>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.WorkerID})
</p>
