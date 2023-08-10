using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class web_admin_barcode_edit : System.Web.UI.Page
    {
        string cnDB = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    randomCodes[i] = GenerateRandomCode(7);
                }

                // 在此將 randomCodes 傳遞到前端
            }
            //
            DateTime myDate = DateTime.Now;
            string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
            //
            string sql_insert_cmd = "INSERT INTO Tickers(ticker_merchant, ticker_name, ticker_inf, ticker_id, ticker_user_id, ticker_add_date, ticker_date, ticker_used)" +
                            "VALUES (@tkr_m, @tkr_name, @tkr_inf, @tkr_id, @tkr_user_id, @tkr_add_date, @tkr_date, @tkr_used)";
            //
            SqlConnection cn = new SqlConnection(cnDB);             // 連線database
            SqlCommand sqlCommand = new SqlCommand(sql_insert_cmd, cn);     // 對資料庫作動
            //
            DataTable dt = new DataTable();
            string sql_select_cmd = "SELECT * FROM Tickers WHERE ticker_merchant = @tkr_m AND ticker_add_date = @tkr_add_date";
            SqlCommand sql_select_produce_barcode = new SqlCommand(sql_select_cmd, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(sql_select_produce_barcode);

            cn.Open();

            for (int i = 0; i < int.Parse(tbox_tkr_amount.Text); i++)
            {
                sqlCommand.Parameters.AddWithValue("@tkr_m", tbox_merchant.Text);
                sqlCommand.Parameters.AddWithValue("@tkr_name", tbox_tkr_name.Text);
                sqlCommand.Parameters.AddWithValue("@tkr_inf", tbox_tkr_inf.Text);
                sqlCommand.Parameters.AddWithValue("@tkr_id", randomCodes[i]);
                sqlCommand.Parameters.AddWithValue("@tkr_user_id", "NULL");
                sqlCommand.Parameters.AddWithValue("@tkr_add_date", myDateString);
                sqlCommand.Parameters.AddWithValue("@tkr_date", tbox_tkr_date.Text);
                sqlCommand.Parameters.AddWithValue("@tkr_used", "No");

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Parameters.Clear();
            }
            //
            sql_select_produce_barcode.Parameters.AddWithValue("@tkr_m", tbox_merchant.Text);
            sql_select_produce_barcode.Parameters.AddWithValue("@tkr_add_date", myDateString);

            // 是否可寫個sql新增資料報錯確認code?

            cn.Close();

            adapter.Fill(dt);

            ListView_Produce_Barcode.DataSource = dt;
            ListView_Produce_Barcode.DataBind();

            Response.Write("<script>alert('新增成功!');</script>");
        }

        protected void btn_search_merchant_ticker_Click(object sender, EventArgs e)
        {
            string search_merchant = tbox_search_merchant_ticker.ToString();
            string sql_search_cmd = "SELECT * FROM Tickers Where merchant_id = @m_id";
            //
            SqlConnection cn = new SqlConnection(cnDB);             // 連線database
            SqlCommand sql_search = new SqlCommand(sql_search_cmd, cn);     // 對資料庫作動
            //
            DataTable dt_search = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_search);

            cn.Open();

            sql_search.Parameters.AddWithValue("@m_id", tbox_search_merchant_ticker.Text);
            
            cn.Close();

            adapter.Fill(dt_search);

            listView_search_barcode.DataSource = dt_search;
            listView_search_barcode.DataBind();

        }
    }
}