<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchWork.aspx.cs" Inherits="EmptyProjectNet45_FineUI.SearchWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server"  Caption="工作信息"  AutoGenerateColumns="False"   PageSize="4" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="False" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" > 
            <Columns>
                 <asp:BoundField DataField="Wterm" HeaderText="学期" SortExpression="Wterm" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Clgrade" HeaderText="年级" SortExpression="Clgrade" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Clno" HeaderText="班级" SortExpression="Clno" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Crname" HeaderText="科目" SortExpression="Crname" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Crtimes" HeaderText="课时" SortExpression="Crtimes" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Crself" HeaderText="自习时长" SortExpression="Crself" ItemStyle-HorizontalAlign="Center" >
 
                
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


        <asp:GridView ID="GridView2" runat="server"  Caption="工作信息"  AutoGenerateColumns="False"   PageSize="4" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="False" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" > 
            <Columns>
                 <asp:BoundField DataField="Wnterm" HeaderText="学期" SortExpression="Wnterm" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Wthing" HeaderText="职务" SortExpression="Wthing" ItemStyle-HorizontalAlign="Center" >
                 
                
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
