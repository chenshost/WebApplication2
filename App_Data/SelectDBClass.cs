﻿using MySql.Data.MySqlClient;
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
        private string DBconn = "server=163.17.136.73;port=1433;user id=a123;password=F3PDEGup6310gG;database=spaced;charset=utf8;";
        public DataTable SelectTable(string strurl)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection dbcn = new MySqlConnection(DBconn))
            {
                MySqlCommand sqlCommand = new MySqlCommand(strurl, dbcn);
                MySqlDataAdapter Adapter = new MySqlDataAdapter(sqlCommand);
                Adapter.Fill(dt);

            }

            return dt;
        }

        public DataTable SelectUser()
        {
            string strurl = "";
            DataTable dt = new DataTable();

            using (MySqlConnection dbcn = new MySqlConnection(DBconn))
            {
                MySqlCommand sqlCommand = new MySqlCommand(strurl, dbcn);
                MySqlDataAdapter Adapter = new MySqlDataAdapter(sqlCommand);
                Adapter.Fill(dt);

            }

            return dt;
        }

    }
}