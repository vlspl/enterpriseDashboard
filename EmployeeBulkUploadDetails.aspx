<%@ Page Title="" Language="C#" MasterPageFile="~/EnterpriseMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeBulkUploadDetails.aspx.cs" Inherits="EmployeeBulkUploadDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <div class="container-fluid">
                    <div class="block-header">
                        <!--<h2>FORM EXAMPLES</h2>-->
                    </div>


                    <!-- Inline Layout | With Floating Label -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                   

                                </div>
                                <div class="body">
                                    <form>
                                        <div class="row clearfix">
                                             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                            <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%> 
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                          <asp:Label ID="lblError" runat="server"></asp:Label>                                                    </div>
                                                <%--<asp:Label ID="lblError" runat="server" Text="" ForeColor=Red Visible="false"></asp:Label>--%>
                                                </div>
                                            </div>
                                            

                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                <%--  <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary btn-lg m-l-15 waves-effect" OnClick="BtnSave_Click"/>--%>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="BtnSave_Click"  />
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
                                    <h2>Employee Bulk Upload Details List
                                    </h2>

                                </div>
                                <div class="body">
                                    <div class="table-responsive">
                                       
                                        <asp:GridView ID="GridEmpBulk" CssClass="table table-bordered table-striped table-hover dataTable js-exportable"
                                            runat="server" AutoGenerateColumns="false"  DataKeyNames="uploadId" >

                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="30">
                                                    <ItemTemplate>
                                                         <%#Container.DataItemIndex+1 %>
                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="DeptId" HeaderText="Department ID" ItemStyle-Width="50" ReadOnly="true"/>--%>
                                                <asp:BoundField DataField="fileName" HeaderText="File Name" ItemStyle-Width="250" />
                                                   <%--<asp:TemplateField  HeaderText="File Name">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=' <%# Eval ("fileName") %>  '><%# Eval ("fileName") %> </asp:HyperLink>
                                                            
                                                        </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                <asp:BoundField DataField="uploadDate" HeaderText="Date" ItemStyle-Width="150" />
                                                 <asp:BoundField DataField="uploadedBy" HeaderText="Uploaded By" ItemStyle-Width="150" />
                                                <%--<asp:CommandField ShowEditButton="true"  HeaderText= "View Log" ItemStyle-Width="20" EditText="<i class='material-icons'>eye</i>"/>--%>
                                                <%--<asp:CommandField ShowDeleteButton="true"  HeaderText= "Delete" ItemStyle-Width="20" DeleteText="<i class='material-icons'>delete</i>"/>--%>

                                              <asp:TemplateField HeaderText="View Log"  ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                     <asp:LinkButton ID="lnkDownload" Text="Log" CommandArgument='<%# Eval("uploadId") %>' runat="server" OnCommand="DownloadFile"></asp:LinkButton>
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









          <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
    </section>
</asp:Content>

