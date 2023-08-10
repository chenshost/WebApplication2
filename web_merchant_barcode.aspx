<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_merchant_barcode.aspx.cs" Inherits="WebApplication2.web_merchant_barcode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>廠商條碼</h2>
    <asp:ListView ID="listview_merchant_barcode" runat="server">
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <th runat="server">廠商名稱</th>
                    <th runat="server">兌換卷名稱</th>
                    <th runat="server">兌換卷資訊</th>
                    <th runat="server">條碼ID</th>
                    <th runat="server">新增時間</th>
                    <th runat="server">截止日</th>
                    <th runat="server">傭有者</th>
                    <th runat="server">兌換狀態</th>
                </tr>
                <tr ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate runat="server">
            <tr runat="server">
                <td><asp:Label ID="Label1" runat="server" Text='<%#Eval("ticker_merchant") %>'></asp:Label></td>
                <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("ticker_name") %>'></asp:Label></td>
                <td><asp:Label ID="Label3" runat="server" Text='<%#Eval("ticker_inf") %>'></asp:Label></td>
                <td><asp:Label ID="Label4" runat="server" Text='<%#Eval("ticker_id") %>'></asp:Label></td>
                <td><asp:Label ID="Label5" runat="server" Text='<%#Eval("ticker_add_date") %>'></asp:Label></td>
                <td><asp:Label ID="Label6" runat="server" Text='<%#Eval("ticker_deadline") %>'></asp:Label></td>
                <td><asp:Label ID="Label7" runat="server" Text='<%#Eval("ticker_user_id") %>'></asp:Label></td>
                <td><asp:Label ID="Label8" runat="server" Text='<%#Eval("ticker_used") %>'></asp:Label></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <h2>生產條碼</h2>
    <div id="produce_barcode_div">
        <div>
            <table>
                <tr>
                    <td><asp:Label ID="label_merchant" runat="server" Text="廠商名稱"></asp:Label></td>
                    <td><asp:Label ID="merchant_text" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="label_tkr_name" runat="server" Text="兌換卷名稱"></asp:Label></td>
                    <td><asp:TextBox ID="tbox_tkr_name" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="label_tkr_inf" runat="server" Text="兌換卷資訊"></asp:Label></td>
                    <td><asp:TextBox ID="tbox_tkr_inf" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="label_tkr_date" runat="server" Text="截止日"></asp:Label></td>
                    <td><asp:TextBox ID="tbox_tkr_date" runat="server" placeholder="YYYYMMDD(不用槓-)"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="label_tkr_amount" runat="server" Text="生產數量"></asp:Label></td>
                    <td><asp:TextBox ID="tbox_tkr_amount" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btn_produce_barcode" runat="server" Text="生產" OnClick="btn_produce_barcode_Click" /></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:ListView ID="ListView_Produce_Barcode" runat="server">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <th runat="server">廠商名稱</th>
                            <th runat="server">兌換卷名稱</th>
                            <th runat="server">兌換卷資訊</th>
                            <th runat="server">條碼ID</th>
                            <th runat="server">新增時間</th>
                            <th runat="server">截止日</th>
                            <th runat="server">傭有者</th>
                            <th runat="server">兌換狀態</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate runat="server">
                    <tr runat="server">
                        <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("ticker_merchant") %>'></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text='<%#Eval("ticker_name") %>'></asp:Label></td>
                        <td><asp:Label ID="Label4" runat="server" Text='<%#Eval("ticker_inf") %>'></asp:Label></td>
                        <td><asp:Label ID="Label5" runat="server" Text='<%#Eval("ticker_id") %>'></asp:Label></td>
                        <td><asp:Label ID="Label8" runat="server" Text='<%#Eval("ticker_add_date") %>'></asp:Label></td>
                        <td><asp:Label ID="Label7" runat="server" Text='<%#Eval("ticker_deadline") %>'></asp:Label></td>
                        <td><asp:Label ID="Label9" runat="server" Text='<%#Eval("ticker_user_id") %>'></asp:Label></td>
                        <td><asp:Label ID="Label10" runat="server" Text='<%#Eval("ticker_used") %>'></asp:Label></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
