<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="LabMaster.aspx.cs" Inherits="LabMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">  
    
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script type="text/javascript">
          $(document).ready(function () {
              $('#show_password').hover(function show() {
                  //Change the attribute to text  
                  $('#txtConpassword').attr('type', 'text');
                  $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
              },
                  function () {
                      //Change the attribute back to password  
                      $('#txtConpassword').attr('type', 'password');
                      $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
                  });
              //CheckBox Show Password  
              $('#show_password').click(function () {
                  $('#txtConpassword').attr('type', $(this).is(':checked') ? 'text' : 'password');
              });
          });
      </script>  
<script>
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}
</script>
    <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="block-header">

                        <!--<h2>FORM EXAMPLES</h2>-->
                    </div>
                    <!-- Inline Layout | With Floating Label -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Lab Master</h2>
                                    <!--<small>With floating label</small>-->

                                    <%--  <div style="float:right">
                                        <asp:Button ID="Button1" runat="server" Text="Add New Branch" class="btn bg-purple waves-effect"/>

                                    </div>--%>
                                </div>
                                <div class="body" id="branch">
                                    <form>
                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group ">
                                                    <div class="form-line">
                                                        <%--  <b> <asp:Label ID="Label7" runat="server" Text="Lab Name" Font-Size="Large"></asp:Label></b>
                                                    <asp:TextBox ID="txtId" runat="server" class="form-control" placeholder=""></asp:TextBo--%>
                                                       <asp:Label ID="Label1" runat="server">Lab Name<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtLName" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                    </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLName" ErrorMessage="Please enter Lab Name" ForeColor="Red" ValidationGroup="onlyForSave"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label2" runat="server" >Lab Owner<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtLOwner" runat="server" class="form-control" placeholder=""></asp:TextBox>



                                                    </div>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLOwner" ErrorMessage="Please enter Lab Owner Name" ForeColor="Red" ValidationGroup="onlyForSave"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>

                                        </div>
                                        <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label3" runat="server" >Email ID<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtemailId" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtemailId" ErrorMessage="Please enter Email ID" ForeColor="Red" ValidationGroup="onlyForSave"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                         <asp:Label ID="Label4" runat="server" >Contact Number<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtcontactNo" runat="server" MaxLength="10" onkeypress="return isNumber(event)" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcontactNo" ErrorMessage="Please enter Contact No" ForeColor="Red" ValidationGroup="onlyForSave"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                          </div>
                                          <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group ">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label5" runat="server">Address<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtaddress"  Style=" resize: none;" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                    </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtaddress" ErrorMessage="Please enter Address" ForeColor="Red" ValidationGroup="onlyForSave"></asp:RequiredFieldValidator>
                                                </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                 <div class="form-group ">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label9" runat="server" Text="Latitude"></asp:Label>
                                                            <asp:TextBox ID="txtlatitude" runat="server" Style="margin-left: 15px;" class="form-control" placeholder=""></asp:TextBox>

                                                    </div>
                                                </div>
                                                  <%-- <div class="form-group ">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label10" runat="server" Text="Status"></asp:Label>
                                                             <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Pending Approval</asp:ListItem>
                                                            <asp:ListItem>Deactive</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>--%>
                                            </div>
                                               </div>
                                       
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6" style="display:none">
                                                    <div  class="form-group">
                                                        <div class="form-line" display:"none">
                                                             <asp:Label ID="Label6" runat="server" Text="User Name" Visible="false"></asp:Label>
                                                            <asp:TextBox ID="txtUaerName" runat="server" class="form-control" placeholder="" Visible="false"></asp:TextBox>
                                                        </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUaerName" ErrorMessage="Please enter User Name" ForeColor="Red" ValidationGroup="onlyForSave"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="form-line" display:"none">
                                                            <asp:Label ID="Label7" runat="server" Text="Password" Visible="false"></asp:Label>
                                                            <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" class="form-control" Visible="false" placeholder=""></asp:TextBox>
                                                           
                                                        </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpassword" ErrorMessage="Please enter Password" ForeColor="Red" ValidationGroup="onlyForSave"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="form-line" display:"none">
                                                            <asp:Label ID="Label8" runat="server" Text="Confirm Password" Visible="false"></asp:Label>
                                                            <asp:TextBox ID="txtConpassword" TextMode="Password" runat="server" class="form-control" Visible="false" placeholder=""  Display="Dynamic"></asp:TextBox>
                                                            <%--<asp:CheckBox ID="CheckBox1"  onchange="document.getElementById('<%=((TextBox)txtConpassword.FindControl("txtConpassword")).ClientID %>').type = this.checked ? 'text' : 'password' runat="server" />
                                                       <input type="checkbox"" /> Show password--%>
                                                            <%-- <div class="input-group-append">
                                                          <button id="show_password" class="btn btn-primary" style="margin-top:-38px; float:right;" type="button">  
                                                                  <span class="fa fa-eye-slash icon"></span>  
                                                              </button>  
                                                        </div>--%>
                                                        </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConpassword" ErrorMessage="Please enter Confirm Password" ForeColor="Red" ValidationGroup="onlyForSave"></asp:RequiredFieldValidator>
                                                        </div>
                                                   <asp:CompareValidator ID="CompareValidator1" runat="server"  ControlToCompare="txtpassword" ControlToValidate="txtConpassword"    ErrorMessage="Password does not match." ForeColor="Red" ValidationGroup="onlyForSave"></asp:CompareValidator>
                                                    <%--<asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtbranchName" ErrorMessage="Please enter Branch" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                </div>
                                               


                                                <%--<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                       
                                                       <asp:TextBox ID="txtaddress" TextMode="MultiLine" style="height:150px; resize:none;" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                                                      
                                                        </div> 
                                                   </div>
                                               </div>--%>

                                                <div style="clear: both;"></div>
                                       
                                         <div class="row clearfix">
                                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <div>

                                                      <center> <asp:Button ID="btnregister" runat="server" Text="Submit Request" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="btnregister_Click" ValidationGroup="onlyForSave"/> </center>
                                                      <center> <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="btnClose_Click"/> </center>

                                                    </div>
                                                </div>
                                             </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- #END# Inline Layout | With Floating Label -->

                </div>
  <div class="loading" align="center">
    Loading. Please wait.
      <img src="../images/waiting.gif" />
</div>
<style type="text/css">
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid Red;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
</style>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });
</script>









            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>

