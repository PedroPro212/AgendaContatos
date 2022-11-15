<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateContato.aspx.cs" Inherits="AgendaContato.Contato.UpdateContato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtTel"></asp:TextBox>
    <asp:DropDownList runat="server" ID="ddlParentesco"></asp:DropDownList>
    <asp:Button runat="server" ID="btnUpdate" Text="Atualizar" OnClick="btnUpdate_Click" />

</asp:Content>
