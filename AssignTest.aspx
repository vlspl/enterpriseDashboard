<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="AssignTest.aspx.cs" Inherits="AssignTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Horizontal Layout -->
     <section class="content">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                 <div class="container-fluid">
                     <div class="row clearfix">
                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                             <div class="card">
                                 <div class="header">
                                     <h2>Assign Test
                                     </h2>

                                 </div>
                                 <div class="body">
                                     <form class="form-horizontal">

                                         <div class="row clearfix">
                                             <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                 <label for="password_2">Select Department</label>
                                             </div>
                                             <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                                 <div class="form-group">
                                                     <div class="form-line">
                                                         <asp:DropDownList ID="drpDept" runat="server" class="form-control"></asp:DropDownList>

                                                     </div>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="row clearfix">
                                             <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                 <label for="branch">Select Branch</label>
                                             </div>
                                             <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                                 <div class="form-group">
                                                     <div class="form-line">
                                                         <asp:DropDownList ID="drpBranch" runat="server" class="form-control"></asp:DropDownList>
                                                     </div>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="row clearfix">
                                             <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                 <label for="age">Age</label>
                                             </div>
                                             <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                                 <div class="form-group">
                                                     <div class="form-line">
                                                         <asp:TextBox ID="txtAge" runat="server" class="form-control" placeholder="Age"></asp:TextBox>
                                                     </div>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="row clearfix">
                                             <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                 <label for="emp">Select Employee</label>
                                             </div>
                                             <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                                 <div class="form-group">
                                                     <div class="form-line">
                                                         <asp:DropDownList ID="drpEmployee" runat="server" class="form-control"></asp:DropDownList>
                                                     </div>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="row clearfix">
                                             <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                 <label for="test">Select Test</label>
                                             </div>
                                             <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                                 <div class="form-group">
                                                     <div class="form-line">
                                                         <asp:DropDownList ID="drptest" runat="server" class="form-control"></asp:DropDownList>
                                                     </div>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="row clearfix">
                                             <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                 <label for="Period">Period</label>
                                             </div>
                                             <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                                 <div class="form-group">
                                                     <div class="form-line">
                                                         <asp:TextBox ID="txtPeriod" runat="server" class="form-control" placeholder="Period"></asp:TextBox>
                                                     </div>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="form-group">

                                             <div class="row clearfix">
                                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                     <center>
                                                         <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary  btn-lg m-l-15 waves-effect" data-type="basic" OnClick="BtnSave_Click" />
                                                     </center>
                                                 </div>
                                             </div>

                                         </div>
                                         <%-- <div class="row clearfix">
                                    <div class="col-lg-offset-2 col-md-offset-2 col-sm-offset-4 col-xs-offset-5">
                                        <button type="button" class="btn btn-primary m-t-15 waves-effect">Save</button>
                                    </div>
                                </div>--%>
                                     </form>
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>
             </ContentTemplate>
         </asp:UpdatePanel>
         </section>
            <!-- #END# Horizontal Layout -->
   <%-- <script src="js/pages/forms/advanced-form-elements.js"></script>--%>
</asp:Content>

