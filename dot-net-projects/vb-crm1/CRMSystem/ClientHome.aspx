<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="ClientHome.aspx.vb" Inherits="CRMSystem.ClientView" %>
<%@ Register TagPrefix="uc" TagName="ClientActionMenu" 
    Src="~/Controls/ClientActionMenu.ascx" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="Server">

    <uc:ClientActionMenu id="clientActionMenu" runat="server" />

    <h4>My Messages:</h4>
    <table id="tblMessageThreads" runat="server">
        <tr>
        <th>Subject</th>
        <th>Date Created</th>
        </tr>
    </table>

</asp:content>