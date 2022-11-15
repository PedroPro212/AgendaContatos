<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarContato.aspx.cs" Inherits="AgendaContato.CadastrarContato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtTel"></asp:TextBox>
    <asp:DropDownList runat="server" ID="ddlParentesco"></asp:DropDownList>
    <asp:Button runat="server" ID="btnAtualizar" Text="Adicionar" OnClick="btnCadastrar_Click" />

</asp:Content>
