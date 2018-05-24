using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180524
{
    public partial class DataList : System.Web.UI.Page
    {
        public string Str { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            List< Model.UserInfo> list = userInfoService.GetList();
            this.DropDownList1.DataSource = list;
            this.DropDownList1.DataTextField = "UserName";
            this.DropDownList1.DataValueField = "ID";
            this.DropDownList1.DataBind();

            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append("<option value=\"" + item.ID + "\">" + item.UserName + "</option>");
            }
            Str = sb.ToString(); 
        }
    }
}