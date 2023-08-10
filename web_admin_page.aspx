<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_admin_page.aspx.cs" Inherits="WebApplication2.web_admin_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>管理者頁面</h1>
    <asp:Button ID="btn_barcode_scan_link" runat="server" Text="條碼掃描管理" OnClick="btn_barcode_scan_link_Click" /><br>
    <asp:Button ID="button2" runat="server" Text="條碼ID管理" OnClick="btn_barcode_edit_link_Click" /><br>
    <asp:Button ID="button3" runat="server" Text="使用者帳號管理" />

    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script>
        function link() {
            //window.location.herf = "~/web_admin_barcode.aspx";
            //$(location).attr('herf', 'web_admin_barcode.aspx');
            //alert("gan");
        }
    </script>

</asp:Content>
