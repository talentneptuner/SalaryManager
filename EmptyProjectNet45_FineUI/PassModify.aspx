<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassModify.aspx.cs" Inherits="EmptyProjectNet45_FineUI.PassModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/manycss.css" type="text/css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <br />
        原密码：<asp:TextBox ID="oldpass" runat="server" Width="200px" Height="35px" CssClass="button textbox1" AutoCompleteType="Disabled"></asp:TextBox>
        <br />
        <br />
        新密码：<asp:TextBox ID="newpass" runat="server" Width="200px" Height="35px" CssClass="button textbox1" AutoCompleteType="Disabled"></asp:TextBox>
    </center>
        <br />
        <br />
        <center>
        <asp:Button ID="modify" runat="server" Text="修改" Width="100px" Height="36px" CssClass="button blue" OnClick="modify_Click" /></center>
    </div>
    </form>
</body>
</html>
