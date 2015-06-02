<%@ Control Language="vb" AutoEventWireup="false" 
    CodeBehind="ClientActionMenu.ascx.vb" Inherits="CRMSystem.ClientActionMenu" %>

 <div id="actionMenu" class="action-menu" runat="server">
        <div id="action-menu-inner">
            <div class="action-menu-item">
                <div class="action-menu-item-inner">
                    <a href="ClientHome.aspx" >Message Threads</a>
                </div>
            </div>
            <div class="action-menu-item">
                <div class="action-menu-item-inner">
                    <a href="ClientCreateMessage" >Create New Thread</a>
                </div>
            </div>
            <div class="action-menu-bottom">bottom</div>
        </div>
    </div>
