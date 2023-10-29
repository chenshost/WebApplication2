using System;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 初始點，如同main
        }

        // method 方法, 在class裡面叫方法
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = TextBox1.Text;
            TextBox1.Text = "";
            Label2.Text = TextBox2.Text;
            TextBox2.Text = "";
            
            //對資料庫作動
            string cnDB = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";    // 連線帳密
            SqlConnection cn = new SqlConnection(cnDB);     // 連線database

            string comd = "Insert Into Table_1 (text1, text2) Values (@t1, @t2)";       //sql語法
            SqlCommand sqlCommand = new SqlCommand(comd, cn);       // run指令

            sqlCommand.Parameters.AddWithValue("@t1", Label1.Text);
            sqlCommand.Parameters.AddWithValue("@t2", Label2.Text);

            cn.Open(); //開始連線，不可下太多次，會報錯

            sqlCommand.ExecuteNonQuery();

            sqlCommand.Parameters.Clear();

            cn.Close(); //關閉連線
        }
    }
}