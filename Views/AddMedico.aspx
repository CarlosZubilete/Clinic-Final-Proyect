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
  <h1>Hi! Please complete the next field</h1>
  <form id="form1" runat="server">
    <%-- DATOS THAT WE'VE GOTTEN FROM --%>
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
      <div>
        Legajo Medico:
        <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
        <%-- REQUIRED --%>
        <asp:RequiredFieldValidator ID="requiredLegajo" runat="server" Display="Dynamic" ControlToValidate="txtLegajo" Text="This field is required"></asp:RequiredFieldValidator>
        <%-- ONLY NUMBER --%>
        <asp:RegularExpressionValidator ID="regexDNI" runat="server" ControlToValidate="txtLegajo" ValidationExpression="^[1-9][0-9]*$" Text="Only numbers"></asp:RegularExpressionValidator>
        <%-- RANGE 6 NUMBERS --%>
<%--        <asp:RangeValidator ID="rangeDNI" runat="server" ControlToValidate="txtDNI" Display="Dynamic" Text="Must be 6 numbers" Type="Integer" MaximumValue="999999" MinimumValue="100000"></asp:RangeValidator>--%>
      </div>
      <%-- ESPECIALIDAD --%>
      <div>
        Speciality: 
        <asp:DropDownList ID="ddlSpecialy" runat="server"></asp:DropDownList>
      </div>
      <%-- HORAIOS ATENCION  --%>

      <%-- DIAS LABORALES --%>
    </div>
  </form>
</body>
</html>
