<%@ Page Language="C#" AutoEventWireup="true"
  UnobtrusiveValidationMode="None"
  CodeBehind="AddPaciente.aspx.cs" Inherits="Views.AddPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <h1>HI , I'm Paciente Page</h1>
    <div>
      <span>DNI:
        <asp:Label ID="lblDNI" runat="server"></asp:Label>
      </span>
      <span>Full Name: 
        <asp:Label ID="lblFullName" runat="server"></asp:Label>
      </span>
      <span>Birthdate
        <asp:Label ID="lblBirthdate" runat="server"></asp:Label>
      </span>
    </div>
  </form>
</body>
</html>
