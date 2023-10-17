using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.web
{
    public partial class tickers : System.Web.UI.Page
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

                listview_ticker();

            }
            else if (IsPostBack)
            {
                listview_ticker();
            }

        }

        public void listview_ticker()
        {
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

                listView_user_tickers.Visible = true;
                listView_exchange.Visible = false;

                qrCodeContainer.InnerHtml = "<img src='data:image/png;base64," + codeClass.QrCode(Session["ticker_id"].ToString()).ToString() + "' />";
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

            string ticker_deadline = dt_user_tickers.Rows[0][3].ToString();

            string check_result_ticker_used = dt_user_tickers.Rows[0][4].ToString();

            if (check_result_ticker_used != "")
            {
                Response.Write("<script>alert('此兌換卷已兌換，不可再兌換');</script>");
            }
            else
            {
                listView_user_tickers.Visible = false;

                listView_exchange.DataSource = dt_user_tickers;
                listView_exchange.DataBind();

                /*------- QRcode生成 --------*/
                qrCodeContainer.InnerHtml = "<img src='data:image/png;base64," + codeClass.QrCode(ticker_id).ToString() + "' />";  // 這個要注意一下
            }

        }

        protected void link_task_Click(object sender, EventArgs e)
        {
            Response.Redirect("tickers.aspx");
        }

        protected void link_community_Click(object sender, EventArgs e)
        {
            Response.Redirect("community.aspx");
        }

        protected void link_menu_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_inf.aspx");
        }
    }
}