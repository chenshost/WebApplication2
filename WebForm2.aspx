<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #terms {
            width: 450px;
/*            height: 500px;*/
            height: auto;
            overflow: auto; /* 讓它有捲軸 */
            border: 1px solid #ccc;
            margin-bottom: 10px;
            padding: 10px;
        }

        .red {
            color: red;
        }
    </style>

    <div id="terms">
        <h2>同意書</h2>
        <p>目前工作是網頁開發為主，因此針對了 HTML, JavaScript, CSS 等知識特別深入研究。若有任何問題，歡迎直接留言或是透過 Mail 討論。</p>

        <p>fontAvailable 是一個很有趣的外掛，它利用字型間的寬度差異性來判斷該字型是否有安裝。既然可以判斷是否有安裝就能針對沒安裝字型的來做設計囉。</p>
        <p>網頁設計人員都知道 HTML + CSS 是設計時不可或缺。但單純的靜態畫面不太能吸引瀏覽者的注意，所以得在搭配 JavaScript 來讓效果動起來。此次就用簡單的 jQuery 語法來讓原本單調的設計有不同的效果。</p>

        <p>如果你是看到預覽圖(感謝梅干熱情提供)而覺得裡面會有好康的話，建議可以按下 Alt + ← 來回到上一頁：如果你現在因為標題看不懂而感到莫名其妙的話，請不要覺得是自己的問題，因為筆者已經想不出範例名稱了XD！所請忽略標題直接看下去。</p>

        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>

        <p class="red">當你按下送出申請鈕時，表示你看過且同意以上的內容！</p>
    </div>
    <input type="submit" name="submit" id="submit" value="送出申請" />
    <div id="terms2" >
        <h2>同意書</h2>
        <p>目前工作是網頁開發為主，因此針對了 HTML, JavaScript, CSS 等知識特別深入研究。若有任何問題，歡迎直接留言或是透過 Mail 討論。</p>

        <p>fontAvailable 是一個很有趣的外掛，它利用字型間的寬度差異性來判斷該字型是否有安裝。既然可以判斷是否有安裝就能針對沒安裝字型的來做設計囉。</p>
        <p>網頁設計人員都知道 HTML + CSS 是設計時不可或缺。但單純的靜態畫面不太能吸引瀏覽者的注意，所以得在搭配 JavaScript 來讓效果動起來。此次就用簡單的 jQuery 語法來讓原本單調的設計有不同的效果。</p>

        <p>如果你是看到預覽圖(感謝梅干熱情提供)而覺得裡面會有好康的話，建議可以按下 Alt + ← 來回到上一頁：如果你現在因為標題看不懂而感到莫名其妙的話，請不要覺得是自己的問題，因為筆者已經想不出範例名稱了XD！所請忽略標題直接看下去。</p>

        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>

        <p class="red">當你按下送出申請鈕時，表示你看過且同意以上的內容！</p>
    </div>
    <div id="terms3" hidden="hidden">
        <h2>同意書11111111111111111111111111111</h2>
        <p>目前工作是網頁開發為主，因此針對了 HTML, JavaScript, CSS 等知識特別深入研究。若有任何問題，歡迎直接留言或是透過 Mail 討論。</p>

        <p>fontAvailable 是一個很有趣的外掛，它利用字型間的寬度差異性來判斷該字型是否有安裝。既然可以判斷是否有安裝就能針對沒安裝字型的來做設計囉。</p>
        <p>網頁設計人員都知道 HTML + CSS 是設計時不可或缺。但單純的靜態畫面不太能吸引瀏覽者的注意，所以得在搭配 JavaScript 來讓效果動起來。此次就用簡單的 jQuery 語法來讓原本單調的設計有不同的效果。</p>

        <p>如果你是看到預覽圖(感謝梅干熱情提供)而覺得裡面會有好康的話，建議可以按下 Alt + ← 來回到上一頁：如果你現在因為標題看不懂而感到莫名其妙的話，請不要覺得是自己的問題，因為筆者已經想不出範例名稱了XD！所請忽略標題直接看下去。</p>

        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
        <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>

        <p class="red">當你按下送出申請鈕時，表示你看過且同意以上的內容！</p>
    </div>
    
    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript"></script>
    <script>
        console.log("視窗高度:" + $(window).height());
        console.log("總高度:" + $(document).height());
        console.log("當前滾動高度:" + $(document).scrollTop());

        var _target = new EventTarget();
        setInterval(function () {
            $window_roll = $(document).height() - $(window).height(); // 
            //console.log($(document).scrollTop());
            console.log("---------");
            console.log("視窗高度:" + $(window).height());
            console.log("總高度:" + $(document).height());
            console.log("當前滾動高度:" + $(document).scrollTop());
            //console.log($window_roll);
            if ($(document).scrollTop() + 10 > $window_roll) {
                terms3.hidden = false;
                console.log("觸發");
                //alert("有!");
            }
        }, 250);
        


        //var event = new Event('build');

        //// 監聽事件
        //elem.addEventListener('build', function (e) {
        //    $window_roll = $(document).height() - $(window).height();
        //    console.log($window_roll);
        //    console.log("在function內的當前滾動高度:" + $(document).scrollTop());
        //    if ($(document).scrollTop() == $window_roll) {
        //        terms3.hidden = false;
        //        alert("有!");
        //    }
        //}, false);

        //// 觸發事件
        //elem.dispatchEvent(event);

        //console.log("視窗高度:" + $(window).height());
        //console.log("總高度:" + $(document).height());
        //console.log("當前滾動高度:" + $(document).scrollTop());

        //var terms3 = document.getElementById('terms3');

        //$(function () {
        //    $window_roll = $(document).height() - $(window).height();
        //    console.log($window_roll);
        //    console.log("在function內的當前滾動高度:" + $(document).scrollTop());
        //    if ($(document).scrollTop() == $window_roll) {
        //        terms3.hidden = false;
        //        alert("有!");
        //    }
        //});

        //$(function () {
        //    // 先取得 #terms 及其各種高度
        //    // 判斷是否停用 $submit
        //    var $terms = $('#terms'),
        //        _height = $terms.height(),
        //        _scrollHeight = $terms.prop('scrollHeight'),
        //        _maxScrollHeight = _scrollHeight - _height - 50;
        //        _least = 0, // 距離底部多少就可以, 0 表示得完全到底部
        //        $submit = $('#submit').attr('disabled', _maxScrollHeight > _least);
        //    console.log("height:" + _height);
        //    console.log("scrollHeight:" + _scrollHeight);
        //    console.log("maxScrollHeight:" + _maxScrollHeight);

        //    // 當 #terms 中捲軸捲動時
        //    $('#terms').scroll(function () {
        //        var $this = $(this);
        //        console.log($this.scrollTop());
        //        // 如果高度已經達到指定的高度就啟用 $submit
        //        if (_maxScrollHeight - $this.scrollTop() < _least) {
        //            console.log("有觸發");
        //            console.log("this.scrollTop():" + $this.scrollTop());
        //            $submit.attr('disabled', false);
        //            var terms2 = document.getElementById('terms2');
        //            terms2.hidden = false;
        //        }
        //    });
        //});
    </script>
</asp:Content>
