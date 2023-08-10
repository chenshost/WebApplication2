<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_task.aspx.cs" Inherits="WebApplication2.web_task" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Button ID="btn_user_inf" runat="server" Text="回到使用者資訊" OnClick="btn_user_inf_Click" />
    </div>
    <div>
        <asp:ListView ID="listView_user_inf" runat="server" OnItemCommand="listView_user_inf_ItemCommand">
            <LayoutTemplate runat="server">
                <table runat="server">
                    <tr runat="server">
                        <th>
                            <asp:Label ID="label_id" runat="server" Text="任務名稱"></asp:Label></th>
                        <th>
                            <asp:Label ID="label_name" runat="server" Text="說明"></asp:Label></th>
                        <th>
                            <asp:Label ID="label6" runat="server" Text="兌換卷商家"></asp:Label></th>
                        <th>
                            <asp:Label ID="label_ticker_name" runat="server" Text="兌換卷獎勵"></asp:Label></th>
                        <th>
                            <asp:Label ID="label3" runat="server" Text="兌換卷資訊"></asp:Label></th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("task_name") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("task_inf") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("award_ticker_merchant") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("award_ticker_name") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("award_ticker_inf") %>'></asp:Label></td>
                    <td>
                        <asp:Button ID="btn_exchange" runat="server" Text="兌換" CommandName="Save" CommandArgument='<%# Container.DisplayIndex %>' OnClick="btn_exchange_Click" />
                    </td>
                    <%--<td><asp:LinkButton ID="LinkButton1" runat="server" Text="btn" CommandName="Save" /></td>--%>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
