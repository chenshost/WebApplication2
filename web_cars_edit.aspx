<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_cars_edit.aspx.cs" Inherits="WebApplication2.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>修改</h1>
    <asp:ListView ID="ListView1" runat="server" >
        <LayoutTemplate >
            <table runat="server">
                <tr runat="server">
                    <td runat="server">id</td>
                    <td runat="server">商品id</td>
                    <td runat="server">商品名稱</td>
                    <td runat="server">商品售價</td>
                    <td runat="server">購買數量</td>
                </tr>
                <tr runat="server" id="ItemPlaceHolder" />
            </table>
        </LayoutTemplate>
        <ItemTemplate runat="server">
            <tr runat="server">
                <td><asp:Label ID="Label1" runat="server" Text='<%#Eval("number") %>'></asp:Label></td>
                <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("car_p_id") %>'></asp:Label></td>
                <%--<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("car_p_name") %>'></asp:Label></td>
                <td><asp:Label ID="Label5" runat="server" Text='<%# Eval("car_p_price") %>'></asp:Label></td>
                <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("buy_amount") %>'></asp:Label></td>
                <td><asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("car_p_id") %>'></asp:TextBox></td>--%>
                <td><asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval("car_p_name") %>'></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval("car_p_price") %>'></asp:TextBox></td>
                <td><asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval("buy_amount") %>'></asp:TextBox></td>
                <td><asp:Button ID="Button1" runat="server" Text="修改" OnClick="cars_edit" /></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:Button ID="Button1" runat="server" Text="全部修改" OnClick="cars_edit_all" />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>

</asp:Content>
