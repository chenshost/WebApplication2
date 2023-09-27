using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Services;
using System.Web.Script.Services;
using System.Diagnostics;
using System.Collections;
using System.Web.Services.Description;

namespace WebApplication2
{
    public partial class community : System.Web.UI.Page
    {
        DataBassClass dbClass = new DataBassClass();

        private static int post_count = 0;

        // public ListView listView_community = new ListView();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../web/login.aspx");
            }

            Web_initialization();

            listview_posts(5, "reset");

        }

        public void Web_initialization()
        {
            string user_community_sql = "select * from community_members where user_id = '" + Session["user_id"].ToString() + "'";
            DataTable user_community_dt = dbClass.SelectTable(user_community_sql);
            string user_community = user_community_dt.Rows[0][1].ToString();

            string community_sql = "select * from community where id = '" + user_community + "'";
            DataTable community_dt = dbClass.SelectTable(community_sql);
            Session["community"] = community_dt.Rows[0][0].ToString();
            string communityName = community_dt.Rows[0][1].ToString();
            string communityDescription = community_dt.Rows[0][2].ToString();
            string communityCreateDate = community_dt.Rows[0][3].ToString();
            string communityCategory = community_dt.Rows[0][4].ToString();

            label_name.Text = communityName;
            //label_community_category.Text = communityClass.community_category(communityCategory);
            label_community_category.Text = community_category(communityCategory);
            label_community_description.Text = communityDescription;
            label_community_create_date.Text = communityCreateDate + " 創建";

            //Lazy<IDataReader> dataReader = new Lazy<IDataReader>();
            //string post_data_sql = "select * from posts where community_id ='" + Session["community"].ToString() + "'";
            string post_data_sql = @"select u.userName , p.id, p.community_id, p.postPin, p.postContent, p.PostDateTime 
                                     from user as u 
                                     inner join posts as p on u.id = p.user_id";
            //DataTable post_data = dbClass.SelectTable(post_data_sql);

            //Lazy<DataTable> listview_lazy = new Lazy<DataTable>();
            //DataTable listview_lazy_result = listview_lazy.Value;
            //listview_lazy_result = dbClass.SelectTable(post_data_sql);
        }

        // 嘗試把listview_community 改善null增加資料
        public static ListView listview_community_stsaic;
        public static UpdatePanel updatePanel_static;

        [WebMethod]
        public static string listview_renew(string reset)
        {
            DataBassClass dbClass = new DataBassClass();

            community community = new community();
            community.listview_posts(5, "");

            UpdatePanel updatePanel1 = new UpdatePanel();
            updatePanel1 = updatePanel_static;
            updatePanel1.Update();


            return reset;
        }

        public void listview_posts(int post_limit, string reset)
        {
            if (reset == "reset")
            {
                post_count = 0;

                listview_community_stsaic = listView_community;
                updatePanel_static = updatePanel;
            }
            else
            {
                post_count += post_limit;
            }

            string post_data_sql = @"select u.userName , p.id, p.community_id, p.postPin, p.postContent, p.PostDateTime 
                                     from user as u 
                                     inner join posts as p on u.id = p.user_id limit " + post_count + ", 5";

            DataTable dt_result = dbClass.SelectTable(post_data_sql);

            dt_result.Columns.Add("post_likes", typeof(int));
            dt_result.Columns.Add("user_like", typeof(Boolean));

            for (int i = 0; i < dt_result.Rows.Count; i++)
            {
                string post_like_sql = @"select count(*) from likes where post_id = " + dt_result.Rows[i][1].ToString();
                DataTable post_like_add = dbClass.SelectTable(post_like_sql);
                dt_result.Rows[i][6] = post_like_add.Rows[0][0].ToString();

                string user_like_sql = @"select id, post_id from likes where user_id = " + Session["user_id"].ToString();
                DataTable user_like = dbClass.SelectTable(user_like_sql);

                for (int j = 0; j < user_like.Rows.Count; )
                {
                    if (user_like.Rows[0][1].ToString() == dt_result.Rows[0][1].ToString())
                    {
                        j++;
                        // 變更likes的狀態(顏色)

                    }
                    else
                    {
                        break;
                    }

                }

            }

            // 這裡將資料綁定到 ListView 並重新綁定
            listView_community = listview_community_stsaic;
            listView_community.DataSource = dt_result;
            listView_community.DataBind();

            //listView_community.add

            updatePanel = updatePanel_static;
            updatePanel.Update();

        }

        void ContactsListView_ItemUpdating(Object sender, ListViewUpdateEventArgs e)
        {
            // Cancel the update operation if any of the fields is empty
            // or null.
            foreach (DictionaryEntry de in e.NewValues)
            {
                // Check if the value is null or empty.
                if (de.Value == null || de.Value.ToString().Trim().Length == 0)
                {
                    //Message.Text = "Cannot set a field to an empty value.";
                    e.Cancel = true;
                }
            }

            // Convert the email address to lowercase.
            String emailValue = e.NewValues["EmailAddress"].ToString();
            e.NewValues["EmailAddress"] = emailValue.ToLower();

        }

        protected void link_task_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_inf.aspx");
        }

        protected void link_community_Click(object sender, EventArgs e)
        {
            Response.Redirect("community.aspx");
        }

        public string community_category(string category_id)
        {
            switch (category_id)
            {
                case "1":
                    return "學習類社群";
                case "2":
                    return "運動類社群";
                case "3":
                    return "作息養成社群";
                case "4":
                    return "控制飲食社群";
                default:
                    return "";
            }
        }

        protected void link_menu_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_inf.aspx");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void Link_like_Click(object sender, EventArgs e)
        {
            string likes_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            LinkButton linkButton = (LinkButton)sender;

            // 找到包含 hidden_id 的 NamingContainer (通常是 ListView 的 Item)
            ListViewDataItem dataItem = (ListViewDataItem)linkButton.NamingContainer;

            // 找到 Label 控制項
            Label hidden_id = (Label)dataItem.FindControl("hidden_id");

            string idValue = "";

            if (hidden_id != null)
            {
                idValue = hidden_id.Text;
                // 現在你可以使用 idValue 這個變數來處理 id 的值
            }

            string like_sql = @"insert into likes (user_id, post_id, LikeDateTime) 
                                values ('" + Session["user_id"].ToString() + "', '" + idValue + "', '" + likes_time + "')";

            // 變更likes的狀態(顏色) 需要去想一下要如何把按讚的圖示連結狀態更新

            dbClass.Insert(like_sql);

        }
    }
}