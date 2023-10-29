<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="web_barcode_scan.aspx.cs" Inherits="WebApplication2.web_barcode_scan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="css/barcode_scan.css">
    
    <h1>WebCam掃描</h1>
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="產出" OnClick="Button1_Click" />
    </div>

    <div class="scan">
        <div class="camera">
            <div id="camera"></div>
        </div>
        <div>
            <asp:image id="ImgBarcode" runat="server" class="barcode" />
        </div>
    </div>

    <div>
        <asp:Label ID="label_show_barcode_id" runat="server" Text="尚未偵測出barcode id"></asp:Label>
        <asp:Label ID="label1" runat="server" Text=""></asp:Label>
        <asp:Label ID="label2" runat="server" Text="no!"></asp:Label>
    </div>

    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript" src="Scripts/quagga.min.js"></script>
    <script>
        // 初始化
        Quagga.init({
            inputStream: {
                name: "Live",
                type: "LiveStream",
                target: document.querySelector('#camera')   // Or '#yourElement' (optional)
            },
            decoder: {
                readers: ["code_128_reader"],
                debug: {
                    drawBoundingBox: false,
                    showFrequency: false,
                    drawScanline: false,
                    showPattern: false
                },
                multiple: false
            }
        }, function (err) {
            if (err) {
                console.log(err);
                return
            }
            console.log("Initialization finished. Ready to start");
            Quagga.start();
        });

        // 條碼判斷式
        Quagga.onProcessed(function (result) {
            var drawingCtx = Quagga.canvas.ctx.overlay,
                drawingCanvas = Quagga.canvas.dom.overlay;

            if (result) {
                if (result.boxes) {
                    drawingCtx.clearRect(0, 0, parseInt(drawingCanvas.getAttribute("width")), parseInt(drawingCanvas.getAttribute("height")));
                    result.boxes.filter(function (box) {
                        return box !== result.box;
                    }).forEach(function (box) {
                        Quagga.ImageDebug.drawPath(box, { x: 0, y: 1 }, drawingCtx, { color: "green", lineWidth: 2 });
                    });
                }

                if (result.box) {
                    Quagga.ImageDebug.drawPath(result.box, { x: 0, y: 1 }, drawingCtx, { color: "#00F", lineWidth: 2 });
                }

                if (result.codeResult && result.codeResult.code) {
                    Quagga.ImageDebug.drawPath(result.line, { x: 'x', y: 'y' }, drawingCtx, { color: 'red', lineWidth: 3 });
                    alert(result.codeResult.code);
                }
            }
        });


    </script>
    
    
</asp:Content>
