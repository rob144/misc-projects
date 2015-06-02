<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="SupportMyTickets.aspx.vb" Inherits="CRMSystem.SupportMyTickets" %>
<%@ Register TagPrefix="uc" TagName="SupportActionMenu" 
    Src="~/Controls/SupportActionMenu.ascx" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="Server">

    <uc:SupportActionMenu id="supportActionMenu" runat="server" />

    <h4>My Tickets:</h4>
    <table id="tblMessageThreads" runat="server">
        <tr>
        <th>Subject</th>
        <th>Date Created</th>
        </tr>
    </table>

</asp:content>
