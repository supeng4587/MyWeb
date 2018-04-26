using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180424
{
    /// <summary>
    /// ImageUpdate 的摘要说明
    /// </summary>
    public class ImageUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["ID"], out id))
            {
                BLL.ImageInfoService imageInfoService = new BLL.ImageInfoService();
                Model.ImageInfo imageInfo = new Model.ImageInfo();
                imageInfo = imageInfoService.read(id);
                if (imageInfo != null)
                {
                    string mapPath = context.Request.MapPath("ImageUpdate.html");
                    string fileContent = File.ReadAllText(mapPath);
                    fileContent = fileContent.Replace("$ID", imageInfo.ID.ToString()).Replace("$OriginalName", imageInfo.OriginalName).Replace("$Path", imageInfo.Path).Replace("$GuidName", imageInfo.GuidName).Replace("$Exetension", imageInfo.Extension).Replace("$ThumbName", imageInfo.ThumbName).Replace("$Size", imageInfo.Size).Replace("$CreateTime", imageInfo.CreateTime.ToString());
                    context.Response.Write(fileContent);
                }
                else
                {
                    context.Response.Write("要更新的图片不存在");
                }
            }
            else
            {
                context.Response.Write("参数错误");
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