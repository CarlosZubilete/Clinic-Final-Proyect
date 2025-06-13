<%@ Page Language="C#" AutoEventWireup="true"
  UnobtrusiveValidationMode="None"
  CodeBehind="Index.aspx.cs" Inherits="Views.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Clinica</title>
</head>
<body>
  <form id="form1" runat="server">
    <h1>Hi! I'm index</h1>
    <div>
      <spam>
        Provincias: 
        <asp:DropDownList ID="ddlProvincies" runat="server">
          <asp:ListItem Value="0" Enabled="True">-- Seleccionar -- </asp:ListItem>
        </asp:DropDownList>
      </spam>
    </div>
  </form>
</body>
</html>
