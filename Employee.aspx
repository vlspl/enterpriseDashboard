<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
  <!-- DOB Validation-->

    <script type="text/javascript">
        function ValidateDOB(sender, args) {
            //Get the date from the TextBox.
            var dateString = document.getElementById(sender.controltovalidate).value;
            var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;

            //Check whether valid dd/MM/yyyy Date Format.
            if (regex.test(dateString)) {
                var parts = dateString.split("/");
                var dtDOB = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
                var dtCurrent = new Date();
                sender.innerHTML = "Eligibility 18 years ONLY."
                if (dtCurrent.getFullYear() - dtDOB.getFullYear() < 18) {
                    args.IsValid = false;
                    return;
                }

                if (dtCurrent.getFullYear() - dtDOB.getFullYear() == 18) {

                    //CD: 11/06/2018 and DB: 15/07/2000. Will turned 18 on 15/07/2018.
                    if (dtCurrent.getMonth() < dtDOB.getMonth()) {
                        args.IsValid = false;
                        return;
                    }
                    if (dtCurrent.getMonth() == dtDOB.getMonth()) {
                        //CD: 11/06/2018 and DB: 15/06/2000. Will turned 18 on 15/06/2018.
                        if (dtCurrent.getDate() < dtDOB.getDate()) {
                            args.IsValid = false;
                            return;
                        }
                    }
                }
                args.IsValid = true;
            } else {
                sender.innerHTML = "Enter date in dd/MM/yyyy format ONLY."
                args.IsValid = false;
            }
        }
    </script>
    <!-- End of code -->
    <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
					<div class="card" style="margin-bottom: 4px;">
					<div class="header">
					 <h2>Employee</h2>
					</div>
					</div>
                   
                    <form class="form-horizontal">
                        <!-- Basic Information -->

                        <div class="row clearfix">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <div class="header">
                                        <h4>Basic Information
                                        </h4>

                                    </div>
                                    <div class="body">

                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label1" runat="server">Full Name<span style="color: Red">*</span></asp:Label>
                                                      <asp:TextBox ID="txtFName" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                    </div>
                                                        <asp:RequiredFieldValidator ID="reqword" ControlToValidate="txtFName" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <%-- <div class="form-line">
                                            <input type="text" class="form-control" placeholder="DOB">
                                        </div>--%>
                                                    <div class="form-line" id="bs_datepicker_container">
                                                       <asp:Label ID="Label2" runat="server" >DOB<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtDOB" runat="server" class="form-control" placeholder="dd/MM/yyyy" OnTextChanged="txtDOB_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    
                                                    </div>
										 <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateDOB"
                                                         ControlToValidate="txtDOB" ErrorMessage="" ForeColor = "Red" />

                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDOB" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter DOB" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row clearfix">
                                         
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtAge" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                                                         <asp:Label ID="Label4" runat="server" >Age<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtAge" runat="server" class="form-control"  MaxLength="3" OnTextChanged="txtAge_TextChanged"></asp:TextBox>
                                                    
                                                        </div>
                                                    <asp:Label ID="lblWarning" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtAge" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Age" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                              <div class="col-md-6">

                                                <div class="form-group">
                                                    <label>Gender:</label>

                                                    <asp:RadioButton ID="rbMale" Text="Male" runat="server" GroupName="Gender" />
                                                    <asp:RadioButton ID="rbFemale" Text="Female" runat="server" GroupName="Gender" />

                                                </div>
                                            </div>
                                        </div>
                                       
                                        <%-- <div class="row clearfix">
                                         

                                           <div class="col-lg-4 col-md-4">
                                                <div class="form-group">
                                                  
                                                         <asp:Label ID="Label33" runat="server" Text="Photo"></asp:Label>
                                                           
                                                    <asp:FileUpload ID="fileuploadimages" runat="server" />
                                                </div>
                                                <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="UploadFile" />
                                                <hr />
                                                <asp:Image ID="Image1" runat="server" Height="100" Width="100" />

                                            </div>
                                        </div>--%>
                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                         <asp:Label ID="Label7" runat="server" Text="Aadhar ID"></asp:Label>
                                                        <asp:TextBox ID="txtAdhar" runat="server" class="form-control" MaxLength="12"></asp:TextBox>
                                                    </div>
