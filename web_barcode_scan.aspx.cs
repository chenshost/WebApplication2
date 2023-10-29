using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Aztec;
using System.Text;

namespace WebApplication2
{
    public partial class web_barcode_scan : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // 圖片抓取
            var filepath = @"C:\Disk\ajax\WebApplication2\Photo\barcode.png";

            //label_show_barcode_id.Text = barcodeReader.ToString();

            using (var stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                var barcodeReader = new BarcodeReader();
                var image = (Bitmap)Bitmap.FromStream(stream);
                var result = barcodeReader.Decode(image);

                if (result != null)
                {
                    // 解碼成功
                    //var decodedBarcode = result.Text;
                    label_show_barcode_id.Text = result.Text;
                    // 在這裡使用您解碼後的條碼
                }
                else
                {
                    // 解碼失敗
                }
            }

            // 
            if (!IsPostBack)
            {
                //List<string> randomCodes = new List<string>();
                string[] randomCodes = new string[50];
                //string str;

                for (int i = 0; i < 50; i++)
                {
                    randomCodes[i] = GenerateRandomCode(10);
                    //randomCodes.Add(code.ToString());

                    //Response.Write("<p>" + randomCodes[i] + "</p>");

                    //label1.Text = randomCodes[i];
                }

                // 在此將 randomCodes 傳遞到前端
            }
            //string session_str = Session["user"].ToString();
        }

        public static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random(Guid.NewGuid().GetHashCode());
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //web_user_inf web_barcode = new web_user_inf();
            //web_barcode.ProdBarcode(barcode);
            string barcode = TextBox1.Text;

            String photoSavePath = Server.MapPath("~/photo") + "\\" + "barcode.png";
            if (File.Exists(photoSavePath))
            {
                File.Delete(photoSavePath);
            }

            BarcodeLib.Barcode bc = new BarcodeLib.Barcode();

            bc.IncludeLabel = true;
            bc.LabelFont = new Font("Verdana", 8f);//標籤字型與大小
            bc.Width = 300;//標籤寬度
            bc.Height = 150;//標籤高度

            System.Drawing.Image img = bc.Encode(TYPE.CODE128, barcode, bc.Width, bc.Height);
            img.Save(photoSavePath, System.Drawing.Imaging.ImageFormat.Png);

            ImgBarcode.ImageUrl = "~/Photo/barcode.png"; //產生的barcode有固定檔名，故這邊可以寫死
        }



    }
}