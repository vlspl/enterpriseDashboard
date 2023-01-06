<%@ Page Title="" Language="C#" MasterPageFile="~/EnterpriseMasterPage.master" AutoEventWireup="true" CodeFile="OldLabMaster.aspx.cs" Inherits="LabMaster" %>

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
                    <!-- Inline Layout | With Floating Label -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Lab Master
                                <!--<small>With floating label</small>-->
                                    </h2>
                                  <%--  <div style="float:right">
                                        <asp:Button ID="Button1" runat="server" Text="Add New Branch" class="btn bg-purple waves-effect"/>

                                    </div>--%>
                                </div>
                                <div class="body" id="branch">
                                    <form>
                                        <div class="row clearfix">
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b><asp:Label ID="Label1" runat="server" Text="Lab Name"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtLabNm" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="txtLabNm" runat="server" Text="0" class="form-control"></asp:Label>
                                                    </div>
                                                </div>
                                                <%--<asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtbranchName" ErrorMessage="Please enter Branch" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                       <b> <asp:Label ID="Label2" runat="server" Text="Lab Address"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="txtAddress" runat="server" Text="0" class="form-control"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                         <b><asp:Label ID="Label3" runat="server" Text="Email ID"></asp:Label></b>
                                                          <%--<asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                     <asp:Label ID="txtEmail" runat="server" Text="0" class="form-control"></asp:Label>
                                                       

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row clearfix">
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label4" runat="server" Text="Contact No"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtContact" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="txtContact" runat="server" Text="0" class="form-control"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>


                                            <%--<asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtbranchName" ErrorMessage="Please enter Branch" ForeColor="Red"></asp:RequiredFieldValidator>--%>


                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label5" runat="server" Text="Lab Owner"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtOwner" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="txtOwner" runat="server" Text="0" class="form-control"></asp:Label>
                                                      

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                         <b> <asp:Label ID="Label6" runat="server" Text="Longitude/Latitude"></asp:Label></b>
                                                        <asp:TextBox ID="txtLongiLatitude" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                         <div class="row clearfix">
                                         
                                               
                                                    <div>
                                                       <center> <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="btnClose_Click"/> </center>
                                                    </div>
                                                
                                           
                                             </div>
                                    
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- #END# Inline Layout | With Floating Label -->
                  
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>

