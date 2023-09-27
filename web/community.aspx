<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="WebApplication2.community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://kit.fontawesome.com/4b0a685128.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="/css/community.css">

    <div>
        <ul class="nav nav-tabs">
            <li>
                <asp:LinkButton runat="server" ID="link_menu" OnClick="link_menu_Click">首頁</asp:LinkButton></li>
            <li>
                <asp:LinkButton runat="server" ID="link_task" OnClick="link_task_Click">任務兌換</asp:LinkButton></li>
            <li class="active">
                <asp:LinkButton runat="server" ID="link_community" OnClick="link_community_Click">社群</asp:LinkButton></li>
            <li>
                <asp:LinkButton runat="server" ID="link_user_inf">個人資料</asp:LinkButton></li>
        </ul>
    </div>
    <div class="container col-xs-6 col-xs-offset-3 table-bordered">
        <div id="header">
            <div id="user_background">
                <div class="user-bg">
                </div>
                <div class="user-headshot-div">
                    <div id="user_headshot" class="user-headshot">
                        <asp:Image ID="headshot_img" runat="server" class="headshot-img" />
                    </div>
                    <asp:Button runat="server" Text="Edit Profile" class="btn btn-link btn-sm col-xs-offset-10 btn-edit-pf" Visible="true" />
                </div>
            </div>
            <div id="user_inf">
                <div id="name">
                    <asp:Label ID="label_name" runat="server" Text="" CssClass="h3">社群名稱</asp:Label><br>
                    <asp:Label ID="label_community_category" runat="server" Text="" CssClass="text-color">社群類型</asp:Label>
                </div>
                <div id="introduction" class="introduction">
                    <asp:Label ID="label_community_description" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Label ID="label_community_create_date" runat="server" Text="" class="text-color"><span class="glyphicon glyphicon-calendar"></span>創社時間</asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="" class="text-color"><span class="glyphicon glyphicon-calendar"></span>其他資料連結</asp:Label>
                </div>
                <div>
                    <asp:Label ID="label_community_number" runat="server" Text="0"></asp:Label>
                    <asp:Label ID="label_community" runat="server" Text="社群人數" class="text-color"></asp:Label>
                    <asp:Label ID="label_active_number" runat="server" Text="0"></asp:Label>
                    <asp:Label ID="label_active" runat="server" Text="活耀度" class="text-color"></asp:Label>
                </div>
                <ul class="nav nav-tabs">
                    <li class="active">
                        <asp:LinkButton runat="server" ID="link_tweets">貼文&公告</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton runat="server" ID="link_tweets_replies">社群成員名單</asp:LinkButton></li>
                    <%--<li>
                        <asp:LinkButton runat="server" ID="link_media">設定</asp:LinkButton></li>--%>
                </ul>
            </div>
        </div>
        <div id="post_area" style="height: auto">
            <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- 這裡是需要動態更新的內容 -->
                    <asp:ListView ID="listView_community" runat="server">
                        <LayoutTemplate>
                            <table runat="server">
                                <tr id="itemPlaceholder" runat="server" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate runat="server">
                            <tr runat="server">
                                <td runat="server" rowspan="2" class="col-xs-1">
                                    <div id="post_user_headshot" class="div-round">
                                </td>
                                <td runat="server" class="col-xs-offset-2">
                                    <asp:Label ID="label_user_name" runat="server" Text='<%#Eval("userName") %>' class="fw-bold"></asp:Label></td>
                                <td runat="server" class="col-xs-offset-2" visible="false">
                                    <asp:Label ID="hidden_id" runat="server" Text='<%#Eval("id") %>'></asp:Label></td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" colspan="3" class="col-xs-offset-2">
                                    <asp:Label ID="post_text" runat="server" Text='<%#Eval("postContent") %>' class=""></asp:Label></td>
                            </tr>
                            <tr runat="server" id="post_link_btn" class="post_link_btn">
                                <td class="col-xs-offset-2"></td>
                                <td runat="server" id="post_td_comment" class="col-xs-offset-2 col-xs-3">
                                    <asp:LinkButton ID="link_community" runat="server">
                                        <i class="fa-regular fa-comment svg-icon"></i>
                                        <asp:Label ID="label_comment" runat="server" Text=" 0" class="text-color"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <td runat="server" id="post_td_share" class="col-xs-3">
                                    <asp:LinkButton ID="link_share" runat="server">
                                        <i class="fa-solid fa-retweet svg-icon"></i>
                                        <asp:Label ID="label_share" runat="server" Text=" 0" class="text-color"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <td runat="server" id="post_td_like" class="col-xs-3">
                                    <asp:LinkButton ID="link_like" runat="server" OnClick="Link_like_Click">
                                        <i class="fa-regular fa-heart svg-icon"></i>
                                        <asp:Label ID="label_like" runat="server" Text='<%#Eval("post_likes") %>' class="text-color" ></asp:Label>
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script type="text/javascript" src="/Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript"></script>
    <script>
        var _target = new EventTarget();
        setInterval(function () {
            $window_roll = $(document).height() - $(window).height();

            if ($(document).scrollTop() + 10 > $window_roll) {
                console.log("底 觸發");

                $.ajax({
                    type: "POST",
                    url: 'community.aspx/listview_renew',
                    data: JSON.stringify({ reset: "a" }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log(response.d);
                    },
                    error: function (e) {
                        console.log(JSON.stringify(e));
                    }
                });
            }
        }, 250);
    </script>

</asp:Content>
