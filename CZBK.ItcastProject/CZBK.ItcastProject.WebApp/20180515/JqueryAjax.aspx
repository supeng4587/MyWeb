<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JqueryAjax.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180515.JqueryAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnGet").click(function () {
                $.get("GetDate.ashx", { "name": "lisi", "pwd": "123" }, function (data) { alert(data) });
            })
            $("#btnPost").click(function () {
                $.post("GetDate.ashx", { "name": "zhangsanPost", "pwd": "123456" }, function (data) { alert(data) });
            })
            $("#btnAjax").click(function () {
                $.ajax({
                    url: "GetDate.ashx",
                    type: "POST",
                    data: "name=Ajax&pwd=456",
                    success: function (data) {
                        alert(data);
                    }
                });
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="Get获取数据" id="btnGet" />
            <input type="button" value="Post获取数据" id="btnPost" />
            <input type="button" value="Ajax获取数据" id="btnAjax" />
        </div>
    </form>
</body>
</html>
