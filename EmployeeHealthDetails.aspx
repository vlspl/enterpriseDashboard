<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeHealthDetails.aspx.cs" Inherits="EmployeeHealthDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Exportable Table -->
    <section class="content">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Employee Health Details
                                    </h2>
                                    <div class="row">
                                        <div class="col-xs-4">

                                            <button class="btn btn-lg bg-pink waves-effect" type="submit" style="margin-left: 260%; font-weight: bolder"><a href="EmployeeHealthPackage.aspx" style="color: white;">Add New Health Package</a></button>

                                        </div>
                                    </div>
                                </div>
                                <div class="body">
                                    <div class="table-responsive">
                                        <%--<table class="table table-bordered table-striped table-hover dataTable js-exportable" style="display:none">
                                            <thead>
                                                <tr>
                                                    <th>Package Name</th>
                                                    <th>Department</th>
                                                    <th>Branch</th>
                                                    <th>Test Count</th>
                                                    <th>Gender</th>
                                                    <th>Status</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tfoot>
                                                <tr>
                                                    <th>Package Name</th>
                                                    <th>Department</th>
                                                    <th>Branch</th>
                                                    <th>Test Count</th>
                                                    <th>Gender</th>
                                                    <th>Status</th>
                                                    <th>Action</th>
                                                </tr>
                                            </tfoot>
                                            <tbody>
                                                <tr>
                                                    <td>Standard</td>
                                                    <td>Finance</td>
                                                    <td>Ahmedabad</td>
                                                    <td>3</td>
                                                    <td>Female</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Standard</td>
                                                    <td>Finance</td>
                                                    <td>Ahmedabad</td>
                                                    <td>5</td>
                                                    <td>Male</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>
                                                <tr>
                                                    <td>Primary</td>
                                                    <td>Sales</td>
                                                    <td>Mumbai</td>
                                                    <td>4</td>
                                                    <td>Female</td>
                                                    <td>Active</td>
                                                    <td>Edit/Delete</td>


                                                </tr>


                                            </tbody>
                                        </table>--%>
                                        <asp:GridView ID="GridEmpHealth" CssClass="table table-bordered table-striped table-hover dataTable js-exportable"
                                            runat="server" AutoGenerateColumns="false" OnRowDeleting="GridEmpHealth_RowDeleting" DataKeyNames="pkgId"
                                             AllowPaging="true"    AllowSorting="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" ItemStyle-Width="30">
                                                    <ItemTemplate>
                                                          <%#Container.DataItemIndex+1 %>
                                                       <%-- <asp:HyperLink runat="server" NavigateUrl='<%# Eval("pkgId", "~/EmployeeHealthPackage.aspx?pkgId={0}") %>'
                                                            Text='<%# Eval("pkgId") %>' />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="pkgId" HeaderText="Pkg_ID" ItemStyle-Width="20" />--%>
                                                <asp:BoundField DataField="Package Name" HeaderText="Package Name" ItemStyle-Width="250" />
                                                <asp:BoundField DataField="Test Count" HeaderText="Test Count" ItemStyle-Width="30" />
                                                <asp:BoundField DataField="Test Name" HeaderText="Test Name" ItemStyle-Width="80" />
                                                
                                                <asp:BoundField DataField="Package For" HeaderText="Package For" ItemStyle-Width="80" />
                                                 <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" ItemStyle-Width="50" />
                                                <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="50" />
                                                <asp:BoundField DataField="Lab Name" HeaderText="Lab Name" ItemStyle-Width="50" />
<%--                                                <asp:CommandField ShowDeleteButton="true" ItemStyle-Width="20" HeaderText="Delete" DeleteText="<i class='material-icons'>delete</i>" />--%>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/EmployeeHealthPackage.aspx?pkgId={0}",
                    HttpUtility.UrlEncode(Eval("pkgId").ToString())) %>'>
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
            <!-- #END# Exportable Table -->
</asp:Content>

