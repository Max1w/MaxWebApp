<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Saida.aspx.cs" Inherits="MaxWebApp.Saida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div>
            <h1 style="margin-bottom: 20px;">Saída de Itens</h1>
        </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="grid-large table table-striped mt-5 table-hover table-light" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand1" DataKeyNames="ID">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="ckSelecionarTodos" runat="server" AutoPostBack="true" OnCheckedChanged="CkSelecionarTodos_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckSelecionados" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Placa" HeaderText="Placa" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:BoundField DataField="ValorAquisicao" HeaderText="Valor de Aquisição" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="DtAquisicao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
            </Columns>
        </asp:GridView>

        <div class="d-flex justify-content-end">
            <a id="botaoCancelar" href="/" class="btn btn-primary m-3">Voltar</a>
            <button type="button" class="btn btn-danger m-3" data-toggle="modal" data-target="#exampleModal">
                Excluir
            </button>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Confirmação</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        Deseja realmente excluir este cadastro?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="NotificaçãoCadastroCancelar()">Cancelar</button>
                        <asp:Button ID="ExcluirItensSelecionados" runat="server" Text="Excluir" OnClick="ExcluirItensSelecionados_Click" CssClass="btn btn-warning" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
