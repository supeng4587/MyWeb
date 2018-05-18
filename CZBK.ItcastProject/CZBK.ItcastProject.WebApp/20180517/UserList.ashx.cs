using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZBK.ItcastProject.WebApp._20180517
{
    /// <summary>
    /// UserList 的摘要说明
    /// </summary>
    public class UserList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int pageIndex;
            if (!int.TryParse(context.Request["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            int pageSize = 10;

            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            int pageCount = userInfoService.GetPageCount(pageSize);
            //判断当前页码值得取值范围
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<Model.UserInfo> list = userInfoService.GetList(pageIndex, pageSize);
            string pagebar = Common.PagebarHelper.GetPagebar(pageIndex, pageCount);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();//序列化和反序列化的类
            string str=js.Serialize(new {UList=list,MyPageBar=pagebar });//将数据序列化成json字符串。匿名类
            context.Response.Write(str);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}