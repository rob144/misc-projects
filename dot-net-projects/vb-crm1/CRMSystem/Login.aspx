<%@ Page Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" 
    CodeBehind="Login.aspx.vb" Inherits="CRMSystem.Login" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <form method="POST" action="Login.aspx">
        
        <div class="loginFormContainer">

            <h3 id="loginFormTitle">Sign in</h3>

            <div id="loginFormFields">
                <div class="login-row">
                    <div id="login-label-username">
                        Username :
                    </div>
                    <div id="login-field-username" >
                        <input id="inpUsername" name="username" type="text"/>
                    </div>
                </div>

                <div class="login-row">
                    <div id="login-label-password">
                        Password :
                    </div>
                    <div id="login-field-password">
                        <input id="inpPassword" name="password" type="password" />
                    </div>
                </div>
            </div>

            <input id="login-button" class="button" type="submit" value="Login" />

        </div>

    </form>

</asp:Content>
