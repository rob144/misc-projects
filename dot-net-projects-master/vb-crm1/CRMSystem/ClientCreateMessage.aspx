<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="ClientCreateMessage.aspx.vb" Inherits="CRMSystem.ClientCreateMessage" %>
<%@ Register TagPrefix="uc" TagName="ClientActionMenu" 
    Src="~/Controls/ClientActionMenu.ascx" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="Server">

    <uc:ClientActionMenu id="clientActionMenu" runat="server" />

    <h4>Create Message</h4>
    
    <form id="formCreateMessage" method="post" action="ClientCreateMessage.aspx" enctype="multipart/form-data">
        <fieldset>
            <legend></legend>

            <input id="hidThreadId" type="hidden" name="threadId" value="-1" />

            <div>
                <label>Subject</label>
                <input id="inpSubject" type="text" name="subject" />
            </div>

            <div>
                <label>Message content</label>
                <textarea id="inpContent" name="content"></textarea>
            </div>

            <div>
                <input class="button" type="submit" value="Save"/>
            </div>
        </fieldset>
    </form>

</asp:content>
