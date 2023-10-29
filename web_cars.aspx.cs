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

namespace WebApplication2
{
    public partial class web_cars : System.Web.UI.Page
    {
        // 全域變數
        // 連線參數
        string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
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

            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(DBconn))
            {
                string strCMD = "SELECT * FROM Cars WHERE user_id = @id";
                cn.Open();

                SqlCommand sqlCommand = new SqlCommand(strCMD, cn);

                sqlCommand.Parameters.AddWithValue("@id", Session["user"].ToString());
                sqlCommand.Parameters.Clear();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dt);

                cn.Close();
            }

            // 
            ListView1.DataSource = dt;

            // 二次讀取
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["msg"] != null)
                {
                    string re_msg = Request.QueryString["msg"].ToString();  // 取?msg=後面的值
                    Response.Write("<script>alert('" + re_msg + "');</script>");
                }
                ListView1.DataBind();
            }

            if (Session["user"] != null)
            {
                Label6.Text = "現在使用者：" + Session["user"];
                Label7.Text = "使用者金額：";
            }
            else
            {
                Label6.Text = "尚未登入";
            }

        }

        // 
        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";
            SqlConnection dbcn = new SqlConnection(DBconn);

            // listview觸發事件
            string commandName = e.CommandName;
            object commandArg = e.CommandArgument;
            ListViewItem selectedItem = e.Item;
            int dataItemIndex = selectedItem.DataItemIndex;

            string label_id ="";

            if (commandName == "Delete_Item")
            {
                Label6.Text = "刪除成功";

                // label物件，要把前端Label1變成相同物件型態
                Label label = e.Item.FindControl("Label1") as Label;
                label_id = label.Text;

                string del_data = "Delete From Cars Where number = @number";

                SqlCommand sql_del_run = new SqlCommand(del_data, dbcn);

                //
                dbcn.Open();

                sql_del_run.Parameters.AddWithValue("@number", label_id);

                sql_del_run.ExecuteNonQuery();
                sql_del_run.Parameters.Clear();

                dbcn.Close();
            }

            // 
            Response.Redirect("web_cars.aspx?msg=刪除成功");
            // c#網頁沒有彈跳式視窗 要用JS去作動
        }

        // 購買(目前無用)
        protected void Button2_Buy(object sender, EventArgs e)
        {
            string car_p_del = "Delete From Cars Where user_id = 'a123'";

            SqlConnection dbcn = new SqlConnection(DBconn);
            SqlCommand sqlCommand = new SqlCommand(car_p_del, dbcn);

            dbcn.Open();

            sqlCommand.ExecuteNonQuery();

            sqlCommand.Parameters.Clear();

            dbcn.Close();

        }

    }
}