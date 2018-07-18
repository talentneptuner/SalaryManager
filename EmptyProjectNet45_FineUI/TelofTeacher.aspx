<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelofTeacher.aspx.cs" Inherits="EmptyProjectNet45_FineUI.TelofTeacher" %>

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
        <asp:TextBox ID="txtName" runat="server" Height="34px" Width="300px" Font-Size="24px" CssClass="button textbox1" >请输入姓名</asp:TextBox>
        &nbsp&nbsp<asp:Button ID="Search_But" runat="server" Text="搜索" Height="40px" Width="80px" Font-Size="Large" Font-Bold="true" Font-Names="微软雅黑" OnClick="Search_But_Click" CssClass="button blue" />
            </center>
    </div>
        <br />
    <div>
    <asp:GridView ID="GridView2" runat="server"  Caption="通讯录"  AutoGenerateColumns="False"   PageSize="4" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="True" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" > 
            <Columns>
                 <asp:BoundField DataField="Tnum" HeaderText="编号" SortExpression="Tnum" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Tname" HeaderText="姓名" SortExpression="Tname" ItemStyle-HorizontalAlign="Center" >
                 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 
                <asp:BoundField DataField="Tphone" HeaderText="电话" SortExpression="Tphone" ItemStyle-HorizontalAlign="Center" >
                 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
            </Columns>               
            <RowStyle BackColor="#EFF3FB" />
            <AlternatingRowStyle BackColor="White" />        
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor=" #3487c3" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor=" #3487c3" Font-Bold="True" ForeColor="White" />         
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"  Font-Names="宋体" Font-Size="12px"  />
            <PagerSettings FirstPageText="首页" LastPageText="末页" 
            NextPageText="下一页" PageButtonCount="5" PreviousPageText="上一页" />          
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
       </asp:GridView>   
    </div>
    </form>
</body>
</html>
