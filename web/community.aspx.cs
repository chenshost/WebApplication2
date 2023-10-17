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
using System.Web.UI.HtmlControls;
using MySqlX.XDevAPI.CRUD;

namespace WebApplication2
{
    public partial class community : System.Web.UI.Page
    {
        DataBassClass dbClass = new DataBassClass();

        private static int post_count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../web/login.aspx");
            }

            if (!Page.IsPostBack)
            {

                Web_initialization();

                listview_posts(5, "reset");

                for (int i = 0; i < listView_community.Items.Count; i++)
                {
                    int val = listView_community.Items.Count;
                }

                linkbutton_stats();
            }
            else if (Page.IsPostBack)
            {
                //Console.WriteLine("hello");
                //Response.Write("<script>alert('幹');</script>");
                //Web_initialization();
                listview_posts(5, "");

            }

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

        public void listview_posts(int post_limit, string reset)
        {
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
                                     inner join posts as p on u.id = p.user_id limit " + post_count;
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

                        // 先去找button的控件component


                        // 是不是for迴圈放這邊才顯示不出來?請看webform1的頁面 是正常的
                        // for (int k = 0; k < ; ) {

                        //foreach (ListViewDataItem item in listView_community.Items)
                        //{

                        //    // 使用FindControl方法尋找指定ID的Label控件
                        //    label_like = (Label)item.FindControl("label_like");
                        //    label_unlike = (Label)item.FindControl("label_unlike");
                        //    link_like = item.FindControl("link_like") as LinkButton;
                        //    link_unlike = (LinkButton)item.FindControl("link_unlike");
                        //    link_comment = (LinkButton)item.FindControl("link_comment");
                        //    label_like_stats = (Label)item.FindControl("label_like");
                        //    //HtmlGenericControl spanElement = (HtmlGenericControl)item.FindControl("icon_like");


                        //    link_like.Visible = false;
                        //    link_unlike.Visible = false;

                        //    //AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                        //    //trigger.ControlID = link_comment.ID;
                        //    //trigger.EventName = "Click";
                        //    //updatePanel.Triggers.Add(trigger);

                        //    // 疑似能夠撈到id的控件?
                        //    //Button btn_id = (Button)sender;
                        //    //int btn_id_click = int.Parse(btn_id.CommandArgument);
                        //    //int label_unlike_id = int.Parse(label_unlike.CommandArgument);
                        //}

                        //if (dt_result.Rows[i][7].ToString() == "(已按讚)")
                        //{
                        //    //現在你可以使用labelText變數來處理Label的值
                        //    //link_like.CssClass = "post_like";

                        //    label_like_stats.Text = "(已按讚)";

                        //    link_like.Visible = true;
                        //    link_unlike.Visible = false;
                        //}
                        //else
                        //{
                        //    link_like.Visible = false;
                        //    link_unlike.Visible = true;

                        //}

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

        #region header連結區 要找時間把這些提出來變物件導向
        protected void link_task_Click(object sender, EventArgs e)
        {
            Response.Redirect("tickers.aspx");
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

        #endregion

        protected void link_comment_Click(object sender, EventArgs e)
        {
            // 將 sender 轉換為 LinkButton 控制項
            LinkButton linkButton = (LinkButton)sender;


            // 疑似能夠撈到id的控件?
            //Button btn_id = (Button)sender;
            //int btn_id_click = int.Parse(btn_id.CommandArgument);
            //int link_comment_id = int.Parse(linkButton.CommandArgument);

            // 找到包含 hidden_id 的 NamingContainer (通常是 ListView 的 Item)
            ListViewDataItem dataItem = (ListViewDataItem)linkButton.NamingContainer;

            // 找到 Label 控制項
            Label hidden_id = (Label)dataItem.FindControl("hidden_id");
            ListView listView_comments = (ListView)dataItem.FindControl("listView_comments");

            string comment_data_sql = @"select u.id, u.userName, c.post_id, c.commentContent from comments as c 
                                        inner join user as u on c.user_id = u.id where c.post_id = " + hidden_id.Text;
            //string comment_data_sql = @"select u.id, u.userName, c.post_id, c.commentContent from comments as c 
            //                            inner join user as u on c.user_id = u.id where c.post_id = 1";

            DataTable comment_data = dbClass.SelectTable(comment_data_sql);

            listView_comments.DataSource = comment_data;
            listView_comments.DataBind();

            listView_comments.Visible = true;

            TextBox comment_tbox = (TextBox)dataItem.FindControl("comment_tbox");
            Button comment_btn = (Button)dataItem.FindControl("comment_btn");

            comment_tbox.Visible = true;
            comment_btn.Visible = true;

            ScriptManager.RegisterStartupScript(this, GetType(), "RestoreWindowHeight", "restoreOriginalWindowHeight();", true);

        }

        protected void Link_unlike_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;

            // 找到包含 hidden_id 的 NamingContainer (通常是 ListView 的 Item)
            ListViewDataItem dataItem = (ListViewDataItem)linkButton.NamingContainer;

            // 找到 Label 控制項
            Label hidden_id = (Label)dataItem.FindControl("hidden_id");
            Label label_like_stats = (Label)dataItem.FindControl("label_like_stats");
            Label label_like_count = (Label)dataItem.FindControl("label_like");
            LinkButton link_like = (LinkButton)dataItem.FindControl("link_like");
            LinkButton link_unlike = (LinkButton)dataItem.FindControl("link_unlike");

            string like_stats = label_like_stats.Text;
            int like_count = int.Parse(label_like_count.Text);

            if (like_stats != "(已按讚)")
            {
                string likes_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

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

                label_like_stats.Text = "(已按讚)";

                like_count++;
                label_like_count.Text = like_count.ToString();

                link_unlike.Visible = false;
                link_like.Visible = true;

            }
            else
            {
                string hidden_like_id = hidden_id.Text;
                string cancel_like_sql = "delete from likes where post_id = '" + hidden_like_id + "' and user_id = '" + Session["user_id"].ToString() + "'";
                dbClass.Delete(cancel_like_sql);

                label_like_stats.Text = "";
                like_count--;
                label_like_count.Text = like_count.ToString();

                link_unlike.Visible = true;
                link_like.Visible = false;
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "RestoreWindowHeight", "restoreOriginalWindowHeight();", true);
        }

        protected void Link_like_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;

            // 找到包含 hidden_id 的 NamingContainer (通常是 ListView 的 Item)
            ListViewDataItem dataItem = (ListViewDataItem)linkButton.NamingContainer;

            // 找到 Label 控制項
            Label hidden_id = (Label)dataItem.FindControl("hidden_id");
            Label label_like_stats = (Label)dataItem.FindControl("label_like_stats");
            Label label_like_count = (Label)dataItem.FindControl("label_like");
            Label label_unlike_count = (Label)dataItem.FindControl("label_unlike");
            LinkButton link_like = (LinkButton)dataItem.FindControl("link_like");
            LinkButton link_unlike = (LinkButton)dataItem.FindControl("link_unlike");

            string like_stats = label_like_stats.Text;
            int like_count = int.Parse(label_like_count.Text);
            int label_unlike = int.Parse(label_unlike_count.Text);

            if (like_stats != "(已按讚)")
            {
                string likes_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

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

                label_like_stats.Text = "(已按讚)";
                
                like_count++;
                label_like_count.Text = like_count.ToString();

                link_unlike.Visible = false;
                link_like.Visible = true;

            }
            else
            {
                string hidden_like_id = hidden_id.Text;
                string cancel_like_sql = "delete from likes where post_id = '" + hidden_like_id + "' and user_id = '" + Session["user_id"].ToString() + "'";
                dbClass.Delete(cancel_like_sql);

                label_like_stats.Text = "";
                like_count--;
                label_unlike--;
                label_like_count.Text = like_count.ToString();
                label_unlike_count.Text = label_unlike.ToString();

                link_unlike.Visible = true;
                link_like.Visible = false;
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "RestoreWindowHeight", "restoreOriginalWindowHeight();", true);
        }

