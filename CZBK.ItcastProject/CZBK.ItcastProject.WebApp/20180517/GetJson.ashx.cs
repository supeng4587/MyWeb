using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180517
{
    /// <summary>
    /// GetJson 的摘要说明
    /// </summary>
    public class GetJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"name\":\"zhangsan\",\"age\":\"22\"}");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}