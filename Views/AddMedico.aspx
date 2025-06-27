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
        <asp:RegularExpressionValidator ID="regexLegajo" runat="server" ControlToValidate="txtLegajo" ValidationExpression="^(?!00000)\d{5}$" Text="It must be 5 numbers"></asp:RegularExpressionValidator>
      </div>
      <hr />
      <%-- ESPECIALIDAD --%>
      <div>
        ESPECIALIDAD: 
        <asp:DropDownList ID="ddlSpecialy" runat="server">
          <asp:ListItem Value="0" Enabled="True">-- Seleccionar -- </asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="requiredSpeciality" runat="server" ControlToValidate="ddlSpecialy" InitialValue="0" Text="This field is requeried"></asp:RequiredFieldValidator>
      </div>
      <hr />
      <%-- HORAIOS ATENCION  --%>
      <div>
        HORARIOS ATENCION : 
        <asp:DropDownList ID="ddlHorariosAtencion" runat="server">
          <asp:ListItem Value="0" Enabled="True"> -- Seleccionar -- </asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="requiredHorarios" runat="server" ControlToValidate="ddlHorariosAtencion" InitialValue="0" Text="This field is requeried"></asp:RequiredFieldValidator>
      </div>
      <hr />
      <%-- DIAS LABORALES --%>
      <div>
        DIAS LABORALES : 
        <asp:DropDownList ID="ddlDiasAtencion" runat="server">
          <asp:ListItem Value="0" Enabled="True"> -- Seleccionar -- </asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="requiredDias" runat="server" ControlToValidate="ddlDiasAtencion" InitialValue="0" Text="This field is requeried"></asp:RequiredFieldValidator>
      </div>
    </div>
    <hr />
    <%-- ADD MEDICO --%>
    <hr />
    <asp:Button ID="btnAdd" runat="server" Text="Agregar Medico" OnClick="btnAdd_Click" />
    <hr />
    <asp:Label ID="lblShowData" runat="server" Text="Label"></asp:Label>
  </form>
</body>
</html>
