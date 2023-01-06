<%@ Page Title="" Language="C#" MasterPageFile="~/EnterpriseMasterPage.master" AutoEventWireup="true" CodeFile="DefaultNew.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="NewChart.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
  
    <section class="content">
        <div class="container-fluid">

            <div class="block-header">
                <h2>DASHBOARD</h2>
            </div>

            <!-- Widgets -->
            <div class="row clearfix">
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-pink hover-expand-effect">
                        <div class="icon">
                            <i class="material-icons">group</i>
                        </div>
                        <div class="content">
                            <div class="text">Employee</div>
                            <div class="number count-to" data-from="0" data-to="125" data-speed="15" data-fresh-interval="20">100,000</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-cyan hover-expand-effect">
                        
                        <div class="icon">
                            <i class="material-icons">location_city</i>
                        </div>
                        <div class="content">
                            <div class="text">Department</div>
                            <div class="number count-to" data-from="0" data-to="257" data-speed="1000" data-fresh-interval="20">752</div>
                        
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-grey hover-expand-effect">
                        <div class="icon">
                            <i class="material-icons">device_hub</i>
                        </div>
                        <div class="content">
                            <div class="text">Branch</div>
                            <div class="number count-to" data-from="0" data-to="243" data-speed="1000" data-fresh-interval="20">468</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-orange hover-expand-effect">
                        <div class="icon">
                            <i class="material-icons">colorize</i>
                        </div>
                        <div class="content">
                            <div class="text">Fully Vaccinated</div>
                            <div class="number count-to" data-from="0" data-to="1225" data-speed="1000" data-fresh-interval="20">26,352</div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Widgets -->

              <!-- New Widgets -->
            <div class="row clearfix">
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-green hover-expand-effect">
                        <div class="icon">
                            <i class="material-icons">mood</i>
                        </div>
                        <div class="content">
                            <div class="text">Healthy</div>
                            <div class="number count-to" data-from="0" data-to="125" data-speed="15" data-fresh-interval="20">58,000</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-red hover-expand-effect">
                        <div class="icon">
                            <i class="material-icons">mood_bad</i>
                        </div>
                        <div class="content">
                            <div class="text">Unhealthy</div>
                            <div class="number count-to" data-from="0" data-to="257" data-speed="1000" data-fresh-interval="20">42,000</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-blue hover-expand-effect">
                        <div class="icon">
                            <i class="material-icons">timelapse</i>
                        </div>
                        <div class="content">
                            <div class="text">Test Pending</div>
                            <div class="number count-to" data-from="0" data-to="243" data-speed="1000" data-fresh-interval="20">768</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box bg-purple hover-expand-effect">
                        <div class="icon">
                            <i class="material-icons">check</i>
                        </div>
                        <div class="content">
                            <div class="text">Test Completed</div>
                            <div class="number count-to" data-from="0" data-to="1225" data-speed="1000" data-fresh-interval="20">26,052</div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# New Widgets -->


            <!--Chart Section -->
            <div class="row clearfix">
                <!-- Line Chart -->
                <!--<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">-->

                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <asp:HiddenField ID="h_dept" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="h_male_count" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="h_female_count" runat="server" ClientIDMode="Static" />
                         
                               <h2>Department 
                             
                               </h2>
                        </div>
                        <div class="body">
                           <canvas id="line_chart" height="150"></canvas>
                             
                        </div>
                        <%-- <div class="card-body">
                                <div id="pieChart" class="chart2 pie">
                                    <div class="chart-pie pt-4 pb-2">
                                        <canvas id="headCountPieChart"></canvas>
                                    </div>
                                </div>
                            </div>--%>
                    </div>
                </div>
                <!-- #END# Line Chart -->
                <!-- Bar Chart -->
                <!--<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">-->
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <asp:HiddenField ID="HAgeMale" runat="server" ClientIDMode="Static" />
                              <asp:HiddenField ID="HAgeFemale" runat="server" ClientIDMode="Static" />
                             <asp:HiddenField ID="HEmpGender" runat="server" ClientIDMode="Static" />


                            <h2>EMPLOYEE AGE RATIO</h2>
                             
                            
                        </div>
                        
                        <div class="body">
                            <canvas id="bar_chart" height="150"></canvas>
                          <%--   <canvas id="empCountPieChart" height="250"></canvas>--%>
                        </div>
                    </div>
                </div>
                <!-- #END# Bar Chart -->
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">

                    <div class="card">
                        <div class="header">
                             <asp:HiddenField ID="HAgegroupAmt" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HGender" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HTestCountGender" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HTotalGenderTestCount" runat="server" ClientIDMode="Static" />
                            <h2>COVID VACCINATED</h2>
                        
                               <asp:HiddenField ID="h_v_status" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="h_v_count" runat="server" ClientIDMode="Static" />

                        </div>
                      
                        <div class="body">
                            <%--<canvas id="pie_chart" height="150"></canvas>--%>
                           <%-- <canvas id="h_bar_chart" height="150"></canvas>--%>
                            <canvas id="testCountPieChart"></canvas>
                        </div>
                    </div>

                </div>

            </div>

            <div class="row clearfix">
                <!-- Radar Chart -->
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>BLOOD GROUP RATIO</h2>

                        </div>
                        <div class="body">
                            <asp:Chart ID="Chart1" runat="server" Height="300px" Width="400px" Visible="false">
                                <Titles>
                                    <asp:Title ShadowOffset="3" Name="Items" />
                                </Titles>
                                <Legends>
                                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                        LegendStyle="Row" />
                                </Legends>
                                <Series>
                                    <asp:Series Name="Default" />
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                                </ChartAreas>
                            </asp:Chart>
                           <%-- <canvas id="radar_chart" height="150"></canvas>--%>
                         
                        </div>

                    </div>
                </div>
                <!-- #END# Radar Chart -->
                <!-- Pie Chart -->
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                               <asp:HiddenField ID="HDepartmentCount" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HDepartmentName" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HDepartmentTotal" runat="server" ClientIDMode="Static" />
                            <h2>TOP VULNEREBILITIES</h2>
                               
                        </div>
                        <div class="body">
