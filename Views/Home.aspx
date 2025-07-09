<%@ Page Title="" Language="C#" MasterPageFile="~/Clinica.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Views.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h1 class="title">HI - I'M HOME</h1>
  <div class="login_cotainer">
    <%-- USER NAME --%>
    <div class="login_usuario">
      <span class="login_usuario_name">Nombre de Usuario:</span>
      <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
    </div>
    <%-- USER PASSWORD --%>
    <div class="login_usuario">
      <span class="login_usuario">Password</span>
      <asp:TextBox ID="txtLoginPass" runat="server"></asp:TextBox>
    </div>
    <%-- BUTOON ENTER --%>
    <asp:Button ID="btnLogin" runat="server" Text="Button" />
  </div>
  <hr />
  <asp:Label ID="lbbMessageSystem" runat="server" Text=""></asp:Label>
</asp:Content>