<%--                                                    <asp:RegularExpressionValidator ID="rvDigits" runat="server" ControlToValidate="txtAdhar" ErrorMessage="Enter Adhar only till 12 digit" ValidationGroup="LoginFrame" ForeColor="Red" ValidationExpression="[0-9]{12}" />
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtAdhar" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Enter Adhar only till 12 digit" ForeColor="Red"></asp:RequiredFieldValidator>
--%>
                                                 
                                                 </div>
                                             </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPan" ValidationGroup="LoginFrame" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                      <asp:Label ID="Label8" runat="server" Text="Pan No"></asp:Label>
                                                        <asp:TextBox ID="txtPan" runat="server" class="form-control" ></asp:TextBox>
                                                    </div>
<%--                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPan"
                                                        Display="Dynamic" ForeColor="Red" ErrorMessage="InValid PAN Card" ValidationExpression="[A-Z]{5}\d{4}[A-Z]{1}"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtPan" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Pan No" ForeColor="Red"></asp:RequiredFieldValidator>
--%>                                                    </div>
                                            </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                            </div>
                        <!--End of Basic Information -->

                        <!-- Contact Information -->
                        <div class="row clearfix">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <div class="header">
                                        <h4>Contact Information
                                        </h4>

                                    </div>
                                    <div class="body">

                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <%-- <input type="text" class="form-control" placeholder="Email Id">--%>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail" ValidationGroup="LoginFrame" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                         <asp:Label ID="Label9" runat="server" >Email ID<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" ></asp:TextBox>
                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtEmail" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Email Id" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                                        ErrorMessage="Please enter valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">  
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label10" runat="server" >Permenant Address<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtPadd" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtPadd" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Permenant Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">

                                                        <asp:Label ID="Label14" runat="server" >Current Address<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtxCAdd" runat="server" class="form-control" ></asp:TextBox>
                                                      
                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtxCAdd" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Current Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                               <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label13" runat="server" Text="State"></asp:Label>

                                                        <asp:TextBox ID="txtState" runat="server" class="form-control" ></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div> 
                                          

                                        </div>
                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                       <asp:Label ID="Label11" runat="server" >Contact No<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtContactNo" runat="server" class="form-control"></asp:TextBox>

                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtContactNo" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Contact No" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Enter Valid Mobile No." ValidationGroup="LoginFrame" ForeColor="Red" ValidationExpression="[0-9]{10}" />
                                                    </div>

                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label12" runat="server" >Alternative Contact No</asp:Label>

                                                        <asp:TextBox ID="txtAContactNo" runat="server" class="form-control" ></asp:TextBox>


                                                    </div>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtAContactNo" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Contact No" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtAContactNo" ErrorMessage="Enter Valid Mobile No." ValidationGroup="LoginFrame" ForeColor="Red" ValidationExpression="[0-9]{10}" />
--%>                                                </div>
                                            </div>
                                        </div>
                                        
                                        
                                        <div class="row clearfix">
                                           <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label15" runat="server" Text="City"></asp:Label>

                                                        <asp:TextBox ID="txtCity" runat="server" class="form-control" ></asp:TextBox>
                                                    </div>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtCity" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter City" ForeColor="Red"></asp:RequiredFieldValidator>
