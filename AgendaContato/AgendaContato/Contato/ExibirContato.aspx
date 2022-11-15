<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExibirContato.aspx.cs" Inherits="AgendaContato.Contato.ExibirContato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>

        body{
            background-color:#487aa1;
        }

        .cadastrar{
            border-radius:15px;
            border-style:none;
            box-shadow:1px 1px 1px black;
            width:120px;
            height:30px;
            font-size:14px;
        }
            .cadastrar:hover{
                width:125px;
                height:35px;
                transition: 0.1s;
                font-size:16px;
            }

        .table{
            background-color:#212529;
            color:white;
        }
    </style>

    <div class="container" style="margin-top:30px;">
        <div class="col-sm-2">
            <asp:Button runat="server" ID="btnCadastrar" CssClass="cadastrar" Text="Criar contato" OnClick="btnCadastrar_Click" />
            <br />
            <asp:Label runat="server" ID="lblQts"></asp:Label>
        </div>

        <div class="col-sm-8">
            <asp:TextBox runat="server" ID="txtNome" placeholder="Digite o nome:" Width="300"></asp:TextBox>
            <asp:Button runat="server" ID="btnPesquisar" Text="Pesquisar" OnClick="btnPesquisar_Click" />

            <div style="margin-top:15px;">
                <asp:GridView runat="server" ID="grdContatos" Width="80%" AutoGenerateColumns="false" 
                    CssClass="table table-condensed" OnRowCommand="grdContatos_RowCommand" 
                    AllowPaging="false" OnRowDataBound="grdContatos_RowDataBound">

                    <Columns>
                        <asp:BoundField DataField="nome" HeaderText="NOME" />
                        <asp:BoundField DataField="tel" HeaderText="NÚMERO" />
                        <asp:ButtonField ButtonType="Link" CommandName="editar" ControlStyle-CssClass="btn btn-warning" Text="Editar" ItemStyle-HorizontalAlign="Center" />
                        <asp:ButtonField ButtonType="Link" CommandName="excluir" ControlStyle-CssClass="btn btn-danger" Text="Excluir" ItemStyle-HorizontalAlign="Center" />
                    </Columns>

                </asp:GridView>
            </div>
        </div>
        
    </div>
    

</asp:Content>
