<%@ WebHandler Language="C#" Class="ShowInfo" %>

using System;
using System.Web;
using System.IO;

public class ShowInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        //获取要操作的模板的路径
        string filePath = context.Request.MapPath("ShowInfo.html");
        //获取文件的物理路径。在asp.net中，对文件或文件夹进行操作一定要获取物理路径
        //读取模板文件中的内容
        string fileContent = File.ReadAllText(filePath);
        fileContent.Replace("$name", "Itcast").Replace("$pwd", "123");
        //将替换后的内容输出给浏览器
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