    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_cars.aspx.cs" Inherits="WebApplication2.web_cars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>購物欄清單</h1>

    <%--<asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="car_p_id" HeaderText="商品id" SortExpression="car_p_id"></asp:BoundField>
            <asp:BoundField DataField="car_p_name" HeaderText="商品名稱" SortExpression="car_p_name"></asp:BoundField>
            <asp:BoundField DataField="car_p_price" HeaderText="商品名稱" SortExpression="car_p_price"></asp:BoundField>
            <asp:BoundField DataField="car_p_amount" HeaderText="購買數量" SortExpression="car_p_amount"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:mydbConnectionString2 %>' SelectCommand="SELECT * FROM [Cars]"></asp:SqlDataSource>--%>
    
    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
    <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand" >
        <LayoutTemplate>
            <table>
                <tr runat="server">
                    <th runat="server">id</th>
                    <th runat="server">商品id</th>
                    <th runat="server">商品名稱</th>
                    <th runat="server">商品售價</th>
                    <th runat="server">購買數量</th>
                </tr>
                <tr runat="server" id="itemPlaceholder" />
            </table>
        </LayoutTemplate>
        <ItemTemplate runat="server">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("number") %>'></asp:Label></td>
                <td><asp:Label ID="Label2" runat="server" Text='<%# Eval("car_p_id") %>'></asp:Label></td>
                <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("car_p_name") %>'></asp:Label></td>
                <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("car_p_price") %>'></asp:Label></td>
                <td><asp:Label ID="Label5" runat="server" Text='<%# Eval("buy_amount") %>'></asp:Label></td>
                <td><asp:Button ID="Button1" runat="server" Text="刪除" CommandName="Delete_Item" /></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="確認購買" OnClick="Button2_Buy" />
    <button><a runat="server" href="~/web_cars_edit.aspx">修改</a></button>

</asp:Content>
