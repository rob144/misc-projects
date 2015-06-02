@ModelType IEnumerable(Of VBAspProjectLog.Worker)

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Personel</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Home/Index">Projects</a></div>
    <div class="actionLink"><a href="/Worker/Create">Create Worker</a></div>
</div>

<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EmailAddress)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.FirstName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.LastName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.EmailAddress)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.WorkerID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.WorkerID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.WorkerID})
        </td>
    </tr>
Next

</table>
