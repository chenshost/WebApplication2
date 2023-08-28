using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Imaging;

using ZXing.Common;
using ZXing.QrCode;
using ZXing;

namespace WebApplication2
{
    public class CodeClass
    {
        public string QrCode(string tciker_id)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE, // 設定條碼格式為 QR Code
                Options = new QrCodeEncodingOptions
                {
                    Height = 200, // 設定 QR Code 的高度
                    Width = 200, // 設定 QR Code 的寬度
                    Margin = 0 // 設定 QR Code 的邊距
                }
            };

            BitMatrix bitMatrix = barcodeWriter.Encode(tciker_id); // 編碼為 BitMatrix

            // 將 BitMatrix 轉換為 Bitmap
            Bitmap qrCodeImage = new Bitmap(bitMatrix.Width, bitMatrix.Height, PixelFormat.Format32bppArgb);
            for (int x = 0; x < bitMatrix.Width; x++)
            {
                for (int y = 0; y < bitMatrix.Height; y++)
                {
                    qrCodeImage.SetPixel(x, y, bitMatrix[x, y] ? Color.Black : Color.White);
                }
            }

            // 將 QR Code 圖片插入到容器中
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            qrCodeImage.Save(stream, ImageFormat.Png);
            string base64Image = Convert.ToBase64String(stream.ToArray());
            //qrCodeContainer.InnerHtml = "<img src='data:image/png;base64," + base64Image + "' />";
            //qrCodeContainer是頁面中的div, InnerHtml是注入html語法, 加入qr code 圖片顯示出來
            //用此方法必須要寫個div命名id, 才能用InnerHtml注入<img>顯示Qrcode
            qrCodeImage.Dispose(); // 釋放圖片資源

            return (base64Image);
        } 
    }
}