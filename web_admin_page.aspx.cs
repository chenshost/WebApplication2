using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class web_admin_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_barcode_scan_link_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_admin_barcode.aspx");
        }

        protected void btn_barcode_edit_link_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_admin_barcode_edit.aspx");
        }
    }
}