<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="user_inf.aspx.cs" Inherits="WebApplication2.user_inf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ul class="nav nav-tabs">
            <li class="active"><asp:LinkButton runat="server" ID="link_menu">首頁</asp:LinkButton></li>
            <li><asp:LinkButton runat="server" ID="link_task" OnClick="link_task_Click">任務兌換</asp:LinkButton></li>
            <li><asp:LinkButton runat="server" ID="link_community" OnClick="link_community_Click">社群</asp:LinkButton></li>
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
                            <th runat="server">商家名稱</th>
                            <th runat="server">兌換截止時間</th>
                            <th runat="server">兌換狀態</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate runat="server">
                    <tr runat="server">
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("id") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("name") %>'></asp:Label></td>
                        <td>
                            <asp:label id="label7" runat="server" text='<%#Eval("merchant_name") %>'></asp:label></td>
                        <td>
                            <asp:Label ID="label_ticker_used" runat="server" Text='<%#Eval("deadline") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="label1" runat="server" Text='<%#Eval("exchange_status") %>'></asp:Label></td>
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

