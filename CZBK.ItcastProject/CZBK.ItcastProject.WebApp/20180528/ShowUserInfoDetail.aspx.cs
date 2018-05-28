using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180528
{
    public partial class ShowUserInfoDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"]);
            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            Model.UserInfo userInfo = userInfoService.GetList(id);
            List<Model.UserInfo> list = new List<Model.UserInfo>();
            list.Add(userInfo);
            this.DetailsView1.DataSource = list;
            this.DetailsView1.DataBind();
        }
    }
}