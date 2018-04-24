using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CZBK.ItcastProject.BLL;
using CZBK.ItcastProject.Model;
using System.Text;

namespace CZBK.ItcastProject.WebApp._20180424
{
    /// <summary>
    /// ImageList 的摘要说明
    /// </summary>
    public class ImageList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string htmlFilePath = context.Request.MapPath("ImageList.html");
            string htmlFileContent = File.ReadAllText(htmlFilePath);

            BLL.ImageInfoService imageInfoService = new BLL.ImageInfoService();
            List<ImageInfo> list = imageInfoService.read();
            if(list != null)
            {
                StringBuilder sb = null;
                foreach (ImageInfo item in list)
                {
                    sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td></td><td></td><td></td><td></td></tr>", item.ID, item.OriginalName, item.Path, item.GuidName, item.Extension, item.Size, item.CreateTime);
                }
                htmlFileContent = htmlFileContent.Replace("@toBody", sb.ToString());
            }
            else
            {
                htmlFileContent = htmlFileContent.Replace("@toBody", "");
            }
            

            context.Response.Write(htmlFileContent);
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