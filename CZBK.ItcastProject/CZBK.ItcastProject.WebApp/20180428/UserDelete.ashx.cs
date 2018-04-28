using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180428
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
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();
                if (userInfoService.Delete(id))
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
                context.Response.Write("参数错误，无法删除！！！");
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