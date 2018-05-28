<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageCacheDemo.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180528.PageCacheDemo" %>
<%@ OutputCache Duration="5" VaryByParam="*" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <hr />
            <a href="ShowUserInfoDetail.aspx?id=9990">用户信息9990</a><br /><hr />
            <a href="ShowUserInfoDetail.aspx?id=9989">用户信息9989</a>
        </div>
    </form>
</body>
</html>
