<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OldLogin.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>Sign In | Bootstrap Based Admin Template - Material Design</title>
    <!-- Favicon-->
    <link rel="icon" href="../../favicon.ico" type="image/x-icon">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css">

    <!-- Bootstrap Core Css -->
    <link href="../../plugins/bootstrap/css/bootstrap.css" rel="stylesheet">

    <!-- Waves Effect Css -->
    <link href="../../plugins/node-waves/waves.css" rel="stylesheet" />

    <!-- Animation Css -->
    <link href="../../plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="../../css/style.css" rel="stylesheet"/>
    <style>
        html, body {
            background-image: url('images/bg6.png');
            background-size: cover;
            background-repeat: no-repeat;
            height: 100%;
            font-family: 'Numans', sans-serif;
        }
        </style>
</head>
<body class="login-page">
    <div class="login-box">
        <div class="logo">
            <a href="javascript:void(0);">Howzu Connect</a>
            
        </div>
        <div class="card">
            <div class="body">
                <form id="sign_in" method="POST" runat="server">
                    <div class="msg">Sign in to start your session</div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">person</i>
                        </span>
                        <div class="form-line">
<%--                            <input type="text" class="form-control" name="username" placeholder="Username" required autofocus>--%>
                            <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Username" required autofocus></asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
<%--                            <input type="password" class="form-control" name="password" placeholder="Password" required>--%>
                            <asp:TextBox ID="txtpassword" runat="server"  class="form-control" placeholder="Password" required TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-8 p-t-5">
                            <input type="checkbox" name="rememberme" id="rememberme" class="filled-in chk-col-pink">
                            <label for="rememberme">Remember Me</label>
                        </div>
                        <div class="col-xs-4">
<%--                          <button class="btn btn-block bg-pink waves-effect" type="submit">SIGN IN</button>--%>
                            <asp:Button ID="btnSave" runat="server" Text="SIGN IN" class="btn btn-block bg-pink waves-effect" OnClick="BtnSave_Click"/>
                        </div>
                    </div>
                    <div class="row m-t-15 m-b--20">
                      <%--  <div class="col-xs-6">
                            <a href="sign-up.html">Register Now!</a>
                        </div>--%>
                        <div class="col-xs-12 align-right">
                            <a href="ForgotPassword.aspx">Forgot Password?</a>
                           
                        </div>
                         <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <!-- Jquery Core Js -->
    <script src="../../plugins/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core Js -->
    <script src="../../plugins/bootstrap/js/bootstrap.js"></script>

    <!-- Waves Effect Plugin Js -->
    <script src="../../plugins/node-waves/waves.js"></script>

    <!-- Validation Plugin Js -->
    <script src="../../plugins/jquery-validation/jquery.validate.js"></script>

    <!-- Custom Js -->
    <script src="../../js/admin.js"></script>
    <script src="../../js/pages/examples/sign-in.js"></script>
</body>
</html>
