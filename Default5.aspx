<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">    
    <div style="color: White;">    
        <h4>    
            Article for C#Corner    
        </h4>    
        <table>    
            <tr>    
                <td>    
                    Select File    
                </td>    
                <td>    
                    <asp:FileUpload ID="FileUpload1" runat="server" /> 
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>    
                <td>    
                </td>    
                <td>    
                    <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />    
                </td>    
            </tr>    
        </table>    
    </div>    
    </form>    
</body>
</html>
