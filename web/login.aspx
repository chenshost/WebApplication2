<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication2.web_login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../css/login.css">
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css"><link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/i18n/defaults-*.min.js"></script>

    <div class="div_login">
        <h1>登入</h1>
        <div>
            <asp:TextBox ID="tbox_ac" runat="server" class="form-control" placeholder="帳號" Text = "1zz"></asp:TextBox><br>
            <asp:TextBox ID="tbox_key" runat="server" Type="password" class="form-control" placeholder="密碼" Text = "1zz"></asp:TextBox><br>
            <asp:DropDownList ID="SelectBox" runat="server" CssClass="selectpicker">
                <asp:ListItem Value="1">使用者</asp:ListItem>
                <asp:ListItem Value="2">商家</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="btn_div">
            <asp:Button ID="btn_login" runat="server" Type="submit" Text="登入" OnClick="login_Click" class="btn btn-default" />
            <asp:Button ID="btn_sign_up" runat="server" Type="submit" Text="創建帳號" OnClick="btn_sign_up_Click" class="btn btn-primary" />
        </div>
    </div>

</asp:Content>
