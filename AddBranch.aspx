<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="AddBranch.aspx.cs" Inherits="AddBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="block-header">
                        <!--<h2>FORM EXAMPLES</h2>-->
                    </div>

                    <!-- Inline Layout | With Floating Label -->

                    <div class="row clearfix  ">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header ">
                                    <h2>Add Branch</h2>
                                <div class="row">
                                <div class="col-xs-4">

                                    <button class="btn btn-lg bg-pink waves-effect" type="submit" style="margin-left: 270%; font-weight: bolder"><a href="Branch.aspx" style="color: white;">View Branch Details </a></button>

                                </div>
                            </div>
                                </div>



                                <div class="body" id="branch">
                                    <form>
                                        <div class="row clearfix justify-containt-right">
                                        </div>
                                       <%-- <div class="col-lg-2 col-md-2 col-sm-2 col-xs-5 ">
                                            <asp:Label ID="Label7" runat="server" Text="Parent Branch"></asp:Label>

                                        </div>--%>
                                       <%-- <div class="col-lg-6 col-md-6 col-sm-6 col-xs-7">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <asp:DropDownList ID="drpParentBranch" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpParentBranch" ErrorMessage="Please enter Parent Branch" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>--%>
                                        <div class="row clearfix"></div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <asp:Label ID="Label1" runat="server" >Branch Name<span style="color: Red">*</span></asp:Label>
                                                    <asp:TextBox ID="txtbranchName" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbranchName"  ValidationGroup="save" ErrorMessage="Please Enter Branch" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <asp:Label ID="Label2" runat="server" >Address<span style="color: Red">*</span></asp:Label>
                                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress" ValidationGroup="save" ErrorMessage="Please enter Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>


                                        </div>
                                       <%-- <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <%--  <asp:TextBox ID="txtContry" runat="server" class="form-control" placeholder="Country"></asp:TextBox>
                                                    <asp:Label ID="Label3" runat="server" Text="Country"></asp:Label>
                                                    <asp:DropDownList ID="drpCountry" runat="server" class="form-control">
                                                      
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                             <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary  btn-lg m-l-15 waves-effect" data-type="basic" OnClick="BtnSave_Click" />
                                        </div>--%>

                                        <div class="row clearfix"></div>
                                       <%-- <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <asp:Label ID="Label4" runat="server" Text="State"></asp:Label>
                                                    <%--<asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder="City"></asp:TextBox>
                                                    <asp:DropDownList ID="drpState" runat="server" class="form-control">
                                                        <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Andaman and Nicobar Islands">	Andaman and Nicobar Islands	</asp:ListItem>
                                                            <asp:ListItem Value="Andhra Pradesh">	Andhra Pradesh	</asp:ListItem>
                                                            <asp:ListItem Value="Arunachal Pradesh">	Arunachal Pradesh	</asp:ListItem>
                                                            <asp:ListItem Value="Assam">	Assam	</asp:ListItem>
                                                            <asp:ListItem Value="Bihar">	Bihar	</asp:ListItem>
                                                            <asp:ListItem Value="Chandigarh">	Chandigarh	</asp:ListItem>
                                                            <asp:ListItem Value="Chattisgarh">	Chattisgarh	</asp:ListItem>
                                                            <asp:ListItem Value="Dadra & Nagar Haveli and Daman & Diu">	Dadra & Nagar Haveli and Daman & Diu	</asp:ListItem>
                                                            <asp:ListItem Value="Delhi">	Delhi	</asp:ListItem>
                                                            <asp:ListItem Value="Goa">	Goa	</asp:ListItem>
                                                            <asp:ListItem Value="Gujarat">	Gujarat	</asp:ListItem>
                                                            <asp:ListItem Value="Haryana">	Haryana	</asp:ListItem>
                                                            <asp:ListItem Value="Himachal Pradesh">	Himachal Pradesh	</asp:ListItem>
                                                          <asp:ListItem Value="Maharashtra">	Maharashtra	</asp:ListItem>
                                                    </asp:DropDownList>


                                                </div>
                                            </div>
                                        </div>--%>


                                        <%--  <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtbranchName" ErrorMessage="Please enter Branch" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                                       <%-- <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <%--<asp:TextBox ID="txtState" runat="server" class="form-control" placeholder="State"></asp:TextBox>
                                                    <asp:Label ID="Label5" runat="server" Text="City"></asp:Label>
                                                    <asp:DropDownList ID="drpCity" runat="server" class="form-control">
                                                       
                                                    </asp:DropDownList>



                                                </div>
                                            </div>
                                        </div>--%>

                                        <form class="form-horizontal">
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please enter zip code" ForeColor="Red"></asp:RequiredFieldValidator>  --%>
                                           <%-- <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label6" runat="server" Text="Zip Code"></asp:Label>
                                                        <asp:TextBox ID="txtZipCode" runat="server" class="form-control" Onsubmit=" return myFun()" placeholder=""></asp:TextBox>

                                                    </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please enter Zip code" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>--%>






                                            <div class="row clearfix"></div>
                                            <div class="col-lg-6 col-md-6 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="mobileno" runat="server">Mobile No<span style="color: Red">*</span></asp:Label>
                                                        <%--<asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="City"></asp:TextBox>--%>
                                                        <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder=""></asp:TextBox>


                                                    </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMobile" ValidationGroup="save" ErrorMessage="Please enter Mobile No." ForeColor="Red"></asp:RequiredFieldValidator>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobile" ErrorMessage="Enter Valid Mobile No." ValidationGroup="LoginFrame" ForeColor="Red" ValidationExpression="[0-9]{10}" />

                                                </div>
                                            </div>


                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <%--<asp:TextBox ID="txtState" runat="server" class="form-control" placeholder="State"></asp:TextBox>--%>
                                                        <asp:Label ID="Label11" runat="server" >Email<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder=""></asp:TextBox>


                                                    </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter EmailId" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail" ValidationGroup="save"
                                                        ErrorMessage="Please enter valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">  
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <form class="form-horizontal">
                                               
                                             <%--   <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:Label ID="Label9" runat="server" Text="Status"></asp:Label>
                                                            <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem>Active</asp:ListItem>
                                                                <asp:ListItem>Deactive</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpStatus" ErrorMessage="Please Select Status" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>--%>

                                                 
                                            <form class="form-horizontal">
                                                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <%--<asp:TextBox ID="txtState" runat="server" class="form-control" placeholder="State"></asp:TextBox>--%>
                                                        <asp:Label ID="Label12" runat="server" >HR Name<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txthr" runat="server" class="form-control" placeholder=""></asp:TextBox>


                                                    </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txthr" ErrorMessage="Please Enter HR Name" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <%--<asp:TextBox ID="txtState" runat="server" class="form-control" placeholder="State"></asp:TextBox>--%>
                                                        <asp:Label ID="Label8" runat="server" >Password<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtpwd" runat="server" class="form-control" placeholder="" ></asp:TextBox>

                                                    </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtpwd" ErrorMessage="Please Enter Password" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:Label ID="Label10" runat="server" >Confirm Password<span style="color: Red">*</span></asp:Label>
                                                        <asp:TextBox ID="txtConpwd" runat="server" class="form-control" placeholder="" ></asp:TextBox>
                                                        </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtConpwd" ErrorMessage="Please Enter Confirm Password" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                   <asp:CompareValidator id="comparePasswords"   runat="server"  ControlToCompare="txtpwd"   ControlToValidate="txtConpwd"  ErrorMessage="Your passwords does not Match!"  Display="Dynamic" Font-Names="Verdana" ForeColor="Red" ValidationGroup="save"/>
                                                        </div>
                                                </div>



