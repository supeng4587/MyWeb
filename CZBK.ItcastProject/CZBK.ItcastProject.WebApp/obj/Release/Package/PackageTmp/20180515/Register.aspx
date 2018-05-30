<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180515.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/tableStyle.css" rel="stylesheet" />
    <script type="text/javascript" src="../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        //window.onload = function () {
        //    var changeCaptcha = document.getElementById("changeCaptcha");
        //    changeCaptcha.onclick = function () {
        //        document.getElementById("captchaImage").src = "captcha.ashx?datetime=" + new Date().getMilliseconds();
        //    }
        //}

        $(function () {
            $("#changeCaptcha").click(function () {
                $("#captchaImage").attr("src", "captcha.ashx?datetime=" + new Date().getMilliseconds());
            })//验证码图片刷新

            $("#userName").blur(function () {
                $("#msgSpan").css("display", "none");
                var userName = $(this).val();
                if (userName != null) {
                    $.ajax({
                        type: "POST",
                        url: "CheckUserName.ashx",
                        data: "userName="+$(this).val(),
                        success: function (data) {
                            $("#msgSpan").css("display", "block");
                            $("#msgSpan").text(data);
                        }
                })
                } else {
                    $("#msgSpan").val("用户名不能为空");
                }                
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th>用户</th>
                    <th>
                        <input type="text" name="txtUserName" value="" id="userName"/><span style="font:14px;color:red;" id="msgSpan"></span></th>
                </tr>
                <tr>
                    <th>密码</th>
                    <th>
                        <input type="password" name="txtUserPass" /></th>
                </tr>
                <tr>
                    <th>验证码</th>
                    <th>
                        <input type="text" name="txtCode" /></th>
                </tr>
                <tr>
                    <th><a href="javascript:void(0)" id="changeCaptcha">看不清</a></th>
                    <td>
                        <img src="captcha.ashx" id="captchaImage" alt=""/><span style="font:14px;color:red;"><%=Msg %></span></td>
                </tr>
                <tr>
                    <th><input type="checkbox" name="autoLogin" value="auto"/></th>
                    <td>是否下次自动登陆</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <input type="submit" value="submit" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

