using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp._20180428
{
    public partial class UserInfoAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //如果使用runat="server",则可以使用string.IsNullOrEmpty(Request.Form["isPostBack"])判断是否为post
            //IsPostBack:如果是post则属性值为false，如果是get则属性值为true
            //IsPostBack:是根据__VIEWSTATE隐藏域进行判断的，如果是post请求，那么隐藏域的值会提交到服务端
            //使用runat="server"后，aspx中的默认form是一个控件，__VIEWSTATE中将记录状态保持的值。也可以不使用，自己写一个隐藏域进行校验如下：
            if (Context.Request.Form["IsPostBack"] != null)
            {
                string userName = Context.Request.Form["txtUserName"];
                string userPass = Context.Request.Form["PassUserPass"];
                string email = Context.Request.Form["txtEmail"];

                UserInfo userInfo = new UserInfo();
                userInfo.UserName = userName;
                userInfo.UserPass = userPass;
                userInfo.Email = email;
                userInfo.RegTime = DateTime.Now;
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();

                if (userInfoService.Create(userInfo))
                {
                    Context.Response.Redirect("UserInfoWebForm.aspx");
                }
                else
                {
                    Context.Response.Redirect("/Error.html");
                }
            }
        }
    }
}