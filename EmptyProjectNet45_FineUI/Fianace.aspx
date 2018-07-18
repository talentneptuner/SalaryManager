<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fianace.aspx.cs" Inherits="EmptyProjectNet45_FineUI.Fianace" %>

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
        <asp:DropDownList ID="Way" runat="server" CssClass="button textbox1" Height="30px" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="Way_SelectedIndexChanged">
            <asp:ListItem>按月份查询</asp:ListItem>
            <asp:ListItem>按年级查询</asp:ListItem>
            <asp:ListItem>按教师类型查询</asp:ListItem>
            </asp:DropDownList>
            &nbsp&nbsp
        <asp:DropDownList ID="choose" runat="server" CssClass="button textbox1" Height="30px" Width="200px"></asp:DropDownList>
            &nbsp&nbsp
        <asp:Button ID="search" runat="server" Text="搜索" CssClass="button blue" Height="40px" Width="75px" Font-Size="20px" OnClick="search_Click"/>
            &nbsp&nbsp
            <asp:Button ID="export" runat="server" Text="导出" CssClass="button blue" Height="40px" Width="75px" Font-Size="20px" OnClick="export_Click"/>
            </center>
    </div>
        <br />
        <asp:GridView ID="GridViewDisplay" runat="server"  Caption="绩效信息"  AutoGenerateColumns="false"   PageSize="4"  
            AllowPaging="false" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="True" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt"  OnRowEditing="GridViewDisplay_RowEditing" OnRowUpdating="GridViewDisplay_RowUpdating" OnRowCancelingEdit="GridViewDisplay_RowCancelingEdit"> 
            <Columns>
                <asp:BoundField DataField="Tnum" HeaderText="职工号" ReadOnly="true" SortExpression="Tnum" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Tname" HeaderText="姓名" ReadOnly="true" SortExpression="Tname" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Pterm" HeaderText="学期" ReadOnly="true" SortExpression="Pterm" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Pmonth" HeaderText="月份" ReadOnly="true" SortExpression="Pmonth" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Ptimes" HeaderText="课时补贴" ReadOnly="true" SortExpression="Ptimes" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Pposition" HeaderText="职务补贴" ReadOnly="true" SortExpression="Pposition" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Pmanager" HeaderText="班主任津贴" ReadOnly="true" SortExpression="Pmanager" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="Paward" HeaderText="获奖津贴" SortExpression="Paward" ItemStyle-HorizontalAlign="Center" >
 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Pabsent" HeaderText="请假扣除" ReadOnly="true" SortExpression="Pabsent" ItemStyle-HorizontalAlign="Center" >
 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Paddelse" HeaderText="其他津贴" SortExpression="Paddelse" ItemStyle-HorizontalAlign="Center" >
 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Preduceelse" HeaderText="其他扣除" SortExpression="Preduceelse" ItemStyle-HorizontalAlign="Center" >
 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Pservice" HeaderText="后勤津贴" ReadOnly="true" SortExpression="Pservice" ItemStyle-HorizontalAlign="Center" >
 
                
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:BoundField>
                <asp:CommandField HeaderText="操作" ShowEditButton="True" ItemStyle-HorizontalAlign="Center"  />
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
