using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp._20180503
{
    public partial class NumberPageCodeNewsList : System.Web.UI.Page
    {
        public string StrHtml { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = 10;
            int pageIndex;
            if (!int.TryParse(Context.Request.QueryString["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            BLL.UserInfoService userInfoServer = new BLL.UserInfoService();

            //对当前的页码范围进行判断
            int pageCount = userInfoServer.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            PageIndex = pageIndex;
            PageCount = pageCount;

            List<UserInfo> list = userInfoServer.GetList(pageIndex, pageSize);
            StringBuilder sb = new StringBuilder();

            foreach (UserInfo item in list)
            {
                sb.AppendFormat("<li><span>{0}</span><a href='' target='_blank'>{1}</a></li>", item.RegTime.ToShortDateString(), item.UserName);
                StrHtml = sb.ToString();
            }
        }
    }
}