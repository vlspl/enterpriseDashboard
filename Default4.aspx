<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-6">
                    <div class="custom-file mb-4">
                        <asp:FileUpload ID="file_upload" class="custom-file-input" runat="server" ClientIDMode="Static" />
                        <label class="custom-file-label text-center" for="file_upload">
                           </label><asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-3">
                    <asp:Button runat="server" ID="btnUpload" ClientIDMode="Static" Text="Upload" class="fa fa-save btn btn-primary"
                        OnClick="btnUpload_Click" />
                    <%--<asp:Button Text="Upload" OnClick="Upload" runat="server" />--%>
                </div>
            </div>
          <%--  <div class="row py-1 color" style="font-weight: bold;">
                <div class="col-lg-12 text-center">
                    OR</div>
            </div>--%>
    </form>
</body>
</html>
