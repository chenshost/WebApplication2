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

namespace WebApplication2.Api
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        SelectDBClass selectDB = new SelectDBClass();
        LoginRoute loginRoute = new LoginRoute();

        // GET api/<controller>/5
        [HttpGet]
        [Route("get")]
        public string Get()
        {
            return "invalid access!";
        }

        //POST api/<controller>
        [HttpPost]
        [Route("post")]
        public IHttpActionResult Post([FromBody] PostData postdata) // 保留
        {
            if (postdata != null)
            {
                string sql = "Select userName, password From user Where userName = '" + postdata.userID + "' AND password = '" + postdata.Password + "'";
                DataTable dt = selectDB.SelectTable(sql);

                if (dt.Rows.Count > 0 )
                {
                    //var session = System.Web.HttpContext.Current.Session; //宣告Session
                    //session.Add("user", postdata.userID); //將認證資訊放入Session
                    //var temp = session["user"];
                    HttpContext.Current.Session["user"] = postdata.userID;
                    string success = "success!, userID:" + postdata.userID + ", Password:" + postdata.Password + ", Session" + HttpContext.Current.Session["user"].ToString();

                    var response = Request.CreateResponse(HttpStatusCode.Moved);
                    response.Headers.Location = new Uri("~/web_login.aspx");

                    //return Ok(response);
                    return Redirect("~/WebForm1.aspx"); // 打開檔案
                }
                else
                {
                    string return_ = "false, userID:" + postdata.userID + ", Password:" + postdata.Password;
                    return Ok(return_);
                }
            }
            else
            {
                return BadRequest("invalid data!");
            }

        }

        public class PostData
        {
            public string userID { get; set; }
            public string Password { get; set; }
        }


        //JSON = {
        //KEY : VALUE
        // "name" : "alan",
        // "age": 18,
        // "address": "",
        // }

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