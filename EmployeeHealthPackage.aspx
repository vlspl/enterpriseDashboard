<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeHealthPackage.aspx.cs" Inherits="EmployeeHealthPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Horizontal Layout -->
    <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Employee Health Package
                                    </h2>

                                </div>
                                <div class="body">
                                    <form class="form-horizontal">

                                        <div class="row clearfix">
                                            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                <label for="email_address_2">Package Name</label>
                                            </div>
                                            <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtPackage" runat="server" class="form-control" placeholder="Enter your Package"></asp:TextBox>

                                                    </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="txtPackage" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Package Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </div>
                                         <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver">

                                        <div class="row clearfix">

                                            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                <label for="password_2" style="font-size:larger">Package For</label>
                                                <div style="float:right; margin-left:10px" >
                                                <asp:Label ID="lblEmCount" runat="server" Text="Employee Count" Font-Bold Font-Size="X-Large" ForeColor="Red" Visible="false"></asp:Label>
                                                    </div>
                                            </div>

                                        </div>
                                            <div class="row clearfix">

                                                <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                    <label for="password_2">Branch</label>
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-2 col-xs2">
                                                    <div class="form-group">
                                                        <div class="form-line">

                                                            <asp:DropDownList ID="drpBranch" runat="server" class="form-control" OnTextChanged="drpBranch_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                    <label for="branch">Department</label>
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-2 col-xs-2">
                                                    <div class="form-group">
                                                        <div class="form-line">
                                                            <asp:DropDownList ID="drpDept" runat="server" class="form-control" OnTextChanged="drpDept_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                                            <%-- <input type="text" id="branch" class="form-control" placeholder="Select Branch">--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row clearfix">
                                                <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                    <%--<asp:CheckBox ID="chkAge" runat="server" AutoPostBack="true"/>--%>
                                                    <label for="age">Age Group</label>
                                                </div>
                                                <div class="col-lg-4 col-md-4 col-sm-3 col-xs-3">
                                                    <div class="form-group">
                                                        <div class="form-line">
                                                            From:
                                                            <asp:TextBox ID="txtAge" runat="server" class="form-control" placeholder="Enter your Age" OnTextChanged="txtAge_TextChanged" AutoPostBack="true">1</asp:TextBox>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtAge" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Age From" ForeColor="Red"></asp:RequiredFieldValidator>
<%--                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtAge" ErrorMessage="Enter Valid Age From" ValidationGroup="LoginFrame" ForeColor="Red" ValidationExpression="[0-9]{3}" />--%>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4 col-sm-3 col-xs-3">
                                                    <div class="form-group">
                                                        <div class="form-line">
                                                            To :
                                                            <asp:TextBox ID="txtAgeto" runat="server" class="form-control" placeholder="Enter your Age" OnTextChanged="txtAgeto_TextChanged" AutoPostBack="true">99</asp:TextBox>
                                                            <%--<input type="text" id="age" class="form-control" placeholder="Enter your Age">--%>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAgeto" ValidationGroup="LoginFrame" runat="server" ErrorMessage="Please Enter Age to" ForeColor="Red"></asp:RequiredFieldValidator>
