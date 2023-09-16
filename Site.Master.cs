using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 初始設定
            label_user_id.ForeColor = Color.White;

            if (Session["user"] != null)
            {
                label_user_id.Text = "用戶:" + Session["user"].ToString();
                btn_login.Visible = false;
                btn_logout.Visible = true;
            }
            else
            {
                label_user_id.Text = "尚未登入";
                btn_login.Visible = true;
                btn_logout.Visible = false;
            }

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("web/login.aspx");
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            //Session["user"] = null;
            Response.Redirect("web/login.aspx");
        }
    }
}