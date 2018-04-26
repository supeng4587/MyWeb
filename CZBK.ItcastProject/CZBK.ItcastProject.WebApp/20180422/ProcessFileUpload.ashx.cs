using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;
using System.Drawing;

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
            if(file.ContentLength>0)
            {
                //校验上传文件扩展名
                string fileName = Path.GetFileName(file.FileName);//file.FileName获得的完全限定名，包含了文件路径，使用Path.GetFileName获得文件名和扩展名
                string fileExt = Path.GetExtension(fileName);//获得文件扩展名
                string[] imgExts = { ".jpg",".png",".bmp","jpeg"};//定义一个常用图片wenjian扩展名数组
                bool exists = ((IList)imgExts).Contains(fileExt);//使用IList接口中Contains判断数组中是否包含上传文件的扩展名
                if (exists)//改成一个数组判断图片格式
                {
                    //file.SaveAs(context.Request.MapPath("/ImageUpload/"+fileName));
                    //context.Response.Write("<html><body><img src='/ImageUpload/" + fileName + "'></body></html>");//展示
                    //解决重名文件和覆盖的问题
                    string guidName = Guid.NewGuid().ToString();
                    string dir = "/ImageUpload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    string fullDir = dir + guidName + fileExt;//文件存储的完成路径
                    if (!Directory.Exists(context.Request.MapPath(dir))){
                        Directory.CreateDirectory(context.Request.MapPath(dir));
                    }

                    file.SaveAs(context.Request.MapPath(fullDir));
                    //context.Response.Write("<html><body><a href=#>"+ fullDir + "</a><img src='"+ fullDir + "'></body></html>");

                    string waterGuidName;
                    //根据成功上传成功的图片创建一个image实例
                    using (Image img = Image.FromFile(context.Request.MapPath(fullDir)))
                    {
                        //根据img实例高度、宽度创建画布
                        using (Bitmap map =new Bitmap(img.Width,img.Height))
                        {
                            //为画布创建画笔
                            using (Graphics g = Graphics.FromImage(map))
                            {
                                //设置高质量插值法
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                                //设置高质量,低速度呈现平滑程度
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                                g.DrawImage(img,0,0, img.Width, img.Height);
                                int imgWidth = img.Width;
                                int imgHeight = img.Height;
                                int mapWidth = map.Width;
                                int mapHeight = map.Height;
                                g.DrawString("test watermark", new Font("宋体", 20.0f, FontStyle.Underline), Brushes.Red, new PointF(map.Width/2,map.Height/2));
                                waterGuidName = "water_"+Guid.NewGuid().ToString();
                                map.Save(context.Request.MapPath(dir + waterGuidName + fileExt), System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                        }
                    }

                    context.Response.Write("<html><body><a href=#>" + dir + waterGuidName + fileExt + "</a></br><img src='" + dir + waterGuidName + fileExt + "'></body></html>");
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