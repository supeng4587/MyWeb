<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserUpdate.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180428.UserUpdate" %>
<%@ Import Namespace="CZBK.ItcastProject.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="UserUpdateForm" method="post" action="UserUpdate.aspx"> 
        <input type="hidden" name="IsPostBack" value="1" />
        <div>
            <table>
            <tr>
                <th>Element</th>
                <th>Info</th>
            </tr>
            <tr>
                <td>ID:</td>
                <td><%=userInfoHtml.ID %><input type="hidden" name="ID" value="<%=userInfoHtml.ID %>" /></td>
            </tr>
            <tr>
                <td>UserName：</td>
                <td><input type="text" name="txtUserName" value="<%=userInfoHtml.UserName %>" /></td>
            </tr>
            <tr>
                <td>UserPass:</td>
                <td><input type="password" name="passUserPass" value="<%=userInfoHtml.UserPass %>" /></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><input type="text" name="txtEmail" value="<%=userInfoHtml.Email %>" /></td>
            </tr>
            <tr>
                <td>RegTime:</td>
                <td><%=userInfoHtml.RegTime %><input type="hidden" name="RegTime" value="<%=userInfoHtml.RegTime %>" /></td>
            </tr>
            <tr><td colspan="2"><input type="submit" value="Submit" /></td></tr>
        </table>
        </div>
    </form>
</body>
</html>
