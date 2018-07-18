<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseManager.aspx.cs" Inherits="EmptyProjectNet45_FineUI.ChooseManager"  %>

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
        <center>
        <asp:DropDownList ID="Class" runat="server" Width="200px" Height="34px" Font-Size="25px" CssClass="button textbox1" AutoPostBack="True" OnSelectedIndexChanged="Class_SelectedIndexChanged"></asp:DropDownList>
        &nbsp&nbsp
            <asp:DropDownList ID="Teacher" runat="server" Width="200px" Height="34px" Font-Size="25px" CssClass="button textbox1"></asp:DropDownList>
        <asp:Button ID="Change" runat="server" Text="确定" Width="60px" Height="34px" CssClass="button blue" OnClick="Change_Click" />
            </center>
    </div>
         <div>
            <hr />
            <center>添加教课信息</center>
            <br />
             <center>
    班级：&nbsp&nbsp&nbsp&nbsp<asp:DropDownList ID="Classname" runat="server" CssClass="button textbox1" Width="200px" Height="30px"></asp:DropDownList>
                 <br /><br />
                 科目：&nbsp&nbsp&nbsp&nbsp <asp:DropDownList ID="Crousename" runat="server" CssClass="button textbox1" Width="200px" Height="30px"></asp:DropDownList>
                 <br /><br />
                 教师编号：&nbsp<asp:DropDownList ID="Teachernum" runat="server" CssClass="button textbox1" Width="200px" Height="30px" AutoPostBack="True" OnSelectedIndexChanged="Teachernum_SelectedIndexChanged"></asp:DropDownList>
                 <br /><br />
                 教师姓名：&nbsp<asp:Label ID="Teachername" runat="server" Text="教师姓名" Width="200px" Height="30px"></asp:Label>
    <br /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
             <center><asp:Button ID="Add" 
        Height="50px" Width="85px"  BackColor="#3366ff"
        runat="server" Text="添加" 
        ForeColor="White" Font-Size="Larger" Font-Bold="true"
         CssClass="button blue" BorderStyle="None" title="添加书目" OnClick="Add_Click"  />
                 </center>
                 </center>
    <hr/></div>  
    </form>
</body>
</html>
