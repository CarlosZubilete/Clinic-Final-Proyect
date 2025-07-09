<%@ Page Title="" Language="C#" MasterPageFile="~/Clinica.Master" AutoEventWireup="true" CodeBehind="AddMedico.aspx.cs" Inherits="Views.AddMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
  <asp:Label ID="lblShowData" runat="server" Text=""></asp:Label>
</asp:Content>
