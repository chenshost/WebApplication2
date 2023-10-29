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