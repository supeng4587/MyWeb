﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Collections;

namespace CZBK.ItcastProject.WebApp._20180424
{
    /// <summary>
    /// Thumb 的摘要说明
    /// </summary>
    public class Thumb : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //0f8fc701-988b-4fae-897d-aa86b958ac64.jpg
            //创建缩略图，定义一个比较小的画布，将图片画到画布上再保存
            HttpPostedFile file = context.Request.Files[0];
            if (file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(file.FileName);
                string[] exts = { ".jpg", "png", "jpeg", "bmp" };//指定常用图片扩展名
                bool exist = ((IList)exts).Contains(fileExt);//判断扩展名存在
                if (exist)
                {
                    string guidPath;
                    using (Bitmap map = new Bitmap(150, 150))
                    {
                        using (Image img = Image.FromStream(file.InputStream))
                        {
                            using (Graphics g = Graphics.FromImage(map))
                            {
                                g.DrawImage(img, 0, 0, map.Width, map.Height);
                                string guidName = Guid.NewGuid().ToString();
                                guidPath = "/ImageUpload/2018/4/24/" + guidName + ".jpg";
                                map.Save(context.Request.MapPath(guidPath), System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                        }
                    }
                    context.Response.Write("<html><body><a href='#'>" + guidPath + "</a></br><img src=" + guidPath + "></body></html>");
                }
                else
                {
                    context.Response.Write("只能上传图片文件。");
                }
            }
            else
            {
                context.Response.Write("请选择上传图片文件。");
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