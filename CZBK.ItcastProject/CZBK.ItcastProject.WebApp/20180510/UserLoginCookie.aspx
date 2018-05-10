<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoginCookie.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180510.UserLoginCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../CSS/tableStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr><th>用户</th><th><input type="text" name="txtUserName" value="<%=loginUserName %>"/></th></tr>
                <tr><th>密码</th><th><input type="password" name="txtUserPass" /></th></tr>
                <tr><td colspan ="2"><input type="submit" value="submit" /></td></tr>
            </table>
        </div>
    </form>
</body>
</html>
