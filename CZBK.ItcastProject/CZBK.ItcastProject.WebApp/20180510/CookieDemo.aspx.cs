using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180510
{
    public partial class CookieDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cookie：是一种客户端状态保持的机制，（网站的数据是存在客户端），与隐藏域与ViewState对象都属于客户端状态保持，Cookie中存储的是关于网站的文本字符串数据，Cookie的存储方式有两种，如果不指定过期时间，那么存储在客户端浏览器内存中，如果指定过去时间，那么存储在客户端的磁盘上，Cookie是与具体的网站有关的，如果我们将Cookie设置了过期时间，那么当用户在指定的时间内访问我们的网站，那么属于我们网站的Cookie数据会放在请求的报文中发送过来，其他网站的Cookie不会发送。
            //Cookie的应用场景，电商记录用户浏览的商品、购物车、登陆时会员名称的记录

            ////创建Cookie
            //Response.Cookies["cp1"].Value = "我是Cookie，cp1的value我没有设置过期时间会存储到客户端的内存中";

            //创建Cookie并指定过去时间
            //Response.Cookies["cp2"].Value = "我是Cookie，cp2的Value,我设置了过期时间会存储到客户端硬盘中";
            //Response.Cookies["cp2"].Expires = System.DateTime.Now.AddDays(3);

            //删除Cookie
            //Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);

            //Cookie跨域（域名）
            //主域下创建的Cookie会自动的发给子域，子域创建的Cookie不会自动的发给主域。
            //有时需要子域的Cookie发送给主域，使用Domain
            //Response.Cookies["cp3"].Value = "子域的Cookie";
            //Response.Cookies["cp3"].Domain = "xxx.com";//主域的域名

            //path属性 某些情况下我们希望访问某些特定文件夹时请求带有Cookie，而访问其他文件夹的时候不带有Cookie。这样就需要设置path属性
            Response.Cookies["cp4"].Value = "cp4";
            Response.Cookies["cp4"].Expires = DateTime.Now.AddDays(3);
            Response.Cookies["cp4"].Path = "/20180510";

            HttpCookie cookie1 = new HttpCookie("cp5");
            cookie1.Value = Server.UrlEncode("我是老五");
            cookie1.Expires = DateTime.Now.AddDays(3);
            Response.Cookies.Add(cookie1);
        }
    }
}