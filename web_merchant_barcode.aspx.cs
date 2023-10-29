using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebApplication2
{
    public partial class web_merchant_barcode : System.Web.UI.Page
    {
        //string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";
        string DBconn = "server=163.17.136.73;port=1433;user id=a123;password=F3PDEGup6310gG;database=spaced;charset=utf8;";

        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection dbcn = new SqlConnection(DBconn);   //mssql
            MySqlConnection dbcn = new MySqlConnection(DBconn); //mysql
            
            //dbClassClass dbClassClass = new dbClassClass();  // 初始化物件導向

            string sql = "SELECT * FROM spaced.merchant WHERE name = @merchant_id";

            if (Session["user"] == null)
            {
                Response.Redirect("web/login.aspx");
                return;
            }
            string merchant_id = Session["user"].ToString();
            merchant_text.Text = merchant_id;

            //dbClassClass.merchant_select_db(sql, ticker_merchant);

            //SqlCommand sql_sel_merchant = new SqlCommand(sql, dbcn);
            MySqlCommand sql_sel_merchant = new MySqlCommand(sql, dbcn);

            dbcn.Open();

            sql_sel_merchant.Parameters.AddWithValue("@merchant_id", merchant_id);

            dbcn.Close();

            //SqlDataAdapter adapter = new SqlDataAdapter(sql_sel_merchant);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql_sel_merchant);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            listview_merchant_barcode.DataSource = dt;
            listview_merchant_barcode.DataBind();
        }

        public static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random(Guid.NewGuid().GetHashCode());
            var result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }

        string[] randomCodes = new string[50];

        protected void btn_produce_barcode_Click(object sender, EventArgs e)
        {
            //
            if (IsPostBack)
            {
                for (int i = 0; i < int.Parse(tbox_tkr_amount.Text); i++)
                {
                    randomCodes[i] = GenerateRandomCode(10);
                }

                // 在此將 randomCodes 傳遞到前端
            }
            //
            DateTime myDate = DateTime.Now;
            string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
            //
            string sql_insert_cmd = "INSERT INTO Tickers(merchant_id, ticker_merchant, ticker_name, ticker_inf, ticker_id, ticker_user_id, ticker_add_date, ticker_deadline, ticker_used)" +
                            "VALUES (@tkr_m_id, @tkr_m, @tkr_name, @tkr_inf, @tkr_id, @tkr_user_id, @tkr_add_date, @tkr_deadline, @tkr_used)";
            //
            SqlConnection cn = new SqlConnection(DBconn);                   // 連線database
            SqlCommand sqlCommand = new SqlCommand(sql_insert_cmd, cn);     // 對資料庫作動
            //
            DataTable dt = new DataTable();
            string sql_select_cmd = "SELECT * FROM Tickers WHERE ticker_merchant = @tkr_m AND ticker_add_date = @tkr_add_date";
            SqlCommand sql_select_produce_barcode = new SqlCommand(sql_select_cmd, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(sql_select_produce_barcode);

            cn.Open();

            for (int i = 0; i < int.Parse(tbox_tkr_amount.Text); i++)
            {
                sqlCommand.Parameters.AddWithValue("@tkr_m_id", merchant_text.Text);
                sqlCommand.Parameters.AddWithValue("@tkr_m", Session["name"].ToString());
                sqlCommand.Parameters.AddWithValue("@tkr_name", tbox_tkr_name.Text);
                sqlCommand.Parameters.AddWithValue("@tkr_inf", tbox_tkr_inf.Text);
                sqlCommand.Parameters.AddWithValue("@tkr_id", randomCodes[i]);
                sqlCommand.Parameters.AddWithValue("@tkr_user_id", "NULL");
                sqlCommand.Parameters.AddWithValue("@tkr_add_date", myDateString);
                sqlCommand.Parameters.AddWithValue("@tkr_deadline", tbox_tkr_date.Text);
                sqlCommand.Parameters.AddWithValue("@tkr_used", "No");

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Parameters.Clear();
            }
            //
            sql_select_produce_barcode.Parameters.AddWithValue("@tkr_m", merchant_text.Text);
            sql_select_produce_barcode.Parameters.AddWithValue("@tkr_add_date", myDateString);

            // 是否可寫個sql新增資料報錯確認code?

            cn.Close();

            adapter.Fill(dt);

            ListView_Produce_Barcode.DataSource = dt;
            ListView_Produce_Barcode.DataBind();

            Response.Write("<script>alert('新增成功!');</script>");

            tbox_tkr_amount.Text = "";
            tbox_tkr_date.Text = "";
            tbox_tkr_inf.Text = "";
            tbox_tkr_name.Text = "";
        }

    }
}