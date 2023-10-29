using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataBassClass dbClass = new DataBassClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.ForeColor = Color.Red;
            if (!IsPostBack)
            {
                LinkButton1.ForeColor = Color.Red;
                Label1.ForeColor = Color.Red;

                listview_posts();
            }
            // 初始點，如同main
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "1")
            {

                Label1.ForeColor = Color.Red;
            }
            else
            {

            }
        }

        protected void link_like_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_community.Items)
            {
                // 使用FindControl方法尋找指定ID的Label控件
                Label label7 = (Label)item.FindControl("label7");
                Label label8 = (Label)item.FindControl("label8");

                label7.Visible = true;
                label8.Visible = false;
            }
        }

        public void listview_posts ()
        {
            string sql = "select * from test;";
            DataTable dt = dbClass.SelectTable(sql);

            listView_community.DataSource = dt;
            listView_community.DataBind();

            //foreach (ListViewItem item in listView_community.Items)
            //{
            //    // 使用FindControl方法尋找指定ID的Label控件
            //    Label label_like = (Label)item.FindControl("label_like");
            //    Label label_unlike = (Label)item.FindControl("label_unlike");

            //    //label_like.Visible = false;
            //    //label_unlike.Visible = false;
            //}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = listView_community.Items[i];

                Label label7 = (Label)item.FindControl("label7");
                Label label8 = (Label)item.FindControl("label8");

                // 获取数据表中的某个条件，假设条件字段在第3列（根据实际情况调整）
                string conditionValue = dt.Rows[i][0].ToString();

                if (conditionValue != "")
                {
                    // 根据条件显示或隐藏 label7 和 label8
                    label7.Visible = true;
                    label8.Visible = false;
                }
                else
                {
                    label7.Visible = false;
                    label8.Visible = true;
                }
            }

        }

        protected void link_unlike_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_community.Items)
            {
                // 使用FindControl方法尋找指定ID的Label控件
                Label label7 = (Label)item.FindControl("label7");
                Label label8 = (Label)item.FindControl("label8");

                label7.Visible = false;
                label8.Visible = true;
            }
        }

        // method 方法, 在class裡面叫方法
    }
}