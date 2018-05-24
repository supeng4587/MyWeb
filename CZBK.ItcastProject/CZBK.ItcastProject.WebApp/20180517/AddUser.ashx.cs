using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180517
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.UserInfo userInfo = new Model.UserInfo();
            userInfo.UserName = context.Request["txtUserName"];
            userInfo.UserPass = context.Request["PassUserPass"];
            userInfo.Email = context.Request["txtEmail"];
            userInfo.RegTime = DateTime.Now;

            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            if (userInfoService.Create(userInfo))
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
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