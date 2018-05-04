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
            <%
                Server.Execute("Child.aspx");
            %>
            <hr />
            <iframe src="Child.aspx" <%--frameborder="0"--%>></iframe>
        </div>
    </form>
</body>
</html>
