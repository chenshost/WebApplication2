<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="user_inf.aspx.cs" Inherits="WebApplication2.user_inf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ul class="nav nav-tabs">
            <li class="active"><asp:LinkButton runat="server" ID="link_menu">首頁</asp:LinkButton></li>
            <li><asp:LinkButton runat="server" ID="link_task" OnClick="link_task_Click">票券兌換</asp:LinkButton></li>
            <li><asp:LinkButton runat="server" ID="link_community" OnClick="link_community_Click">社群</asp:LinkButton></li>
            <li><asp:LinkButton runat="server" ID="link_user_inf">個人資料</asp:LinkButton></li>
        </ul>
    </div>
    <div>
        <h2>首頁</h2>
    </div>

</asp:Content>

