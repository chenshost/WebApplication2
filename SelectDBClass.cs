using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class SelectDBClass
    {
        public string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";
        public void GetSelectDb(string strurl)
        {
            //string DBconn = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true";
            string db_show_cmd = strurl;

            SqlConnection dbcn = new SqlConnection(DBconn);
            SqlCommand sqlCommand = new SqlCommand(db_show_cmd, dbcn);

            dbcn.Open();



            dbcn.Close();
        }

        public void merchant_select_db(string sql_str, string sql_val)
        {
            SqlConnection dbcn = new SqlConnection(DBconn);
            SqlCommand sqlCommand = new SqlCommand(sql_str, dbcn);

            dbcn.Open();

            sqlCommand.Parameters.AddWithValue("@ticker_merchant", sql_val);

            dbcn.Close();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.Fill(dt);

        }
    }
}