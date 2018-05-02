using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp._20180428
{
    public partial class UserDetailWebForm : System.Web.UI.Page
    {
        public UserInfo userInfo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserDetailInfo(Context.Request.QueryString["ID"]);
        }

        public void GetUserDetailInfo(string ID)
        {
            int id;
            if(int.TryParse(ID,out id))
            {
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();
                userInfo = userInfoService.GetList(id);
            }
            else
            {
                Context.Response.Redirect("/Error.htm");
            }
        }
    }
}