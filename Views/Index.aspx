<%@ Page Language="C#" AutoEventWireup="true"
  UnobtrusiveValidationMode="None"
  CodeBehind="Index.aspx.cs" Inherits="Views.Index" %>

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
    </div>
    <%--  NAME --%>
    <div>
      <span>Name:</span>
      <asp:TextBox ID="textName" runat="server"></asp:TextBox>

    </div>
    <%-- LAST-NAME --%>
    <div>
      <span>Last-Name: </span>
      <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    </div>
    <%-- SEXO --%>
    <div>
      <span>Sexo:</span>
      <asp:RadioButtonList ID="radioListSexo" runat="server">
        <asp:ListItem Value="man">Man</asp:ListItem>
        <asp:ListItem Value="woman">Woman</asp:ListItem>
      </asp:RadioButtonList>
    </div>
    <%-- FECHA-NACIMIENTO --%>
    <div>
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
      </div>
      <%-- EMAIL--%>
      <div>
        <span>E-mail: </span>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
      </div>
      <%-- PHONE-NUMBER--%>
      <div>
        <span>Phone: </span>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
      </div>


      <hr />
      <%-- BUTTON SEND --%>
      <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
      <hr />
      <%-- LABEL SHOW --%>
      <span>
        <asp:Label ID="lblShowMessage" runat="server" Text=""></asp:Label>
      </span>
    </div>
  </form>
</body>
</html>
