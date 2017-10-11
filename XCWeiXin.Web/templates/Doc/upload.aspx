<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Image ID="Image1" Width="60px" Height="40px" runat="server" />
      <asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click" />
      <asp:Button ID="Button2" runat="server" Text="最新上传" OnClick="Button2_Click" />

    </div>
      
    </form>
</body>
</html>
