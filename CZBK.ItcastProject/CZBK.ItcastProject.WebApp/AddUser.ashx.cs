using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CZBK.ItcastProject.Model;
using CZBK.ItcastProject.BLL;

namespace CZBK.ItcastProject.WebApp
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class AddUser : IHttpHandler
    {
        BLL.UserInfoService userInfoService = new BLL.UserInfoService();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request.Form["txtUserName"];
            string userPass = context.Request.Form["PassUserPass"];
            string email = context.Request.Form["txtEmail"];

             UserInfo userInfo = new UserInfo();
            userInfo.UserName = userName;
            userInfo.UserPass = userPass;
            userInfo.Email = email;
            userInfo.RegTime = DateTime.Now;

            if (userInfoService.Create(userInfo))
            {
                context.Response.Redirect("UserInfoList.ashx");
            }
            else
            {
                context.Response.Redirect("Error.html");
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