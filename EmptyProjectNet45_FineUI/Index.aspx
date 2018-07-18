<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EmptyProjectNet45_FineUI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="./Wopop_files/style_log.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" type="text/css" href="./Wopop_files/style.css"/>
<link rel="stylesheet" type="text/css" href="./Wopop_files/userpanel.css"/>
<link rel="stylesheet" type="text/css" href="./Wopop_files/jquery.ui.all.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div class="login_m">
<div class="login_logo"><img src="img/int.png" width="275" height="75"/></div>
<div class="login_boder">

<div class="login_padding" id="login_model">

  <h2>账号：</h2>
  <label>
      <asp:TextBox ID="Num" runat="server" CssClass="txt_input txt_input2"></asp:TextBox>
  </label>
  <h2>密码：</h2>
  <label>
    <asp:TextBox ID="Password" runat="server" CssClass="txt_input txt_input2" TextMode="Password"></asp:TextBox>
  </label>
 
 

 
  <div class="rem_sub">
  
    <label>
        <asp:Button ID="register" runat="server" Text="登录" CssClass="sub_button" OnClick="register_Click"/>
    </label>
  </div>
</div>

<div class="copyrights">Collect from <a href="Index.aspx" >湖北省xx中学</a></div>






<!--login_padding  Sign up end-->
</div><!--login_boder end-->
</div><!--login_m end-->
 <br/> <br/>



</form>
</body>
</html>
