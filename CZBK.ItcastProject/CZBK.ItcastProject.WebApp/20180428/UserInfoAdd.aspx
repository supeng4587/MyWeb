<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoAdd.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180428.UserInfoAdd" %>
<%@ Import Namespace="CZBK.ItcastProject.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="UserInfoAdd" method ="post" action="UserInfoAdd.aspx">
        <input type="hidden" name ="IsPostBack" value="1" />
        <div>
            <table>
                <tr>
                    <th>Element</th>
                    <th>Information</th>
                </tr>
                <tr>
                    <td>UserName：</td>
                    <td>
                        <input type="text" name="txtUserName" /></td>
                </tr>
                <tr>
                    <td>UserPass:</td>
                    <td>
                        <input type="password" name="PassUserPass" /></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <input type="text" name="txtEmail" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="submit" value="Create" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
