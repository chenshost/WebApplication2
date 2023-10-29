using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Data;
using MySqlX.XDevAPI;
using System.Web;
using static WebApplication2.Api.ValuesController;

namespace WebApplication2.Api
{

    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        DataBassClass dbClass = new DataBassClass();

        // GET api/<controller>/5
        [HttpGet]
        [Route("get")]
        public string Get()
        {
            return "invalid access!";
        }

        //POST api/<controller>
        [HttpPost, ActionName("post")]
        //[HttpPost]
        [Route("post")]
        public IHttpActionResult Post([FromBody] PostData postdata)
        {
            if (postdata != null)
            {
                string sql = "Select id From user Where userName = '" + postdata.userID + "'";
                DataTable dt = dbClass.SelectTable(sql);
                string ticker_sql = "Select * From tickers Where id = '" + postdata.TickerID + "' AND userID = '" + dt.Rows[0][0].ToString() + "'";
                DataTable dt_ticker = dbClass.SelectTable(ticker_sql);

                //string user_id = dt.Rows[0][0].ToString();

                if (dt.Rows.Count > 0 && dt_ticker.Rows.Count > 0)
                {
                    Guid verify = Guid.NewGuid();
                    // guid不能加字串 資料欄長度會爆掉(varchar(38))

                    string verifi_time = DateTime.Now.AddMinutes(5).ToString("yyyy-MM-dd HH:mm:ss");

                    string verifi_sql = @"insert into verify (code, time, user_id, ticker_id) 
                                          values ('" + verify + "', '" + verifi_time + "', '" + dt.Rows[0][0].ToString() + "', '" + dt_ticker.Rows[0][0].ToString() + "')";
                    dbClass.Insert(verifi_sql);

                    return Ok(verify);
                }
                else
                {
                    //string return_ = "false, userID:" + postdata.userID + ", Password:" + postdata.Password;
                    return Ok("Wrong Data");
                }
            }
            else
            {
                return BadRequest("invalid data!");
            }
        }

        [HttpPost, ActionName("community")]
        [Route("post")]
        public IHttpActionResult Post_Community([FromBody] PostData postdata) // 保留
        {
            string sql = "Select id From user Where userName = '" + postdata.userID + "'";
            DataTable dt = dbClass.SelectTable(sql);

            if (dt.Rows.Count > 0)
            {
                Guid verify = Guid.NewGuid();
                // guid不能加字串 資料欄長度會爆掉(varchar(38))

                string verifi_time = DateTime.Now.AddMinutes(5).ToString("yyyy-MM-dd HH:mm:ss");

                string verifi_sql = @"insert into verify (code, time, user_id) 
                                      values ('" + verify + "', '" + verifi_time + "', '" + dt.Rows[0][0].ToString() + "')";
                dbClass.Insert(verifi_sql);

                return Ok(verify);
            }
            else
            {
                return BadRequest("invalid data!");
            }
        }

        public class PostData
        {
            public string userID { get; set; }
            //public string Password { get; set; }
            public string TickerID { get; set; }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}