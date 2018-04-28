using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using CZBK.ItcastProject.BLL;
//using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp._20180428
{
    public partial class UserInfoWebForm : System.Web.UI.Page
    {
        public string StrHtml { get; set; }
        public List<Model.UserInfo> List { get; set; } 

        /// <summary>
        /// 页面加载完成后。load事件 类似WinForm里的Form_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            List<Model.UserInfo> userlist = userInfoService.GetList();

            List = userlist;
            //StringBuilder sb = new StringBuilder();
            //foreach (Model.UserInfo userInfo in userlist)
            //{
            //    sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href='UserDetailWebForm.aspx?id={0}'>Detail</a></td><td><a href='javascript:void(0)' onclick= rowDelete(\"{1}\",\"{0}\")>Delete</a></td><td><a href='UpdateUserDetail.ashx?id={0}'>Update</a></td></tr>", userInfo.ID, userInfo.UserName, userInfo.UserPass, userInfo.Email, userInfo.RegTime);
            //}
            //StrHtml = sb.ToString();
        }
    }
}