<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="Department.aspx.cs" Inherits="Department" %>

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
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Add Department
                                <!--<small>With floating label</small>-->
                                    </h2>

                                </div>
                                <div class="body">
                                    <form>
                                        <div class="row clearfix">
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">

                                                        <asp:TextBox ID="txtdeptName" runat="server" class="form-control" placeholder="Department Name"></asp:TextBox>
                                                    </div>
                                               <%--<asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtdeptName" ErrorMessage="Please enter Department" ForeColor="Red"></asp:RequiredFieldValidator>--%> 
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
                                                <asp:Label ID="lblError" runat="server" Text="" ForeColor=Red Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                <%--  <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary btn-lg m-l-15 waves-effect" OnClick="BtnSave_Click"/>--%>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="BtnSave_Click" />
<%--                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="BtnUpdate_Click" Visible="false" />--%>
                                                </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- #END# Inline Layout | With Floating Label -->
                    <!-- Exportable Table -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Depertment List
                                    </h2>

                                </div>
                                <div class="body">
                                    <div class="table-responsive">
                                       
                                        <asp:GridView ID="GridDept" CssClass="table table-bordered table-striped table-hover dataTable js-exportable"
                                            runat="server" AutoGenerateColumns="false" OnRowDeleting="GridDept_RowDeleting" DataKeyNames="DeptId" OnRowEditing="GridDept_RowEditing" OnRowUpdating="GridDept_RowUpdating" OnRowCancelingEdit="GridDept_RowCancelingEdit">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="30">
                                                    <ItemTemplate>
                                                         <%#Container.DataItemIndex+1 %>
                                                        <%--<asp:HyperLink runat="server" NavigateUrl='<%# Eval("deptId", "~/Department.aspx?deptId={0}") %>'
                                                            Text='<%# Eval("deptId") %>' />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="DeptId" HeaderText="Department ID" ItemStyle-Width="50" ReadOnly="true"/>--%>
                                                <asp:BoundField DataField="deptName" HeaderText="Department Name" ItemStyle-Width="350" />
                                                <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-Width="350" />
                                                
                                                <%--<asp:CommandField ShowEditButton="true"  HeaderText= "Update" ItemStyle-Width="20" EditText="<i class='material-icons'>edit</i>"/>--%>
                                                <%--<asp:CommandField ShowDeleteButton="true"  HeaderText= "Delete" ItemStyle-Width="20" DeleteText="<i class='material-icons'>delete</i>"/>--%>

                                              <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" HeaderText= "Update"   NavigateUrl='<%# string.Format("~/Department.aspx?DeptId={0}",
                    HttpUtility.UrlEncode(Eval("DeptId").ToString())) %>'>
                                                     <i class="material-icons">edit</i></asp:HyperLink>
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

