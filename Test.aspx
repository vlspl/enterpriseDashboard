<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="block-header">
                        <!--<h2>FORM EXAMPLES</h2>-->
                    </div>
                    <!-- Inline Layout | With Floating Label -->
                  <%--<div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Add Test
                               
                                    </h2>

                                </div>
                                <div class="body">
                                    <form>
                                        <div class="row clearfix">
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtTestName" runat="server" class="form-control" placeholder="Test Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtTestName" ErrorMessage="Please enter Test" ForeColor="Red"></asp:RequiredFieldValidator>  
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtRange" runat="server" class="form-control" placeholder="Normal Range"></asp:TextBox>

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
                                    <h2>Test List
                                    </h2>

                                </div>
                                <div class="body">
                                    <div class="table-responsive">
                                        <%--<table class="table table-bordered table-striped table-hover dataTable js-exportable" style="display: none">
                                            <thead>
                                                <tr>
                                                    <th>Test Name</th>
                                                    <th>Status</th>
                                                    <th>Action</th>

                                                </tr>
                                            </thead>
                                            <tfoot>
                                                <tr>
                                                    <th>Test Name</th>
                                                    <th>Status</th>
                                                    <th>Action</th>
                                                </tr>
                                            </tfoot>
                                            <tbody>
                                                <tr>
                                                    <td>Diabetes</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Blood Pressure</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Hypertension</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Covid 19</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Accountant</td>
                                                    <td>Accountant</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Brielle Williamson</td>
                                                    <td>Integration Specialist</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Herrod Chandler</td>
                                                    <td>Sales Assistant</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Rhona Davidson</td>
                                                    <td>Integration Specialist</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Colleen Hurst</td>
                                                    <td>Javascript Developer</td>

                                                    <td>Edit/Delete</td>

                                                </tr>

                                                <tr>
                                                    <td>Finance</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Sales</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Support</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Human resource</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Accountant</td>
                                                    <td>Accountant</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Brielle Williamson</td>
                                                    <td>Integration Specialist</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Herrod Chandler</td>
                                                    <td>Sales Assistant</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Rhona Davidson</td>
                                                    <td>Integration Specialist</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Colleen Hurst</td>
                                                    <td>Javascript Developer</td>

                                                    <td>Edit/Delete</td>

                                                </tr>

                                                <tr>
                                                    <td>Finance</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Sales</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Support</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Human resource</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Accountant</td>
                                                    <td>Accountant</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Brielle Williamson</td>
                                                    <td>Integration Specialist</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Herrod Chandler</td>
                                                    <td>Sales Assistant</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Rhona Davidson</td>
                                                    <td>Integration Specialist</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Colleen Hurst</td>
                                                    <td>Javascript Developer</td>

                                                    <td>Edit/Delete</td>

                                                </tr>

                                            </tbody>
                                        </table>--%>

                                        <asp:GridView ID="GridTest" CssClass="table table-bordered table-striped table-hover dataTable js-exportable"
                                            runat="server" AutoGenerateColumns="false" OnRowDeleting="GridTest_RowDeleting" DataKeyNames="sTestId" OnRowEditing="GridTest_RowEditing" OnRowUpdating="GridTest_RowUpdating" 
                                            OnRowCancelingEdit="GridTest_RowCancelingEdit" OnRowDataBound = "OnRowDataBound"  AllowPaging="true"    AllowSorting="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="30">
                                                    <ItemTemplate>
                                                         <%#Container.DataItemIndex+1 %>
                                                       <%-- <asp:HyperLink runat="server" NavigateUrl='<%# Eval("sTestId", "~/TestMaster.aspx?sTestId={0}") %>'
                                                            Text='<%# Eval("sTestId") %>' />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="sTestId" HeaderText="Test ID" ItemStyle-Width="50" />--%>
                                                <asp:BoundField DataField="sTestCode" HeaderText="Test Code" ItemStyle-Width="250" ReadOnly="true"/>
                                                <asp:BoundField DataField="sTestName" HeaderText="Test Name" ItemStyle-Width="300" />
                                                <asp:BoundField DataField="sProfileName" HeaderText="Profile" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="sSectionName" HeaderText="Section" ItemStyle-Width="50" />
                                                 

<%--                                                <asp:CommandField ShowEditButton="true" ItemStyle-Width="20" HeaderText= "Update" ButtonType ="Link" EditText="<i class='material-icons'>edit</i>"/>
                                                <asp:CommandField ShowDeleteButton="true" ItemStyle-Width="20" HeaderText= "Delete" ButtonType ="Link" DeleteText="<i class='material-icons'>delete</i>"/>--%>
                                                 <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/TestMaster.aspx?sTestId={0}",
                    HttpUtility.UrlEncode(Eval("sTestId").ToString())) %>' HeaderText="Action">
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

