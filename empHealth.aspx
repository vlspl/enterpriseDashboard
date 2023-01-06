<%@ Page Language="C#" AutoEventWireup="true" CodeFile="empHealth.aspx.cs" Inherits="empHealth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <!-- Bootstrap Core Css -->
  <link rel="icon" href="favicon.ico" type="image/x-icon">
     <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css">

    <!-- Bootstrap Core Css -->
    <link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet">

    <!-- Waves Effect Css -->
    <link href="plugins/node-waves/waves.css" rel="stylesheet" />

    <!-- Animation Css -->
    <link href="plugins/animate-css/animate.css" rel="stylesheet" />

     <!-- Sweetalert Css -->
    <link href="plugins/sweetalert/sweetalert.css" rel="stylesheet" />

      <!-- Colorpicker Css -->
    <link href="plugins/bootstrap-colorpicker/css/bootstrap-colorpicker.css" rel="stylesheet" />

    
    <!-- Dropzone Css -->
    <link href="plugins/dropzone/dropzone.css" rel="stylesheet">

    <!-- Multi Select Css -->
    <link href="plugins/multi-select/css/multi-select.css" rel="stylesheet">

    <!-- Bootstrap Spinner Css -->
    <link href="plugins/jquery-spinner/css/bootstrap-spinner.css" rel="stylesheet">

    <!-- Bootstrap Tagsinput Css -->
    <link href="plugins/bootstrap-tagsinput/bootstrap-tagsinput.css" rel="stylesheet">

    <!-- Bootstrap Select Css -->
    <link href="plugins/bootstrap-select/css/bootstrap-select.css" rel="stylesheet" />

    <!-- noUISlider Css -->
    <link href="plugins/nouislider/nouislider.min.css" rel="stylesheet" />
    <!-- JVectorMap Css -->
    
    <link  href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.15.4/css/fontawesome.min.css" rel="stylesheet"/>
    <link href="plugins/jvectormap/jquery-jvectormap-1.2.2.css" rel="stylesheet" />

    <!-- Morris Css -->
    <link href="plugins/morrisjs/morris.css" rel="stylesheet" />
   
        <!-- Animation Css -->
    <link href="plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <!-- AdminBSB Themes. You can choose a theme from css/themes instead of get all themes -->
    <link href="css/themes/all-themes.css" rel="stylesheet" />
    <style>
		body {

  overflow-x: hidden; 
}
	</style>
   
    
   
