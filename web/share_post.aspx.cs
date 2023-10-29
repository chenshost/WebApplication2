using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.web
{
    public partial class share_post : System.Web.UI.Page
    {
        DataBassClass dbClass = new DataBassClass();

        private static int post_count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../web/login.aspx");
            }

            Web_initialization();

            listview_posts(5, "reset");

            link_comment_Click();
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

            label_community_category.Text = community_category(communityCategory);
            label_community_description.Text = communityDescription;
            label_community_create_date.Text = communityCreateDate + " 創建";

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

        public void listview_posts(int post_limit, string reset)
        {
            //Session["share_post"] = "2";
            // 初始狀態設定
            if (reset == "reset")
            {
                post_count = 5;
                post_count += post_limit;

                Session["total_posts"] = 0;
            }
            else
            {
                post_count += post_limit;
            }

            #region 資料流處理
            // 貼文資料
            string post_data_sql = @"select u.userName , p.id, p.community_id, p.postPin, p.postContent, p.PostDateTime 
                                     from user as u 
                                     inner join posts as p on u.id = p.user_id where p.id = '" + Session["share_post"].ToString() +"'";
            DataTable dt_result = dbClass.SelectTable(post_data_sql);

            // 這邊順序要注意 調行後資料會異動連帶影響程式判斷
            dt_result.Columns.Add("post_likes", typeof(int));       // [0][6]
            dt_result.Columns.Add("user_like", typeof(string));     // [0][7]
            dt_result.Columns.Add("total_comments", typeof(int));   // [0][8]

            Label label_like = new Label();
            Label label_unlike = new Label();
            LinkButton link_like = new LinkButton();
            LinkButton link_unlike = new LinkButton();
            LinkButton link_comment = new LinkButton();
            Label label_like_stats = new Label();

            // 處理 每則留言.按讚資料總數資料
            for (int i = 0; i < dt_result.Rows.Count; i++)
            {
                // 每則去增加按讚總數
                string post_like_sql = "select count(*) from likes where post_id = " + dt_result.Rows[i][1].ToString();
                DataTable post_like_add = dbClass.SelectTable(post_like_sql);
                dt_result.Rows[i][6] = post_like_add.Rows[0][0].ToString();

                // 每則去增加總留言數
                string total_comments_sql = "select count(*) from comments where post_id = " + dt_result.Rows[i][1];
                DataTable total_comments = dbClass.SelectTable(total_comments_sql);
                dt_result.Rows[i][8] = total_comments.Rows[0][0].ToString();

                // select使用者有按讚的資料
                string user_like_sql = "select id, post_id from likes where user_id = " + Session["user_id"].ToString();
                DataTable user_like = dbClass.SelectTable(user_like_sql);

                listView_community.DataSource = dt_result;
                listView_community.DataBind();

                // 增加 及 判斷使用者是否有對貼文按讚
                for (int j = 0; j < user_like.Rows.Count; j++)
                {
                    // 判斷使用者有無按讚 貼文的id 是否等於 按讚對應的貼文id
                    if (dt_result.Rows[i][1].ToString() == user_like.Rows[j][1].ToString())
                    {
                        dt_result.Rows[i][7] = "(已按讚)";

                    }

                }

            }
            #endregion

            int total_posts = int.Parse(Session["total_posts"].ToString());

            if (total_posts == dt_result.Rows.Count)
            {
                posts_bottom_label.Visible = true;
                //posts_bottom_label.Text = dt_result.Rows.Count.ToString();
                posts_bottom_label.Text = "沒有更多貼文";
            }
            else
            {
                Session["total_posts"] = dt_result.Rows.Count;
            }

            // 這裡將資料綁定到 ListView 並重新綁定
            listView_community.DataSource = dt_result;
            listView_community.DataBind();

            linkbutton_stats();
        }

        public void linkbutton_stats()
        {
            for (int i = 0; i < listView_community.Items.Count; i++)
            {
                ListViewDataItem item = listView_community.Items[i];

                LinkButton link_like = (LinkButton)item.FindControl("link_like");
                LinkButton link_unlike = (LinkButton)item.FindControl("link_unlike");
                Label label_like_stats = (Label)item.FindControl("label_like_stats");
                Label label_unlike_stats = (Label)item.FindControl("label_unlike_stats");

                string label_like_stats_text = label_like_stats.Text;

                if (label_like_stats_text == "(已按讚)")
                {
                    link_like.Visible = true;
                    link_unlike.Visible = false;
                }
                else
                {
                    link_like.Visible = false;
                    link_unlike.Visible = true;
                }

            }

        }

        public void link_comment_Click()
        {
            ListView listView_comments = new ListView();

            foreach (ListViewDataItem item in listView_community.Items)
            {
                // 使用FindControl方法尋找指定ID的Label控件
                listView_comments = (ListView)item.FindControl("listView_comments");
            }

            string comment_data_sql = @"select u.id, u.userName, c.post_id, c.commentContent from comments as c 
                                        inner join user as u on c.user_id = u.id where c.post_id = " + Session["share_post"].ToString();

            DataTable comment_data = dbClass.SelectTable(comment_data_sql);

            listView_comments.DataSource = comment_data;
            listView_comments.DataBind();

        }

        protected void link_share_Click(object sender, EventArgs e)
        {

        }

        protected void link_unlike_Click(object sender, EventArgs e)
        {

        }

        protected void link_like_Click(object sender, EventArgs e)
        {

        }

        protected void comment_btn_Click(object sender, EventArgs e)
        {

        }
    }
}