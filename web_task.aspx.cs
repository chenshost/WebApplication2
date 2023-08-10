using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class web_task : System.Web.UI.Page
    {
        string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(DBconn);

            string task = "SELECT * FROM Task";
            SqlCommand sql_task = new SqlCommand(task, sqlConnection);

            DataTable task_dt = new DataTable();

            sqlConnection.Open();

            SqlDataAdapter task_adapter = new SqlDataAdapter(sql_task);
            task_adapter.Fill(task_dt);

            listView_user_inf.DataSource = task_dt;
            listView_user_inf.DataBind();

            sqlConnection.Close();

        }

        protected void listView_user_inf_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Save")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                // 您可以根据行索引执行特定操作或获取相关行数据
                // 例如：string columnName = (string)ListView1.DataKeys[rowIndex]["ColumnName"];
                //       进行后续逻辑处理
            }


            //Response.Redirect("<script>alert('" + i + "')</script>");
        }

        protected void btn_exchange_Click(object sender, EventArgs e)
        {
            // 如果按钮的 OnClick 事件也需要处理，您可以在这里添加逻辑
            Button button = (Button)sender;
            //string id = button.CommandArgument;
            int task_row_nb = int.Parse(button.CommandArgument);

            SqlConnection sqlConnection = new SqlConnection(DBconn);

            string task = "SELECT * FROM Task";
            SqlCommand sql_task = new SqlCommand(task, sqlConnection);

            string tickers = "SELECT TOP 1 * FROM Tickers WHERE ticker_merchant = @tkr_m AND ticker_name = @tkr_n AND ticker_user_id = 'NULL'";
            SqlCommand sql_tickers = new SqlCommand(tickers, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter task_adapter = new SqlDataAdapter(sql_task);
            DataTable task_dt = new DataTable();
            task_adapter.Fill(task_dt);


            sqlConnection.Close();

            string award_ticker_merchant = task_dt.Rows[task_row_nb][3].ToString();
            string award_ticker_name = task_dt.Rows[task_row_nb][4].ToString();

            sqlConnection.Open();

            sql_tickers.Parameters.AddWithValue("tkr_m", "巴星克");
            sql_tickers.Parameters.AddWithValue("tkr_n", "咖啡兌換卷");

            /* -- */
            SqlDataAdapter ticker_adapter = new SqlDataAdapter(sql_tickers);
            DataTable ticker_dt = new DataTable();
            ticker_adapter.Fill(ticker_dt);

            sql_tickers.ExecuteNonQuery();
            sql_tickers.Parameters.Clear();

            sqlConnection.Close();

            string award_ticker_id = ticker_dt.Rows[0][4].ToString();

            if (Session["user"] == null || Session["user"].ToString() == "")
            {
                Response.Write("<script>alert('請先登入');</script>");
            }
            else
            {
                string award_for_user = "UPDATE Tickers SET ticker_user_id = @user_id WHERE ticker_merchant = @tkr_m AND ticker_name = @tkr_n AND ticker_id = @tkr_id";
                SqlCommand sql_award_for_user = new SqlCommand(award_for_user, sqlConnection);

                string session_user = Session["user"].ToString();

                sqlConnection.Open();

                sql_award_for_user.Parameters.AddWithValue("@user_id", Session["user"].ToString());
                sql_award_for_user.Parameters.AddWithValue("@tkr_m", award_ticker_merchant);
                sql_award_for_user.Parameters.AddWithValue("@tkr_n", award_ticker_name);
                sql_award_for_user.Parameters.AddWithValue("@tkr_id", award_ticker_id);

                sql_award_for_user.ExecuteNonQuery();
                sql_award_for_user.Parameters.Clear();

                sqlConnection.Close();

                Response.Write("<script>alert('兌換成功!請秀出條碼給商家掃描。');</script>");

            }

        }

        protected void btn_user_inf_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_user_inf.aspx");
        }
    }
}