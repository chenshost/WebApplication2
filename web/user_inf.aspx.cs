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
    public partial class user_inf : System.Web.UI.Page
    {
        DataBassClass dbClass = new DataBassClass();
        CodeClass codeClass = new CodeClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("../web/login.aspx");

                    Session.Remove("user");
                }

                string sel_user_ticker = @"select t.id, v.name, m.name as merchant_name, v.deadline, 
                                           CASE 
                                               WHEN t.exchange_time IS NOT NULL THEN '已兌換'
                                               ELSE ''
                                           END AS exchange_status
                                           from (tickers as t 
                                               inner join voucher as v
                                               on t.voucher_id = v.id
                                               )
                                           inner join merchant as m
                                           on v.merchant_id = m.id
                                           where t.userID =  '" + Session["user_id"].ToString() + "'";

                DataTable user_ticker_dt = dbClass.SelectTable(sel_user_ticker);

                listView_user_tickers.DataSource = user_ticker_dt;
                listView_user_tickers.DataBind();

                if (Session["ticker_id"] != null)
                {
                    string sql_check_used_cmd = @"select t.id, v.name, m.name as merchant_name, v.deadline, 
                                                  CASE 
                                                      WHEN t.exchange_time IS NOT NULL THEN '已兌換'
                                                      ELSE ''
                                                  END AS exchange_status
                                                  from (tickers as t 
                                                      inner join voucher as v
                                                      on t.voucher_id = v.id
                                                      )
                                                  inner join merchant as m
                                                  on v.merchant_id = m.id
                                                  where t.id =  '" + Session["ticker_id"].ToString() + "'";
                    DataTable dt_user_tickers = dbClass.SelectTable(sql_check_used_cmd);
                    listView_user_tickers.DataSource = dt_user_tickers;
                    listView_user_tickers.DataBind();

                    qrCodeContainer.InnerHtml = "<img src='data:image/png;base64," + codeClass.QrCode(Session["ticker_id"].ToString()).ToString() + "' />";
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

            string sql_check_used_cmd = @"select t.id, v.name, m.name as merchant_name, v.deadline, 
                                           CASE 
                                               WHEN t.exchange_time IS NOT NULL THEN '已兌換'
                                               ELSE ''
                                           END AS exchange_status
                                           from (tickers as t 
                                               inner join voucher as v
                                               on t.voucher_id = v.id
                                               )
                                           inner join merchant as m
                                           on v.merchant_id = m.id
                                           where t.id =  '" + ticker_id + "'";
            DataTable dt_user_tickers = dbClass.SelectTable(sql_check_used_cmd);

            string check_result_ticker_used = dt_user_tickers.Rows[0][4].ToString();
            
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
                qrCodeContainer.InnerHtml = "<img src='data:image/png;base64," + codeClass.QrCode(ticker_id).ToString() + "' />";  // 這個要注意一下
            }

        }

        protected void link_task_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_inf.aspx");
        }

        protected void btn_back_list_Click(object sender, EventArgs e)
        {
            Session.Remove("ticker_id");
            Response.Redirect("user_inf.aspx");
        }

        protected void link_community_Click(object sender, EventArgs e)
        {
            Response.Redirect("community.aspx");
        }
    }
}