<%--                                                <div class="row clearfix"></div>
                                                <div class="col-lg-2 col-md-4 col-sm-4 col-xs-5 form-control-label">
                                                    <label for="email_address_2">Branch Admin:</label>
                                                </div>
                                                <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                                </div>

                                                <div class="row clearfix"></div>



                                                <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                    <label for="email_address_2">User Name</label>
                                                </div>
                                                <div class=" col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                    <div class="form-group">
                                                        <div class="form-line">
                                                            <asp:DropDownList ID="txtUserNameBranch" runat="server"  class="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-lg-1 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                    <label for="email_address_2">Designation</label>
                                                </div>
                                                <div class=" col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                    <div class="form-group">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtDesignation" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                        </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Please enter Designation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>


                                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">

                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />


                                                </div>
                                                <div class="row clearfix">
                                                <div class="col-lg-6 col-md-2 col-sm-2 col-xs-2">

                                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" AutoGenerateColumns="False"
                                                        OnRowDeleting="OnRowDeleting" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added.">
                                                        <Columns>

                                                            <asp:BoundField DataField="UserNameBranch" HeaderText="User Name" ItemStyle-Width="120">
                                                                <ItemStyle Width="120px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Designation" HeaderText="Designation" ItemStyle-Width="120">
                                                                <ItemStyle Width="120px" />
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowDeleteButton="True" HeaderText="Action" ButtonType="Button" ItemStyle-Width="80" />
                                                        </Columns>
                                                    </asp:GridView>


                                                </div>
                                               </div>--%>
                                                <div>
 <div class="row clearfix"><br /></div>
                                                    <center>  
                                                        <asp:Button ID="BtnSave"  runat="server" Text="Save" CssClass="btn btn-primary waves-effect"  data-type="basic" OnClick="BtnSave_Click"  ValidationGroup="save"/>
                                                        <asp:Button ID="btnUpdate"  runat="server" Text="Close" CssClass="btn btn-primary waves-effect"  data-type="basic" OnClick="btnUpdate_Click"  />
                                                        </center>
                                                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                </div>

                                            </form>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>




                <!-- #END# Exportable Table -->

            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
    



</asp:Content>

