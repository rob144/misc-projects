@Imports VBAspProjectLog
@ModelType User
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Project Log - Login</h2>

<form method="POST" action="Login/Login">

     @If TempData("Message") & "" <> "" Then
            @<div class="loginFailed">@TempData("Message")</div>
        End If

    <div class="loginControlsContainer">

        <div class="editor-row login-row">
            <div id="login-label-username" class="editor-label">
                @Html.DisplayNameFor(Function(model) model.UserName):
            </div>
            <div id="login-field-username" class="editor-field">
                @Html.EditorFor(Function(model) model.UserName)
                @Html.ValidationMessageFor(Function(model) model.UserName)
            </div>
        </div>

        <div class="editor-row login-row">
            <div id="login-label-password" class="editor-label">
                @Html.DisplayNameFor(Function(model) model.Password):
            </div>
            <div id="login-field-password" class="editor-field">
                @Html.EditorFor(Function(model) model.Password)
                @Html.ValidationMessageFor(Function(model) model.Password)
            </div>
        </div>

        <!---
            <input name="username" class="inpUsername" type="text" size="30"
                data-val="true" data-val-required="The Username field is required." />
            <span class="field-validation-valid" data-valmsg-for="username" data-valmsg-replace="true"></span>
            <label>Password:</label>
            <input name="password" class="inpPassword" type="password" size="30"
                 data-val="true" data-val-required="The Password field is required." />
            <span class="field-validation-valid" data-valmsg-for="password" data-valmsg-replace="true"></span>
        --->
        <p>
            <input type="submit" value="Login" />
        </p>

    </div>

</form>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section