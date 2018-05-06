<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerDemo.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180504.ServerDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            主页面
           <%-- <%
                Server.Execute("Child.aspx");
            %>
            <hr />
            <iframe src="Child.aspx" frameborder="0"></iframe>--%>

            <!--server.transfer和response.redirect的区别：
                server.tranfer：是服务端的内部跳转，不会向浏览器返回信息，所以地址栏中的URL变；
                response.redirect：是服务端向浏览器返回一个302，浏览器重定向向指定页面再次发出请求。-->
           <%-- <%Server.Transfer("Child.aspx"); %>--%>

            <%=Server.HtmlEncode("<font color='red'></fonnt>") %> 
            <%--htmlencode:将html标签进行编码输出，浏览器不做渲染--%>
            <%--htmldecode:将已经编码处理过的html标签解码处理，是浏览器可以对其渲染--%>

            <%--UrlEncode:将url进行编码例如：<a href="aa.aspx?a=<%=Server.UrlEncode("特殊字符") %>"></a>，在处理url地址传参的时候遇到乱码或意想不到的问题，可以考虑用这个处理
            UrlDecode:将url进行解码处理。--%>


            这是主页面的第二部分内容！
        </div>
    </form>
</body>
</html>
