<%@ Page Title="" Language="C#" MasterPageFile="~/EnterpriseMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <link rel="stylesheet" href="NivoSlider/themes/default/default.css" type="text/css"
        media="screen" />
    <link rel="stylesheet" href="NivoSlider/themes/light/light.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="NivoSlider/themes/dark/dark.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="NivoSlider/themes/bar/bar.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="NivoSlider/nivo-slider.css" type="text/css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section>

        <!-- Left Sidebar -->
        <aside id="leftsidebar" class="sidebar">
            <!-- User Info -->
            <div class="user-info">

                <div class="info-container">
                    <div class="name" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><b>
                        <asp:Label ID="lblUsernm" runat="server" Text="" Font-Size="X-Large"></asp:Label></b></div>
                     <%--<asp:Label ID="lblOrg" runat="server" Text="0" Font-Size="X-Large"></asp:Label>--%>
                    <div class="email">
                        <h6>
                            <asp:Label ID="lblDesignation" runat="server" Text="" Visible="false"></asp:Label></h6>

                    </div>

                    <div class="btn-group user-helper-dropdown">
                        <i class="material-icons" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">keyboard_arrow_down</i>

                        <ul class="dropdown-menu pull-right">
                            <li>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"> <i class="material-icons">account_circle</i>Profile</asp:LinkButton></li>
                            <li role="separator" class="divider"></li>
                           <%-- <li id="1"><a href="Default.aspx?zoneId=1"><i class="material-icons">account_box</i>CEO</a></li>
                            <li id="2"><a href="Default.aspx?zoneId=2"><i class="material-icons">people_outline</i>North Zone - CEO</a></li>
                            <li id="3"><a href="Default.aspx?zoneId=2"><i class="material-icons">person</i>Country Head</a></li>
                            <li id="4"><a href="Default.aspx?zoneId=4"><i class="material-icons">person_pin</i>Regional CEO</a></li>
                            <li id="5"><a href="Default.aspx?zoneId=3"><i class="material-icons">perm_identity</i>District HR</a></li>
                            <li role="separator" class="divider"></li>--%>
                            <li><a href="Login.aspx"><i class="material-icons">input</i>Sign Out</a></li>
                        </ul>
