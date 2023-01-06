<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="rmtest" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enterprise Login</title>
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
          <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">  
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
    <script type="text/javascript">
        $(document).ready(function () {
            $('#show_password').hover(function show() {
                //Change the attribute to text  
                $('#txtpassword').attr('type', 'text');
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            },
            function () {
                //Change the attribute back to password  
                $('#txtpassword').attr('type', 'password');
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
            });
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {
                $('#txtpassword').attr('type', $(this).is(':checked') ? 'text' : 'password');
            });
        });  
    </script>
</head>
<body class="body">
   
    <form id="sign_in" class="login-form" method="POST" runat="server">
        <section class="login-block">
    <div class="container">
	<div class="row">
		
		
        <div class="col-md-4 login-sec">
		    <h2 class="text-center">Login Now</h2>
		   
                
  <div class="form-group">
    <label for="exampleInputEmail1" class="text-uppercase">Username</label>
   <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Username" style="margin-left: 33px; width: 288px;" required autofocus></asp:TextBox>
     <div class="input-group">  
        <button  class="btn btn-primary" style="margin-top:-38px;" >  
            <span class="fa fa-user"></span>  
        </button>  
        </div>
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1" class="text-uppercase">Password</label>
    <asp:TextBox ID="txtpassword" runat="server"  class="form-control" placeholder="Password" required style="margin-left: 36px; width: 285px;" TextMode="Password" OnTextChanged="txtpassword_TextChanged"></asp:TextBox>
     <div class="input-group-append">  
        <button id="show_password" class="btn btn-primary" style="margin-top:-38px;" type="button">  
            <span class="fa fa-eye-slash icon"></span>  
        </button>  
        </div> 
  </div>
  
  
    <div class="form-check">
    <label class="form-check-label">
     <input type="checkbox" name="rememberme" id="rememberme" class="filled-in chk-col-pink">
                            <label for="rememberme">Remember Me</label>
    </label>
    <asp:Button ID="btnSave" runat="server" Text="SIGN IN" class="btn btn-primary float-right login_btn" OnClick="BtnSave_Click"/>
						<asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
  </div>
  <div class="form-group" style="margin-top:40px;">

        <a href="newForgotPass.aspx" style="folat:right;">Forgot Password?</a>
     
  </div>

<div class="copy-text">Powered By <a href="https://visionarylifescience.com"><b>Visionary LifeSciences Pvt Ltd</b></a>.&copy; 2021</div> 
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
