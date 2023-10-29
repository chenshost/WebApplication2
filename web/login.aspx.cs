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
using System.Reflection;

namespace WebApplication2
{
    public partial class web_login : System.Web.UI.Page
    {
        DataBassClass dbClass = new DataBassClass();
        LoginRoute loginRoute = new LoginRoute();

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] url = Request.Url.Query.ToString().Split('?');

            // url處理
            if (url.Length > 1 && url[1] != null)
            {
                //tbox_ac.Text = "1zz";
                //tbox_key.Text = "1zz";

                string post_data_sql = "select * from verify where code = '"+ url[1] + "'";
                DataTable post_data_dt = dbClass.SelectTable(post_data_sql);

                DateTime nowtime = DateTime.Now;
                DateTime verify_time = DateTime.Parse(post_data_dt.Rows[0][1].ToString());

                // 驗證
                if (url[1] == post_data_dt.Rows[0][0].ToString() && nowtime < verify_time)
                {
                    string user_data_sql = "select userName, Password from user where id = '" + post_data_dt.Rows[0][2].ToString() + "'";
                    DataTable user_dt = dbClass.SelectTable(user_data_sql);

                    Session["user"] = user_dt.Rows[0][0];
                    Session["user_id"] = post_data_dt.Rows[0][2];
                    Session["ticker_id"] = post_data_dt.Rows[0][3];

                    //dbClass.Delete(delete_verify);

                    Response.Redirect("user_inf.aspx");
                }
                else
                {
                    string delete_verify = "delete from verify where code = '" + url[1] + "'";
                    dbClass.Delete(delete_verify);
                    Response.Write("<script>alert('驗證過時，請重新再兌換！');</script>");
                }
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

            DataTable user_dt = dbClass.SelectTable(login_sql);

            if (user_dt.Rows.Count <= 0)
            {
                Response.Write("<script>alert('帳號或密碼錯誤');</script>");
                return;
            }

            Session["user"] = tbx_u_id;
            Session["user_id"] = user_dt.Rows[0][0].ToString();

            if (selectedValue == "1")
            {
                Response.Redirect("user_inf.aspx");
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