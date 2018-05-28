using CZBK.ItcastProject.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180528
{
    public partial class SqlCacheDep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["userInfoList"] == null)
            {
                SqlCacheDependency sCDep = new SqlCacheDependency("GSSMS", "UserInfo");
                string sql = "select * from userinfo";
                DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text);
                Cache.Insert("userInfoList", dt,sCDep);
                Response.Write("data from database");
            }
            else
            {
                Response.Write("data from cache");
            }
        }
    }
}