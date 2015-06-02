@ModelType IEnumerable(Of VBAspProjectLog.User)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Users</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Home/Index">Projects</a></div>
    <div class="actionLink"><a href="/Worker/Index">Personel</a></div>
    <div class="actionLink"><a href="/User/Create">Create User</a></div>
</div>

<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
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
            @Html.DisplayFor(Function(modelItem) currentItem.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.EmailAddress)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.UserID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.UserID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.UserID})
        </td>
    </tr>
Next

</table>
