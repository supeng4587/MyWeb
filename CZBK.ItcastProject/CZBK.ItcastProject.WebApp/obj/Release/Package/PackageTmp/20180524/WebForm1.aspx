<%@ Page Title="" Language="C#" MasterPageFile="~/20180524/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CZBK.ItcastProject.WebApp._20180524.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function show() {
            document.getElementById(<%=TextBox1.ClientID%>)
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    WebForm的TextBox<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</asp:Content>
