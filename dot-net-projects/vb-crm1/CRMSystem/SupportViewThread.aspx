<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="SupportViewThread.aspx.vb" Inherits="CRMSystem.SupportViewThread" %>
<%@ Register TagPrefix="uc" TagName="SupportActionMenu" 
    Src="~/Controls/SupportActionMenu.ascx" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="Server">

    <uc:SupportActionMenu id="supportActionMenu" runat="server" />

    <h3 id="messageThreadTitle" runat="server">Thread topic: </h3>

    <form id="formAddMessage" method="post" action="SupportViewThread.aspx" enctype="multipart/form-data">
        <fieldset>
            <legend>Add Message</legend>

            <input id="hidThreadId" type="hidden" name="threadId" value="-1" runat="server"/>

            <div>
                <label>Add message</label>
                <textarea id="inpContent" name="content"></textarea>
            </div>

            <div>
                <input class="button" type="submit" value="Save"/>
            </div>
        </fieldset>
    </form>

    <div id="messageThreadContainer" runat="server">
    </div>

</asp:content>