--%>                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label16" runat="server" >Pincode<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtpincode" runat="server" class="form-control" ></asp:TextBox>
                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtpincode" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Pin Code" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtpincode" ErrorMessage="Enter Valid Pin Code" ValidationGroup="LoginFrame" ForeColor="Red" ValidationExpression="[0-9]{6}" />
                                                </div>
                                            </div>

                                        </div>



                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--End of Contact Information -->

                        <!-- Organizational Information -->
                        <div class="row clearfix">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <div class="header">
                                        <h4>Organizational Information
                                        </h4>

                                    </div>
                                    <div class="body">

                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label17" runat="server" >Employee Id<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtEmpid" runat="server" class="form-control" ></asp:TextBox>


                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtEmpid" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Employee Id" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label18" runat="server" >Designation<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtdsgn" runat="server" class="form-control" ></asp:TextBox>

                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtdsgn" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Designation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">

                                                         <asp:Label ID="Label19" runat="server" >Department<span style="color: Red">*</span></asp:Label>
<%--                                                       <asp:TextBox ID="txtDpt" runat="server" class="form-control" ></asp:TextBox>--%>
                                                        <asp:DropDownList ID="drpDept" runat="server"  class="form-control"></asp:DropDownList>
                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="drpDept" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Select Department" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">

                                                        <asp:Label ID="Label20" runat="server" >Branch Name<span style="color: Red">*</span></asp:Label>
                                                        <%--<asp:TextBox ID="txtBranchName" runat="server" class="form-control" ></asp:TextBox>--%>
                                                         <asp:DropDownList ID="drpBranch" runat="server"  class="form-control" ></asp:DropDownList>

                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="drpBranch" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Select Branch" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">


                                                        <asp:Label ID="Label21" runat="server" Text="Date Of Joining"></asp:Label>
                                                        <asp:TextBox ID="txtDOJ" runat="server" class="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
                                                    </div>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtDOJ" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter DOJ" ForeColor="Red"></asp:RequiredFieldValidator>
--%>                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">

                                                        <asp:Label ID="Label22" runat="server" Text="Employment Status"></asp:Label>

                                                        <asp:TextBox ID="txtEmpStatus" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>

                        <!--End of Organizational Information -->

                        <!-- Health Information -->
                        <div class="row clearfix">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <div class="header">
                                        <h4>Health Information
                                        </h4>

                                    </div>
                                    <div class="body">

                                        <div class="row clearfix">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label23" runat="server" >Blood Group<span style="color: Red" >*</span></asp:Label>
                                                        <asp:DropDownList ID="txtBG" runat="server" class="form-control">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>A +Ve</asp:ListItem>
                                                            <asp:ListItem>A -Ve</asp:ListItem>
                                                            <asp:ListItem>B +Ve</asp:ListItem>
                                                            <asp:ListItem>B- Ve</asp:ListItem>
                                                            <asp:ListItem>AB +Ve</asp:ListItem>
                                                            <asp:ListItem>AB- Ve</asp:ListItem>
                                                            <asp:ListItem>O +Ve</asp:ListItem>
                                                            <asp:ListItem>O -Ve</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<asp:TextBox ID="txtBG" runat="server" class="form-control"></asp:TextBox>--%>
                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtBG" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Select Blood Group" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <%--<input type="text" class="form-control" placeholder="Health ID">--%>
                                                        <asp:Label ID="Label24" runat="server" Text="Health ID"></asp:Label>
                                                        <asp:TextBox ID="txtHID" runat="server" class="form-control"></asp:TextBox>

                                                    </div>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtHID" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Health ID" ForeColor="Red"></asp:RequiredFieldValidator>
