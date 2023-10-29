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
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2
{
    public partial class web_admin_barcode : System.Web.UI.Page
    {
        // 全域變數
        string cnDB = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";    // 連線database

        protected void Page_Load(object sender, EventArgs e)
        {
            //LoginRoute loginRoute = new LoginRoute(Session["user"].ToString());

            // 圖片抓取
            var filepath = @"C:\Disk\ajax\WebApplication2\Photo\barcode.png";

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

        }

        protected void btn_barcode_test_Click(object sender, EventArgs e)
        {
            //web_user_inf web_barcode = new web_user_inf();
            //web_barcode.ProdBarcode(barcode);

            string barcode = tbox_barcode_test.Text;

            if (barcode == null || barcode == "")
            {
                Response.Write("<script>alert('請輸入id');</script>");
            }
            else
            {
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
}