<%--                            <canvas id="donut_chart" height="150"></canvas>--%>
                            <canvas id="headCountPieChart" height="250"></canvas>
                        </div>
                    </div>
                </div>
                <!-- #END# Pie Chart -->
            </div>

            <div class="row clearfix">
                <!-- Gender Chart -->
                <!--<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">-->

                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <h2>Gender Count</h2>

                        </div>
                        <div class="body">
                           <%-- <canvas id="line_chart" height="150"></canvas>--%>
                            <img src="images/genderchart.png" height="150" width="250"/>
                            <h3><span id="spanMale"
                                    runat="server" clientidmode="Static" style="margin-left:0px;margin-top:0px;">0</span>
                                <span id="spanFemale"
                                    runat="server" clientidmode="Static" style="margin-left:75px;margin-top:0px;">0</span>
                            </h3>
                           
                        </div>
                    </div>
                </div>
                <!-- #END# Gender Chart -->
                <!-- Donut Chart -->
                <!--<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">-->
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                    <div class="card">
                        <div class="header">
                            <h2>Test Count</h2>

                        </div>
                        <div class="body">
                            <canvas id="donut_chart1" height="150"></canvas>

                        </div>
                    </div>
                </div>
                <!-- #END# Donut Chart -->

                   <!-- Pie Chart -->
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">

                    <div class="card">
                        <div class="header">
                             <asp:HiddenField ID="HhealthName" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HhealthCount" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="HhealthTotal" runat="server" ClientIDMode="Static" />
                            <h2>Employee Health Chart</h2>
                        
                        </div>
                        <div class="body">
                          <%--  <canvas id="pie_chart1" height="150"></canvas>--%>
                                
                             <canvas id="healthCountPieChart" height="250"></canvas> 
                               <%--<canvas id="h_bar_chart" height="150"></canvas> --%>
                        </div>
                    </div>

                </div>
                   <!-- #END# Pie Chart -->
            </div>

            <!-- #END# Chart Section -->
        </div>
    </section>
           
         
</asp:Content>

