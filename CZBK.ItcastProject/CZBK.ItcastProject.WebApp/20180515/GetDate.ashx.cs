﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180515
{
    /// <summary>
    /// GetDate 的摘要说明
    /// </summary>
    public class GetDate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(DateTime.Now.ToString());
            context.Response.Write(context.Request["name"]);
            context.Response.Write(context.Request["pwd"]);
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