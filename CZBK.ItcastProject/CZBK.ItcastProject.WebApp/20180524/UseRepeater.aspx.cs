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
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            this.Repeater1.DataSource = userInfoService.GetList();
            this.Repeater1.DataBind();
        }
    }
}