using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class DataBassClass
    {
        private string DBconn = "server=163.17.136.73;port=1433;user id=a123;password=F3PDEGup6310gG;database=spaced;charset=utf8;TreatTinyAsBoolean=false;";

        // 以後要改成SqlDataReader.Read 方法
        // 不然會增加記憶體(伺服器上)
        // while去判斷有無資料 沒有就跳出
        
        // 前後端分離 
        // 技術名詞 spa ssr 

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

        public void Insert(string sql)
        {
            using (MySqlConnection dbcn = new MySqlConnection(DBconn))
            {
                MySqlCommand sqlCommand = new MySqlCommand(sql, dbcn);

                dbcn.Open();

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Parameters.Clear();

                dbcn.Close();

            }
        }

        public void Delete(string sql) 
        {
            using (MySqlConnection dbcn = new MySqlConnection(DBconn))
            {
                MySqlCommand sqlCommand = new MySqlCommand(sql, dbcn);

                dbcn.Open();

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Parameters.Clear();

                dbcn.Close();

            }
        }
    }
}