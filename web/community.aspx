<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="WebApplication2.community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://kit.fontawesome.com/4b0a685128.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="/css/community.css">

    <div>
        <ul class="nav nav-tabs">
            <li>
                <asp:LinkButton runat="server" ID="link_menu" OnClick="link_menu_Click">首頁</asp:LinkButton></li>
            <li>
                <asp:LinkButton runat="server" ID="link_task" OnClick="link_task_Click">票券兌換</asp:LinkButton></li>
            <li class="active">
                <asp:LinkButton runat="server" ID="link_community" OnClick="link_community_Click" OnClientClick="storeOriginalWindowHeight(); return true;">社群</asp:LinkButton></li>
            <li>
                <asp:LinkButton runat="server" ID="link_user_inf">個人資料</asp:LinkButton></li>
        </ul>
    </div>
    <div class="container col-sm-6 col-sm-offset-3 table-bordered">
        <div id="header">
            <div id="user_background">
                <div class="user-bg">
                </div>
                <div class="user-headshot-div">
                    <div id="user_headshot" class="user-headshot">
                        <asp:Image ID="headshot_img" runat="server" class="headshot-img" />
                    </div>
                    <asp:Button runat="server" Text="Edit Profile" class="btn btn-link btn-sm col-xs-offset-10 col-xs-2 btn-edit-pf" Visible="true" />
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
                </ul>
            </div>
        </div>
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
                                        <i class="fa-regular fa-comment fa-lg svg-icon"></i>
                                        <asp:Label ID="label_comment" runat="server" Text='<%#Eval("total_comments") %>' class="text-color"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <%-- 分享貼文 --%>
                                <td runat="server" id="post_td_share" class="col-xs-3">
                                    <asp:LinkButton ID="link_share" runat="server" OnClick="link_share_Click">
                                        <i class="fa-solid fa-retweet fa-lg svg-icon"></i>
                                        <asp:Label ID="label_share" runat="server" Text="" class="text-color"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <%-- 點讚 --%>
                                <td runat="server" id="post_td_like" class="col-xs-3">
                                    <asp:LinkButton ID="link_unlike" runat="server" OnClick="Link_unlike_Click" CssClass="text-color">
                                        <span id="" class=""><i class="fa-regular fa-lg fa-heart"></i></span>
                                        <asp:Label ID="label_unlike" runat="server" Text='<%#Eval("post_likes") %>' class="" ></asp:Label>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="link_like" runat="server" OnClick="Link_like_Click" CssClass="post_like">
                                        <span id="icon_like" class=""><i class="fa-solid fa-heart fa-lg"></i></span>
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

    <script type="text/javascript" src="/Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript"></script>
    <script>
        var _target = new EventTarget();
        let refresh_data = 0;
        //window.onscroll = function () { reflash(); };

        // 取高度狀態
        var window_roll_session = window.sessionStorage.getItem('window_roll');
        // 取貼文狀態
        //var total_posts_session = window.sessionStorage.getItem('total_posts');
        var total_posts_session = 0;
        // 
        $window_roll = $(document).height() - $(window).height();
        //
        function storeOriginalWindowHeight() {
            window.sessionStorage.removeItem('window_roll');
            window_roll_session = 0;
            window.sessionStorage.removeItem('float_window_height');
            $(document).scrollTop(0);
        }
        //
        var g = $('#<%=posts_bottom_label.ClientID%>').html();
        // 按鈕按下復原高度
        var originalWindowHeight;

        function restoreOriginalWindowHeight() {
            //window.sessionStorage.clear('window_roll');

            // 取浮動的高度值
            var window_height_session = window.sessionStorage.getItem('float_window_height');

            console.log("trigger");
            console.log(window_height_session);
            $(document).scrollTop(window_height_session);
        }

        // 設高度初始狀態 撈session重整前的狀態
        $(document).scrollTop(window_roll_session);

        // 監聽事件
        window.addEventListener("scroll", function () {

            //console.log("總長度:" + $(document).height());
            //console.log("視窗高度:" + $(window).height());
            //console.log("網頁滾動高度:" + $(document).scrollTop());
            //console.log("---------------------");
            
            // 高度 浮動值
            window.sessionStorage.setItem('float_window_height', $(document).scrollTop());

            //更新資料
            if (!refresh_data) {

                if (g != "沒有更多貼文") {
                
                    if ($(document).scrollTop() + 40 > $window_roll) {

                        /*$.ajax({
                            type: "POST",
                            url: 'community.aspx/listview_renew',
                            //data: JSON.stringify({ reset: "a" }),
                            data: JSON.stringify({ post_limit: "5", reset: "" }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                console.log(response.d);
                                refresh_data = 1;
                            },
                            error: function (e) {
                                console.log(JSON.stringify(e));
                            }
                        });*/
                        
                        __doPostBack("listView_community", "");
                        refresh_data = 1;

                        window.sessionStorage.setItem('window_roll', $window_roll);
                        window.sessionStorage.setItem('total_posts', g);
                        //console.log("trigger");

                    } else {
                        refresh_data = 0;
                    }
                }

            } else {
                //console.log("沒有更多貼文了");
            }

        });

    </script>

</asp:Content>
