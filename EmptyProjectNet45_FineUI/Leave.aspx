<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="EmptyProjectNet45_FineUI.Leave" %>

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
        <br />
        每天只能提交一次
        <br />
        <br />
        开始时间：&nbsp<asp:TextBox ID="applyday" runat="server" Width="200px" Height="40px" CssClass="button textbox2" TextMode="Date"></asp:TextBox>
        <br /><br />
        请假天数：&nbsp<asp:TextBox ID="applylong" runat="server" Width="200px" Height="40px" CssClass="button textboxNum" TextMode="Number"></asp:TextBox>
        <br /><br />
        请假理由：&nbsp<asp:TextBox ID="applyreason" runat="server" Width="200px" Height="40px" CssClass="button textbox2" TextMode="DateTime"  ></asp:TextBox>
    </center>
        <center>
            <br />
          <asp:Button ID="Deliver" runat="server" Text="提交" Width="75px" Height="36px" CssClass="button blue" OnClick="Deliver_Click"></asp:Button>
        </center>
    </div>
        <br />
        <br />
        <asp:GridView ID="GridviewDisplay" runat="server"   Caption="请假信息"  AutoGenerateColumns="False"   PageSize="4" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="False" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" > 
            <Columns>
                 <asp:BoundField DataField="Lnum" HeaderText="编号" SortExpression="Lnum" ItemStyle-HorizontalAlign="Center"  >
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
                <asp:BoundField DataField="Ldeal" HeaderText="处理者" SortExpression="Ldeal" ItemStyle-HorizontalAlign="Center" >
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
    </form>
</body>
</html>
