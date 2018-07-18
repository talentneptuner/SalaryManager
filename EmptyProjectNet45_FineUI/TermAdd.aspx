<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TermAdd.aspx.cs" Inherits="EmptyProjectNet45_FineUI.TermAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/manycss.css" type="text/css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <center>
        <asp:DropDownList ID="former" runat="server" CssClass="button textbox1" Width="150px" Height="34px">
            <asp:ListItem>2015</asp:ListItem>
            <asp:ListItem>2016</asp:ListItem>
            <asp:ListItem>2017</asp:ListItem>
            <asp:ListItem>2018</asp:ListItem>
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
            </asp:DropDownList>
        <asp:DropDownList ID="later" runat="server" CssClass="button textbox1" Width="150px" Height="34px">
            <asp:ListItem>2016</asp:ListItem>
            <asp:ListItem>2017</asp:ListItem>
            <asp:ListItem>2018</asp:ListItem>
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
            <asp:ListItem>2021</asp:ListItem>
            </asp:DropDownList>
        <asp:DropDownList ID="type" runat="server" CssClass="button textbox1" Width="150px" Height="34px">
            <asp:ListItem Value="1">上</asp:ListItem>
            <asp:ListItem Value="2">下</asp:ListItem>
            </asp:DropDownList>
            </center>
        <br /><br />
        <center>
            开始日期：&nbsp<asp:TextBox ID="begin" runat="server" CssClass="button textbox1" Width="150px" Height="34px" TextMode="Date"></asp:TextBox>
            &nbsp&nbsp
            结束日期：&nbsp<asp:TextBox ID="end" runat="server" CssClass="button textbox1" Width="150px" Height="34px" TextMode="Date"></asp:TextBox>
        </center>
        <br />
        <br />
        <center>
        <asp:Button ID="Open_Term" runat="server" Text="开始学期" CssClass="button blue" Width="125px" Height="62px" OnClick="Open_Term_Click" />
        &nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="Close_Term" runat="server" Text="结束学期" CssClass="button blue" Width="125px" Height="62px" OnClick="Close_Term_Click" />
           </center>

        <br />
        <center>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </center>
    </div>
    </form>
    <p>
&nbsp;</p>
</body>
</html>
