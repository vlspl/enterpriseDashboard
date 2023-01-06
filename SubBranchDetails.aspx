<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="SubBranchDetails.aspx.cs" Inherits="subBranchDetails" %>

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

                    <div class="row clearfix  ">
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="card">
                            <div class="header ">
                                <h2>Sub Branch Details
                                <!--<small>With floating label</small>-->
                                </h2>
                                <%--  <div style="float:right">
                                        <asp:Button ID="Button1" runat="server" Text="Add New Branch" class="btn bg-purple waves-effect"/>

                                    </div>--%>
                            </div>

                            <div class="body" id="branch">
                                <form>
                                    <div class="row clearfix justify-containt-right">
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-5 ">
                                        <asp:Label ID="Label7" runat="server" Text="Parent Branch"></asp:Label>

                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-7">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:DropDownList ID="drpParentBranch" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbranchName" ErrorMessage="Please enter Parent Branch" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    </div>

                                    <div class="row clearfix"></div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-5 ">
                                        <asp:Label ID="Label1" runat="server" Text="Sub Branch"></asp:Label>

                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-7">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:DropDownList ID="drpSubBranch" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbranchName" ErrorMessage="Please enter Parent Branch" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    </div>


                                    <div class="row clearfix"></div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-5 ">
                                        <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>

                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-7">
                                        <div class="form-group form-float">
                                            <div class="form-line">

                                                <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                                    
                                                    <asp:ListItem>Active</asp:ListItem>
                                                    <asp:ListItem>Deactive</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStatus" ErrorMessage="Please enter Status" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>--%>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                        <center>

                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>

                                            <asp:Button ID="BtnSave" class="btn btn-primary btn-lg m-l-15 waves-effect m-b-20"  style="margin-left: 80px;" runat="server" Width="100px" Text="Save" onclick="BtnSave_Click" />
                                         <asp:Button ID="BtnClose" class="btn btn-primary btn-lg m-l-15 waves-effect m-b-20"  runat="server" Width="100px" Text="Close" onclick="BtnClose_Click" />

                                        </center>

                                    </div>


<%--                                    <div>
                                        <asp:TextBox ID="txtsearch" runat="server" OnTextChanged="txtsearch_TextChanged"></asp:TextBox>
                                    </div>--%>

                                    <div class="row clearfix"></div>

                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" AutoGenerateColumns="False"
                                        EmptyDataText="No records has been added." OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowDataBound="OnRowDataBound"
                                          OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="branch_subBranchId" AllowPaging="true" AllowSorting="true"
                                         OnPageIndexChanging="OnPageIndexChanging" PageSize="10">


                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="30">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                    <%--<asp:HyperLink runat="server" NavigateUrl='<%# Eval("deptId", "~/Department.aspx?deptId={0}") %>'
                                                            Text='<%# Eval("deptId") %>' />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="DeptId" HeaderText="Department ID" ItemStyle-Width="50" ReadOnly="true"/>--%>
                                            <asp:BoundField DataField="parentBranch" HeaderText="Parent  Branch" ItemStyle-Width="150" readonly="true"/>
                                            <asp:BoundField DataField="subBranch" HeaderText=" Sub Branch " ItemStyle-Width="150" readonly="true"/>
                                            <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-Width="150" />


                                            <asp:CommandField ShowEditButton="true"  HeaderText= "Update" ItemStyle-Width="20" EditText="<i class='material-icons'>edit</i>"/>
                                            <%--<asp:CommandField ShowDeleteButton="true" HeaderText="Delete" ItemStyle-Width="20" DeleteText="<i class='material-icons'>delete</i>" />--%>

                                            <%-- <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Department.aspx?DeptId={0}",
                    HttpUtility.UrlEncode(Eval("DeptId").ToString())) %>'>
                                                     <i class="material-icons">edit</i></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                        </Columns>

                                    </asp:GridView>


                                </form>
                            </div>

                        </div>
                    </div>

                    <%--   </div>--%>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </section>
</asp:Content>

