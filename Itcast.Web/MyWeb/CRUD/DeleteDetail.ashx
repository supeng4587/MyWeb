<%@ WebHandler Language="C#" Class="DeleteDetail" %>

using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DeleteDetail : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int id;
        if (int.TryParse(context.Request.QueryString["ID"], out id))
        {
            string conStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM dbo.UserInfo WHERE id = @id";
                    cmd.Connection = conn;
                    SqlParameter par = new SqlParameter("@id", SqlDbType.Int);
                    par.Value = id;
                    cmd.Parameters.Add(par);
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                            context.Response.Redirect("UserInfoList.ashx");
                    }
                    else
                    {
                            context.Response.Write("查无此人");
                    }
                }
            }
        }
        else
        {
            context.Response.Write("参数不正确");
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