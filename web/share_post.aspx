<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="share_post.aspx.cs" Inherits="WebApplication2.web.share_post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container col-sm-6 col-sm-offset-3 table-bordered">
        <div id="post_area" style="height: auto">
            <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <!-- Listview貼文主體 -->
                    <asp:ListView ID="listView_community" runat="server" EnableViewState="true" OnItemCommand="listView_comments_ItemCommand">
                        <LayoutTemplate>
                            <table runat="server">
                                <tr id="itemPlaceholder" runat="server" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate runat="server">
                            <tr runat="server" class="post_head post_link_btn">
                                <td runat="server" rowspan="2" class="col-xs-1">
                                    <div id="post_user_headshot" class="div-round">
                                </td>
                                <td runat="server" class="col-xs-offset-2 post_head">
                                    <asp:Label ID="label_user_name" runat="server" Text='<%#Eval("userName") %>' class="fw-bold"></asp:Label></td>
                                <td runat="server" class="col-xs-offset-2" visible="false">
                                    <asp:Label ID="hidden_id" runat="server" Text='<%#Eval("id") %>'></asp:Label></td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" colspan="3" class="col-xs-offset-2">
                                    <asp:Label ID="post_text" runat="server" Text='<%#Eval("postContent") %>' class=""></asp:Label></td>
                            </tr>
                            <%-- 貼文功能連結 --%>
                            <tr runat="server" id="post_link_btn" class="post_link_btn">
                                <td class="col-xs-offset-2"></td>
                                <%-- 留言 --%>
                                <td runat="server" id="post_td_comment" class="col-xs-offset-2 col-xs-3">
                                    <asp:LinkButton ID="link_comment" runat="server" OnClick="link_comment_Click">
                                        <i class="fa-regular fa-comment svg-icon"></i>
                                        <asp:Label ID="label_comment" runat="server" Text='<%#Eval("total_comments") %>' class="text-color"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <%-- 分享貼文 --%>
                                <td runat="server" id="post_td_share" class="col-xs-3">
                                    <asp:LinkButton ID="link_share" runat="server" OnClick="link_share_Click">
                                        <i class="fa-solid fa-retweet svg-icon"></i>
                                        <asp:Label ID="label_share" runat="server" Text="" class="text-color"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <%-- 點讚 --%>
                                <td runat="server" id="post_td_like" class="col-xs-3">
                                    <asp:LinkButton ID="link_unlike" runat="server" OnClick="Link_unlike_Click" CssClass="text-color">
                                        <span id="" class=""><i class="fa-regular fa-heart"></i></span>
                                        <asp:Label ID="label_unlike" runat="server" Text='<%#Eval("post_likes") %>' class="" ></asp:Label>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="link_like" runat="server" OnClick="Link_like_Click" CssClass="post_like">
                                        <span id="icon_like" class=""><i class="fa-solid fa-heart"></i></span>
                                        <asp:Label ID="label_like" runat="server" Text='<%#Eval("post_likes") %>' class="" ></asp:Label>
                                        <asp:Label ID="label_like_stats" runat="server" Text='<%#Eval("user_like") %>' class="" Visible="false"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                            </tr>
                            <%-- 留言板 --%>
                            <tr>
                                <td colspan="4">
                                    <asp:ListView ID="listView_comments" runat="server" >
                                        <LayoutTemplate>
                                            <table runat="server">
                                                <tr id="itemPlaceholder" runat="server" />
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate runat="server">
                                            <tr runat="server">
                                                <td runat="server" rowspan="2" class="col-xs-1">
                                                    <div id="comments_user_headshot" class="post-headshot">
                                                </td>
                                                <td runat="server" class="col-xs-offset-2">
                                                    <asp:Label ID="label_comments_user" runat="server" Text='<%#Eval("userName") %>' class="fw-bold"></asp:Label></td>
                                                <td runat="server" class="col-xs-offset-2" visible="false">
                                                    <asp:Label ID="hidden_id" runat="server" Text='<%#Eval("id") %>'></asp:Label></td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" colspan="3" class="col-xs-offset-2">
                                                    <asp:Label ID="label_comments_text" runat="server" Text='<%#Eval("commentContent") %>' class=""></asp:Label></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </td>
                            </tr>
                            <tr id="comment_div" runat="server">
                                <td runat="server" colspan="4" class="col-xs-offset-2">
                                    <asp:TextBox ID="comment_tbox" runat="server" placeholder="" CssClass="col-xs-offset-2" Visible="false"></asp:TextBox>
                                    <asp:Button runat="server" Text="留言" ID="comment_btn" class="btn btn-xs" Visible="false" OnClick="comment_btn_Click"/>
                                </td>
                            </tr>
                            <tr class="post_bottom"></tr>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:postbacktrigger controlid="comment_btn"></asp:postbacktrigger>--%>
                </Triggers>
            </asp:UpdatePanel>
            <asp:Label ID="posts_bottom_label" runat="server" Text="" style="display: table; margin: 0 auto;" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>
