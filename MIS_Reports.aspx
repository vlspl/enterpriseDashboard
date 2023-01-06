<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="MIS_Reports.aspx.cs" Inherits="MIS_Reports" %>
    <%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <script type="text/javascript">
     function showModal() {
         $("#myModal").modal('show');
     }

     </script>
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
 <script type="text/javascript">

     function goBack() {
         var url = 'AnalyteMaster.aspx';
         window.location.href = url;
     }
 </script>

 <link href="Content/vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">

   <script src="Content/vendor/jquery/jquery.min.js"></script>
    <script src="Content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
   
    <script src="Content/js/demo/datatables.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content">
        <div class="container-fluid">
            <div class="block-header">
                <form class="form-horizontal" >
                    <!-- Report Section -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h4>MIS Reports
                                    </h4>

                                </div>
                                <div class="body">

                                    <div class="row clearfix">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <asp:Label ID="Label28" runat="server">Report Name</asp:Label>

                                                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                        </div>


                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <div class="form-line">

                                                    <asp:Label ID="Label29" runat="server">From Date</asp:Label>
                                                    <asp:TextBox ID="txtfromDate" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <div class="form-line">

                                                    <asp:Label ID="Label30" runat="server">To</asp:Label>

                                                    <asp:TextBox ID="txttodate" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                       <asp:Button ID="Btn_Show" runat="server" Text="Show" OnClick="Btn_Show_Click" />
                                    </div>

                                        <div class="body">
                          
                                         <div class="table-responsive">
                                               
                                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" 
                                                    EmptyDataText="No records has been added." AllowPaging="true"    AllowSorting="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" OnRowDataBound="grvReportDetails_RowDataBound" >
                                                    
                                                </asp:GridView>
                                                    
                                                </div>
                                            </div>
                                         

                                     <asp:Button ID="btnexporttoexcel" runat="server" Text="Export to Excel"  style="margin-top:30px; margin-left:5px;"
          CssClass="btn btn-info" onclick="btnexporttoexcel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <!--End of Section -->
    </section>
</asp:Content>

