<%@ WebHandler Language="C#" Class="UserInfoList" %>

using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

public class UserInfoList : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connstr))
        {
            using (SqlDataAdapter atper = new SqlDataAdapter("SELECT * FROM dbo.UserInfo ORDER BY id DESC", conn))
            {
                DataTable dt = new DataTable();
                atper.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href='ShowDetail.ashx?ID={0}'>Detail</a></td><td><a href='javascript:void(0)' onclick= rowDelete(\"{1}\",\"{0}\")>Delete</a></td><td><a href='ShowEditDetail.ashx?ID={0}'>Edit</a></td></tr>", row["ID"].ToString(), row["UserName"].ToString(), row["UserPass"].ToString(), row["Email"].ToString(), row["RegTime"].ToString());
                    }
                    string filePath = context.Request.MapPath("UserInfoList.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("@tbaby", sb.ToString());
                        context.Response.Write(fileContent);
                }
                else
                {
                        context.Response.Write("暂无数据!!");
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