using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.IO;

namespace CZBK.ItcastProject.WebApp._20180528
{
    public partial class CacheDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["userInfoList"] == null)
            {
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();
                List<Model.UserInfo> list = userInfoService.GetList();
                //Cache["userInfoList"] = list;
                Cache.Insert("userInfoList", list, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, RemoveCache);
                Response.Write("数据来自数据库。");
                //Cache.Remove("userInfoList");
            }
            else
            {
                List<Model.UserInfo> list = (List<Model.UserInfo>)Cache["userInfoList"];
                Response.Write("数据来自缓存");
            }
        }

        protected void RemoveCache(string key,object value,CacheItemRemovedReason reason)
        {
            //if (reason == CacheItemRemovedReason.Expired)
            //{
            //    string filePath = Request.MapPath("/logs/CacheRmove.txt");
            //    string outText = "缓存过期，移除缓存";
            //    using(FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //    {
            //        using(StreamWriter sw = new StreamWriter(fs))
            //        {
            //            sw.WriteLine("{0}\n",outText,DateTime.Now);
            //            sw.Flush();
            //        }
            //    }
            //}
        }
    }
}