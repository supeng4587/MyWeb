using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CZBK.ItcastProject.BLL;
using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp
{
    /// <summary>
    /// UpdateUserInfo 的摘要说明
    /// </summary>
    public class UpdateUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id;
            if(int.TryParse(context.Request.Form["ID"],out id))
            {
                UserInfo userInfo = new UserInfo();
                userInfo.ID = id;
                userInfo.UserName = context.Request.Form["txtUserName"];
                userInfo.UserPass = context.Request.Form["passUserPass"];
                userInfo.Email = context.Request.Form["txtEmail"];

                BLL.UserInfoService userInfoService = new BLL.UserInfoService();
                if (userInfoService.Update(userInfo))
                {
                    context.Response.Redirect("UserInfoList.ashx");
                }
                else
                {
                    context.Response.Redirect("Error.html");
                }
            }
            else
            {
                context.Response.Write("更新参数错误");
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