--%>                                                </div>
                                            </div>

                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--End of Health Information -->

                        <!-- Qualification -->
                        <div class="row clearfix">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <div class="header">
                                        <h4>Qualification
                                        </h4>

                                    </div>
                                    <div class="body">

                                        <div class="row clearfix">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <div class="form-line">

                                                        <asp:Label ID="Label32" runat="server" >Qualification<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtQualification" runat="server" class="form-control" placeholder=""></asp:TextBox>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtQualification" ValidationGroup="LoginFrame" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                </div>
                                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" AutoGenerateColumns="false"
                                                    EmptyDataText="No records has been added." OnRowDeleting="OnRowDeleting" OnRowDataBound="OnRowDataBound">
                                                    <Columns>

                                                        <asp:BoundField DataField="Qulification" HeaderText="Qualification" ItemStyle-Width="120" />
                                                        <asp:BoundField DataField="Pyear" HeaderText="Passing Year" ItemStyle-Width="120" />
                                                        <asp:BoundField DataField="Grade" HeaderText="Grade" ItemStyle-Width="120" />
                                                        <asp:BoundField DataField="University" HeaderText="University/College" ItemStyle-Width="120" />
                                                        <%--  <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="120" />--%>
                                                        <%--<asp:ButtonField Text="Delete" HeaderText="Delete"></asp:ButtonField>--%>
                                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label25" runat="server">Passing Year<span style="color: Red">*</span></asp:Label>

                                                        <asp:TextBox ID="txtPyear" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPyear" ValidationGroup="LoginFrame" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <%--<input type="text" class="form-control" placeholder="Grade">--%>
                                                        <asp:Label ID="Label26" runat="server" >Grade<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtGrade" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtGrade" ValidationGroup="LoginFrame" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label27" runat="server" >University/Collage<span style="color: Red">*</span></asp:Label>

                                                        <asp:TextBox ID="txtUnversity" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtUnversity" ValidationGroup="LoginFrame" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />

                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--End of Qualification -->

                        <!-- Experience -->
                        <div class="row clearfix">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <div class="header">
                                        <h4>Experience
                                        </h4>

                                    </div>
                                    <div class="body">

                                        <div class="row clearfix">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label28" runat="server" >Company Name</asp:Label>

                                                        <asp:TextBox ID="txtCname" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                </div>
                                                <asp:GridView ID="GrdExp" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" AutoGenerateColumns="false"
                                                    EmptyDataText="No records has been added." OnRowDeleting="OnRowDeletingExp">
                                                    <Columns>

                                                        <asp:BoundField DataField="CompName" HeaderText="Company Name" ItemStyle-Width="220" />
                                                        <asp:BoundField DataField="Period" HeaderText="Period From" ItemStyle-Width="120" />
                                                        <asp:BoundField DataField="tto" HeaderText="To" ItemStyle-Width="120" />
                                                        <asp:BoundField DataField="Cdsgn" HeaderText="Designation" ItemStyle-Width="120" />
                                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                            </div>


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <div class="form-line">

                                                        <asp:Label ID="Label29" runat="server" >Period From</asp:Label>
                                                        <asp:TextBox ID="txtPeriod" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <div class="form-line">

                                                        <asp:Label ID="Label30" runat="server" >To</asp:Label>

                                                        <asp:TextBox ID="txtto" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <div class="form-line">

                                                        <asp:Label ID="Label31" runat="server" Text="Designation"></asp:Label>
                                                        <asp:TextBox ID="txtCdsgn" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                    <asp:Button ID="Btn_AddExp" runat="server" Text="Add" OnClick="Btn_AddExp_Click" />
                                                </div>
                                            </div>
                                        </div>



                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--End of Experience -->

                        <!-- Documents -->
                        <div class="row clearfix">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <div class="header">
                                        <h4>Documents
                                        </h4>

                                    </div>
                                    <div class="body">

                                        <div class="row clearfix">
                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <div class="form-line">
                                                        <asp:FileUpload ID="DocId" CssClass=" btn btn-default" runat="server" />
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%--  <div class="body">
                            <form action="/" id="frmFileUpload" class="dropzone" method="post" enctype="multipart/form-data">
                                <div class="dz-message">
                                  
                                </div>
                                <div class="fallback">
                                    <input name="file" type="file" multiple />
                                </div>
                            </form>
                        </div>--%>
                                </div>
                            </div>
                        </div>
                        <!--End of Doc -->

                          <!-- Status -->
                        <div class="row clearfix" id="updateStatus" runat="server" visible="false">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <div class="header">
                                        <h4>Employment Status
                                        </h4>

                                    </div>
                                    <div class="body">

                                        <div class="row clearfix">
                                           <%-- <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label3" runat="server" >Status<span style="color: Red" >*</span></asp:Label>
                                                        <asp:DropDownList ID="drpEmpStatus" runat="server" class="form-control" OnTextChanged="drpEmpStatus_TextChanged" OnSelectedIndexChanged="drpEmpStatus_SelectedIndexChanged">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>Active</asp:ListItem>
                                                            <asp:ListItem>Deactive</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtBG" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="drpEmpStatus" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Select Employee Status" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>--%>
                                            <div class="col-md-6" id="divReason" runat="server">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <%--<input type="text" class="form-control" placeholder="Health ID">--%>
                                                        <asp:Label ID="Label5" runat="server" Text="Deactive Reason"></asp:Label>
                                                        <asp:TextBox ID="txtReason" runat="server" class="form-control"></asp:TextBox>

                                                    </div>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtHID" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Health ID" ForeColor="Red"></asp:RequiredFieldValidator>
