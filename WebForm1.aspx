<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/css/community.css">
    <script src="https://kit.fontawesome.com/4b0a685128.js" crossorigin="anonymous"></script>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="按下" OnClick="Button1_Click" />
    <asp:LinkButton ID="LinkButton1" runat="server"><span><i id="icon_like" class="fa-regular fa-heart"></i></span>LinkButton</asp:LinkButton>
    <asp:Label ID="label_like" runat="server" Text="like" class=""></asp:Label>
    <asp:Label ID="label_unlike" runat="server" Text="unlike" class="post_like"></asp:Label>

    <asp:ListView ID="listView_community" runat="server">
        <LayoutTemplate>
            <table runat="server">
                <tr id="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate runat="server">
            <tr>
                <td>
                    <asp:LinkButton ID="link_like" runat="server" CssClass="text-color" OnClick="link_like_Click">
                        <span id="icon_like1" class="text-color"><i class="fa-regular fa-heart"></i></span>
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="link_unlike" runat="server" CssClass="text-color" OnClick="link_unlike_Click">
                        <span id="icon_like2" class="post_like"><i class="fa-regular fa-heart"></i></span>
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:Label ID="label7" runat="server" Text='<%#Eval("text") %>' class=""></asp:Label>

                </td>
                <td>
                    <asp:Label ID="label8" runat="server" Text='<%#Eval("time") %>' class=""></asp:Label>

                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>


</asp:Content>
