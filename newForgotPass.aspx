<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newForgotPass.aspx.cs" Inherits="newForgotPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <style>
@import url("//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css");
.login-block{
    background: #96c8eb;  /* fallback for old browsers */

float:left;
width:100%;
padding : 30px 0;
}
.body{
    overflow-y: hidden;
}
.banner-sec{background:url(images/bg7.png)  no-repeat left bottom; background-size:cover;  min-height:607px;  border-radius: 0 10px 10px 0; padding:0;}
.container{background:#fff; border-radius: 10px; box-shadow:15px 20px 0px rgba(0,0,0,0.1);}
.carousel-inner{border-radius:0 10px 10px 0;}
.carousel-caption{text-align:left; left:5%;}
.login-sec{padding: 50px 30px; position:relative;}
.login-sec .copy-text{position:absolute; width:80%; bottom:20px; font-size:13px; text-align:center;}
.login-sec .copy-text i{color:#FEB58A;}
.login-sec .copy-text a{color:#E36262;}
.login-sec h2{margin-bottom:30px; font-weight:800; font-size:30px; color: #DE6262;}
.login-sec h2:after{content:" "; width:100px; height:5px; background:#FEB58A; display:block; margin-top:20px; border-radius:3px; margin-left:auto;margin-right:auto}
.btn-login{background: #DE6262; color:#fff; font-weight:600;}
.banner-text{width:70%; position:absolute; bottom:40px; padding-left:20px;}
.banner-text h2{color:#fff; font-weight:600;}
.banner-text h2:after{content:" "; width:100px; height:5px; background:#FFF; display:block; margin-top:20px; border-radius:3px;}
.banner-text p{color:#fff;}

    </style>
</head>
<body class="body">
   
    <form id="sign_in" class="login-form" method="POST" runat="server">
        <section class="login-block">
    <div class="container">
	<div class="row">
		
		
        <div class="col-md-4 login-sec">
		    <h2 class="text-center">Forgot Password</h2>
		   
                
  <div class="form-group">
  <label>Enter your email address that you used to register. We'll send you an email with your username and a
                        link to reset your password.</label>
    
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1" class="text-uppercase">Email ID</label>
    <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
  </div>
  
  
    <div class="form-check">
    
     <asp:Button ID="btnForgotPwd" runat="server" Text="RESET MY PASSWORD" class="btn btn-secondary btn-block btn-lg bg-pink waves-effect" OnClick="btnForgotPwd_Click" />
  </div>
  <div class="form-group" style="margin-top:40px;">

        <asp:Label ID="lbl_msg" runat="server" Text="Label" Visible="false"></asp:Label><br /><br />
       <a style="text-align:center;" href="Login.aspx">Sign In !</a>
     
  </div>

<div class="copy-text">Created with <a href="https://howzu.co.in/">Visinary LifeSciences Pvt Ltd</a></div>
		</div>
        <div class="col-md-8 banner-sec">
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                
            <div class="carousel-inner" role="listbox">
    <div class="carousel-item active">
    
    </div>
   
            </div>	   
		    
		</div>
	</div>
</div>
</section>
    </form>
</body>
</html>

