using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace JSONPDemo.Controllers
{
    public class JOSNPController:ApiController
    {
       
        public string Get(int id)
        {
            return "demo";
        }

        public HttpResponseMessage Get(int id,string callBack)
        {
            var content = new JOSNPReturn
            {
                CallBack = callBack,
                JSON = "{'id':'"+id.ToString()+"','data':'Hello from jsonpp controller'}"
            };

            var msg = Request.CreateResponse(HttpStatusCode.OK,content,"application/javascript");
            return msg;
        }
    }
}