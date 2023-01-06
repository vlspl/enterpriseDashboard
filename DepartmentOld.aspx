<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="DepartmentOld.aspx.cs" Inherits="Department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content">
        <div class="container-fluid">
            <div class="block-header">
                <!--<h2>FORM EXAMPLES</h2>-->
            </div>

          
            <!-- Inline Layout | With Floating Label -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                                Add Department
                                <!--<small>With floating label</small>-->
                            </h2>
                            <!--<ul class="header-dropdown m-r--5">
                                <li class="dropdown">
                                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                        <i class="material-icons">more_vert</i>
                                    </a>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="javascript:void(0);">Action</a></li>
                                        <li><a href="javascript:void(0);">Another action</a></li>
                                        <li><a href="javascript:void(0);">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>-->
                        </div>
                        <div class="body">
                            <form>
                                <div class="row clearfix">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                      <asp:TextBox ID="txtdeptName" runat="server" class="form-control" placeholder="Department Name"></asp:TextBox>

                                               
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                                    <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                               <asp:ListItem>Active</asp:ListItem>
                                                <asp:ListItem>Deactive</asp:ListItem>
                                                 </asp:DropDownList>
                                              <%--  <input type="password" class="form-control">
                                                <label class="form-label">Status</label>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                       <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary btn-lg m-l-15 waves-effect" OnClick="BtnSave_Click"/>
<%--                                        <button type="button" class="btn btn-primary btn-lg m-l-15 waves-effect">Save</button>--%>
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
                            <h2>
                                Depertment List
                            </h2>

                        </div>
                        <div class="body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-striped table-hover dataTable js-exportable">
                                    <thead>
                                        <tr>
                                            <th>Department Name</th>
                                            <th>Status</th>
                                            <th>Action</th>

                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            <th>Department Name</th>
                                            <th>Status</th>
                                            <th>Action</th>
                                        </tr>
                                    </tfoot>
                                    <tbody>
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
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Brielle Williamson</td>
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Herrod Chandler</td>
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Rhona Davidson</td>
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Colleen Hurst</td>
                                            <td>Active</td>

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
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Brielle Williamson</td>
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Herrod Chandler</td>
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Rhona Davidson</td>
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Colleen Hurst</td>
                                            <td>Active</td>

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
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Brielle Williamson</td>
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Herrod Chandler</td>
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Rhona Davidson</td>
                                            <td>Active</td>
                                            <td>Edit/Delete</td>


                                        </tr>
                                        <tr>
                                            <td>Colleen Hurst</td>
                                            <td>Active</td>

                                            <td>Edit/Delete</td>

                                        </tr>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->
        </div>
    </section>
</asp:Content>

