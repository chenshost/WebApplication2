using BarcodeLib;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
//using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.IO;
using System.Web.Services;
using System.Drawing.Imaging;
using System.Text;
using ZXing.Common;
using ZXing.QrCode;
using ZXing;
using MySql.Data.MySqlClient;

namespace WebApplication2
{
    public partial class web_user_inf : System.Web.UI.Page
    {
        // 全域變數
        // 連線參數
        //string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";
        string DBconn = "server=163.17.136.73;port=1433;user id=a123;password=F3PDEGup6310gG;database=spaced;charset=utf8;";

        protected void Page_Load(object sender, EventArgs e)
        {
            //
            if (Session["user"] == null)
            {
                //Response.Write("<script>alert('請先登入');</script>");
                Server.Transfer("web_login.aspx");

                Session.Remove("user");
            }
            string user_id = Session["user"].ToString();

            MySqlConnection dbcn = new MySqlConnection(DBconn);

            dbcn.Open();

            string sel_user_ticker = "SELECT * FROM tickers WHERE user_id = @u_id";
            MySqlCommand sel_user_ticker_run = new MySqlCommand(sel_user_ticker, dbcn);
            sel_user_ticker_run.Parameters.AddWithValue("@u_id", user_id);
            MySqlDataAdapter user_ticker_adapter = new MySqlDataAdapter(sel_user_ticker_run);
            //user_ticker_adapter.SelectCommand = sel_user_ticker_run;
            DataTable user_ticker_dt = new DataTable();
            user_ticker_adapter.Fill(user_ticker_dt);
            listView_user_tickers.DataSource = user_ticker_dt;
            listView_user_tickers.DataBind();

            sel_user_ticker_run.ExecuteNonQuery();
            sel_user_ticker_run.Parameters.Clear();

            dbcn.Close();


            //using (SqlConnection dbcn = new SqlConnection(DBconn))
            //{
            //    string db_show_cmd = "SELECT * FROM users Where user_id = @id";
            //    SqlCommand sqlCommand = new SqlCommand(db_show_cmd, dbcn);

            //    string sql_tickers_cmd = "SELECT ticker_merchant, ticker_name, ticker_inf, ticker_id, ticker_deadline, ticker_used FROM Tickers Where ticker_user_id = @id";
            //    SqlCommand sql_tickers = new SqlCommand(sql_tickers_cmd, dbcn);

            //    // 物件導向
            //    //SelectDBClass selectDB = new SelectDBClass();
            //    //selectDB.GetSelectDb(db_show_cmd);

            //    dbcn.Open();
            //    // user資料
            //    sqlCommand.Parameters.AddWithValue("@id", user_id);
            //    SqlDataAdapter adapter_user_inf = new SqlDataAdapter(sqlCommand);
            //    DataTable dt_user_inf = new DataTable();
            //    adapter_user_inf.Fill(dt_user_inf);
            //    listView_user_inf.DataSource = dt_user_inf;
            //    listView_user_inf.DataBind();

            //    sqlCommand.ExecuteNonQuery();
            //    sqlCommand.Parameters.Clear();

            //    // user票眷
            //    sql_tickers.Parameters.AddWithValue("@id", user_id);
            //    SqlDataAdapter adapter_user_tickers = new SqlDataAdapter(sql_tickers);
            //    DataTable dt_user_tickers = new DataTable();
            //    adapter_user_tickers.Fill(dt_user_tickers);
            //    listView_user_tickers.DataSource = dt_user_tickers;
            //    listView_user_tickers.DataBind();

            //    sql_tickers.ExecuteNonQuery();
            //    sql_tickers.Parameters.Clear();

            //    dbcn.Close();
            //}

        }

        protected void btn_exchange_Click(object sender, EventArgs e)
        {
            Button btn_id = (Button)sender;
            //string id = button.CommandArgument;
            int btn_id_click = int.Parse(btn_id.CommandArgument);

            Label label_ticker_id = listView_user_tickers.Items[btn_id_click].FindControl("Label5") as Label;
            string ticker_id = label_ticker_id.Text;

            MySqlConnection dbcn = new MySqlConnection(DBconn);

            // 核對
            string sql_check_used_cmd = "SELECT * FROM tickers Where id = @t_id AND user_id = @u_id AND exchange_time IS NULL";
            MySqlCommand sql_check_used = new MySqlCommand(sql_check_used_cmd, dbcn);

            dbcn.Open();

            sql_check_used.Parameters.AddWithValue("@t_id", ticker_id);
            string user_id = Session["user"].ToString();
            sql_check_used.Parameters.AddWithValue("@u_id", user_id);
            
            MySqlDataAdapter adapter_user_tickers = new MySqlDataAdapter(sql_check_used);
            DataTable dt_user_tickers = new DataTable();
            adapter_user_tickers.Fill(dt_user_tickers);
            // 更新使用者票眷listview
            listView_user_tickers.DataSource = dt_user_tickers;
            listView_user_tickers.DataBind();

            // 
            sql_check_used.ExecuteNonQuery();
            sql_check_used.Parameters.Clear();

            dbcn.Close();

            // 核對結果
            string check_result_ticker_id = dt_user_tickers.Rows[0][0].ToString();
            string check_result_ticker_used = dt_user_tickers.Rows[0][5].ToString();

            /* barcode圖片 ---------------------- */
            //var filepath = @"C:\Disk\ajax\WebApplication2\Photo\barcode.png";

            if (check_result_ticker_used != "")
            {
                Response.Write("<script>alert('此兌換卷已兌換，不可再兌換');</script>");
            }
            else
            {
                /*------- QRcode生成 --------*/
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

                BitMatrix bitMatrix = barcodeWriter.Encode(check_result_ticker_id); // 編碼為 BitMatrix

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
                qrCodeContainer.InnerHtml = "<img src='data:image/png;base64," + base64Image + "' />";

                qrCodeImage.Dispose(); // 釋放圖片資源
            }

        }

        protected void btn_task_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_task.aspx");
        }
    }
}