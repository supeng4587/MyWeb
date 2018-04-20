<%@ WebHandler Language="C#" Class="UpdateUserInfo" %>

using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class UpdateUserInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int id;
        if (int.TryParse(context.Request.Form["ID"], out id))
        {
            string userName = context.Request.Form["txtUserName"];
            string userPass = context.Request.Form["passUserPass"];
            string email = context.Request.Form["txtEmail"];
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE dbo.UserInfo SET UserName=@userName,UserPass=@userPass,Email=@email WHERE ID =@id";
                    cmd.Connection = conn;
                    SqlParameter[] pars =
                        {
                            new SqlParameter("@id",SqlDbType.Int),
                            new SqlParameter("@userName",SqlDbType.NVarChar,64),
                            new SqlParameter("@userPass",SqlDbType.NVarChar,64),
                            new SqlParameter("@email",SqlDbType.NVarChar,64)
                        };
                    pars[0].Value = id;
                    pars[1].Value = userName;
                    pars[2].Value = userPass;
                    pars[3].Value = email;
                    cmd.Parameters.AddRange(pars);
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        context.Response.Redirect("UserInfoList.ashx");
                    }
                    else
                    {
                        context.Response.Write("未能正确更新");
                    }
                };
            };
        }
        else
        {
            context.Response.Write("参数错误");
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