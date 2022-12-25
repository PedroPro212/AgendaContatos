<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarContato.aspx.cs" Inherits="AgendaContato.CadastrarContato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .caixas{

        }
    </style>

    <div class="container" style="margin-top:15px;">
        <div class="row">
            <div class="col-sm-1">
                <p>Nome:</p>
                <p>Telefone:</p>
            </div>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="txtNome" CssClass="caixas"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtTel" CssClass="caixas"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlParentesco"></asp:DropDownList><br />
                <asp:Button runat="server" ID="btnAtualizar" Text="Adicionar" OnClick="btnCadastrar_Click" />
            </div>
        </div>
    </div>
    

</asp:Content>
