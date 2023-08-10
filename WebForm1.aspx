<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>表單元素</h1>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/><br>

    <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br>
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

</asp:Content>
