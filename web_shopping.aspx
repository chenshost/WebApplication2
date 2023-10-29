<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_shopping.aspx.cs" Inherits="WebApplication2.web_products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>商品頁</h1>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="product_id">
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <th runat="server">商品id</th>
                    <th runat="server">商品名稱</th>
                    <th runat="server">商品庫存</th>
                    <th runat="server">商品售價</th>
                </tr>
                <tr ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate runat="server">
            <%-- 這邊不用寫table 因為table算已經包含在裡面 --%>
            <%-- 使用Eval方式來撈資料 --%>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("product_id") %>'></asp:Label></td>
                <td><asp:Label ID="Label2" runat="server" Text='<%# Eval("product_name") %>'></asp:Label></td>
                <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("product_amount") %>'></asp:Label></td>
                <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("product_price") %>'></asp:Label></td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:mydbConnectionString %>' SelectCommand="SELECT * FROM [Products]"></asp:SqlDataSource>
    
    <asp:Button ID="Button1" runat="server" Text="購買" OnClick="Button1_AddtoCar" />
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>

</asp:Content>
