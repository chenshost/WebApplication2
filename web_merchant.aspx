<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_merchant.aspx.cs" Inherits="WebApplication2.web_merchant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>掃描</h2>
    <div>
        <asp:Button ID="btn_merchant_barcode" runat="server" Text="條碼資訊" Onclick="btn_merchant_barcode_OnClick" />
    </div>
    <div class="qrscanner" id="scanner">
        <div>
            <video class="qrPreviewVideo" autoplay="" tabindex="0" src="" playsinline="true"></video>
        </div>
    </div>
    <div>
        <textarea id="scannedTextMemo" class="textInput form-memo form-field-input textInput-readonly" rows="3" readonly=""></textarea>
    </div>

    <script type="text/javascript" src="Scripts/JsQR/jsqrscanner.nocache.js"></script>
    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript">
        // 掃描結果.文字
        function onQRCodeScanned(scannedText) {
            var scannedTextMemo = document.getElementById("scannedTextMemo");

            if (scannedTextMemo) {
                scannedTextMemo.value = scannedText;
                alert(scannedText);

                $.ajax({
                    type: "POST",
                    url: "web_merchant.aspx/Exchange",
                    data: JSON.stringify({ QRcode_id: scannedText }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        // 处理服务器端返回的结果
                        //console.log(response.d); //傳後端測試
                        //alert(response.d);
                        if (response.d == "success") {
                            alert("兌換成功!");
                        }
                        else if (response.d == "error") {
                            alert("兌換失敗");
                        }
                        else if (response.d == "was used") {
                            alert("此兌換卷已被兌換!");
                        }
                        else {
                            alert("錯誤");
                        }
                    },
                    error: function (xhr, status, error) {
                        // 处理错误信息
                        console.log(error);
                    }
                });
            }
        }

        function provideVideo() {
            var n = navigator;

            if (n.mediaDevices && n.mediaDevices.getUserMedia) {
                return n.mediaDevices.getUserMedia({
                    video: {
                        facingMode: "environment"
                    },
                    audio: false
                });
            }

            return Promise.reject('Your browser does not support getUserMedia');
        }

        function provideVideoQQ() {
            return navigator.mediaDevices.enumerateDevices()
                .then(function (devices) {
                    var exCameras = [];
                    devices.forEach(function (device) {
                        if (device.kind === 'videoinput') {
                            exCameras.push(device.deviceId)
                        }
                    });

                    return Promise.resolve(exCameras);
                }).then(function (ids) {
                    if (ids.length === 0) {
                        return Promise.reject('Could not find a webcam');
                    }

                    return navigator.mediaDevices.getUserMedia({
                        video: {
                            'optional': [{
                                'sourceId': ids.length === 1 ? ids[0] : ids[1]//this way QQ browser opens the rear camera
                            }]
                        }
                    });
                });
        }

        //this function will be called when JsQRScanner is ready to use
        function JsQRScannerReady() {
            //create a new scanner passing to it a callback function that will be invoked when
            //the scanner succesfully scan a QR code
            var jbScanner = new JsQRScanner(onQRCodeScanned);
            //var jbScanner = new JsQRScanner(onQRCodeScanned, provideVideo);
            //reduce the size of analyzed image to increase performance on mobile devices
            jbScanner.setSnapImageMaxSize(300);
            var scannerParentElement = document.getElementById("scanner");
            if (scannerParentElement) {
                //append the jbScanner to an existing DOM element
                jbScanner.appendTo(scannerParentElement);
            }
        }
    </script>

</asp:Content>
