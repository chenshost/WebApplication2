<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_user_inf.aspx.cs" Inherits="WebApplication2.web_user_inf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="css/user_inf.css">
    <div>
        <asp:Button ID="btn_task" runat="server" Text="任務兌換" OnClick="btn_task_Click" />
    </div>
    <div>
        <h2>使用者資訊</h2>
        <div>
            <asp:ListView ID="listView_user_inf" runat="server">
                <LayoutTemplate>
                    <table>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <th>
                            <asp:Label ID="label_id" runat="server" Text="使用者id"></asp:Label></th>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("user_id") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="label_name" runat="server" Text="名稱"></asp:Label></th>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("user_name") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="label_email" runat="server" Text="email"></asp:Label></th>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("user_mail") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="label_money" runat="server" Text="經驗值"></asp:Label></th>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("user_money") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="label5" runat="server" Text="權限"></asp:Label></th>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("user_grade") %>'></asp:Label></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <div>
        <h2>擁有的兌換卷</h2>
        <div>
            <asp:ListView ID="listView_user_tickers" runat="server">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <th runat="server">條碼ID</th>
                            <th runat="server">票卷名稱</th>
                            <th runat="server">任務id</th>
                            <th runat="server">廠商</th>
                            <th runat="server">兌換時間</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate runat="server">
                    <tr runat="server">
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("id") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("voucher_name") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("task_id") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("merchant_id") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="label_ticker_used" runat="server" Text='<%#Eval("exchange_time") %>'></asp:Label></td>
                        <td>
                            <asp:Button ID="btn_exchange" runat="server" Text="兌換" OnClick="btn_exchange_Click" CommandArgument='<%# Container.DisplayIndex %>' /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div>
            <%--<div class="Barcode">
                <asp:Image ID="ImgBarcode" runat="server" class="barcode" />
            </div>--%>
            <div>
                <div id="qrCodeContainer" runat="server" style="padding-top: 20px;"></div>
            </div>
        </div>
    </div>

</asp:Content>

