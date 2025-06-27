<%@ Page Language="C#" AutoEventWireup="true"
  UnobtrusiveValidationMode="None"
  CodeBehind="AddPersona.aspx.cs" Inherits="Views.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Clinica</title>
</head>
<body>

  <h1>Hi! I'm index</h1>

  <form id="form1" runat="server">
    <%-- SCRIPT MANAGER --%>
    <asp:ScriptManager runat="server" ID="scriptManager" />
    <%-- DNI --%>
    <div>
      <span>DNI:</span>
      <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
      <%-- VALIDATIONS--%>
      <asp:RequiredFieldValidator ID="requiredDNI" runat="server" Display="Dynamic" ControlToValidate="txtDNI" Text="This field is required"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="regexDNI" runat="server" ControlToValidate="txtDNI" ValidationExpression="^[1-9][0-9]*$" Text="Only numbers"></asp:RegularExpressionValidator>
      <asp:RangeValidator ID="rangeDNI" runat="server" ControlToValidate="txtDNI" Display="Dynamic" Text="Must be 8 numbers" Type="Integer" MaximumValue="99999999" MinimumValue="10000000"></asp:RangeValidator>
    </div>
    <%--  NAME --%>
    <div>
      <span>Name:</span>
      <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

      <%-- VALIDATIONS --%>
      <asp:RequiredFieldValidator ID="requiredName" runat="server" Display="Dynamic" ControlToValidate="txtName" Text="This field is required"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="regexName" runat="server" Text="Must be characters (max 50)" Display="Dynamic" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{1,50}$" ControlToValidate="txtName"></asp:RegularExpressionValidator>
    </div>
    <%-- LAST-NAME --%>
    <div>
      <span>Last-Name: </span>
      <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="requiredLastName" runat="server" Display="Dynamic" ControlToValidate="txtLastName" Text="This field is required"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="Must be characters (max 50)" Display="Dynamic" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{1,50}$" ControlToValidate="txtLastName"></asp:RegularExpressionValidator>
    </div>
    <%-- DATE --%>
    <div>
      <span>Fecha de nacimiento:</span>
      <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="requiredDate" runat="server" Text="This field is required"
        ControlToValidate="txtDate" Display="Dynamic"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="regexDate" runat="server" Text="Invalided Date"
        ValidationExpression="^(0[1-9]|1[0-9]|2[0-9]|3[01])/(0[1-9]|1[0-2])/([12][0-9]{3})$"
        Display="Dynamic" ControlToValidate="txtDate"></asp:RegularExpressionValidator>
      <asp:Label runat="server" ID="lblDateError"></asp:Label>
    </div>
    <%-- SEXO --%>
    <div>
      <span>Sexo:</span>
      <asp:RadioButtonList ID="radioListSexo" runat="server">
        <asp:ListItem Value="M">Man</asp:ListItem>
        <asp:ListItem Value="F">Woman</asp:ListItem>
      </asp:RadioButtonList>
      <asp:RequiredFieldValidator ID="requiredSexo" runat="server" Text="You must select one" ControlToValidate="radioListSexo" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <%-- NACIONALIDAD --%>
    <div>
      <span>Nacionality: 
        <asp:DropDownList ID="ddlNacionalities" runat="server">
          <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
        </asp:DropDownList>
        <%-- REQUIRED --%>
        <asp:RequiredFieldValidator ID="requiredNacionality" runat="server" Text="You must select one" ControlToValidate="ddlNacionalities" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
      </span>
    </div>
    <div>
      <%-- UPPANEL FOR THE DROP-DOWN-LIST --%>
      <asp:UpdatePanel ID="UpdatePanel_DDL" runat="server">
        <ContentTemplate>
          <%-- PROVINCIES --%>
          <span>Provincies: 
        <asp:DropDownList ID="ddlProvincies" runat="server" OnSelectedIndexChanged="ddlProvincies_SelectedIndexChanged" AutoPostBack="True">
          <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
        </asp:DropDownList>
            <%-- REQUIRED --%>
            <asp:RequiredFieldValidator ID="requiredProvincie" runat="server" Text="You must select one" ControlToValidate="ddlProvincies" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
          </span>
          <hr />
          <%-- LOCALITIES  --%>
          <span>Localities:
        <asp:DropDownList ID="ddlLocalities" runat="server">
          <asp:ListItem Value="0" Enabled="True"> -- Select -- </asp:ListItem>
        </asp:DropDownList>
            <%-- REQUIRED --%>
            <asp:RequiredFieldValidator ID="requiredLocaly" runat="server" Text="You must select one" ControlToValidate="ddlLocalities" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
          </span>
        </ContentTemplate>
      </asp:UpdatePanel>
      <%-- ADDRESS--%>
      <div>
        <span>Address:</span>
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regexAddress" runat="server" Text="Max. 100 characters" Display="Dynamic" ValidationExpression="^.{0,100}$" ControlToValidate="txtAddress"></asp:RegularExpressionValidator>
      </div>
      <%-- EMAIL--%>
      <div>
        <span>E-mail: </span>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regexEmail" runat="server" Text="Must be a email" Display="Dynamic" ValidationExpression="^[\w\.-]+@[\w\.-]+\.\w{2,}$" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
      </div>
      <%-- PHONE-NUMBER--%>
      <div>
        <span>Phone: </span>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regexPhone" runat="server" Text="Must be numbers" Display="Dynamic" ValidationExpression="^[0-9]*$" ControlToValidate="txtPhone"></asp:RegularExpressionValidator>
      </div>
      <hr />
      <%-- BUTTON SEND --%>
      <asp:Button ID="btnSendMedico" runat="server" Text="Add as a Medico" OnClick="btnSendMedico_Click" />
      <hr />
      <%-- BUTTON SEND --%>
      <asp:Button runat="server" Text="Add as a Pacient" ID="btnSendPacient" OnClick="btnSendPacient_Click" />
      <hr />
      <%-- BUTTON SEND --%>
    <%--  <asp:Button runat="server" Text="MEDICO.ASX" ID="Button1" OnClick="btnSendTest_Click" ValidationGroup="test" />
      <hr />--%>
      <%-- LABEL SHOW --%>
      <span>
        <asp:Label ID="lblShowMessage" runat="server" Text=""></asp:Label>
      </span>
    </div>
  </form>
</body>
</html>

<%-- TODO: AGRUPAR LOS TEXT-BOX PARA INFROMARLE AL USUARIO , EN DONDE ESTA HERRANDO. --%>