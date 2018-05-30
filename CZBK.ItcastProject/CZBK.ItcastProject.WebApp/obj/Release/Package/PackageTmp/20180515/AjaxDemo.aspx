<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDemo.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180515.AjaxDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            document.getElementById("btn").onclick = function () {
                var xhr = new XMLHttpRequest();
                if (XMLHttpRequest) {//成立表示用户使用的是高版本浏览器、不成立表示使用的是IE低版本浏览器
                    xhr = new XMLHttpRequest();
                } else {//现在基本上不用了
                    xhr = new ActiveXObject("Microsoft.XMLHTTP");//加上了这个jb玩意儿以后IDE不明确xhr是否能明确的创建出来，所以后续的提示都没了
                }
                xhr.open("get", "GetDate.ashx?name=zhangsan&pwd=123", true);
                xhr.send();
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
            <input type="button" name="btnSubmit" id="btn" value="普通Button提交" />
        </div>
    </form>
</body>
</html>