--%>                                                </div>
                                            </div>

                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--End of Status -->
                        <div class="form-group">
                            <%--<div class="form-line">--%>
                            <div class="row clearfix">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <center>

                                        <asp:Button ID="BtnSave" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Save" ValidationGroup="LoginFrame" OnClick="BtnSave_Click" />
                                        <asp:Button ID="BtnUpdate" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Update" ValidationGroup="LoginFrame" OnClick="BtnUpdate_Click"  visible="false" />
                                        <asp:Button ID="BtnDelete" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Delete"  OnClick="BtnDelete_Click" onclientclick="return DeleteItem()" xmlns:asp="#unknown" visible="false" />
                                        <%--  <button type="button" class="btn btn-primary btn-lg m-l-15 waves-effect" onclick="">SAVE</button>--%>
                                    </center>

                                </div>
                            </div>
                             <div class="row">
                            <div class="col-md-6">
                            </div>
                            <div class="col-md-6">
                                <div class="pad">
                                    <asp:Literal Text="" ID="litErrorMessage" runat="server" /></div>
                            </div>
                        </div>
                            <%--</div>--%>
                        </div>
                       
                    </form>
                    <!-- #END# Horizontal Layout -->


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


 <!-- DOB Validation-->

    <script type="text/javascript">
        function CalculateAge(birthday) {

            var re = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d+$/;

            if (birthday.value != '') {

                if (re.test(birthday.value)) {
                    birthdayDate = new Date(birthday.value);
                    dateNow = new Date();

                    var years = dateNow.getFullYear() - birthdayDate.getFullYear();
                    var months = dateNow.getMonth() - birthdayDate.getMonth();
                    var days = dateNow.getDate() - birthdayDate.getDate();
                    if (isNaN(years)) {

                        document.getElementById('txtAge').innerHTML = '';
                        document.getElementById('lblError').innerHTML = 'Input date is incorrect!';
                        return false;

                    }

                    else {
                        document.getElementById('lblError').innerHTML = '';

                        if (months < 0 || (months == 0 && days < 0)) {
                            years = parseInt(years) - 1;
                            document.getElementById('txtAge').innerHTML = years + ' Years '
                        }
                        else {
                            document.getElementById('txtAge').innerHTML = years + ' Years '
                        }
                    }
                }
                else {
                    document.getElementById('lblError').innerHTML = 'Date must be dd/MM/yyyy format';
                    return false;
                }
            }
        }
    </script>
    <!-- End of code -->

<!-- Confirm Delete -->
 <script type="text/javascript">
     function DeleteItem() {
         if (confirm("Are you sure you want to delete ...?")) {
             return true;
         }
         return false;
     }
 </script>
  <!-- End Of code -->



            </ContentTemplate>
            <Triggers>

     <%--   <asp:AsyncPostBackTrigger ControlID = "btnAsyncUpload"

          EventName = "Click" />--%>

       <%-- <asp:PostBackTrigger ControlID = "btnUpload" />--%>

    </Triggers>
        </asp:UpdatePanel>
    </section>
    <script src="js/pages/forms/advanced-form-elements.js"></script>
</asp:Content>

