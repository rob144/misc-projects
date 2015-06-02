<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="SupportHome.aspx.vb" Inherits="CRMSystem.SupportView" %>
<%@ Register TagPrefix="uc" TagName="SupportActionMenu" 
    Src="~/Controls/SupportActionMenu.ascx" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="Server">
    
    <uc:SupportActionMenu id="supportActionMenu" runat="server" />

    <h4>Ticket Queue</h4>
    <form method="post" action="SupportHome">
    
        <input class="button" type="submit" value="Take selected"/>

        <table id="tblMessageThreads" runat="server">
            <tr>
            <th>Select</th>
            <th>Subject</th>
            <th>Date Created</th>
            </tr>
        </table>

        
    </form>

</asp:content>
