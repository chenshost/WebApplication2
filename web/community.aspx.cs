using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class community : System.Web.UI.Page
    {
        DataBassClass dbClass = new DataBassClass();
        CommunityClass communityClass = new CommunityClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../web/login.aspx");
            }

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

            //string post_data_sql = "select * from posts where community_id ='" + Session["community"].ToString() + "'";
            string post_data_sql  = @"select u.userName , p.id, p.community_id, p.postPin, p.postContent, p.PostDateTime 
                                      from user as u 
                                      inner join posts as p on u.id = p.user_id";

            DataTable post_data = dbClass.SelectTable(post_data_sql);
            listView_community.DataSource = post_data;
            listView_community.DataBind();

            string post_like_sql = @"select count(*) from likes where post_id = '" + "'";

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
    }
}