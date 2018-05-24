<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UseRepeater.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180524.UseRepeater" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<link href="../CSS/tableStyle.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr style="background-color:aquamarine">
                            <th>ID</th>
                            <th>UserNmae</th>
                            <th>UserPass</th>
                            <th>Email</th>
                            <th>RegTime</th>
                            <th>Detail</th>
                            <th>Delete</th>
                            <th>Edit</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: darkgray">
                        <td><%#Eval("ID") %></td>
                        <td><%#Eval("UserName") %></td>
                        <td><%#Eval("UserPass") %></td>
                        <td><%#Eval("Email") %></td>
                        <td><%#Eval("RegTime") %></td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: gray">
                        <td><%#Eval("ID") %></td>
                        <td><%#Eval("UserName") %></td>
                        <td><%#Eval("UserPass") %></td>
                        <td><%#Eval("Email") %></td>
                        <td><%#Eval("RegTime") %></td>
                    </tr>
                </AlternatingItemTemplate>
                <SeparatorTemplate>
                    <tr>
                        <td colspan="5">
                            <hr />
                        </td>
                    </tr>
                </SeparatorTemplate>
                <FooterTemplate>
                    <tr style="background-color:aquamarine">
                        <th>ID</th>
                        <th>UserNmae</th>
                        <th>UserPass</th>
                        <th>Email</th>
                        <th>RegTime</th>
                        <th>Detail</th>
                        <th>Delete</th>
                        <th>Edit</th>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
