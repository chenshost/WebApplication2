using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class web_creat_ac : System.Web.UI.Page
    {
        string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Creat_ac(object sender, EventArgs e)
        {
            #region SqlDataSource方法
            //SelectDBClass selectDB = new SelectDBClass();
            //selectDB.GetSelectDb("Select * From Cars");

            //string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";
            //string db_show_cmd = "Select * From Cars";

            //SqlConnection dbcn = new SqlConnection(DBconn);
            //SqlCommand sqlCommand = new SqlCommand(db_show_cmd, dbcn);

            //dbcn.Open();

            //SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //ListView1.DataSource = dt;
            //ListView1.DataBind();

            //dbcn.Close();
            /* 以上是物件導向資料庫的方法 */
            #endregion


            string id = tbox_id.Text;
            string key = tbox_key.Text;
            string name = tbox_name.Text;
            string email = tbox_email.Text;
            string money = tbox_money.Text;

            if (id == null || id =="")
            {
                Response.Write("<script>alert('請輸入帳號!');</script>");
            }
            else if (key == null || key == "")
            {
                Response.Write("<script>alert('請輸入密碼!');</script>");
            }
            else if (name == null || name == "")
            {
                Response.Write("<script>alert('請輸入名子!');</script>");
            }
            else if (email == null || email == "")
            {
                Response.Write("<script>alert('請輸入Email!');</script>");
            }
            else if (money == null || money == "")
            {
                Response.Write("<script>alert('請儲值初始金額!');</script>");

                //if (money > '1000')
                //{

                //}
            }
            else
            {
                using (SqlConnection cn = new SqlConnection(DBconn))
                {
                    string creat_ac_sql_cmd = "INSERT Users (user_id, key_word, user_name, user_mail, user_money, user_grade) " +
                                              "VALUES (@id, @key, @name, @email, @money, 'User')";

                    SqlCommand sql_cmd_run = new SqlCommand(creat_ac_sql_cmd, cn);

                    cn.Open();

                    sql_cmd_run.Parameters.AddWithValue("@id", id);
                    sql_cmd_run.Parameters.AddWithValue("@key", key);
                    sql_cmd_run.Parameters.AddWithValue("@name", name);
                    sql_cmd_run.Parameters.AddWithValue("@email", email);
                    sql_cmd_run.Parameters.AddWithValue("@money", money);

                    sql_cmd_run.ExecuteNonQuery();

                    sql_cmd_run.Parameters.Clear();

                    cn.Close();
                }

                Response.Write("<script>alert('註冊成功!');</script>");

                Session["user"] = id;

                Server.Transfer("web_user_inf.aspx");

            }

            
        }

    }
}