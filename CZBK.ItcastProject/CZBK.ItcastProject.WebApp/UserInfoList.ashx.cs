using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CZBK.ItcastProject.Model;
using CZBK.ItcastProject.BLL;
using System.Text;
using System.IO;

namespace CZBK.ItcastProject.WebApp
{
    /// <summary>
    /// UserInfoList 的摘要说明
    /// </summary>
    public class UserInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            List<UserInfo> list = userInfoService.GetList();
            StringBuilder sb = new StringBuilder();
            foreach (UserInfo userInfo in list)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href='ShowUserDetail.ashx?id={0}'>Detail</a></td><td><a href='javascript:void(0)' onclick= rowDelete(\"{1}\",\"{0}\")>Delete</a></td><td><a href='UpdateUserDetail.ashx?id={0}'>Update</a></td></tr>", userInfo.ID, userInfo.UserName, userInfo.UserPass, userInfo.Email, userInfo.RegTime);
            }
            string filePath = context.Request.MapPath("UserInfoList.html");
            string fileContent = File.ReadAllText(filePath);
            fileContent = fileContent.Replace("@tboby", sb.ToString());
            context.Response.Write(fileContent);
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