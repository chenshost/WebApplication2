<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #terms {
            width: 450px;
            height: 500px;
            overflow: auto; /* 讓它有捲軸 */
            border: 1px solid #ccc;
            margin-bottom: 10px;
            padding: 10px;
        }

        .red {
            color: red;
        }
    </style>

    <form method="post">
        <div id="terms">
            <h2>同意書</h2>
            <p>目前工作是網頁開發為主，因此針對了 HTML, JavaScript, CSS 等知識特別深入研究。若有任何問題，歡迎直接留言或是透過 Mail 討論。</p>

            <p>fontAvailable 是一個很有趣的外掛，它利用字型間的寬度差異性來判斷該字型是否有安裝。既然可以判斷是否有安裝就能針對沒安裝字型的來做設計囉。</p>
            <p>網頁設計人員都知道 HTML + CSS 是設計時不可或缺。但單純的靜態畫面不太能吸引瀏覽者的注意，所以得在搭配 JavaScript 來讓效果動起來。此次就用簡單的 jQuery 語法來讓原本單調的設計有不同的效果。</p>

            <p>如果你是看到預覽圖(感謝梅干熱情提供)而覺得裡面會有好康的話，建議可以按下 Alt + ← 來回到上一頁：如果你現在因為標題看不懂而感到莫名其妙的話，請不要覺得是自己的問題，因為筆者已經想不出範例名稱了XD！所以請忽略標題直接看下去。</p>

            <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
            
            <p>目前工作是網頁開發為主，因此針對了 HTML, JavaScript, CSS 等知識特別深入研究。若有任何問題，歡迎直接留言或是透過 Mail 討論。</p>

            <p>fontAvailable 是一個很有趣的外掛，它利用字型間的寬度差異性來判斷該字型是否有安裝。既然可以判斷是否有安裝就能針對沒安裝字型的來做設計囉。</p>
            <p>網頁設計人員都知道 HTML + CSS 是設計時不可或缺。但單純的靜態畫面不太能吸引瀏覽者的注意，所以得在搭配 JavaScript 來讓效果動起來。此次就用簡單的 jQuery 語法來讓原本單調的設計有不同的效果。</p>

            <p>如果你是看到預覽圖(感謝梅干熱情提供)而覺得裡面會有好康的話，建議可以按下 Alt + ← 來回到上一頁：如果你現在因為標題看不懂而感到莫名其妙的話，請不要覺得是自己的問題，因為筆者已經想不出範例名稱了XD！所以請忽略標題直接看下去。</p>

            <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>
            
            <p>目前工作是網頁開發為主，因此針對了 HTML, JavaScript, CSS 等知識特別深入研究。若有任何問題，歡迎直接留言或是透過 Mail 討論。</p>

            <p>fontAvailable 是一個很有趣的外掛，它利用字型間的寬度差異性來判斷該字型是否有安裝。既然可以判斷是否有安裝就能針對沒安裝字型的來做設計囉。</p>
            <p>網頁設計人員都知道 HTML + CSS 是設計時不可或缺。但單純的靜態畫面不太能吸引瀏覽者的注意，所以得在搭配 JavaScript 來讓效果動起來。此次就用簡單的 jQuery 語法來讓原本單調的設計有不同的效果。</p>

            <p>如果你是看到預覽圖(感謝梅干熱情提供)而覺得裡面會有好康的話，建議可以按下 Alt + ← 來回到上一頁：如果你現在因為標題看不懂而感到莫名其妙的話，請不要覺得是自己的問題，因為筆者已經想不出範例名稱了XD！所以請忽略標題直接看下去。</p>

            <p>Img2DataURI 除了可以把圖片編碼成 DataURI 格式之外，也可以把編碼後的資料再轉回成圖片。如此一來就能偷偷的把別人的圖片還原囉(這不是這程式的主功能XD)！</p>

            <p class="red">當你按下送出申請鈕時，表示你看過且同意以上的內容！</p>
        </div>
        <input type="submit" name="submit" id="submit" value="送出申請" />
    </form>
    <div id="terms2" hidden="hidden">
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
    
    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript"></script>
    <script>
        $(function () {
            // 先取得 #terms 及其各種高度
            // 判斷是否停用 $submit
            var $terms = $('#terms'),
                _height = $terms.height(), // terms區塊高度
                _scrollHeight = $terms.prop('scrollHeight'), // 總滾動高度
                _maxScrollHeight = _scrollHeight - _height - 50; // 最大滾動高度 = 總滾動高度 - terms區塊高度 - 50
            _least = 0, // 距離底部多少就可以, 0 表示得完全到底部
                $submit = $('#submit').attr('disabled', _maxScrollHeight > _least); // 最大滾動高度 大於 least??
            console.log("height:" + _height);
            console.log("scrollHeight:" + _scrollHeight);
            console.log("maxScrollHeight:" + _maxScrollHeight);

            // 當 #terms 中捲軸捲動時
            $('#terms').scroll(function () {
                var $this = $(this);
                // 如果高度已經達到指定的高度就啟用 $submit
                if (_maxScrollHeight - $this.scrollTop() <= _least) {
                    console.log("this.scrollTop():" + $this.scrollTop());
                    console.log("maxScrollHeight:" + _maxScrollHeight);
                    //console.log("_maxScrollHeight減去this.scrollTop()之後小於_least");
                    $submit.attr('disabled', false);
                    var terms2 = document.getElementById('terms2');
                    terms2.hidden = false;
                }
            });
        });

        //function zoom(event) {
        //    event.preventDefault();

        //    scale += event.deltaY * -0.01;

        //    // Restrict scale
        //    scale = Math.min(Math.max(0.125, scale), 4);

        //    // Apply scale transform
        //    el.style.transform = `scale(${scale})`;
        //}

        //let scale = 1;
        //const el = document.querySelector(".div");
        //el.onwheel = zoom;
    </script>

</asp:Content>
