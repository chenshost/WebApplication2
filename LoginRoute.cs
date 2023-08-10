using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace WebApplication2
{
    public class LoginRoute
    {
        public LoginRoute(string session)
        {
            HttpContext.Current.Response.Redirect("web_login.aspx");
            if (session == null || session == "")
            {
                HttpContext.Current.Response.Redirect("web_login.aspx");
            }
            else
            {
                return;
            }
        }
    }
}