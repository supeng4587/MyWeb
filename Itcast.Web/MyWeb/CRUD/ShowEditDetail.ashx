<%@ WebHandler Language="C#" Class="ShowEditDetail" %>

using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public class ShowEditDetail : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        int id;
        //tryparse尝试将第一个参数成整形，如果能转换成功那么返回true，并且将转换成功的整形数字赋值给第二个参数，否则返回false。
        if (int.TryParse(context.Request.QueryString["ID"], out id))
        {
            //根据接收到的ID查询数据表中相应的记录
            string conStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                using (SqlDataAdapter apter = new SqlDataAdapter("SELECT * FROM UserInfo WHERE Id=@id", conn))
                {
                    SqlParameter par = new SqlParameter("@id", SqlDbType.Int);
                    par.Value = id;
                    apter.SelectCommand.Parameters.Add(par);
                    DataTable dt = new DataTable();
                    apter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string filePath = context.Request.MapPath("ShowEditDetail.html");
                        string fileContent = File.ReadAllText(filePath);
                        fileContent = fileContent.Replace("$ID", dt.Rows[0]["ID"].ToString()).Replace("$UserName", dt.Rows[0]["UserName"].ToString()).Replace("$UserPass", dt.Rows[0]["UserPass"].ToString()).Replace("$Email", dt.Rows[0]["Email"].ToString()).Replace("$RegTime", dt.Rows[0]["RegTime"].ToString());
                        context.Response.Write(fileContent);
                    }
                    else
                    {
                        context.Response.Write("查无此人！！");
                    }
                };
            };
        }
        else
        {
            context.Response.Write("参数异常。");
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