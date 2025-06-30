<%@ Page Language="C#" AutoEventWireup="true"
  UnobtrusiveValidationMode="None"
  CodeBehind="AddTurno.aspx.cs" Inherits="Views.AddTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <h1>Hi, I'm The Turno Page :D</h1>
  <form id="form1" runat="server">

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

    <%-- ESPECIALIDAD --%>
    <div>
      <%-- UPPANEL FOR THE DROP-DOWN-LIST --%>
      <asp:UpdatePanel ID="UpdatePanel_DDL" runat="server">
        <ContentTemplate>
          <div>
            <span>ESPECIALIDAD: </span>
            <asp:DropDownList ID="ddlSpecialities" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSpecialities_SelectedIndexChanged">
              <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredSpecialities" runat="server" Text="You must select one" ControlToValidate="ddlSpecialities" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
          </div>
          <hr />
          <%-- LEGAJO MEDICO --%>
          <div>
            <span>MEDICOS:</span>
            <asp:DropDownList ID="ddlSpecialityDoctors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSpecialityDoctors_SelectedIndexChanged">
              <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredDoctorSpeciality" runat="server" Text="You must select one" ControlToValidate="ddlSpecialityDoctors" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
          </div>
          <%-- LABEL SHOW --%>
          <hr />

          <%-- TURNO DISPONIBILIDAD --%>
          <%-- DIAS DISPONIBILIDAD --%>
          <div>
            <span>Dias Disponibles: </span>
            <asp:DropDownList ID="ddlDaysAvailable" runat="server">
              <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredDaysAvailable" runat="server" Text="You must select one" ControlToValidate="ddlDaysAvailable" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
          </div>
          <hr />

          <%-- TURNO DISPONIBILIDAD --%>
          <%-- HORARIOS DISPONIBILIDAD --%>
          <asp:Label ID="lblShow" runat="server" Text=""></asp:Label>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>


    <%-- FECHA TURNO --%>
    <div>
    </div>

    <%-- OBESERVACION--%>
    <div>
    </div>

    <hr />
    <%-- BUTTON --%>
    <%--    <asp:Button ID="btnSendTurno" runat="server" Text="Agendar" OnClick="btnSendTurno_Click" ValidationGroup="test" />--%>
  </form>
</body>
</html>

<%-- 
  	DNI_Paciente char(8) not null,
	LegajoMedico varchar(5) not null,
	Fecha date not null,
	Horario int not null,
	Asistio BIT NOT NULL DEFAULT 0,
	Observacion VARCHAR(1000) NULL,
--%>