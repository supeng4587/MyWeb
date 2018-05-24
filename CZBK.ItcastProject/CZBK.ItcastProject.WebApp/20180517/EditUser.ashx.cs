using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180517
{
    /// <summary>
    /// EditUser 的摘要说明
    /// </summary>
    public class EditUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            int id;
            if(int.TryParse(context.Request["id"],out id))
            {
                Model.UserInfo userInfo = new Model.UserInfo();
                userInfo = userInfoService.GetList(id);
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