using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180528
{
    public partial class FileCacheDependency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Request.MapPath("/20180528/File.txt");
            if (Cache["fileContent"] == null)
            {
                string fileContent = File.ReadAllText(filePath);
                System.Web.Caching.CacheDependency cDep = new System.Web.Caching.CacheDependency(filePath);
                Cache.Insert("fileContent", fileContent, cDep);
                Response.Write("data from file|"+fileContent);
            }
            else
            {
                Response.Write("data from Cache|" + Cache["fileContent"].ToString());
            }
        }
    }
}