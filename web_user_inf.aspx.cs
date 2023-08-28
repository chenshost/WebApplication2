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
using System.Web.DynamicData;

namespace WebApplication2
{
    public partial class web_user_inf : System.Web.UI.Page
    {
        SelectDBClass selectDB = new SelectDBClass();
        CodeClass codeClass = new CodeClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Server.Transfer("web_login.aspx");

                    Session.Remove("user");
                }

                string sel_user_ticker = "SELECT * FROM tickers WHERE userID = '" + Session["user_id"].ToString() + "'";
                DataTable user_ticker_dt = selectDB.SelectTable(sel_user_ticker);

                listView_user_tickers.DataSource = user_ticker_dt;
                listView_user_tickers.DataBind();

                if (Session["ticker_id"] != null)
                {
                    string sql_check_used_cmd = "SELECT * FROM tickers WHERE userID = '" + Session["user_id"].ToString() + "' AND id = '" + Session["ticker_id"].ToString() + "'";
                    DataTable dt_user_tickers = selectDB.SelectTable(sql_check_used_cmd);
                    listView_user_tickers.DataSource = dt_user_tickers;
                    listView_user_tickers.DataBind();

                    qrCodeContainer.InnerHtml = "<img src='data:image/png;base64," + codeClass.QrCode(Session["ticker_id"].ToString()).ToString() + "' />";
                    Session.Remove("ticker_id");
                    btn_back_list.Visible = true;
                }

            }

        }

        protected void btn_exchange_Click(object sender, EventArgs e)
        {
            //Button clickedButton = (Button)sender;
            //clickedButton.Visible = false;
            //btn_exchange.visible

            Button btn_id = (Button)sender;
            //string id = button.CommandArgument;
            int btn_id_click = int.Parse(btn_id.CommandArgument);

            Label label_ticker_id = listView_user_tickers.Items[btn_id_click].FindControl("Label5") as Label;
            string ticker_id = label_ticker_id.Text;
            string user_id = Session["user_id"].ToString();

            string sql_check_used_cmd = "SELECT * FROM tickers WHERE userID = '" + user_id + "' AND id = '" + ticker_id + "'";
            DataTable dt_user_tickers = selectDB.SelectTable(sql_check_used_cmd);

            string check_result_ticker_id = dt_user_tickers.Rows[0][0].ToString();
            string check_result_ticker_used = dt_user_tickers.Rows[0][3].ToString();
            
            if (check_result_ticker_used != "")
            {
                Response.Write("<script>alert('此兌換卷已兌換，不可再兌換');</script>");
            }
            else
            {
                listView_user_tickers.DataSource = dt_user_tickers;
                listView_user_tickers.DataBind();
                
                btn_back_list.Visible = true;   // 按鈕顯示更新
                /*------- QRcode生成 --------*/
                //codeClass.QrCode(check_result_ticker_id);
                qrCodeContainer.InnerHtml = "<img src='data:image/png;base64," + codeClass.QrCode(check_result_ticker_id).ToString() + "' />";  // 這個要注意一下
            }

        }

        protected void btn_task_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_user_inf.aspx");
        }

        protected void btn_back_list_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_user_inf.aspx");
        }
    }
}