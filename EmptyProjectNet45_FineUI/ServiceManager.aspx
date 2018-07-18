<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceManager.aspx.cs" Inherits="EmptyProjectNet45_FineUI.ServiceManager" %>

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
    <asp:GridView ID="GridViewDisplay" runat="server"  Caption="职工信息"  AutoGenerateColumns="false"   PageSize="4"  
            AllowPaging="false" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="True" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" OnRowDeleting="GridViewDisplay_RowDeleting" OnRowEditing="GridViewDisplay_RowEditing" OnRowUpdating="GridViewDisplay_RowUpdating" OnRowCancelingEdit="GridViewDisplay_RowCancelingEdit"> 
            <Columns>
                <asp:BoundField DataField="Wnum" HeaderText="职工编号" SortExpression="Wnum" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                <asp:BoundField DataField="Tname" HeaderText="姓名" SortExpression="Tname" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                 <asp:BoundField DataField="Wthing" HeaderText="工作" SortExpression="Wthing" ItemStyle-HorizontalAlign="Center"  />
                <asp:BoundField DataField="Wnterm" HeaderText="学期" SortExpression="Wnterm" ItemStyle-HorizontalAlign="Center" ReadOnly="true"/>
                
                <asp:CommandField HeaderText="操作" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
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
    </div>
        <br />
        <br />
        <div>
            <hr />
            <center>添加职务信息</center>
            <br />
             <center>
    职务：&nbsp<asp:textbox ID="workname" runat="server" CssClass="button textbox1" Width="200px" Height="30px"></asp:textbox>
                 <br /><br />
                
                 编号：&nbsp<asp:DropDownList ID="num" runat="server" CssClass="button textbox1" Width="200px" Height="34px" AutoPostBack="True" OnSelectedIndexChanged="num_SelectedIndexChanged"></asp:DropDownList>
                 <br /><br />
                 姓名：&nbsp<asp:Label ID="name" runat="server" Text="职工姓名" Width="200px" Height="34px"></asp:Label>
    <br /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
             <center><asp:Button ID="Add" 
        Height="50px" Width="85px"  BackColor="#3366ff"
        runat="server" Text="添加" 
        ForeColor="White" Font-Size="Larger" Font-Bold="true"
         CssClass="button blue" BorderStyle="None" title="添加" OnClick="Add_Click"  />
                 </center>
                 </center>
    <hr/></div>  
    </form>
</body>
</html>
