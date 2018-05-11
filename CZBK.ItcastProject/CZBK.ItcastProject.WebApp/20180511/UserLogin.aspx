<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180511.UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=GBK" />
    <title>网站管理后台登录
</title>
    <link href="./网站管理后台登录_files/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        <!--
        body {
            margin-top: 150px;
        }
        -->
    </style>
    <script type="text/jscript" src="../JS/jquery-1.7.1.min.js"></script>
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
            })
        })
    </script>
</head>
<body>
        <form name="form1" id="form1" runat="server">
        <div>
            <input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUKLTk5MTEyNDkyMmQYAQUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0tleV9fFgEFCGJ0bkxvZ2luDPRvv9LGLqiVqStAd5fp6Kr+5/0=" />
        </div>

        <div>

            <input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value="/wEWBQLemczKAwLd+/CSBQK1qbSRCwLChPzDDQKC3IeGDDY6Y328gLlSy6Sd5458JxEqkhYO" />
        </div>
        <div>
            <table width="549" height="287" border="0" align="center" cellpadding="0" cellspacing="0" background="./网站管理后台登录_files/login_bg.jpg">
                <tbody>
                    <tr>
                        <td width="23">
                            <img src="./网站管理后台登录_files/login_leftbg.jpg" width="23" height="287" /></td>
                        <td width="503" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tbody>
                                    <tr>
                                        <td width="49%" valign="bottom">
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td height="100" valign="top" class="login_text">
                                                            <div align="left">
                                                                网站后台管理系统
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div align="right">
                                                                <img src="./网站管理后台登录_files/login_img.jpg" width="104" height="113" /></div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td width="2%">
                                            <img src="./网站管理后台登录_files/login_line.jpg" width="6" height="287" /></td>
                                        <td width="49%">
                                            <div align="right">
                                                <table width="223" border="0" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <img src="./网站管理后台登录_files/login_tit.jpg" width="223" height="30" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="10" cellpadding="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td width="28%">
                                                                                <div align="left">用户名：</div>
                                                                            </td>
                                                                            <td width="72%">
                                                                                <div align="left">
                                                                                    <span class="style1">
                                                                                        <input name="txtUserName" type="text" id="txtUserName" class="form2" style="height: 15px; width: 140px;" />
                                                                                    </span>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div align="left">密&nbsp;&nbsp;码：</div>
                                                                            </td>
                                                                            <td>
                                                                                <div align="left">
                                                                                    <span class="style1">
                                                                                        <input name="txtUserPass" type="password" id="txtUserPass" class="form2" style="height: 15px; width: 140px;" /></span>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div align="left">验证码：</div>
                                                                            </td>
                                                                            <td>
                                                                                <div align="left">
                                                                                    <img id="captchaImage" src="captcha.ashx" style="border-width: 0px;" />&nbsp;<a href="javascript:void(0)" id="changeCaptcha">看不清</a>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div align="left">验证码：</div>
                                                                            </td>
                                                                            <td>
                                                                                <div align="left">
                                                                                    <span class="style1">
                                                                                        <input name="txtCode" type="text" size="8" id="txtCode" class="form2" style="height: 15px;" /></span>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <div align="center"><a href="http://www.800kb.com/ClientManager/#"></a></div>
                                                                            </td>
                                                                            <td>
                                                                                <div align="center">
                                                                                    <input type="image" name="btnLogin" id="btnLogin" src="./网站管理后台登录_files/login_menu2.jpg" style="border-width: 0px;" /><a href="http://www.800kb.com/ClientManager/#"></a>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <strong><span style="color: #3180b7">辽ICP备XXXXXXXX号</span></strong></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td width="23">
                            <img src="./网站管理后台登录_files/login_rigbg.jpg" width="23" height="287" /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>


</body>
</html>--%>

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
                        <input type="text" name="txtUserName" value="" /></th>
                </tr>
                <tr>
                    <th>密码</th>
                    <th>
                        <input type="password" name="txtUserPass" /></th>
                </tr>
                <tr>
                    <th>验证码</th>
                    <th>
                        <input type="text" name="captcha" /></th>
                </tr>
                <tr>
                    <th><a href="javascript:void(0)" id="changeCaptcha">看不清</a></th>
                    <td>
                        <img src="captcha.ashx" id="captchaImage" alt=""/><span style="font:14px;color:red;"><%=Msg %></span></td>
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
