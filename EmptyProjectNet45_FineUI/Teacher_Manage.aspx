<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Manage.aspx.cs" Inherits="EmptyProjectNet45_FineUI.Teacher_Manage" %>

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
    <asp:TextBox ID="keyname" runat="server" CssClass="button textbox1" Text="请输入姓名或者编号" Width="300px" Height="35px"></asp:TextBox>
        &nbsp&nbsp
        <asp:Button ID="search" runat="server" Text="搜索" CssClass="button blue" Height="40px" Width="75px" Font-Size="20px" OnClick="search_Click" OnClientClick="return confirm('确认要吗？');"/>
    </center>

    </div>
        <asp:GridView ID="GridViewDisplay" runat="server"  Caption="教师信息"  AutoGenerateColumns="false"   PageSize="4"  
            AllowPaging="false" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="20px" Width="100%" Visible="True" CssClass="mGrid" PagerStyle-CssClass="pgr"    
    AlternatingRowStyle-CssClass="alt" OnRowDeleting="GridViewDisplay_RowDeleting" OnRowEditing="GridViewDisplay_RowEditing" OnRowUpdating="GridViewDisplay_RowUpdating" OnRowCancelingEdit="GridViewDisplay_RowCancelingEdit"> 
            <Columns>
                <asp:BoundField DataField="Tnum" HeaderText="职工编号" SortExpression="Tnum" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                <asp:BoundField DataField="Tname" HeaderText="姓名" SortExpression="Tname" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                 <asp:BoundField DataField="Tposition" HeaderText="工作" SortExpression="Tposition" ItemStyle-HorizontalAlign="Center"  />
                <asp:BoundField DataField="Tisgrade" HeaderText="年级主任" SortExpression="Tisgrade" ItemStyle-HorizontalAlign="Center" />
                
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="删除" OnClientClick="JavaScript:return confirm('真的要删除吗？');" ForeColor="Black"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
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
