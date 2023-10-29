<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="WebApplication2.community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://kit.fontawesome.com/4b0a685128.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="/css/community.css">

    <div class="container col-sm-6 col-sm-offset-3">
        <%-- 頭部 --%>
        <div id="header" class="header">
            <div id="user_background">
                <div class="user-bg">
                </div>
                <div class="user-headshot-div">
                    <div id="user_headshot" class="user-headshot">
                        <asp:Image ID="headshot_img" runat="server" class="headshot-img" />
                    </div>
                </div>
            </div>
            <div id="user_inf">
                <div id="name">
                    <asp:Label ID="label_name" runat="server" Text="" CssClass="h3 fw-bold text-b">社群名稱</asp:Label><br>
                    <asp:Label ID="label_community_category" runat="server" Text="" CssClass="text-g">社群類型</asp:Label>
                </div>
                <div id="introduction" class="introduction">
                    <asp:Label ID="label_community_description" runat="server" Text="" CssClass="text-b"></asp:Label>
                </div>
                <div>
                    <span class="glyphicon glyphicon-calendar text-g"></span>
                    <asp:Label ID="label_community_create_date" runat="server" Text="" class="text-g">創社時間</asp:Label>
                </div>
                <div>
                    <asp:Label ID="label_community_number" runat="server" Text="0" CssClass="text-b"></asp:Label>
                    <asp:Label ID="label_community" runat="server" Text="社群人數" class="text-g"></asp:Label>
                    <asp:Label ID="label_active_number" runat="server" Text="0" CssClass="text-b"></asp:Label>
                    <asp:Label ID="label_active" runat="server" Text="活耀度" class="text-g"></asp:Label>
                </div>
                <ul class="nav nav-tabs">
                    <li id="li_1" runat="server" class="active">
                        <asp:LinkButton runat="server" ID="link_tweets" OnClick="link_tweets_Click">貼文&公告</asp:LinkButton></li>
                    <li id="li_2" runat="server">
                        <asp:LinkButton runat="server" ID="link_members" OnClick="link_members_Click">成員名單</asp:LinkButton></li>
                    <li id="li_3" runat="server">
                        <asp:LinkButton runat="server" ID="link_star" OnClick="link_star_Click">上月小新星</asp:LinkButton></li>
                </ul>
            </div>
        </div>
        <div id="post_area" style="height: auto">
            <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Always">
                <ContentTemplate>
                <%-- Listview貼文主體 --%>
                    <asp:ListView ID="listView_community" runat="server" EnableViewState="true" OnItemCommand="listView_comments_ItemCommand" Visible="true">
                        <LayoutTemplate>
                            <div runat="server" id="lstProducts">
                                <div runat="server" id="Div1" />
                                <table runat="server" class="post-area-table">
                                    <tr id="itemPlaceholder" runat="server" />
                                </table>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate runat="server">
                            <tr class="h-10"></tr>
                            <tr>
                                <td runat="server" class="post-color1 post-border-top" colspan="6"></td>
                            </tr>
                            <tr runat="server" class="post-color2">
                                <td class="post-color1">
                                    <div class="p-b-left-up"></div>
                                </td>
                                <td runat="server" rowspan="2" class="col-xs-1">
                                    <div id="post_user_headshot" class="div-round">
                                </td>
                                <td runat="server" class="col-xs-offset-2 " colspan="3">
                                    <asp:Label ID="label_user_name" runat="server" Text='<%#Eval("userName") %>' class="fw-bold"></asp:Label></td>
                                <td runat="server" class="col-xs-offset-2" visible="false">
                                    <asp:Label ID="hidden_id" runat="server" Text='<%#Eval("id") %>'></asp:Label></td>
                                <td class="post-color1">
                                    <div class="p-b-right-up"></div>
                                </td>
                            </tr>
                            <tr runat="server" class="post-color2">
                                <td class="post-border-left"></td>
                                <td runat="server" colspan="3" class="col-xs-offset-2">
                                    <asp:Label ID="post_text" runat="server" Text='<%#Eval("postContent") %>' class=""></asp:Label></td>
                                <td class="post-border-right"></td>
                            </tr>
                            <%-- 貼文功能連結 --%>
                            <tr runat="server">
                                <td class="post-border-left"></td>
                                <td runat="server" colspan="4" class="h-10 post-color2"></td>
                                <td class="post-border-right"></td>
                            </tr>
                            <tr runat="server" id="post_link_btn" class="post-color2">
                                <td class="post-border-left"></td>
                                <td class="col-xs-offset-2"></td>
                                <%-- 留言 --%>
                                <td runat="server" id="post_td_comment" class="col-xs-offset-2 col-xs-3">
                                    <asp:LinkButton ID="link_comment" runat="server" OnClick="link_comment_Click">
                                        <i class="fa-regular fa-comment fa-lg svg-icon"></i>
                                        <asp:Label ID="label_comment" runat="server" Text='<%#Eval("total_comments") %>' class="text-g"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <%-- 分享貼文 --%>
                                <td runat="server" id="post_td_share" class="col-xs-3">
                                    <asp:LinkButton ID="link_share" runat="server" OnClick="link_share_Click">
                                        <i class="fa-solid fa-retweet fa-lg svg-icon"></i>
                                        <asp:Label ID="label_share" runat="server" Text="" class="text-g"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <%-- 點讚 --%>
                                <td runat="server" id="post_td_like" class="col-xs-3">
                                    <asp:LinkButton ID="link_unlike" runat="server" OnClick="Link_unlike_Click" CssClass="text-g">
                                        <span id="" class=""><i class="fa-regular fa-lg fa-heart"></i></span>
                                        <asp:Label ID="label_unlike" runat="server" Text='<%#Eval("post_likes") %>' class=""></asp:Label>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="link_like" runat="server" OnClick="Link_like_Click" CssClass="post_like">
                                        <span id="icon_like" class=""><i class="fa-solid fa-heart fa-lg"></i></span>
                                        <asp:Label ID="label_like" runat="server" Text='<%#Eval("post_likes") %>' class=""></asp:Label>
                                        <asp:Label ID="label_like_stats" runat="server" Text='<%#Eval("user_like") %>' class="" Visible="false"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <td class="post-border-right"></td>
                            </tr>
                            <%-- 留言板 --%>
                            <tr class="post-color2">
                                <td class="post-border-left"></td>
                                <td colspan="4">
                                    <asp:ListView ID="listView_comments" runat="server">
                                        <LayoutTemplate>
                                            <table runat="server">
                                                <tr id="itemPlaceholder" runat="server" />
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate runat="server">
                                            <tr runat="server">
                                                <td runat="server" rowspan="2" class="col-xs-2 col-xs-offset-2">
                                                    <div id="comments_user_headshot" class="post-headshot m-1">
                                                </td>
                                                <td runat="server" class="col-xs-offset-2">
                                                    <asp:Label ID="label_comments_user" runat="server" Text='<%#Eval("userName") %>' class="fw-bold"></asp:Label></td>
                                                <td runat="server" class="col-xs-offset-2" visible="false">
                                                    <asp:Label ID="hidden_id" runat="server" Text='<%#Eval("id") %>'></asp:Label></td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" colspan="3" class="col-xs-offset-2">
                                                    <asp:Label ID="label_comments_text" runat="server" Text='<%#Eval("commentContent") %>' class=""></asp:Label></td>
                                                <td class="post-color2"></td>
                                                <%--  --%>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </td>
                                <td class="post-border-right"></td>
                            </tr>
                            <tr id="comment_div" runat="server" class="post-color1">
                                <td class="post-color1">
                                    <div class="p-b-left-down"></div>
                                </td>
                                <td runat="server" colspan="4" class="col-xs-offset-2 post-color2">
                                    <asp:TextBox ID="comment_tbox" runat="server" placeholder="" CssClass="col-xs-offset-2" Visible="false"></asp:TextBox>
                                    <asp:Button runat="server" Text="留言" ID="comment_btn" class="btn btn-xs" Visible="false" OnClick="comment_btn_Click" />
                                </td>
                                <td class="post-color1">
                                    <div class="p-b-right-down"></div>
                                </td>
                            </tr>
                            <tr>
                                <td runat="server" class="post-color1 post-border-bottom" colspan="6"></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                <%-- 社團成員 --%>

                <%-- 上月小新星 --%>
                    <table id="table_star_test" runat="server" class="col-xs-12" Visible="false">
                        <tr>
                            <td>
                                <div class="h-10"></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="post-border">
                                <div class="post-box col-xs-12">
                                    <asp:Label ID="label_title" runat="server" Text="上月之星" CssClass="text-b"></asp:Label>
                                    <asp:Label ID="label2" runat="server" Text="1st.  " CssClass="flat-center text-b">
                                        <asp:Label ID="label1" runat="server" Text="1zz" CssClass="text-b"></asp:Label>
                                    </asp:Label>
                                    <asp:Label ID="label3" runat="server" Text="2nd.  " CssClass="flat-center text-b">
                                        <asp:Label ID="label4" runat="server" Text="1aa" CssClass="text-b"></asp:Label>
                                    </asp:Label>
                                    <asp:Label ID="label5" runat="server" Text="3rd.  " CssClass="flat-center text-b">
                                        <asp:Label ID="label6" runat="server" Text="3430sss" CssClass="text-b"></asp:Label>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="h-10"></div>
                            </td>
                        </tr>
                    </table>
                    <asp:ListView ID="listView1" runat="server" Visible="false">
                        <LayoutTemplate>
                            <table runat="server">
                                <tr id="itemPlaceholder" runat="server" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate runat="server">
                            <tr>
                                <td>
                                    <%-- 現在要做上月之星 依據流程圖設計會出現上個月任務完成度最高的使用者 --%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:postbacktrigger controlid="Button1"></asp:postbacktrigger>--%>
                </Triggers>
            </asp:UpdatePanel>
            <asp:Label ID="posts_bottom_label" runat="server" Text="" Style="display: table; margin: 0 auto;" Visible="false"></asp:Label>
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
            // 取浮動的高度值
            var window_height_session = window.sessionStorage.getItem('float_window_height');

            console.log("trigger");
            console.log(window_height_session);
            $(document).scrollTop(window_height_session);
        }

        // 設高度初始狀態 撈session重整前的狀態
        $(document).scrollTop(window_roll_session);
        //
        function webstartup() {
            window.sessionStorage.clear()
        }

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
