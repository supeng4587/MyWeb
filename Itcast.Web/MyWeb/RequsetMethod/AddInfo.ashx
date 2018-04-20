<%@ WebHandler Language="C#" Class="AddInfo" %>

using System;
using System.Web;

public class AddInfo : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        //string userName = context.Request.QueryString["txtName"];
        //string userPwd = context.Request.QueryString["txtPwd"];

        string userName = context.Request.Form["txtName"];
        string userPwd = context.Request.Form["txtPwd"];
        context.Response.Write("用户名是：" + userName + "，用户密码：" + userPwd);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}