        protected void comment_btn_Click(object sender, EventArgs e)
        {
            Button comment_btn = (Button)sender;
            ListViewDataItem dataItem = (ListViewDataItem)comment_btn.NamingContainer;

            Label hidden_id = (Label)dataItem.FindControl("hidden_id");
            
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            TextBox comment_tbox = (TextBox)dataItem.FindControl("comment_tbox");

            string comment_sql = @"insert into comments (user_id, post_id, commentContent, commentDateTime) 
                                   values ('" + Session["user_id"].ToString() + "', '" + hidden_id.Text + "', '" + comment_tbox.Text + "', '" + dateTime + "')";
            dbClass.Insert(comment_sql);


        }

        protected void link_share_Click(object sender, EventArgs e)
        {
            LinkButton comment_btn = (LinkButton)sender;
            ListViewDataItem dataItem = (ListViewDataItem)comment_btn.NamingContainer;

            Label hidden_id = (Label)dataItem.FindControl("hidden_id");

            string share_post_sql = @"select u.userName , p.id, p.community_id, p.postPin, p.postContent, p.PostDateTime 
                                      from user as u 
                                      inner join posts as p on u.id = p.user_id where p.id = " + hidden_id.Text;

            DataTable dt_result = dbClass.SelectTable(share_post_sql);

            // 這邊順序要注意 調行後資料會異動連帶影響程式判斷
            dt_result.Columns.Add("post_likes", typeof(int));       // [0][6]
            dt_result.Columns.Add("user_like", typeof(string));     // [0][7]
            dt_result.Columns.Add("total_comments", typeof(int));   // [0][8

            // 增加按讚總數 每則去
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

                // select使用者有增加的貼文
                string user_like_sql = "select id, post_id from likes where user_id = " + Session["user_id"].ToString();
                DataTable user_like = dbClass.SelectTable(user_like_sql);

                // 增加 及 判斷使用者是否有對貼文按讚
                for (int j = 0; j < user_like.Rows.Count; j++)
                {
                    // 判斷使用者有無按讚 貼文的id 是否等於 按讚對應的貼文id
                    if (dt_result.Rows[i][1].ToString() == user_like.Rows[j][1].ToString())
                    {
                        dt_result.Rows[i][7] = "(已按讚)";

                        foreach (ListViewItem item in listView_community.Items)
                        {
                            // 使用FindControl方法尋找指定ID的Label控件
                            Label label_like = (Label)item.FindControl("label_like");
                            LinkButton link_like = (LinkButton)item.FindControl("link_like");
                            Label label_like_stats = (Label)item.FindControl("label_like");

                            if (label_like != null)
                            {
                                // 取得Label的值
                                string labelText = label_like.Text;

                                //現在你可以使用labelText變數來處理Label的值
                                link_like.CssClass = "post_like";

                                label_like_stats.Text = "(已按讚)";

                                //現在你可以使用labelText變數來處理Label的值
                                //link_like.CssClass = "post_like";

                                //label_like_stats.Text = "(已按讚)";

                                //label_like.ForeColor = System.Drawing.Color.Red;

                                //label_like.BackColor = Color.FromArgb(17, 182, 114);
                                //label_like.BackColor = Color.Yellow;
                                //label_like.BackColor = Color.FromKnownColor(KnownColor.DeepPink);
                            }
                        }

                    }

                }

            }

            listView_community.DataSource = dt_result;
            listView_community.DataBind();
        }

        protected void listView_comments_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            #region 
            /*
            LinkButton link_comment = (LinkButton)e.Item.FindControl("link_comment");
            Label label_like_stats = (Label)e.Item.FindControl("label_like");

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                // 找到LinkButton控件
                LinkButton linkButton = (LinkButton)e.Item.FindControl("link_comment");

                if (linkButton != null)
                {
                    // 访问LinkButton的ID
                    string linkButtonID = linkButton.ID;

                    // 在这里你可以使用linkButtonID或进行其他操作
                    //linkButton.Visible = false;
                    //link_comment.Visible = false;
                }
            }



            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = link_comment.ID;
            trigger.EventName = "Click";
            updatePanel.Triggers.Add(trigger);
            */
            #endregion

            
        }
    }
}