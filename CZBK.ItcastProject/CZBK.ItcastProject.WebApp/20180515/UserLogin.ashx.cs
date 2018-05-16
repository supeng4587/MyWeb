using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180515
{
    /// <summary>
    /// UserLogin 的摘要说明
    /// </summary>
    public class UserLogin : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request["userName"];
            string userPass = context.Request["userPass"];
            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            string msg = string.Empty;
            Model.UserInfo userInfo = null;

            if (userInfoService.ValidateUserInfo(userName, userPass, out msg, out userInfo))
            {
                context.Session["userInfo"] = userInfo;
                context.Response.Write("ok:" + msg);
            }
            else
            {
                context.Response.Write("no:" + msg);
            }
            
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