<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPay.aspx.cs" Inherits="EmptyProjectNet45_FineUI.SearchPay" %>

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
        <asp:TextBox ID="month" runat="server" TextMode="Date" Height="34px" Width="300px" Font-Size="24px" CssClass="button textbox2" OnTextChanged="month_TextChanged" >2017-6-1</asp:TextBox>
                    &nbsp&nbsp<asp:Button ID="Search_But" runat="server" Text="搜索" Height="40px" Width="80px" Font-Size="24px" Font-Bold="true" Font-Names="微软雅黑" CssClass="button blue" OnClick="Search_But_Click" />
            </center>
    </div>
        <br />
    <div>
    <asp:GridView ID="GridView1" runat="server"  Caption="月绩效工资信息"  AutoGenerateColumns="False"   PageSize="4" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="False" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" > 
            <Columns>
                 <asp:BoundField DataField="Pterm" HeaderText="学期" SortExpression="Pterm" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Pmonth" HeaderText="月份" SortExpression="Pmonth" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Ptimes" HeaderText="课时补贴" SortExpression="Ptimes" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Pposition" HeaderText="职务补贴" SortExpression="Pposition" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Pmanager" HeaderText="班主任津贴" SortExpression="Pmanager" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Paward" HeaderText="获奖津贴" SortExpression="Paward" ItemStyle-HorizontalAlign="Center" >
 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Pabsent" HeaderText="请假扣除" SortExpression="Pabsent" ItemStyle-HorizontalAlign="Center" >
 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Paddelse" HeaderText="其他津贴" SortExpression="Paddelse" ItemStyle-HorizontalAlign="Center" >
 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Preduceelse" HeaderText="其他扣除" SortExpression="Preduceelse" ItemStyle-HorizontalAlign="Center" >
 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Pservice" HeaderText="后勤津贴" SortExpression="Pservice" ItemStyle-HorizontalAlign="Center" >
 
                
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
