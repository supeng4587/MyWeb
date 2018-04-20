<%@ WebHandler Language="C#" Class="AddUser" %>

using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class AddUser : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        //1.接受表单数据
        string UserName = context.Request.Form["txtUserName"];
        string UserPass = context.Request.Form["PassUserPass"];
        string Email = context.Request.Form["txtEmail"];
        //2.链接数据库添加用户
        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "insert into userinfo (username,userpass,email,regtime) values (@username,@userpass,@email,GETDATE())";
                SqlParameter[] pars =
                    {
                        new SqlParameter("@username",SqlDbType.NChar,64),
                        new SqlParameter("@userpass",SqlDbType.NChar,64),
                        new SqlParameter("@email",SqlDbType.NChar,64)
                    };
                pars[0].Value = UserName;
                pars[1].Value = UserPass;
                pars[2].Value = Email;
                cmd.Parameters.AddRange(pars);
                conn.Open();
                //3.返回结果
                if (cmd.ExecuteNonQuery() > 0)
                {
                    context.Response.Redirect("UserInfoList.ashx");//实现页面跳转
                }
                else
                {
                    context.Response.Redirect("Error.html");
                }
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