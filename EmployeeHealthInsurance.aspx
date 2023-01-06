<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeHealthInsurance.aspx.cs" Inherits="EmployeeHealthInsurance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <!-- Horizontal Layout -->
     <section class="content">
      <div class="container-fluid">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                               Employee Health Insurance
                            </h2>
                            
                        </div>
                        <div class="body">
                            <form class="form-horizontal">
                               <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtPolicy" ErrorMessage="Please enter Policy name" ForeColor="Red"></asp:RequiredFieldValidator>  
                                <div class="row clearfix">
                                    <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                        <label for="email_address_2">Policy Name</label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:TextBox ID="txtPolicy" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row clearfix">
<%--                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDept" ErrorMessage="Please Select Department" ForeColor="Red"></asp:RequiredFieldValidator>  --%>
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
<%--                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpBranch" ErrorMessage="Please Select Branch" ForeColor="Red"></asp:RequiredFieldValidator>  --%>
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
<%--                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpState" ErrorMessage="Please select State" ForeColor="Red"></asp:RequiredFieldValidator>  --%>
                                    <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                        <label for="State">Select State</label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:DropDownList ID="drpState" runat="server" class="form-control">
                                                     <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>Maharashtra</asp:ListItem>
                                                    <asp:ListItem>Gujrat</asp:ListItem>
                                                     <asp:ListItem>Aasam</asp:ListItem>
                                                    <asp:ListItem>Bihar</asp:ListItem>
                                                    <asp:ListItem>Bengal</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 <div class="row clearfix">
                               <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpCity" ErrorMessage="Please Select City" ForeColor="Red"></asp:RequiredFieldValidator>--%>  
                                    <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                        <label for="City">Select City</label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:DropDownList ID="drpCity" runat="server" class="form-control"></asp:DropDownList>
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
                                                <asp:TextBox ID="txtAge" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                   <div class="row clearfix">
                               <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpGender" ErrorMessage="Please Select Gender" ForeColor="Red"></asp:RequiredFieldValidator>--%>  
                                    <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                        <label for="gender">Select Gender</label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:DropDownList ID="drpGender" runat="server" class="form-control">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 <div class="row clearfix">
                               <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpHospital" ErrorMessage="Please select Hospital" ForeColor="Red"></asp:RequiredFieldValidator>--%>  
                                    <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                        <label for="Hospital">Select Hospital</label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:DropDownList ID="drpHospital" runat="server" class="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 <div class="row clearfix">
                               <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drpStatus" ErrorMessage="Please Select Status" ForeColor="Red"></asp:RequiredFieldValidator>--%>  
                                    <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                        <label for="status">Status</label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>Active</asp:ListItem>
                                                    <asp:ListItem>Deactive</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                               <div class="form-group">
              
                                      <div class="row clearfix">
                                              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                 <center> <asp:Button ID="BtnSave" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Save" OnClick="BtnSave_Click" /></center>
                                                  <center><asp:Button ID="btnUpdate" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Update" OnClick="BtnUpdate_Click" Visible="false"/></center>
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
         </section>
            <!-- #END# Horizontal Layout -->
</asp:Content>

