using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CZBK.ItcastProject.BLL;
using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp._20180424
{
    /// <summary>
    /// ImageDetail 的摘要说明
    /// </summary>
    public class ImageDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["ID"], out id))
            {
                BLL.ImageInfoService imageInfoService = new BLL.ImageInfoService();
                ImageInfo imageInfo = imageInfoService.read(id);

                string filePath = context.Request.MapPath("ImageDetail.html");
                string fileContent = File.ReadAllText(filePath);
                fileContent = fileContent.Replace("$ID", imageInfo.ID.ToString()).Replace("$OriginalName", imageInfo.OriginalName).Replace("$Path", imageInfo.Path).Replace("$GuidName", imageInfo.GuidName).Replace("$Exetension", imageInfo.Extension).Replace("$ThumbName", imageInfo.ThumbName).Replace("$Size", imageInfo.Size).Replace("$CreateTime", imageInfo.CreateTime.ToString());
                context.Response.Write(fileContent);
            }
            else
            {
                context.Response.Redirect("/Error.html");
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