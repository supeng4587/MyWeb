﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUserInfoDetail.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180528.ShowUserInfoDetail" %>
<%@ OutputCache Duration="10" VaryByParam="*" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px"></asp:DetailsView>
        </div>
    </form>
</body>
</html>