<%--                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAgeto" ErrorMessage="Enter Valid Age to" ValidationGroup="LoginFrame" ForeColor="Red" ValidationExpression="[0-9]{3}" />--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row clearfix">
                                                <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                    <%--<asp:CheckBox ID="chkGender" runat="server" AutoPostBack="true"/>--%>
                                                    <label for="gender">Gender</label>
                                                </div>
                                                <div class="col-lg-8 col-md-8 col-sm-6 col-xs-4">
                                                    <div class="form-group">
                                                        <div class="form-line">
                                                            <asp:DropDownList ID="drpGender" runat="server" class="form-control" OnTextChanged="drpGender_TextChanged" AutoPostBack="true">
                                                                <asp:ListItem>All</asp:ListItem>
                                                                <asp:ListItem>Male</asp:ListItem>
                                                                <asp:ListItem>Female</asp:ListItem>

                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--  <div class="row clearfix">
                                             <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                <label for="test">All Employee</label>
                                             </div>
                                             <div class="col-lg-10 col-md-10 col-sm-8 col-xs-7">
                                                 <div class="form-group">
                                                     <div class="form-line">
                                                         <asp:DropDownList ID="drpEmp" runat="server" class="form-control"></asp:DropDownList>
                                                     </div>
                                                 </div>
                                             </div>
                                         </div>--%>
                                        </asp:Panel>
                                        <div style="margin-bottom:40px;"></div>
                                      
                                        <div class="row clearfix">
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpstatus" ErrorMessage="Please enter Package name" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                <label for="status">Path Lab Name</label>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-3 col-xs-3">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:DropDownList ID="drpLab" runat="server" class="form-control" OnSelectedIndexChanged="drpLab_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <%--  <input type="text" id="status" class="form-control" placeholder="Select Gender">--%>
                                                    </div>
                                                </div>

                                            </div>
                                            <div>
                                                <%--<button type="button" class="btn btn-primary btn-lg m-l-15 waves-effect">Add</button></center>--%>
                                                <asp:Button ID="Button1" runat="server" Text="+" Font-Bold Font-Size="Large" class="btn button-place btn-lg m-l-15 waves-effect" OnClick="InsertLab" />
                                                <div><asp:Label ID="lblWarning" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></div>
                                            </div>
                                        </div>
                                        <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" AutoGenerateColumns="false"
                                            EmptyDataText="No records has been added." OnRowDeleting="OnRowDeletingLab" OnRowDataBound="OnRowDataBound">
                                            <Columns>
                                                 <asp:TemplateField HeaderText="ID" ItemStyle-Width="10">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:BoundField DataField="labName" HeaderText="Lab Name" ItemStyle-Width="100" />
                                                <asp:BoundField DataField="labCode" HeaderText="Lab Code" ItemStyle-Width="100" />
                                                <asp:BoundField DataField="orgId" HeaderText="orgId" ItemStyle-Width="0" Visible="false"/>
                                                <%--  <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="120" />--%>
                                                <%--<asp:ButtonField Text="Delete" HeaderText="Delete"></asp:ButtonField>--%>
                                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-Width="50" />
                                            </Columns>
                                        </asp:GridView>
                                          <div class="row clearfix">
                                            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-5 form-control-label">
                                                <label for="status">Test Name</label>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-3 col-xs-3">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:DropDownList ID="drpTest" runat="server" class="form-control">
                                                        </asp:DropDownList>
                                                        <%--   <input type="text" id="status" class="form-control" placeholder="Select Gender">--%>
                                                    </div>
                                                </div>

                                            </div>
                                            <div>
                                                <%-- <button type="button" class="btn btn-primary btn-lg m-l-15 waves-effect" OnClick="Insert">Add</button></center>--%>
                                                <asp:Button ID="btnAdd" runat="server" Text="+" Font-Bold Font-Size="Large" class="btn button-place btn-lg m-l-15 waves-effect" OnClick="Insert" />
                                                <div><asp:Label ID="lblWarningTest" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></div>
                                            </div>
                                        </div>
                                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" AutoGenerateColumns="false"
                                            EmptyDataText="No records has been added." OnRowDeleting="OnRowDeleting" OnRowDataBound="OnRowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="10">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:BoundField DataField="testName" HeaderText="Test Name" ItemStyle-Width="100" />
                                                <asp:BoundField DataField="testCode" HeaderText="Test Code" ItemStyle-Width="100" />
                                                <asp:BoundField DataField="orgId" HeaderText="orgId" ItemStyle-Width="0" Visible="false" />


                                                <%--  <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="120" />--%>
                                                <%--<asp:ButtonField Text="Delete" HeaderText="Delete"></asp:ButtonField>--%>
                                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-Width="50" />
                                            </Columns>
                                            
                                        </asp:GridView>
                                        <div class="form-group">

                                            <div class="row clearfix">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                      <center>
                                                        <asp:Button ID="BtnSave" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Save" OnClick="BtnSave_Click" ValidationGroup="LoginFrame" />
                                                    </center>
                                                     <center>
                                                        <asp:Button ID="btnDelete" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Delete" OnClick="BtnDelete_Click" Visible="false" />
                                                    <center>
                                                    <center>
                                                        <asp:Button ID="btnUpdate" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Close" OnClick="BtnUpdate_Click" Visible="false" />
                                                    </center>
                                                      
                                                  
                                                    <%--<center>
                                                         <button type="button" class="btn btn-primary btn-lg m-l-15 waves-effect">SAVE</button></center>--%>
                                                </div>
                                            </div>

                                        </div>
                                        <%-- <div class="row clearfix">
                                    <div class="col-lg-offset-2 col-md-offset-2 col-sm-offset-4 col-xs-offset-5">
                                        <button type="button" class="btn btn-primary m-t-15 waves-effect">Save</button>
                                    </div>
                                </div>--%>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
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









            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
    <!-- #END# Horizontal Layout -->
</asp:Content>

