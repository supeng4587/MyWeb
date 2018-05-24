<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataList.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180524.DataList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetList" TypeName="CZBK.ItcastProject.BLL.UserInfoService"></asp:ObjectDataSource>
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="UserPass" HeaderText="UserPass" SortExpression="UserPass" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="RegTime" HeaderText="RegTime" SortExpression="RegTime" />
            </Columns>
        </asp:GridView>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        <hr />
        <select name="UserInfoList">
            <%=Str %>
        </select>
    </form>
</body>
</html>
