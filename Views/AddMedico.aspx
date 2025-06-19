<%@ Page
  Language="C#" AutoEventWireup="true"
  UnobtrusiveValidationMode="None"
  CodeBehind="AddMedico.aspx.cs" Inherits="Views.AddMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <h1>Hi! I'm Add Medico Page</h1>
  <form id="form1" runat="server">
    <%-- DATOS GOT --%>
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
    <div>
      <%-- N° LEGAJO --%>

      <%-- ESPECIALIDAD --%>

      <%-- HORAIOS ATENCION  --%>

      <%-- DIAS LABORALES --%>
    </div>
  </form>
</body>
</html>
