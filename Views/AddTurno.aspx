<%@ Page Title="" Language="C#" MasterPageFile="~/Clinica.Master" AutoEventWireup="true" CodeBehind="AddTurno.aspx.cs" Inherits="Views.AddTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%-- SCRIPT MANAGER --%>
  <asp:ScriptManager runat="server" ID="scriptManager" />

  <%-- DNI PACIENTE --%>
  <div>
    <span>DNI PACIENTE:</span>
    <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="requiredDNI" runat="server" Display="Dynamic" ControlToValidate="txtDNI" Text="This field is required"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regexDNI" runat="server" ControlToValidate="txtDNI" ValidationExpression="^[1-9][0-9]*$" Text="Only numbers"></asp:RegularExpressionValidator>
    <asp:RangeValidator ID="rangeDNI" runat="server" ControlToValidate="txtDNI" Display="Dynamic" Text="Must be 8 numbers" Type="Integer" MaximumValue="99999999" MinimumValue="10000000"></asp:RangeValidator>
    <hr />
    <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>
    <hr />
    <asp:Button ID="btnLookup" runat="server" Text="Buscar" OnClick="btnLookup_Click" />
  </div>
  <hr />
  <div>
    <%-- UPPANEL FOR THE DROP-DOWN-LIST --%>
    <asp:UpdatePanel ID="UpdatePanel_DDL" runat="server">
      <ContentTemplate>
        <h3>Lookup Turno:</h3>
        <div>

          <span>Date Turno: </span>
          <asp:TextBox ID="txtDateTurno" runat="server"></asp:TextBox>
          <%-- REGEX VALIDATION --%>
          <asp:RegularExpressionValidator ID="regexDate" runat="server" Text="Invalided Date"
            ValidationExpression="^(0[1-9]|1[0-9]|2[0-9]|3[01])-(0[1-9]|1[0-2])-([12][0-9]{3})$"
            Display="Dynamic" ControlToValidate="txtDateTurno"></asp:RegularExpressionValidator>
          <%-- DDL SPECIALITIES --%>
          <div>
            <span>ESPECIALIDAD: </span>
            <asp:DropDownList ID="ddlSpecialities" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSpecialities_SelectedIndexChanged">
              <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredSpecialities" runat="server" Text="You must select one" ControlToValidate="ddlSpecialities" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
          </div>
          <%-- BUTTON --%>
          <asp:Button ID="btnSendTurno" runat="server" Text="Find" OnClick="btnSendTurno_Click" ValidationGroup="test" />

        </div>
        <hr />
        <div>
          <div>
            <span>MEDICOS:</span>
            <asp:DropDownList ID="ddlSpecialityDoctors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSpecialityDoctors_SelectedIndexChanged">
              <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredDoctorSpeciality" runat="server" Text="You must select one" ControlToValidate="ddlSpecialityDoctors" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
          </div>
          <asp:Label runat="server" ID="lblDateError"></asp:Label>

        </div>

        <hr />

        <%-- TURNO DISPONIBILIDAD --%>
        <%-- DIAS DISPONIBILIDAD --%>
        <div>
          <span>Dias Disponibles: </span>
          <asp:DropDownList ID="ddlDaysAvailable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDaysAvailable_SelectedIndexChanged">
            <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator ID="requiredDaysAvailable" runat="server" Text="You must select one" ControlToValidate="ddlDaysAvailable" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
        </div>
        <hr />

        <%-- TURNO DISPONIBILIDAD --%>
        <%-- HORARIOS DISPONIBILIDAD --%>
        <div>
          <span>Horarios Disponibles: </span>
          <asp:DropDownList ID="ddlDoctorsSchedules" runat="server">
            <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator ID="requiredDoctorSchedules" runat="server" Text="You must select one" ControlToValidate="ddlDoctorsSchedules" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
        </div>

        <hr />
        <%-- LABEL SHOW --%>
        <asp:Label ID="lblShow" runat="server" Text=""></asp:Label>

      </ContentTemplate>
    </asp:UpdatePanel>
  </div>

</asp:Content>

<%-- 
  TODO: Don't forget do to fecha Turno and Pacient's observation
  --%>