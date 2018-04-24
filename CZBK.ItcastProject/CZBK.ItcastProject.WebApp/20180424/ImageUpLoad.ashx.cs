using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Collections;
using CZBK.ItcastProject.BLL;
using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp._20180424
{
    /// <summary>
    /// ImageUpLoad 的摘要说明
    /// </summary>
    public class ImageUpLoad : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HttpPostedFile file = context.Request.Files[0];

            if (file.ContentLength > 0)
            {
                string filePath = Path.GetFileName(file.FileName);//通过file的完全限定名得出源文件的文件名和扩展名
                string fileExt = Path.GetExtension(file.FileName);//通过file的完全限定名得出源文件的扩展名
                string guidName;
                string thumbName;
                string imgWidth;
                string imgHeight;
                string dir = "/ImageUpload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                if (!Directory.Exists(context.Request.MapPath(dir)))
                {
                    Directory.CreateDirectory(context.Request.MapPath(dir));
                }//如果目录不存在就创建一个

                string[] imageExt = { ".jpg", ".png", "bmp", ".jpge" };
                bool exist = ((IList)imageExt).Contains(fileExt);

                if (exist)
                {
                    guidName = Guid.NewGuid().ToString();
                    thumbName = "thumb" + guidName;
                    file.SaveAs(context.Request.MapPath(dir + guidName + fileExt));

                    //画缩略图
                    using (Bitmap map = new Bitmap(100, 100))
                    {
                        using (Graphics g = Graphics.FromImage(map))
                        {
                            Image img = Image.FromStream(file.InputStream);
                            imgWidth = img.Width.ToString();
                            imgHeight = img.Height.ToString();

                            g.DrawImage(img, 0, 0, 100, 100);
                            map.Save(context.Request.MapPath(dir + thumbName + fileExt), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }

                    //组imageinfo写数据库
                    ImageInfo imageInfo = new ImageInfo();
                    imageInfo.OriginalName = file.FileName;
                    imageInfo.Path = dir;
                    imageInfo.GuidName = guidName;
                    imageInfo.Extension = fileExt;
                    imageInfo.ThumbName = thumbName;
                    imageInfo.Size = imgWidth + "X" + imgHeight;
                    imageInfo.CreateTime = DateTime.Now;

                    BLL.ImageInfoService imageInfoService = new BLL.ImageInfoService();

                    if (imageInfoService.create(imageInfo))
                    {
                        context.Response.Redirect("ImageList.ashx");
                    }
                    else
                    {
                        context.Response.Redirect("/Error.html");
                    }
                }
                else
                {
                    context.Response.Write("仅能上传图片文件");
                }
            }
            else
            {
                context.Response.Write("请选择要上传的图片");
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