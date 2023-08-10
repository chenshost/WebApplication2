using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        // 全域變數
        string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            //
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(DBconn))
            {
                string strCMD = "SELECT * FROM Cars";
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand(strCMD, cn);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dt);

                cn.Close();
            }

            ListView1.DataSource = dt;

            if (!Page.IsPostBack)
            {
                ListView1.DataBind();
            }

        }

        // 修改購物車 單筆 資料
        protected void cars_edit(object sender, EventArgs e)
        {
            // 全域
            SqlConnection dbcn = new SqlConnection(DBconn);

            // label物件，要把前端Label1變成相同物件型態
            //Label label = e.Item.FindControl("Label1") as Label;
            //label_id = label.Text;

            //
            //Label cars_nmb = ListView1.Items[i].FindControl("Label1") as Label;

            //TextBox txb_p_name = ListView1.Items[i].FindControl("TextBox3") as TextBox;
            //TextBox txb_p_price = ListView1.Items[i].FindControl("TextBox4") as TextBox;
            //TextBox txb_buy_amount = ListView1.Items[i].FindControl("TextBox5") as TextBox;



        }

        // 修改購物車 *全部* 資料
        protected void cars_edit_all(object sender, EventArgs e)
        {
            // db參數
            SqlConnection cn = new SqlConnection(DBconn);

            // list
            List<string> list1_edit = new List<string>();

            // 取listview1 item的所有textbox, update Cars資料表
            for (int i = 0; i < ListView1.Items.Count; i++)
            {
                // 宣告 取 編輯的標籤物件
                Label cars_nmb = ListView1.Items[i].FindControl("Label1") as Label;
                //Label cars_name = ListView1.Items[i].FindControl("Label2") as Label;

                // 輸入框, 
                TextBox txb_p_name = ListView1.Items[i].FindControl("TextBox3") as TextBox;
                TextBox txb_p_price = ListView1.Items[i].FindControl("TextBox4") as TextBox;
                TextBox txb_buy_amount = ListView1.Items[i].FindControl("TextBox5") as TextBox;

                // 串接單列資料
                list1_edit.Add(cars_nmb.Text + "," + txb_p_name.Text + "," + txb_p_price.Text + "," + txb_buy_amount.Text);

            }

            // 資料 + sql處理
            for (int i = 0; i < list1_edit.Count; i++)
            {
                // 切割資料, list物件的資料需要分割成陣列才能寫入資料庫
                string[] list1_edit_array = list1_edit[i].Split(',');  // Split','代表分割, 只能是單引號

                // 寫入的sql語法
                string edit_update = "Update Cars Set car_p_name = @txb_p_name, car_p_price = @txb_p_price, buy_amount = @txb_buy_amount Where number = @cars_nmb";
                SqlCommand edit_update_run = new SqlCommand(edit_update, cn);

                // 寫入資料表, 指定陣列欄位把各變數寫進去
                cn.Open();

                edit_update_run.Parameters.AddWithValue("@txb_p_name", list1_edit_array[1]);
                edit_update_run.Parameters.AddWithValue("@txb_p_price", list1_edit_array[2]);
                edit_update_run.Parameters.AddWithValue("@txb_buy_amount", list1_edit_array[3]);
                edit_update_run.Parameters.AddWithValue("@cars_nmb", list1_edit_array[0]);

                edit_update_run.ExecuteNonQuery();

                edit_update_run.Parameters.Clear();

                cn.Close();
            }
        }

    }
}