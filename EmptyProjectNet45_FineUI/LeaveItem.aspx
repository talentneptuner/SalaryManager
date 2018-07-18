<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveItem.aspx.cs" Inherits="EmptyProjectNet45_FineUI.LeaveItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/manycss.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="GridviewDisplay" runat="server"   Caption="请假信息"  AutoGenerateColumns="False"   PageSize="4" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="False" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" OnRowCommand="GridviewDisplay_RowCommand" > 
            <Columns>
                 <asp:BoundField DataField="Lnum" HeaderText="编号" SortExpression="Lnum" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Ltnum" HeaderText="申请人编号" SortExpression="Ltnum" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Lname" HeaderText="申请人姓名" SortExpression="Lname" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Ltime" HeaderText="时间" SortExpression="Ltime" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Llong" HeaderText="天数" SortExpression="Llong" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Lstate" HeaderText="状态" SortExpression="Lstate" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 
               
                 <asp:TemplateField FooterText="查看" HeaderText="查看">
                     <ItemTemplate>
                         <center><asp:Button ID="seek" OnClick="seek_Click" runat="server" Text="查看" CssClass="button blue" /></center></ItemTemplate>
                 </asp:TemplateField>
               
               
                 <asp:TemplateField HeaderText="操作"><ItemTemplate>
                     <asp:Button ID="agree" runat="server" Font-Size="15px" Text="同意" Width="50px" Height="30px" CssClass="button blue" OnClick="agree_Click" />&nbsp&nbsp<asp:Button ID="refuse" runat="server" Text="拒绝" Font-Bold="false" Font-Size="15px" Width="50px" Height="30px" CssClass="button blue" OnClick="refuse_Click" /></ItemTemplate></asp:TemplateField>
               
               
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
    </form>
</body>
</html>
