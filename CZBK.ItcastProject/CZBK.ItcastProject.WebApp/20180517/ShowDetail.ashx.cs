using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180517
{
    /// <summary>
    /// ShowDetail 的摘要说明
    /// </summary>
    public class ShowDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id;
            if(int.TryParse(context.Request["id"],out id))
            {
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();
                Model.UserInfo userInfo = new Model.UserInfo();

                userInfo = userInfoService.GetList(id);
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                context.Response.Write(js.Serialize(userInfo));
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