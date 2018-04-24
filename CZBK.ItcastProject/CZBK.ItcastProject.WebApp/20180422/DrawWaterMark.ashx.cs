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
    /// DrawWaterMark 的摘要说明
    /// </summary>
    public class DrawWaterMark : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HttpPostedFile file = context.Request.Files[0];
            if (file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(fileName);
                string[] exts = { ".jpg", "png", "jpeg", "bmp" };//指定常用图片扩展名
                bool exist = ((IList)exts).Contains(fileExt);//判断扩展名存在

                if (exist)
                {
                    using (Image img = Image.FromStream(file.InputStream)) 
                    using (Bitmap map = new Bitmap(img))
                    {
                        using (Graphics g = Graphics.FromImage(map))
                        {
                            g.DrawString("test watermark", new Font("宋体", 14.0f, FontStyle.Italic), Brushes.YellowGreen, new PointF(100, 150));
                            string guidName = Guid.NewGuid().ToString();
                            string dir = "/ImageUpload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                            if (!Directory.Exists(context.Request.MapPath(dir)))
                            {
                                Directory.CreateDirectory(context.Request.MapPath(dir));
                            }

                            map.Save(context.Request.MapPath(dir + guidName + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                            context.Response.Write("<html><body><a href='#'>" + dir + guidName + ".jpg" + "</a></br><img src='" + dir + guidName + ".jpg" + "'</body></html>");
                        }
                    }
                }
                else
                {
                    context.Response.Write("只能上传图片文件。");
                }
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