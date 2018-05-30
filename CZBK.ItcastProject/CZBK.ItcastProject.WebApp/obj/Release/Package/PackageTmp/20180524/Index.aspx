<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180524.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        //function show() {//在套用母版页的时候ID和htmlid将会不一致，所以不能这么用
        //    document.getElementById("Button1");
        //}

    </script>
    <style type="text/css">
        .txt {
            font-size: 20px;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:TextBox ID="TextBox1" runat="server" Height="98px" OnTextChanged="ClickTextChange" TextMode="MultiLine" Width="185px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="txt" />
            <asp:Label ID="Label1" runat="server" Text="Label" AssociatedControlID="TextBox1">aaaa</asp:Label>--%>
        </div>
        <%--<asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" AutoPostBack="true"></asp:TextBox>--%>
        <%--<hr />
        男<asp:RadioButton ID="RadioButton1" runat="server" GroupName="sex" />
        女<asp:RadioButton ID="RadioButton2" runat="server" GroupName="sex" />--%>

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"  OnClientClick="alert('ssss')" />

        <asp:Panel ID="Panel1" runat="server" GroupingText="aaa" BackColor="#0099ff" Font-Size="Large" >fasdfdsa</asp:Panel>
        <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button2" runat="server" Text="上传" OnClick="Button2_Click" />

        <input type="text" runat="server" id="txt1" />

    </form>
</body>
</html>
