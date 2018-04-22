using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

namespace CZBK.ItcastProject.WebApp._20180422
{
    /// <summary>
    /// ProcessFileUpload 的摘要说明
    /// </summary>
    public class ProcessFileUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write(context.Request.Form["txtName"]);
            HttpPostedFile file = context.Request.Files[0];
            if(file != null)
            {
                //校验上传文件扩展名
                string fileName = Path.GetFileName(file.FileName);//file.FileName获得的完全限定名，包含了文件路径，使用Path.GetFileName获得文件名和扩展名
                string fileExt = Path.GetExtension(fileName);//获得文件扩展名
                string[] imgExts = { ".jpg",".png",".bmp","jpeg"};//定义一个常用图片wenjian扩展名数组
                bool exists = ((IList)imgExts).Contains(fileExt);//使用IList接口中Contains判断数组中是否包含上传文件的扩展名
                if (exists)//改成一个数组判断图片格式
                {
                    file.SaveAs(context.Request.MapPath("/ImageUpload/"+fileName));
                    context.Response.Write("<html><body><img src='/ImageUpload/" + fileName + "'></body></html>");
                }
                else
                {
                    context.Response.Write("只能上传图片文件");
                }
            }
            else
            {
                context.Response.Write("请选择上传文件");
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