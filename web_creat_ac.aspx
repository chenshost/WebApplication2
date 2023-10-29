<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_creat_ac.aspx.cs" Inherits="WebApplication2.web_creat_ac" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>創建帳號</h1>
    <button><a runat="server" href="~/web/login.aspx">回上一頁</a></button>
    <div>
        <formview ID="FormView1" runat="server" onsubmit="return confirm()">
            <table>
                <tr>
                    <td><asp:TextBox ID="tbox_name" runat="server" placeholder="名稱" class="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="tbox_email" runat="server" placeholder="E-mail"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="tbox_key" runat="server" placeholder="密碼" Type="password" class="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btn_creat" runat="server" Text="申請" OnClick="Creat_ac" /></td>
                </tr>
            </table>
        </formview>
    </div>

    <p id="demo">8787</p>
    <Button runat="server" onclick="hey()">gan</Button>


    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script>
        function hey() {
            document.getElementById("demo").innerHTML = "蝦?";
        }

        function confirm() {
            //document.write("有function");
            alert("有function");
        }

    </script>

</asp:Content>
