<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="EmployeeDetails" EnableEventValidation = "false"%>

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
                            <h2>
                                Employee Details
                            </h2>
                            <div class="row">
                                <div class="col-xs-4">

                                    <button class="btn btn-lg bg-pink waves-effect" type="submit" style="margin-left: 270%; font-weight: bolder"><a href="Employee.aspx" style="color: white;">Add New Employee </a></button>

                                </div>
                            </div>
                        </div>
                        <div class="body">
                          
                            <div class="table-responsive">
                               
                           
                                <asp:GridView ID="GridEmp" CssClass="table table-bordered table-striped table-hover dataTable js-exportable"
                                    runat="server" AutoGenerateColumns="false" OnRowDeleting="GridEmp_RowDeleting" DataKeyNames="EmployeeId" 
                                    AllowPaging="true"    AllowSorting="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" OnRowDataBound="OnRowDataBound"  runat="server">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="30">
                                            <ItemTemplate>
                                                 <%#Container.DataItemIndex+1 %>
                                               <%-- <asp:HyperLink runat="server" NavigateUrl='<%# Eval("EmployeeId", "~/Employee.aspx?EmployeeId={0}") %>'
                                                    Text='<%# Eval("EmployeeId") %>' />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" ItemStyle-Width="50" />--%>
                                        <asp:BoundField DataField="sFullName" HeaderText="Name" ItemStyle-Width="250" />
                                        <asp:BoundField DataField="sEmailId" HeaderText="Email ID" ItemStyle-Width="150" />
                                        <asp:BoundField DataField="sMobile" HeaderText="Mobile No" ItemStyle-Width="80" />
                                        <asp:BoundField DataField="Dept" HeaderText="Department" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="BatchName" HeaderText="Branch" ItemStyle-Width="150" />
                                       <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" ItemStyle-Width="50" Visible="false"/>
                                       <%--<asp:CommandField ShowDeleteButton="true" ItemStyle-Width="20"  HeaderText= "Delete" DeleteText="<i class='material-icons'>delete</i>"/>--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink  runat="server" NavigateUrl='<%# string.Format("~/Employee.aspx?EmployeeId={0}",
                    HttpUtility.UrlEncode(Eval("EmployeeId").ToString())) %>'>
                                                     <i class="material-icons">edit</i></asp:HyperLink>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>

                                </asp:GridView>
                                <br/>
                               <%-- <asp:Button ID="btnExcel" runat="server" Text="Export To Excel" OnClick="ExportToExcel" Width="120" />
                                <asp:Button ID="btnWord" runat="server" Text="Export To Word" OnClick="ExportToWord" Width="120" />
                                <br />
                                <br />
                                <asp:Button ID="btnCSV" runat="server" Text="Export To CSV" OnClick="ExportToCSV" Width="120" />
                                <asp:Button ID="btnPDF" runat="server" Text="Export To PDF" OnClick="ExportToPDF" Width="120" />--%>
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
