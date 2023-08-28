<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_user_inf.aspx.cs" Inherits="WebApplication2.web_user_inf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%--<asp:Button ID="btn_task" runat="server" Text="任務兌換" OnClick="btn_task_Click" />--%>
        <ul class="nav nav-tabs">
            <li><asp:LinkButton runat="server" ID="link_task" OnClick="btn_task_Click">任務兌換</asp:LinkButton></li>
            <li><asp:LinkButton runat="server" ID="link_user_inf">個人資料</asp:LinkButton></li>
        </ul>
        <asp:Button ID="btn_back_list" runat="server" Text="取消(返回兌換)" OnClick="btn_back_list_Click" class="btn" Visible="false"/>
    </div>
    <div>
        <h2>擁有的兌換卷</h2>
        <div>
            <asp:ListView ID="listView_user_tickers" runat="server">
                <LayoutTemplate>
                    <table runat="server" css="table table-striped">
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
                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("voucher_id") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("task_id") %>'></asp:Label></td>
                        <%--<td>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("merchant_id") %>'></asp:Label></td>--%>
                        <td>
                            <asp:Label ID="label_ticker_used" runat="server" Text='<%#Eval("exchange_time") %>'></asp:Label></td>
                        <td>
                            <asp:Button ID="btn_exchange" runat="server" Text="兌換" OnClick="btn_exchange_Click" CommandArgument='<%# Container.DisplayIndex %>' Visible="true" class="btn"/></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div>
            <div>
                <div id="qrCodeContainer" runat="server" style="padding-top: 20px;"></div>
            </div>
        </div>
    </div>

</asp:Content>

