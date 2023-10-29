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
        public string post_userID { get; set; }
        public string post_Password { get; set; }

    }
}