</head>
<body >
<nav class="navbar" style="background-color:#f44336; color:#fff;">
       <h4 style="margin-left:30px;"> <a href="Default.aspx" title="Back to Home" style="color:#fff;"> <i class="material-icons">home</i></a><span style="margin-left:20px;"> EMPLOYEE HEALTH GRAPH DETAILS </span></h4>
    </nav>
    <section>
        <form id="form1" runat="server">
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Customize Push Notification</h5>

                        </div>
                        <div class="modal-body">
                            <p>
                                <asp:TextBox ID="txtpushMessage" CssClass="form-control" TextMode="MultiLine" Style="resize: none; height: 100px;" runat="server"></asp:TextBox>
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                            <asp:Button ID="btnsendNotification" runat="server" class="btn btn-primary" Text="Send Notification" OnClick="btnsendNotification_Click" />
                        </div>
                    </div>
                </div>
            </div>
          

                    <div class="col-md-12">
                        <div class="col-sm-4">
                            <div class="card" style="margin-top: 80px">
                                <div class="header">

                                    <asp:HiddenField ID="htestStatus" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="htestCount" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="HEmpGender" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="HAgeMale" runat="server" ClientIDMode="Static" />
                                    <h2>GENDER WISE  </h2>

                                </div>

                                <div class="body">
                                    <%--  <canvas id="emp_bar_chart" height="300"></canvas>--%>
                                    <canvas id="bar_chart" height="300"></canvas>
                                </div>

                            </div>
                        </div>
                        <div class="col-sm-4">

                            <div class="card" style="margin-top: 80px">
                                <div class="header">

                                    <asp:HiddenField ID="h_v_status" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="h_v_count" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="h_dept" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="h_male_count" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="h_female_count" runat="server" ClientIDMode="Static" />
                                    <h2>BRANCH WISE</h2>

                                </div>

                                <div class="body">
                                    <canvas id="bar_stacked" height="300"></canvas>

                                </div>
                            </div>


                        </div>

                        <div class="col-sm-4">
                              
                             <div class="card" style="margin-top: 80px">
                                 <div class="body" style="height:406px;">
                                     
                                   <div class="info-box bg-pink hover-expand-effect" style="background-color: #9c27b0 !important; ">
                                <div class="icon" style="background-color: #9c27b0 !important;">
                                    <i class="material-icons">event_available</i>
                                </div>
                                <div class="content" style="background-color: #9c27b0 !important;">
                                    <div class="text">Total Employee Count </div>
                                    <div class="number count-to" data-from="0" data-to="125" data-speed="15" data-fresh-interval="20">
                                        <asp:Label ID="lbltotal" Style="font-size: 20px;" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                            </div>

                                     
                                      <div class="info-box bg-pink hover-expand-effect" style="background-color: rgb(0,128,0) !important; margin-top: -15px;">
                                <div class="icon" style="background-color:rgb(0,128,0) !important">
                                    <i class="material-icons">dvr</i>
                                </div>
                                <div class="content" style="background-color: rgb(0,128,0) !important">
                                    <div class="text">Healthy</div>
                                    <div class="number count-to" data-from="0" data-to="125" data-speed="15" data-fresh-interval="20">
                                        <asp:Label ID="lblhealthy" Style="font-size: 20px; margin-left: 10px;" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="info-box bg-pink hover-expand-effect" style="background-color:rgb(255, 0, 0) !important; margin-top: -15px;">
                                <div class="icon" style="background-color: rgb(255, 0, 0) !important;">
                                    <i class="material-icons">event_available</i>
                                </div>
                                <div class="content" style="background-color:rgb(255, 0, 0) !important;">
                                    <div class="text">Unhealthy </div>
                                    <div class="number count-to" data-from="0" data-to="125" data-speed="15" data-fresh-interval="20">
                                        <asp:Label ID="lblunhealthy" Style="font-size: 20px; margin-left: 10px;" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                            </div>
                         
                         
                             

                            </div>
                        </div>

                        </div>
                    </div>

                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div class="row clearfix"></div>
                    <div class="col-md-12">
                        <div class="card">
                            <div class="header">
                                <h2>Filters :</h2>
                            </div>

                            <div class="body">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label col-sm-4">Select Branch</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="drpbranch" runat="server" CssClass="form-control">
                                             
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label col-sm-4">Select Department</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="drpdepartment" runat="server" CssClass="form-control"
                                               >
                                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <p><b>To communicate with your employee send customize push notification here. </b></p>
                                    <asp:Button ID="btnpushnotification" runat="server" CssClass="btn btn-info" Style="float: right;" Text="Push Notification" data-toggle="modal" data-target="#exampleModal" />
                                </div>
                                <div class="row clearfix"></div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label col-sm-4">Gender</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="drpgender" runat="server" CssClass="form-control"
                                                >
                                                <asp:ListItem>All</asp:ListItem>
                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label col-sm-4">Age Group</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="drpagegroup" runat="server" CssClass="form-control"
                                                >
                                            <asp:ListItem>All</asp:ListItem>
                                                <asp:ListItem>18-25</asp:ListItem>
                                                <asp:ListItem>26-35</asp:ListItem>
                                                <asp:ListItem>36-45</asp:ListItem>
                                                <asp:ListItem>46-60</asp:ListItem>
                                                <asp:ListItem>60+</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 <div class="row clearfix"></div>
                                 <div class="col-sm-4">
                                       <div class="form-group">
                                        <label class="control-label col-sm-4">Health Ratio </label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="drphratio" runat="server" CssClass="form-control"
                                               >
                                                <%--<asp:ListItem>- Select Center -</asp:ListItem>--%>
                                                <asp:ListItem>All</asp:ListItem>
                                                <asp:ListItem>Healthy</asp:ListItem>
                                                <asp:ListItem>Unhealthy</asp:ListItem>
                                              
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                 </div>
                                <div class="col-sm-4">
                                    <asp:Button ID="btnsearch" CssClass="btn btn-info" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                </div>

                                <div class="row clearfix"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row clearfix"></div>
                    <div class="col-md-12">
                        <div class="card">
                            <div class="header">
                                <h2>Detailed Information for Employee Health Ratio: <span style="float: right;">No of Records:
                                <asp:Label ID="lblcount" runat="server" Text="0"></asp:Label></span></h2>

                            </div>

                            <div class="body">
                                <div class="col-md-12" style="overflow: auto;">
                                    <asp:GridView ID="gridtopV" CssClass="table table-hover" runat="server" Width="100%"
                                        AllowPaging="True" AutoGenerateColumns="false" OnPageIndexChanging="gridtopV_PageIndexChanging"
                                         OnRowDataBound="gridtopV_RowDataBound" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No">
                                                <ItemTemplate>
                                                      <%#Container.DataItemIndex+1 %>
                                                    <%--<asp:Label ID="Label0" runat="server" Text='<%# Bind("tempId") %>'>></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FName") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gender">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("gender") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Age">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Age") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                           <%-- <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("empCode") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                          <%--  <asp:TemplateField HeaderText="Test Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("testName") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                           <%-- <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("status") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                             <asp:TemplateField HeaderText="Result">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label30" runat="server" Text='<%# Bind("sResult") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label30" runat="server" Text='<%# Bind("Dept") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label30" runat="server" Text='<%# Bind("batchName") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                                <div class="row clearfix"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row clearfix"></div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </section>
     <!-- Jquery Core Js -->
    <script src="plugins/jquery/jquery.min.js"></script>

    <!--Bootstrap Core Js-->
    <script src="plugins/bootstrap/js/bootstrap.js"></script>

    <!-- Google Maps API Js -->
    <script src="https://maps.google.com/maps/api/js?v=3&sensor=false"></script>

    <!--Select Plugin Js-->
    <script src="../../plugins/bootstrap-select/js/bootstrap-select.js"></script>

    <!--Slimscroll Plugin Js-->
    <script src="../../plugins/jquery-slimscroll/jquery.slimscroll.js"></script>
       
    <!-- Bootstrap Colorpicker Js -->
    <script src="../../plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.js"></script>

    <!--Waves Effect Plugin Js-->
    <script src="../../plugins/node-waves/waves.js"></script>

     <!-- noUISlider Plugin Js -->
    <script src="../../plugins/nouislider/nouislider.js"></script>

    <!-- Autosize Plugin Js -->
    <script src="../../plugins/autosize/autosize.js"></script>

