using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180511
{
    /// <summary>
    /// LoginOut 的摘要说明
    /// </summary>
    public class LoginOut : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session["userInfo"] = null;
            context.Response.Cookies["cp1"].Expires = System.DateTime.Now.AddDays(-1);
            context.Response.Cookies["cp2"].Expires = System.DateTime.Now.AddDays(-1);
            context.Response.Redirect("UserLogin.aspx");
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