<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="ClientViewThread.aspx.vb" Inherits="CRMSystem.ClientViewThread" %>
<%@ Register TagPrefix="uc" TagName="ClientActionMenu" 
    Src="~/Controls/ClientActionMenu.ascx" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="Server">

    <uc:ClientActionMenu id="clientActionMenu" runat="server" />

    <h3 id="messageThreadTitle" runat="server">Thread topic: </h3>

    <form id="formAddMessage" method="post" action="ClientViewThread.aspx" enctype="multipart/form-data">
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
