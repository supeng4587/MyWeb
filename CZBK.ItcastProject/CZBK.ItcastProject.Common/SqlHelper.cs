using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CZBK.ItcastProject.Common
{
    public class SqlHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString; 

        public static DataTable GetDataTable(string sql,CommandType type,params SqlParameter[] pars)
        {
            using(SqlConnection conn =new SqlConnection(connStr))
            {
                using(SqlDataAdapter apter = new SqlDataAdapter(sql, conn))
                {
                    if(pars != null)
                    {
                        apter.SelectCommand.Parameters.AddRange(pars);
                    }
                    apter.SelectCommand.CommandType = type;
                    DataTable dt = new DataTable();
                    apter.Fill(dt);
                    return dt;
                }
            }
        }

        public static int ExecuteNonQuery(string sql,CommandType type,params SqlParameter[] pars)
        {
            using(SqlConnection conn =new SqlConnection(connStr))
            {
                using (SqlCommand cmd=new SqlCommand(sql,conn))
                {
                    if(pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
