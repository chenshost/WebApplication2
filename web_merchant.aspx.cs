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
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.Services.Protocols;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;


namespace WebApplication2
{
    public partial class web_merchant : System.Web.UI.Page
    {
        SelectDBClass selectDB = new SelectDBClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Server.Transfer("web_login.aspx");

                Session.Remove("user");
            }
            string user_id = Session["user"].ToString();
        }

        [WebMethod]
        public static string Exchange(string QRcode_id)
        {
            //string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";
            string DBconn = "server=163.17.136.73;port=1433;user id=a123;password=F3PDEGup6310gG;database=spaced;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(DBconn);

            string sql_sel = "SELECT * FROM tickers WHERE id = @ticker_id";
            MySqlCommand sql_sel_run = new MySqlCommand(sql_sel, conn);

            conn.Open();

            //sql_run.Parameters.AddWithValue("@data", barcode_id);

            sql_sel_run.Parameters.AddWithValue("@ticker_id", QRcode_id);
            //sql_sel_run.Parameters.AddWithValue("@ticker_user_id", "a123");

            MySqlDataAdapter sql_sel_fill = new MySqlDataAdapter(sql_sel_run);
            DataTable sql_sel_dt = new DataTable();
            sql_sel_fill.Fill(sql_sel_dt);

            conn.Close();

            if (sql_sel_dt.Rows.Count <= 0)
            {
                return "error";
            }
            else
            {
                string ticker_id = sql_sel_dt.Rows[0][0].ToString();
                string ticker_used = sql_sel_dt.Rows[0][5].ToString();

                if (ticker_used == "")
                {
                    string sql_update_exchange = "UPDATE Tickers SET exchange_time = @datetime WHERE id = @ticker_id";
                    MySqlCommand sql_update_exchange_run = new MySqlCommand(sql_update_exchange, conn);
                    DateTime myDate = DateTime.Now;
                    string DateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");

                    conn.Open();

                    sql_update_exchange_run.Parameters.AddWithValue("@datetime", DateString);
                    sql_update_exchange_run.Parameters.AddWithValue("@ticker_id", ticker_id);

                    sql_update_exchange_run.ExecuteNonQuery();
                    sql_update_exchange_run.Parameters.Clear();

                    conn.Close();

                    return "success";
                }
                else if (ticker_used != "")
                {
                    return "was used";
                }
                 
                return "";
            }

        }

        protected void btn_merchant_barcode_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("web_merchant_barcode.aspx");
        }
    }
}