<%--                        <asp:DropDownList ID="DropDownList1" runat="server" class="dropdown-menu pull-right">
                            <asp:ListItem>CEO</asp:ListItem>
                            <asp:ListItem>Country Head</asp:ListItem>
                            <asp:ListItem>Branch HR</asp:ListItem>
                        </asp:DropDownList>--%>
                    </div>
                </div>
            </div>
            <!-- #User Info -->
            <!-- Menu -->
            <div class="menu">
                <ul class="list">
                    <li class="header">Dashboard</li>
                    <div class="block-header">
                        <%--<h2> <span style="margin-left:10px;" data-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample"><i class="fa fa-filter fa-2x" aria-hidden="true"></i>DASHBOARD</span>
                
                    <asp:TextBox ID="txtCart" runat="server" class="form-control" data-role="tagsinput" OnTextChanged="txtCart_TextChanged" ></asp:TextBox>
                    <span style="margin-left:10px;"><a id="fltr" runat="server" href="Default.aspx">Reset-Filter</a></span>
               </h2>--%>
                    </div>
                    <%--  <li> <div class="body">
                            <div class="form-group">
                                Filters
                                <div class="form-line demo-tagsinput-area" style="margin-bottom: -25px">
                                    <asp:TextBox ID="txtCart" runat="server" class="form-control" data-role="tagsinput" OnTextChanged="txtCart_TextChanged"></asp:TextBox>
                                    </div>
                            </div>
                        </div></li>--%>
                    <li class="active">
                        <a class="menu-toggle" href="#">
                            <i class="material-icons">add_location</i>
                            <span>Select Region</span>
                        </a>
                        <ul class="ml-menu">
                            <li>
                                <a href="#">Select District</a>

                                <asp:DropDownList ID="drpcountry" runat="server" AutoPostBack="true" OnTextChanged="drpcountry_TextChanged">
                                    <asp:ListItem>All</asp:ListItem>
                                </asp:DropDownList>

                            </li>
                          <%--  <li>
                                <a href="#">Select State/City</a>
                                <asp:DropDownList ID="drpState" runat="server" AutoPostBack="true" OnTextChanged="drpState_TextChanged"></asp:DropDownList>

                            </li>--%>

                        </ul>
                    </li>
                    <%-- <li>
                        <a class="menu-toggle">
                            <i class="material-icons">date_range</i>
                            <span>Select Date Range</span>
                        </a>
                        <ul class="ml-menu">
                            <li>
                                <div class="input-daterange input-group" id="bs_datepicker_range_container">
                                    <div class="form-line">
                                        <input type="text" class="form-control" placeholder="Start Date...">
                                    </div>
                                    <span class="input-group-addon">to</span>
                                    <div class="form-line">
                                        <input type="text" class="form-control" placeholder="End Date...">
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </li>--%>



                    <li>
                        <a class="menu-toggle">
                            <i class="material-icons ">work</i>
                            <span>Select Organogram</span>
                        </a>
                        <ul class="ml-menu">

                            <li>
                                <a>Select Department</a>
                                <div>
                                    <asp:DropDownList ID="drpDept" runat="server" OnTextChanged="drpDept_TextChanged" AutoPostBack="true">
                                        <asp:ListItem>All</asp:ListItem>

                                    </asp:DropDownList>

                                </div>
                            </li>
                        </ul>
                    </li>
                    <%--<li>
                        <a class="menu-toggle">
                            <i class="material-icons">local_hospital</i>
                            <span>Employee Health</span>
                        </a>
                        <ul class="ml-menu">
                            <li>

                                <div class="col-md-3">
                                    <asp:DropDownList ID="drphealth" runat="server" AutoPostBack="true" OnTextChanged="drphealth_TextChanged">
                                        <asp:ListItem>All</asp:ListItem>
                                        <asp:ListItem>Healthy</asp:ListItem>
                                        <asp:ListItem>Unhealthy</asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                            </li>
                        </ul>
                    </li>--%>
                    <li>
                        <a class="menu-toggle">
                            <i class="material-icons">person</i>
                            <span>Gender</span>
                        </a>
                        <ul class="ml-menu">
                            <li>

                                <div>

                                    <div class="col-md-3">
                                        <asp:DropDownList ID="drpGender" runat="server" AutoPostBack="true" OnTextChanged="drpGender_TextChanged">
                                       <asp:ListItem>All</asp:ListItem>
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                            </asp:DropDownList>

                                    </div>

                                </div>
                            </li>
                        </ul>
                    </li>
                    <li class="header">Employee</li>
                    <li>
                        <a class="menu-toggle">
                            <i class="material-icons">assignment_ind</i>
                            <span>Employee Management</span>
                        </a>
                        <ul class="ml-menu">
                            <li>
                                <a href="EmployeeDetails.aspx">Employees</a>
                            </li>
                            <li>
                                <a class="menu-toggle">Employee Health</a>
                              
                                <ul class="ml-menu">
                                    <li>
                                        <a href="EmployeeHealthDetails.aspx" >
                                            <span>Employee Health Package</span>

                                        </a>
                                    </li>
                                    <li>
                                        <a href="TestResultUpload.aspx">
                                            <span>Test Result Bulk Upload</span>
                                        </a>
                                    </li>
                                 </ul>
                            </li>
                          <%--  <li>
                                <a href="EmployeeInsuranceDetails.aspx">Employee Health Insurance</a>
                            </li>--%>
                            <%--<li>
                                <a href="TestDetails.aspx">Assign Test</a>
                            </li>--%>
                             <li>
                                <a href="EmployeeBulkUploadDetails.aspx">Employees Bulk Upload</a>
                            </li>
                        </ul>
                    </li>
                    <li class="header">Master</li>
                    <li>
                        <a class="menu-toggle">
                            <i class="material-icons">assignment</i>
                            <span>Master Management</span>
                        </a>
                        <ul class="ml-menu">
                            <li>
                                <a href="Department.aspx">Department</a>
                            </li>
                            <li>
                                <a  class="menu-toggle">
                                    District
                                </a>
                                <ul class="ml-menu">
                                    <li>
                                        <a href="Branch.aspx">
                                            <span>District Master</span>
                                        </a>
                                    </li>
                                     <%--<li>
                                        <a href="Branch.aspx">
                                            <span>User Branch Assign</span>
                                        </a>
                                    </li>--%>
                                    <%-- <li>
                                        <a href="Branch.aspx">
                                            <span>Branch-SubBranch assign</span>
                                        </a>
                                    </li>--%>
                                </ul>
                                <%--<a href="Branch.aspx">Branch</a>--%>
                            </li>
                            <li>
                                <a href="Test.aspx">Test</a>
                            </li>
                            <li>
                                <a href="Hospital_LabMaster.aspx">Path Lab Master</a>
                            </li> 
                          <%--  <li>
                                <a href="UserDetails.aspx">User Registration</a>
                            </li>--%>
                        </ul>
                    </li>

			 <li class="header"> Reports</li>
                       <li>
                          <a class="menu-toggle">
                            <i class="material-icons">assignment</i>
                            <span>MIS Reports</span>
                        </a>
                        <ul class="ml-menu">
                            <li>
                                <a href="MIS_Reports.aspx">MIS Reports</a>
                                </li>
                            </ul>
                      </li>
                </ul>
            </div>
            <!-- Footer -->
            <div class="legal">
                <div class="copyright">
                    &copy;Powered By <a href="https://howzu.co.in">Visionary Life Science</a>.
                </div>
                <%-- <div class="version">
                    <b>Version: </b> 1.0.5
                </div>--%>
            </div>
            <!-- #Footer -->

        </aside>

        <!-- #END# Left Sidebar -->
        <!-- Right Sidebar -->
        <aside id="rightsidebar" class="right-sidebar">
            <ul class="nav nav-tabs tab-nav-right" role="tablist">
                <li role="presentation" class="active"><a href="#skins" data-toggle="tab">SKINS</a></li>
                <li role="presentation"><a href="#settings" data-toggle="tab">SETTINGS</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane fade in active in active" id="skins">
                    <ul class="demo-choose-skin">
                        <li data-theme="red" class="active" id="r">
                            <div class="red"><a href="Default.aspx?colorId=1"></a></div>
                            <span>Red</span>
                        </li>
                        <li data-theme="pink" id="p">
                            <div class="pink"><a href="Default.aspx?colorId=2"></a></div>
                            <span>Pink</span>
                        </li>
                        <li data-theme="purple" id="prpl">
                            <div class="purple"><a href="Default.aspx?colorId=3"></a></div>
                            <span>Purple</span>
                        </li>
                        <li data-theme="deep-purple">
                            <div class="deep-purple" id="dprpl"></div>
                            <span>Deep Purple</span>
                        </li>
                        <li data-theme="indigo">
                            <div class="indigo" id="indgo"></div>
                            <span>Indigo</span>
                        </li>
                        <li data-theme="blue">
                            <div class="blue" id="bl"></div>
                            <span>Blue</span>
                        </li>
                        <li data-theme="light-blue">
                            <div class="light-blue" id="lgtbl"></div>
                            <span>Light Blue</span>
                        </li>
                        <li data-theme="cyan">
                            <div class="cyan" id="cyn"></div>
                            <span>Cyan</span>
                        </li>
                        <li data-theme="teal">
                            <div class="teal" id="tl"></div>
                            <span>Teal</span>
                        </li>
                        <li data-theme="green">
                            <div class="green" id="grn"></div>
                            <span>Green</span>
                        </li>
                        <li data-theme="light-green">
                            <div class="light-green" id="lgtrn"></div>
                            <span>Light Green</span>
                        </li>
                        <li data-theme="lime">
                            <div class="lime" id="lm"></div>
                            <span>Lime</span>
                        </li>
                        <li data-theme="yellow">
                            <div class="yellow" id="ylo"></div>
                            <span>Yellow</span>
                        </li>
                        <li data-theme="amber">
                            <div class="amber" id="ambr"></div>
                            <span>Amber</span>
                        </li>
                        <li data-theme="orange">
                            <div class="orange" id="orng"></div>
                            <span>Orange</span>
                        </li>
                        <li data-theme="deep-orange">
                            <div class="deep-orange" id="dporng"></div>
                            <span>Deep Orange</span>
                        </li>
                        <li data-theme="brown">
                            <div class="brown" id="brn"></div>
                            <span>Brown</span>
                        </li>
                        <li data-theme="grey">
                            <div class="grey" id="gry"></div>
                            <span>Grey</span>
                        </li>
                        <li data-theme="blue-grey">
                            <div class="blue-grey" id="blugry"></div>
                            <span>Blue Grey</span>
                        </li>
                        <li data-theme="black">
                            <div class="black" id="blk"></div>
                            <span>Black</span>
                        </li>
                    </ul>
                </div>
                <div role="tabpanel" class="tab-pane fade" id="settings">
                    <div class="demo-settings">
                        <p>GENERAL SETTINGS</p>
                        <ul class="setting-list">
                            <li>
                                <span>Report Panel Usage</span>
                                <div class="switch">
                                    <label>
                                        <input type="checkbox" checked><span class="lever"></span></label>
                                </div>
                            </li>
                            <li>
                                <span>Email Redirect</span>
                                <div class="switch">
                                    <label>
                                        <input type="checkbox"><span class="lever"></span></label>
                                </div>
                            </li>
                        </ul>
                        <p>SYSTEM SETTINGS</p>
                        <ul class="setting-list">
                            <li>
                                <span>Notifications</span>
                                <div class="switch">
                                    <label>
                                        <input type="checkbox" checked><span class="lever"></span></label>
                                </div>
                            </li>
                            <li>
                                <span>Auto Updates</span>
                                <div class="switch">
                                    <label>
                                        <input type="checkbox" checked><span class="lever"></span></label>
                                </div>
                            </li>
                        </ul>
                        <p>ACCOUNT SETTINGS</p>
                        <ul class="setting-list">
                            <li>
                                <span>Offline</span>
                                <div class="switch">
                                    <label>
                                        <input type="checkbox"><span class="lever"></span></label>
                                </div>
                            </li>
                            <li>
                                <span>Location Permission</span>
                                <div class="switch">
                                    <label>
                                        <input type="checkbox" checked><span class="lever"></span></label>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </aside>
        <!-- #END# Right Sidebar -->
    </section>

    <section class="content">
        <div class="container-fluid">

            <div class="block-header">
                <h2>DASHBOARD</h2>
            </div>

            <!-- Widgets -->
            <div class="row clearfix">
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-pink "><!--hover-expand-effect-->
                        <div class="icon">
                            <i class="material-icons">group</i>
                        </div>
                        <div class="content">
                            <div class="text"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/EmployeeDetails.aspx" ForeColor="White">Employee</asp:HyperLink></div>
                            <div class="number count-to" data-from="0" data-to="125" data-speed="15" data-fresh-interval="20">
                                <asp:Label ID="lblEmpCounter" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-cyan"><!-- hover-expand-effect-->

                        <div class="icon">
                            <i class="material-icons">location_city</i>
                        </div>
                        <div class="content">
                            <div class="text">  <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Department.aspx" ForeColor="White">Department</asp:HyperLink></div>
                            <div class="number count-to" data-from="0" data-to="257" data-speed="1000" data-fresh-interval="20">
                                <asp:Label ID="lblDeptCounter" runat="server" Text="0"></asp:Label></div>

                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-green"><!-- hover-expand-effect-->
                        <div class="icon">
                            <i class="material-icons">mood</i>
                        </div>
                        <div class="content">
                            <div class="text"><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/empHealth.aspx?g_dtls=Healthy" ForeColor="White">Healthy</asp:HyperLink></div>
                            <div class="number count-to" data-from="0" data-to="125" data-speed="15" data-fresh-interval="20">
                                <asp:Label ID="lblHealthyCounter" runat="server" Text="0"></asp:Label></div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-red "><!--hover-expand-effect-->
                        <div class="icon">
                            <i class="material-icons">mood_bad</i>
                        </div>
                        <div class="content">
                            <div class="text"><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/empHealth.aspx?g_dtls=Unhealthy" ForeColor="White">Unhealthy</asp:HyperLink></div>
                            <div class="number count-to" data-from="0" data-to="257" data-speed="1000" data-fresh-interval="20">
                                <asp:Label ID="lblUnhealthyCounter" runat="server" Text="0"></asp:Label></div>
                        </div>
                    </div>
                </div>


            </div>
            <!-- #END# Widgets -->

            <!-- New Widgets -->
            <div class="row clearfix">

                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-blue "><!--hover-expand-effect-->
                        <div class="icon">
                            <i class="material-icons">timelapse</i>
                        </div>
                        <div class="content">
                            <div class="text"><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/TestPendingDetails.aspx" ForeColor="White">Test Pending</asp:HyperLink></div>
                            <div class="number count-to" data-from="0" data-to="243" data-speed="1000" data-fresh-interval="20">
                                <asp:Label ID="lbltestPendingCounter" runat="server" Text="0"></asp:Label></div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-purple "><!--hover-expand-effect-->
                        <div class="icon">
                            <i class="material-icons">check</i>
                        </div>
                        <div class="content">
                            <div class="text"><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/topVer.aspx" ForeColor="White">Test Completed</asp:HyperLink></div>
                            <div class="number count-to" data-from="0" data-to="1225" data-speed="1000" data-fresh-interval="20">
                                <asp:Label ID="lbltestCompletedCounter" runat="server" Text="0"></asp:Label></div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-orange "><!--hover-expand-effect-->
                        <div class="icon">
                            <i class="material-icons">colorize</i>
                        </div>
                        <div class="content">
                            <div class="text"><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/dtl_chart.aspx" ForeColor="White">Fully Vaccinated</asp:HyperLink></div>
                            <div class="number count-to" data-from="0" data-to="1225" data-speed="1000" data-fresh-interval="20">
                                <asp:Label ID="lblFullvaccineCounter" runat="server" Text="0"></asp:Label></div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-grey "><!--hover-expand-effect-->
                        <div class="icon">
                            <i class="material-icons">device_hub</i>
                        </div>
                        <div class="content">
                            <div class="text">  <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Branch.aspx" ForeColor="White">District</asp:HyperLink></div>
                            <div class="number count-to" data-from="0" data-to="243" data-speed="1000" data-fresh-interval="20">
                                <asp:Label ID="lblBranchCounter" runat="server" Text="0"></asp:Label></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# New Widgets -->

            <!--Chart Section -->

            <!--New Section -->
            <div class="row clearfix">
                <%-- <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">--%>
                <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8">
                    <div class="card">
                        <div class="header">
                            <asp:HiddenField ID="HDepartmentCount" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HDepartmentName" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HDepartmentTotal" runat="server" ClientIDMode="Static" />
                            <h2>TOP VULNEREBILITIES</h2>
                        </div>
                        <div class="body">
                            <%--  <canvas id="donut_chart" height="150"></canvas>--%>
                            <canvas id="headCountPieChart" height="300"></canvas>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <asp:HiddenField ID="HhealthName" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HhealthCount" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HhealthTotal" runat="server" ClientIDMode="Static" />
                            <h2>EMPLOYEE HEALTH RATIO</h2>
                        </div>
                        <div class="body">
                            <canvas id="health_pie_chart" height="150"></canvas>
                            <%-- <canvas id="healthCountPieChart" height="200"></canvas>--%>
                        </div>
                    </div>
                </div>
                <%--<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">--%>
            </div>
            <div class="row clearfix">
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <asp:HiddenField ID="HAgegroupAmt" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HGender" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HTestCountGender" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HTotalGenderTestCount" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="h_v_status" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="h_v_count" runat="server" ClientIDMode="Static" />
                            <h2>COVID VACCINATED</h2>

                        </div>

                        <div class="body">
                            <canvas id="pie_chart" height="50"></canvas>

                        </div>
                    </div>

                </div>
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <asp:HiddenField ID="HAgeMale" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HAgeFemale" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HEmpGender" runat="server" ClientIDMode="Static" />
                            <h2>EMPLOYEE AGE RATIO</h2>
                        </div>
                        <div class="body">
                            <canvas id="bar_chart" height="287"></canvas>

                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <h2>TEST COUNT</h2>
                            <asp:HiddenField ID="htestStatus" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="htestCount" runat="server" ClientIDMode="Static" />
                        </div>
                        <div class="body">
                            <canvas id="emp_bar_chart" height="285"></canvas>

                        </div>
                    </div>
                </div>

            </div>
            <div class="row clearfix">
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <h2>BLOOD GROUP RATIO</h2>
                            <asp:HiddenField ID="hBGgender" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hbldgrpCount" runat="server" ClientIDMode="Static" />
                        </div>
                        <div class="body">

                            <canvas id="h_bar_chart" height="285"></canvas>

                        </div>

                    </div>
                </div>
                <!-- #END# Line Chart -->
                <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8">
                    <div class="card">
                        <div class="header">

                            <asp:HiddenField ID="h_dept" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="h_male_count" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="h_female_count" runat="server" ClientIDMode="Static" />
                            <h2>DEPARTMENT 
                             
                            </h2>
                        </div>
                        <div class="body">
                            <%--<canvas id="line_chart" height="128"></canvas>--%>
                            <canvas id="bar_chart_stacked" height="128"></canvas>
                        </div>

                    </div>
                </div>

            </div>
            <div class="row clearfix">
                <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8">
                    <div class="card">
                        <div class="body" style="height: 355px">

                            <%--<img src="images/howzu_img.png" style="width: 100%; height: 100%; object-fit: cover;" />--%>
                              <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                                <!-- Indicators -->
                                <ol class="carousel-indicators">
                                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                                </ol>

                                <!-- Wrapper for slides -->
                                <div class="carousel-inner" role="listbox">

                                    <%--<div class="item active">
                                        <asp:Repeater ID="repeaterNivoSlider" runat="server">
                                            <ItemTemplate>
                                                <a href="http://dev7studios.com">
                                                    <img src='<%#"images/"+Eval("ImagePath") %>' data-thumb="<%#"images/"+Eval("ImagePath") %>"
                                                        alt="" title="This is an example of a caption" /></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>--%>
                                    <div class="item active">
                                        <%--<img src="../../images/image-gallery/11.jpg" />--%>
                                        <img src="images/appfeature.png" style="width: 100%; height: 100%;" />
                                    </div>
                                    <div class="item">
                                        <img src="images/appinfo.png" style="width: 100%; height: 100%;"/> 
                                    </div>
                                    <div class="item">
                                        <img src="images/bmi calcuter.png" style="width: 100%; height: 100%;"/>
                                    </div>
                                     <div class="item">
                                         <img src="images/download app.png" style="width: 100%; height: 100%;"/>
                                    </div>
                                     <div class="item">
                                         <img src="images/cowin.png" style="width: 100%; height: 100%;"/>
                                    </div>
                                </div>

                                <!-- Controls -->
                                <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                    <span class="sr-only">Previous</span>
                                </a>
                                <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                    <span class="sr-only">Next</span>
                                </a>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <h2>GENDER COUNT</h2>

                        </div>
                        <div class="body">

                            <img src="images/genderchart.png" height="200" width="250" />
                            <h3><span id="spanMale"
                                runat="server" clientidmode="Static" style="margin-left: 0px; margin-top: 0px;">0</span>
                                <span id="spanFemale"
                                    runat="server" clientidmode="Static" style="margin-left: 150px; margin-top: 0px;">0</span>
                            </h3>

                        </div>
                    </div>
                </div>
                <!-- #END# Gender Chart -->
                <!--End New Section -->
                <!-- #END# Chart Section -->
            </div>
        </div>
    </section>

      <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript" src="NivoSlider/jquery.nivo.slider.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>
</asp:Content>



