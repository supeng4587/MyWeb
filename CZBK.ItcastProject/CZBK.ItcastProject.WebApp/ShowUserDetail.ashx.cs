using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CZBK.ItcastProject.Model;
using CZBK.ItcastProject.BLL;
using System.IO;

namespace CZBK.ItcastProject.WebApp
{
    /// <summary>
    /// ShowUserDetail 的摘要说明
    /// </summary>
    public class ShowUserDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                BLL.UserInfoService userInfoService = new UserInfoService();
                UserInfo userInfo = new UserInfo();
                userInfo = userInfoService.GetList(id);
                if (userInfo != null)
                {
                    string filePath = context.Request.MapPath("ShowUserDetail.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$ID", userInfo.ID.ToString()).Replace("$UserName", userInfo.UserName).Replace("$UserPass", userInfo.UserPass).Replace("$Email", userInfo.Email).Replace("$RegTime", userInfo.RegTime.ToString());
                    context.Response.Write(fileContent);
                }
                else
                {
                    context.Response.Redirect("Error.html");
                }
            }
            else
            {
                context.Response.Write("查询参数错误。");
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