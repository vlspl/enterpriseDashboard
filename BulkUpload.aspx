<%@ Page Title="" Language="C#" MasterPageFile="~/EnterpriseMasterPage.master" AutoEventWireup="true" CodeFile="BulkUpload.aspx.cs" Inherits="BulkUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-6">
                    <div class="custom-file mb-4">
                        <asp:FileUpload ID="file_upload" class="custom-file-input" runat="server" ClientIDMode="Static" />
                        <label class="custom-file-label text-center" for="file_upload">
                            Choose file</label><asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnUpload" ClientIDMode="Static" Text="Upload" class="fa fa-save btn btn-primary"
                        OnClick="btnUpload_Click" />
                </div>
            </div>
            <div class="row py-1 color" style="font-weight: bold;">
                <div class="col-lg-12 text-center">
                    OR</div>
            </div>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>

