<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="Branch.aspx.cs" Inherits="Branch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                  
                    <!-- Exportable Table -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Branch List
                                    </h2>
                                      <div class="row">
                                <div class="col-xs-4">
                                    <span style="float:right;">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">All Branch Details</asp:LinkButton> </span>
                                    <button class="btn btn-lg bg-pink waves-effect" type="submit" style="margin-left: 270%; font-weight: bolder"><a href="AddBranch.aspx" style="color: white;">Add New Branch </a></button>
                                   <%--  <div style="margin-left:50px;">
                                    <span>A: Active</span>
                                <span> D:Deactive</span>
                                    </div>--%>
                                </div>
                               <div class="col-xs-4">
                                   <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Deactive Branch Details</asp:LinkButton> </span>
                                 </div>
                            </div>
                                </div>
                                <div class="body">
                                    <div class="table-responsive">
                                      
                                        <asp:GridView ID="GridBranch" CssClass="table table-bordered table-striped table-hover dataTable js-exportable"
                                            runat="server" AutoGenerateColumns="false" OnRowDeleting="GridBranch_RowDeleting" DataKeyNames="ID" OnRowEditing="GridBranch_RowEditing" 
                                            OnRowUpdating="GridBranch_RowUpdating" OnRowCancelingEdit="GridBranch_RowCancelingEdit" OnRowDataBound="GridBranch_RowDataBound"
                                             AllowPaging="true"    AllowSorting="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="30">
                                                    <ItemTemplate>
                                                         <%#Container.DataItemIndex+1 %>
                                                       <%-- <asp:HyperLink runat="server" NavigateUrl='<%# Eval("branchId", "~/Branch.aspx?branchId={0}") %>'
                                                            Text='<%# Eval("branchId") %>' />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="branchId" HeaderText="Branch ID" ItemStyle-Width="50" ReadOnly="true" />--%>
                                                <asp:BoundField DataField="BranchName" HeaderText="Branch Name" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="BranchAddress" HeaderText="Address" ItemStyle-Width="150" />
                                                
                                                <asp:BoundField DataField="Contact" HeaderText="Mobile No" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="Email" HeaderText="Email Id" ItemStyle-Width="250" />
                                                <asp:BoundField DataField="IsActive" HeaderText="Status" ItemStyle-Width="70" />

                                                <%--<asp:CommandField ShowEditButton="true" HeaderText="Update" ItemStyle-Width="20" EditText="<i class='material-icons'>edit</i>" />--%>
                                                <%--<asp:CommandField ShowEditButton="true" HeaderText="View" ItemStyle-Width="20" EditText="<i class='material-icons'>visibility</i>" />--%>
                                                <%--<asp:CommandField ShowDeleteButton="true" HeaderText="Delete" ItemStyle-Width="20" DeleteText="<i class='material-icons'>delete</i>" />--%>
                                                 <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server"   NavigateUrl='<%# string.Format("~/AddBranch.aspx?ID={0}",
                                                         HttpUtility.UrlEncode(Eval("ID").ToString())) %>'>
                                                     <i class="material-icons">visibility</i></asp:HyperLink>
                                            <%--   <asp:HyperLink runat="server" data-toggle="modal" data-target="#defaultModal" NavigateUrl='<% HttpUtility.UrlEncode(Eval("ID").ToString())) %>' >
                                                     <i class="material-icons">edit</i></asp:HyperLink>--%>
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

