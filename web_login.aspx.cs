using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;
using MySql.Data.MySqlClient;
using Jose;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using WebApplication2.Api;
using System.Security.Policy;

namespace WebApplication2
{
    public partial class web_login : System.Web.UI.Page
    {
        SelectDBClass selectDB = new SelectDBClass();
        LoginRoute loginRoute = new LoginRoute();

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.Url.Query.ToString();
            string[] url_query = url.Split(new string[] { "?userID=", "&Password=", "&TickerID="}, StringSplitOptions.RemoveEmptyEntries);

            if (url_query.Length > 1)
            {
                string sql = "Select id, userName, password From user Where userName = '" + url_query[0] + "' AND password = '" + url_query[1] + "'";
                DataTable dt = selectDB.SelectTable(sql);

                Session["user"] = dt.Rows[0][1];
                Session["user_id"] = dt.Rows[0][0];
                Session["ticker_id"] = url_query[2];

                Response.Redirect("web_user_inf.aspx");
            }
            else
            {
                Console.WriteLine("Value not found");
            }


        }

        protected void login_Click(object sender, EventArgs e)
        {
            string tbx_u_id = tbox_ac.Text; // ac
            string tbx_key = tbox_key.Text; // pw
            if (tbx_u_id == "" || tbx_key == "")
            {
                Response.Write("<script>alert('請輸入帳號密碼!');</script>");
                return;
            }

            string selectedValue = SelectBox.SelectedValue;
            string login_sql = "";

            if (selectedValue == "1")
            {
                login_sql = "Select id, userName, password From user Where userName = '" + tbx_u_id + "' AND password = '" + tbx_key + "'";
            }
            else if (selectedValue == "2")
            {
                login_sql = "Select id, name, password From merchant Where name = '" + tbx_u_id + "' AND password = '" + tbx_key + "'";
            }

            DataTable user_dt = selectDB.SelectTable(login_sql);
            string user_id = user_dt.Rows[0][0].ToString();

            if (user_dt.Rows.Count <= 0)
            {
                Response.Write("<script>alert('帳號或密碼錯誤');</script>");
                return;
            }

            Session["user"] = tbx_u_id;
            Session["user_id"] = user_id;

            if (selectedValue == "1")
            {
                Response.Redirect("web_user_inf.aspx");
            }
            else if (selectedValue == "2")
            {
                Response.Redirect("web_merchant.aspx");
            }
        }

        protected void btn_sign_up_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_creat_ac.aspx");
        }
    }
}