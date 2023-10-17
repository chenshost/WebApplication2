using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
//using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.IO;
using System.Web.Services;
using System.Drawing.Imaging;
using System.Text;
using ZXing.Common;
using ZXing.QrCode;
using ZXing;
using MySql.Data.MySqlClient;
using System.Web.DynamicData;

namespace WebApplication2
{
    public partial class user_inf : System.Web.UI.Page
    {
        DataBassClass dbClass = new DataBassClass();
        CodeClass codeClass = new CodeClass();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("../web/login.aspx");

                    Session.Remove("user");
                }

            }
            else if (IsPostBack)
            {

            }

        }

        protected void link_task_Click(object sender, EventArgs e)
        {
            Response.Redirect("tickers.aspx");
        }

        protected void link_community_Click(object sender, EventArgs e)
        {
            Response.Redirect("community.aspx");
        }
    }
}