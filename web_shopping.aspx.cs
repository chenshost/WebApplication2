using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class web_products : System.Web.UI.Page
    {
        // 全域變數
        string cnDB = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";    // 連線database

        protected void Page_Load(object sender, EventArgs e)
        {
            //對資料庫作動
            string sqlcmd = "Select * From Products";               // sql語法指令
            // 
            SqlConnection cn = new SqlConnection(cnDB);             // 連線database
            SqlCommand sqlCommand = new SqlCommand(sqlcmd, cn);     // 對資料庫作動

            cn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            ListView1.DataSource = dt;

            cn.Close();

            if (!Page.IsPostBack)
            {
                ListView1.DataBind();
            }

        }

        protected void Button1_AddtoCar(object sender, EventArgs e)
        {
            //資料庫連線
            SqlConnection cn = new SqlConnection(cnDB);     //連線

            // 全域變數
            // List物件的字串
            List<string> add_car = new List<string>();
            List<string> update_id = new List<string>();
            //
            int List_Count = ListView1.Items.Count;     // 取list物件的總量
            string[] update_amount = new string[List_Count];    // 購買數量 空矩陣
            List<string> p_amount_array = new List<string>();

            // 串接有填入購買數量的資料列
            for (int i = 0; i < ListView1.Items.Count; i++)     // ListView1.Items.Count=這個ListView1資料列的總數
            {
                TextBox txb = ListView1.Items[i].FindControl("TextBox1") as TextBox;

                // 輸入框不等於空值就串接資料
                if (txb.Text != "")
                {
                    // 取前端Label的值, 商品id, 名稱, 庫存量, 售價
                    Label p_id = ListView1.Items[i].FindControl("Label1") as Label;
                    Label p_name = ListView1.Items[i].FindControl("Label2") as Label;
                    Label p_amount = ListView1.Items[i].FindControl("Label3") as Label;
                    Label p_price = ListView1.Items[i].FindControl("Label4") as Label;

                    add_car.Add(p_id.Text + "," + p_name.Text + "," + p_price.Text + "," + txb.Text);   // .Add增加, 使用者的訂單
                    update_id.Add(p_id.Text);           // 購買的id表
                    p_amount_array.Add(p_amount.Text);  // 原商品頁的庫存數量表

                }

            }

            // 加入Cars表, 計算add_car總長度去跑
            for (int i = 0; i < add_car.Count; i++)
            {
                // 分割List加入矩陣
                string[] add_car_array = add_car[i].Split(',');  // Split','代表分割, 只能是單引號

                // 購買數量更新, 運算
                //      新數量      = 表單上的數量(label3, 原始數量)  - add_car矩陣[3,輸入數量]
                int new_amount_ans = Int32.Parse(p_amount_array[i]) - Int32.Parse(add_car_array[3]);
                // 新數量轉字串, 更新商品數量
                string new_amount = new_amount_ans.ToString();

                // 跑list, i的資料欄為空就不run if
                if (update_id[i] != null)
                {
                    update_amount[i] = new_amount;
                }

                string sqlcmd = "Insert Into Cars (user_id, car_p_id, car_p_name, car_p_price, buy_amount) " +
                                "Values ('a123', @p_id, @p_name, @p_price, @buy_amount)";
                SqlCommand sqlcmd_run = new SqlCommand(sqlcmd, cn);     // 格式:( sql指令, 資料庫連線)


                // sql open, 跑sql及 @變數加入參數
                cn.Open();

                sqlcmd_run.Parameters.AddWithValue("@p_id", add_car_array[0]);
                sqlcmd_run.Parameters.AddWithValue("@p_name", add_car_array[1]);
                sqlcmd_run.Parameters.AddWithValue("@p_price", add_car_array[2]);
                sqlcmd_run.Parameters.AddWithValue("@buy_amount", add_car_array[3]);

                sqlcmd_run.ExecuteNonQuery();

                sqlcmd_run.Parameters.Clear();

                cn.Close();

            }

            // 更新數量, 指定id+更新
            for (int i = 0; i < add_car.Count; i++)
            {
                string update_p_amount = "Update Products Set product_amount = @new_amount Where product_id = @p_id";
                SqlCommand sqlcmd_update = new SqlCommand(update_p_amount, cn);

                cn.Open();

                sqlcmd_update.Parameters.AddWithValue("@p_id", update_id[i]);
                sqlcmd_update.Parameters.AddWithValue("@new_amount", update_amount[i]);

                sqlcmd_update.ExecuteNonQuery();

                sqlcmd_update.Parameters.Clear();

                cn.Close();

            }

            Response.Redirect("web_shopping.aspx");
            // c#網頁沒有彈跳式視窗 要用JS去作動
        }

    }
}