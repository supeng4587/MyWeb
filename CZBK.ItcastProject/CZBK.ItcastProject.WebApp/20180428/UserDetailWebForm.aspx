<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetailWebForm.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180428.UserDetailWebForm" %>

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
        <tr>
            <th>Element</th>
            <th>Info</th>
        </tr>
        <tr>
            <td>ID:</td>
            <td>$ID</td>
        </tr>
        <tr>
            <td>UserName：</td>
            <td>$UserName</td>
        </tr>
        <tr>
            <td>UserPass:</td>
            <td>$UserPass</td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>$Email</td>
        </tr>
        <tr>
            <td>RegTime:</td>
            <td>$RegTime</td>
        </tr>
        <tr>
            <td colspan="2" >
                <a href="UserInfoList.ashx">Back</a>
            </td>
        </tr>
    </table>
        </div>
    </form>
</body>
</html>
