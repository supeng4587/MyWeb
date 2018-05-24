using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180517
{
    /// <summary>
    /// ChangeUser 的摘要说明
    /// </summary>
    public class ChangeUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id;
            if (int.TryParse(context.Request["txtEditUserID"], out id))
            {
                Model.UserInfo userInfo = new Model.UserInfo();
                userInfo.ID = id;
                userInfo.UserName = context.Request["txtEditUserName"];
                userInfo.UserPass = context.Request["txtEditUserPass"];
                userInfo.Email = context.Request["txtEditEmail"];
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();
                if (userInfoService.Update(userInfo))
                {
                    context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("no");
                }
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