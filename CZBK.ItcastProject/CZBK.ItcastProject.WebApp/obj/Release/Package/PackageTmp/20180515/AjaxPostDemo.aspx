<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxPostDemo.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180515.AjaxPostDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        window.onload = function () {
            document.getElementById("btnPost").onclick = function () {
                var xhr = new XMLHttpRequest();

                xhr.open("post","GetDate.ashx",true);
                xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                xhr.send("name=lisi&pwd=123456");
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4) {
                        if (xhr.status == 200) {
                            alert(xhr.responseText);
                        }
                    }
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" name="btnAjaxPost" id="btnPost" value="获取Post数据" />
        </div>
    </form>
</body>
</html>
