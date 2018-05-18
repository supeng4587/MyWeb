using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180517
{
    /// <summary>
    /// UserDelete 的摘要说明
    /// </summary>
    public class UserDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id;
            if(int.TryParse(context.Request["id"],out id))
            {
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();
                if (userInfoService.Delete(id))
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