using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180524
{
    public partial class UseRepeater : System.Web.UI.Page
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex;
            if(!int.TryParse(Request["pageIndex"],out pageIndex))
            {
                pageIndex = 1;
            }
            int pageSize = 5;
            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            int pageCount = userInfoService.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            PageIndex = pageIndex;
            PageCount = pageCount;
            this.Repeater1.DataSource = userInfoService.GetList(pageIndex,pageSize);
            this.Repeater1.DataBind();
        }

        //ItemCommand:只要Repeater的其他服务段事件被触发，那么Repeater的ItemCommand事件也会被触发，所以在ItemCommand事件中可以完成Repeater其他服务端事件的处理。
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName== "BtnDeleteUserInfo")
            {
                Response.Write(e.CommandArgument);
            }
        }
    }
}