<%--      <!-- Bootstrap Tagsinput Css -->
    <link href="../../plugins/bootstrap-tagsinput/bootstrap-tagsinput.css" rel="stylesheet">--%>
        <!-- Bootstrap Tags Input Plugin Js -->
    <script src="../../plugins/bootstrap-tagsinput/bootstrap-tagsinput.js"></script>

    <!-- Moment Plugin Js -->
    <script src="plugins/momentjs/moment.js"></script>

    <!-- Bootstrap Material Datetime Picker Plugin Js -->
    <script src="plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js"></script>

    <!-- Bootstrap Datepicker Plugin Js -->
    <script src="plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>

    <!-- Jquery CountTo Plugin Js -->
    <script src="plugins/jquery-countto/jquery.countTo.js"></script>

    <!-- Morris Plugin Js -->
    <script src="plugins/raphael/raphael.min.js"></script>
    <script src="plugins/morrisjs/morris.js"></script>
<%--    <script src="plugins/chartjs/Chart.bundle.min.js"></script>--%>
    <!--Chart Plugins Js-->
    <%--<script src="../../plugins/chartjs/Chart.bundle.js"></script>--%>
     <script src="plugins/chartjs/Chart.js"></script>
        <script src="plugins/chartjs/chart306.min.js"></script>
  <%--  <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.6.0/chart.min.js"></script>--%>

    <!-- Flot Charts Plugin Js -->
    <script src="plugins/flot-charts/jquery.flot.js"></script>
    <script src="plugins/flot-charts/jquery.flot.resize.js"></script>
    <script src="plugins/flot-charts/jquery.flot.pie.js"></script>
    <script src="plugins/flot-charts/jquery.flot.categories.js"></script>
    <script src="plugins/flot-charts/jquery.flot.time.js"></script>

    <!-- Sparkline Chart Plugin Js -->
    <script src="plugins/jquery-sparkline/jquery.sparkline.js"></script>

    <!-- JVectorMap Plugin Js -->
    <script src="plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>

    
    <!-- Jquery DataTable Plugin Js -->
    <script src="plugins/jquery-datatable/jquery.dataTables.js"></script>
    <script src="plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/jszip.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/pdfmake.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/vfs_fonts.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/buttons.print.min.js"></script>

     <!-- SweetAlert Plugin Js -->
    <script src="plugins/sweetalert/sweetalert.min.js"></script>
    <script src="js/pages/ui/dialogs.js"></script>
    <!--Custom Js-->
    <script src="js/admin.js"></script>
     <script src="js/pages/tables/jquery-datatable.js"></script>
      <%--<script src="../../js/pages/examples/profile.js"></script>--%>
    <script src="js/pages/examples/profile.js"></script>
     <%--   <script src="../../js/pages/charts/chartjs.js"></script>--%>

  <%--  <script src=" js/pages/charts/chartjs.js"></script>--%>
<%--   <script src="dtls_chartJS.js"></script>--%>
    <script src="empHealth_chartJS.js"></script>

    <script src="js/pages/forms/basic-form-elements.js"></script>
    <%--<script src="js/pages/forms/advanced-form-elements.js"></script>--%>
   
    <!--Demo Js-->
    <script src="js/demo.js"></script>

</body>
</html>
