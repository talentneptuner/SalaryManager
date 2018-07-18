<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherManager2.aspx.cs" Inherits="EmptyProjectNet45_FineUI.TeacherManager2" %>

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
    
    </div>
    <div>
        <hr />
            <center>添加教师</center>
            <br />
             <center>
                 编号：&nbsp<asp:textbox ID="add_ID" runat="server" CssClass="button textbox1" Width="200px" Height="30px"></asp:textbox>
                 <br /><br />
                
                 姓名：&nbsp<asp:textbox ID="add_name" runat="server" CssClass="button textbox1" Width="200px" Height="34px" AutoPostBack="True"></asp:textbox>
                 <br /><br />
                 电话：&nbsp<asp:textbox ID="add_phone" runat="server" CssClass="button textbox1" Width="200px" Height="34px" AutoPostBack="True"></asp:textbox>
                 &nbsp&nbsp
                 职务：&nbsp<asp:DropDownList ID="add_position" CssClass="button textbox1" runat="server"  Width="200px" Height="34px">
                     <asp:ListItem>教师</asp:ListItem>
                     <asp:ListItem>后勤</asp:ListItem>
                 </asp:DropDownList>
    <br /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
             <center><asp:Button ID="Add" Height="50px" Width="85px"  BackColor="#3366ff" runat="server" Text="添加" ForeColor="White" Font-Size="Larger" Font-Bold="true" CssClass="button blue" BorderStyle="None" title="添加" OnClick="Add_Click"  />
                 </center>
                 </center>
    <hr/>
    </div>
        <div>
        <hr />
            <center>添加班级</center>
            <br />
             <center>
                 编号：&nbsp<asp:textbox ID="add_classnum" runat="server" CssClass="button textbox1" Width="200px" Height="30px"></asp:textbox>
                 <br /><br />
                
                 班号：&nbsp<asp:textbox ID="add_classno" runat="server" CssClass="button textbox1" Width="200px" Height="34px" AutoPostBack="True"></asp:textbox>
                 <br /><br />
                 年级：&nbsp<asp:DropDownList ID="add_grade" CssClass="button textbox1" runat="server"  Width="200px" Height="34px">
                     <asp:ListItem>七年级</asp:ListItem>
                     <asp:ListItem>八年级</asp:ListItem>
                     <asp:ListItem>九年级</asp:ListItem>
                 </asp:DropDownList>
    <br /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
             <center><asp:Button ID="add_class" Height="50px" Width="85px"  BackColor="#3366ff" runat="server" Text="添加" ForeColor="White" Font-Size="Larger" Font-Bold="true" CssClass="button blue" BorderStyle="None" title="添加" OnClick="add_class_Click"  />
                 </center>
                 </center>
    <hr/>
    </div>
        <asp:GridView ID="GridViewDisplay" runat="server"  Caption="班级信息"  AutoGenerateColumns="false"   PageSize="4"  
            AllowPaging="false" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="True" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" OnRowDeleting="GridViewDisplay_RowDeleting"> 
            <Columns>
                <asp:BoundField DataField="Clnum" HeaderText="班级编号" SortExpression="Clnum" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                <asp:BoundField DataField="Clgrade" HeaderText="年级" SortExpression="Clgrade" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                 <asp:BoundField DataField="Clno" HeaderText="班号" SortExpression="Clno" ItemStyle-HorizontalAlign="Center"  />
                <asp:BoundField DataField="Clmanager" HeaderText="班主任编号" SortExpression="Clmanager" ItemStyle-HorizontalAlign="Center" ReadOnly="true"/>
                <asp:BoundField DataField="Tname" HeaderText="班主任" SortExpression="Tname" ItemStyle-HorizontalAlign="Center" ReadOnly="true"/>
                
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="删除" OnClientClick="JavaScript:return confirm('真的要删除吗？');" ForeColor="Black"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>               
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />        
            <FooterStyle BackColor="#3487c3" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#3487c3" Font-Bold="True" ForeColor="White" />         
           <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  Font-Names="宋体" Font-Size="12px"  />
            <PagerSettings FirstPageText="首页" LastPageText="末页" 
            NextPageText="下一页" PageButtonCount="5" PreviousPageText="上一页" />          
       </asp:GridView>  
    </form>
</body>
</html>
