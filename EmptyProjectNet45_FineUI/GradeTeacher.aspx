<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeTeacher.aspx.cs" Inherits="EmptyProjectNet45_FineUI.GradeTeacher" %>

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
                   <asp:Label ID="idea" runat="server" Text="*如果要调换的，需要删除原有数据，重新添加*" Font-Size="20px" ForeColor="#ff0000" Font-Bold="true" Font-Names="微软雅黑"></asp:Label>
            </center>
        </div>
    <div>
    <asp:GridView ID="GridViewDisplay" runat="server"  Caption="本年级教师信息"  AutoGenerateColumns="false"   PageSize="4"  
            AllowPaging="false" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="False" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" OnRowDeleting="GridViewDisplay_RowDeleting"> 
            <Columns>
                <asp:BoundField DataField="Clnum" HeaderText="班级编号" SortExpression="Clnum" ItemStyle-HorizontalAlign="Center"  />
                <asp:BoundField DataField="Clno" HeaderText="班级名" SortExpression="Clno" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="Tnum" HeaderText="教师编号" SortExpression="Tnum" ItemStyle-HorizontalAlign="Center"  />
                <asp:BoundField DataField="Tname" HeaderText="教师名" SortExpression="Tname" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Crnum" HeaderText="课程编号" SortExpression="Crnum" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Crname" HeaderText="课程名" SortExpression="Crname" ItemStyle-HorizontalAlign="Center" />
                <asp:CommandField HeaderText="操作" ShowDeleteButton="True" />
                
            </Columns>               
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />        
            <FooterStyle BackColor="#3487c3" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#3487c3" Font-Bold="True" ForeColor="White" />         
           <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  Font-Names="宋体" Font-Size="12px"  />
            <PagerSettings FirstPageText="首页" LastPageText="末页" 
            NextPageText="下一页" PageButtonCount="5" PreviousPageText="上一页" />          
       </asp:GridView>  
    </div>
    </form>
</body>
</html>
