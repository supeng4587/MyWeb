using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace CZBK.ItcastProject.WebApp
{
    /// <summary>
    /// MakeImage 的摘要说明
    /// </summary>
    public class MakeImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //给用户创建一张图片，并且把这张图片保存
            //创建一个画布
            using(Bitmap bitMap = new Bitmap(300, 600))
            {
                //给画布创建一个画笔
                using(Graphics g = Graphics.FromImage(bitMap))
                {
                    g.Clear(Color.Gray);
                    //在画布上写字
                    //1.写的文字
                    //2.font属性字体、大小、颜色
                    //3.在画布的什么位置写字
                    g.DrawString("传智播客", new Font("宋体", 14.0f, FontStyle.Italic), Brushes.GreenYellow,new PointF(150,400));

                    //将画布保存成一张图片
                    string fileName = Guid.NewGuid().ToString();
                    //将画布保存成一张图片，并且指定图片的类型
                    bitMap.Save(context.Request.MapPath("/ImageUpload/" + fileName + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                    context.Response.Write("<html><body><img src='/ImageUpload/" + fileName + ".jpg'/></body></html>");
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