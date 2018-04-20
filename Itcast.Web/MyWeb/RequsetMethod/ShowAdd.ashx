<%@ WebHandler Language="C#" Class="ShowAdd" %>

using System;
using System.Web;
using System.IO;

public class ShowAdd : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string filePath = context.Request.MapPath("Add.html");
        string fileContent = File.ReadAllText(filePath);
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