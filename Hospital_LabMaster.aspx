<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="Hospital_LabMaster.aspx.cs" Inherits="Hospital_LabMaster" %>

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
                  <%--  <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Add Hospital And Lab Master
                              
                                    </h2>

                                </div>
                                <div class="body">
                                    <form>
                                        <div class="row clearfix">
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtHospital" runat="server" class="form-control" placeholder="Hospital Name"></asp:TextBox>

                                                    </div>
                                                </div>
                                                <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtHospital" ErrorMessage="Please enter Hospital Name" ForeColor="Red"></asp:RequiredFieldValidator>  
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:DropDownList ID="drpState" runat="server" class="form-control">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Maharashtra</asp:ListItem>
                                                            <asp:ListItem>Aasam</asp:ListItem>
                                                            <asp:ListItem>Gujarat</asp:ListItem>
                                                            <asp:ListItem>Kerala</asp:ListItem>
                                                            <asp:ListItem>Bengal</asp:ListItem>
                                                            <asp:ListItem>Bihar</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:DropDownList ID="drpCity" runat="server" class="form-control">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Mumbai</asp:ListItem>
                                                            <asp:ListItem>Pune</asp:ListItem>
                                                            <asp:ListItem>Gujrat</asp:ListItem>
                                                            <asp:ListItem>Nashik</asp:ListItem>
                                                            <asp:ListItem>Nagpur</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Active</asp:ListItem>
                                                            <asp:ListItem>Deactive</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="BtnSave_Click" />
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <!-- #END# Inline Layout | With Floating Label -->
                    <!-- Exportable Table -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Lab List
                                    </h2>
                                      <div class="row">
                                <div class="col-xs-4">

                                    <button class="btn btn-lg bg-pink waves-effect" type="submit" style="margin-left: 270%; font-weight: bolder"><a href="LabMaster.aspx" style="color: white;">Add New Lab </a></button>

                                </div>
                            </div>
                                </div>
                               
                                <div class="body">
                                    <div class="table-responsive">
                                      
                                        <asp:GridView ID="GridHospital" CssClass="table table-bordered table-striped table-hover dataTable js-exportable"
                                            runat="server" AutoGenerateColumns="false" OnRowDeleting="GridHospital_RowDeleting" DataKeyNames="sLabId" OnRowEditing="GridHospital_RowEditing" OnRowUpdating="GridHospital_RowUpdating" OnRowCancelingEdit="GridHospital_RowCancelingEdit" 
                                            OnRowDataBound = "OnRowDataBound"  AllowPaging="true" AllowSorting="true" OnPageIndexChanging="OnPageIndexChanging">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="30">
                                                    <ItemTemplate>
                                                         <%#Container.DataItemIndex+1 %>
                                                       <%-- <asp:HyperLink runat="server" NavigateUrl='<%# Eval("sLabId", "~/LabMaster.aspx?sLabId={0}") %>'
                                                            Text='<%# Eval("sLabId") %>' />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="sLabId" HeaderText="Lab ID" ItemStyle-Width="50" visible="false"/>
                                                <asp:BoundField DataField="sLabName" HeaderText="Lab Name" ItemStyle-Width="250" ReadOnly="true"/>
                                                <asp:BoundField DataField="sLabAddress" HeaderText="Lab Address" ItemStyle-Width="300" />
                                                <asp:BoundField DataField="sLabManager" HeaderText="Lab Manager" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="sLabStatus" HeaderText="Status" ItemStyle-Width="50" />
                                                 <asp:BoundField DataField="sLabContact" HeaderText="Contact No." ItemStyle-Width="150" />

<%--                                                <asp:CommandField ShowEditButton="true" ItemStyle-Width="20" HeaderText= "Update" ButtonType ="Link" EditText="<i class='material-icons'>edit</i>"/>
                                                <asp:CommandField ShowDeleteButton="true" ItemStyle-Width="20" HeaderText= "Delete" ButtonType ="Link" DeleteText="<i class='material-icons'>delete</i>"/>--%>
                                                 <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/LabMaster.aspx?sLabId={0}",
                    HttpUtility.UrlEncode(Eval("sLabId").ToString())) %>' HeaderText="Action">
                                                     <i class="material-icons">visibility</i></asp:HyperLink>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>

                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- #END# Exportable Table -->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>

