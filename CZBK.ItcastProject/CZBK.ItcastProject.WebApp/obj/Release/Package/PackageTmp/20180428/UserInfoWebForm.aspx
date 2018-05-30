<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoWebForm.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180428.UserInfoWebForm" %>

<%@ Import Namespace="CZBK.ItcastProject.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/tableStyle.css" rel="stylesheet" />
    <script src="../JS/jquery-1.7.1.min.js"></script>
    <script>
        function rowDelete(username, id) {
            id = parseInt(id);
            if (confirm("are you sure delete it:\u000d\u000d" + username)) {
                $(location).attr('href', 'UserDelete.ashx?id=' + id)
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="UserInfoAdd.aspx">Add User</a>
            <table>
                <tr>
                    <th>ID</th>
                    <th>UserNmae</th>
                    <th>UserPass</th>
                    <th>Email</th>
                    <th>RegTime</th>
                    <th>Detail</th>
                    <th>Delete</th>
                    <th>Edit</th>
                </tr>
                <%foreach (UserInfo userInfo in List)
                    {%>
                <tr>
                    <td><%=userInfo.ID %></td>
                    <td><%=userInfo.UserName %></td>
                    <td><%=userInfo.UserPass %></td>
                    <td><%=userInfo.Email %></td>
                    <td><%=userInfo.RegTime %></td>
                    <td><a href="UserDetailWebForm.aspx?ID=<%=userInfo.ID %>">Detail</a></td>
                    <td><a href="javascript:void(0)" onclick="rowDelete('<%=userInfo.UserName %>','<%=userInfo.ID %>')">Delete</a></td>
                    <td><a href="UserUpdate.aspx?id=<%=userInfo.ID %>">Update</a></td>
                </tr>
                <%}
                %>
            </table>
        </div>
    </form>
</body>
</html>
