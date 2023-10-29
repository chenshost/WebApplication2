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

namespace WebApplication2
{
    public partial class web_login : System.Web.UI.Page
    {
        // 全域
        //string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";
        string DBconn = "server=163.17.136.73;port=1433;user id=a123;password=F3PDEGup6310gG;database=spaced;charset=utf8;";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            // 登入資料
            string tbx_u_id = tbox_ac.Text; // ac
            string tbx_key = tbox_key.Text; // pw
            if (tbx_u_id == "" || tbx_key == "")
            {
                Response.Write("<script>alert('請輸入帳號密碼!');</script>");
                return;
            }

            // 撈使用者資料
            //SqlConnection cn = new SqlConnection(DBconn);   // 連線database
            MySqlConnection cn = new MySqlConnection(DBconn);
            //cn.ConnectionString = DBconn;

            string selectedValue = SelectBox.SelectedValue;
            string login_sql = "";

            if (selectedValue == "1")
            {
                login_sql = "Select userName, password From user Where userName = @user_id AND password = @key";  // sql語法
            }
            else if (selectedValue == "2")
            {
                login_sql = "Select name, password From merchant Where name = @user_id AND password = @key";  // sql語法
            }

            MySqlCommand login_sql_run = new MySqlCommand(login_sql, cn);   // sql指令

            // sql
            cn.Open();

            login_sql_run.Parameters.AddWithValue("@user_id", tbx_u_id);
            login_sql_run.Parameters.AddWithValue("@key", tbx_key);

            cn.Close();

            // 
            MySqlDataAdapter adapter = new MySqlDataAdapter(login_sql_run);
            DataTable user_dt = new DataTable();
            adapter.Fill(user_dt);
            if (user_dt.Rows.Count <= 0)
            {
                Response.Write("<script>alert('帳號或密碼錯誤');</script>");
                return;
            }

            string user_id = user_dt.Rows[0][0].ToString();
            //string user_name = user_dt.Rows[0][2].ToString();
            string key = user_dt.Rows[0][1].ToString();
            //string user_grade = user_dt.Rows[0][5].ToString();

            // 驗證使用者
            if (tbx_u_id == user_id && tbx_key == key)
            {
                // 將登入帳號記錄在 Session 內
                Session["user"] = tbx_u_id;
                //Session["grade"] = user_grade;
                //Session["name"] = user_name;

                // Route
                if (selectedValue == "1")
                {
                    Response.Redirect("web_user_inf.aspx");
                }
                else if (selectedValue == "2")
                {
                    Response.Redirect("web_merchant.aspx");
                    //Response.Redirect("web_admin_page.aspx");
                }

            }
        }

        protected void btn_sign_up_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_creat_ac.aspx");
        }
    }
}