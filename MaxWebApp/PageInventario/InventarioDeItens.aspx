<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InventarioDeItens.aspx.cs" Inherits="MaxWebApp.PageInventario.InventarioDeItens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div>
            <h1 style="margin-bottom: 20px;">Inventário</h1>
        </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="grid-large table table-striped mt-5 table-hover table-light" AutoGenerateColumns="false" DataKeyNames="ID" AllowPaging="true" OnRowCommand="GridView1_RowCommand1">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Placa" HeaderText="Placa" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:BoundField DataField="Grupo" HeaderText="Grupo" />
                <asp:BoundField DataField="Localizacao" HeaderText="Localização" />
                <asp:BoundField DataField="Observacao" HeaderText="Observação" />
                <asp:BoundField DataField="ValorAquisicao" HeaderText="Valor de Aquisição" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="DtAquisicao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Editar" Text="Editar" CssClass="btn btn-outline-primary" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <header>
            <h1>EDITAR ITENS</h1>
        </header>
        <style>
            input, select, textarea {
                max-width: none;
            }

            .alert {
                position: fixed;
                top: 10px;
                right: 10px;
                display: none;
            }
        </style>
        <div class="container-fluid">
            <div class="d-flex row justify-content-center align-items-center align-middle" style="margin-top: 5em; margin-bottom: 7em;">
                <div class="col-12">
                    <asp:HiddenField ID="hfItemId" runat="server" />
                    <div class="d-flex">
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="txtCodigoDoItem">Código *</label>
                            <asp:TextBox ID="txtCodigoDoItem" runat="server" CssClass=" form-control shadow p-3 bg-light" ReadOnly="true"></asp:TextBox>
                            <asp:Label ID="avisoCodigo" runat="server" Text="Favor não inserir caracteres especiais" ForeColor="Red" Style="display: none;"></asp:Label>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="txtPlacaItem">Placa *</label>
                            <asp:TextBox ID="txtPlacaItem" runat="server" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <asp:Label ID="avisoPlaca" runat="server" Text="Favor inserir um número" ForeColor="Red" Style="display: none;"></asp:Label>
                        </div>
                        <div class="form-group m-1 col-8" style="padding-right: 0px; padding-left: 0px">
                            <label for="txtDescricaoItem">Descrição *</label>
                            <asp:TextBox ID="txtDescricaoItem" runat="server" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <asp:Label ID="avisoDescricao" runat="server" Text="Favor não inserir caracteres especiais" ForeColor="Red" Style="display: none;"></asp:Label>
                        </div>
                    </div>
                    <div class="d-flex">
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="txtDtAquisicao">Data da Aquisição *</label>
                            <asp:TextBox ID="txtDtAquisicao" runat="server" TextMode="Date" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="ddlGrupoItem">Grupo</label>
                            <asp:DropDownList ID="ddlGrupoItem" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Móvel" Value="Móvel"></asp:ListItem>
                                <asp:ListItem Text="Imóvel" Value="Imóvel"></asp:ListItem>
                                <asp:ListItem Text="Dominical" Value="Dominical"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="ddlConservacaoItem">Estado de Conservação</label>
                            <asp:DropDownList ID="ddlConservacaoItem" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Ótimo" Value="Ótimo"></asp:ListItem>
                                <asp:ListItem Text="Bom" Value="Bom"></asp:ListItem>
                                <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                                <asp:ListItem Text="Ruim" Value="Ruim"></asp:ListItem>
                                <asp:ListItem Text="Péssimo" Value="Péssimo"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group m-1 col-6" style="padding-right: 8px; padding-left: 0px">
                            <label for="txtLocalizacoFisicaItem">Localização Física</label>
                            <asp:TextBox ID="txtLocalizacoFisicaItem" runat="server" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <asp:Label ID="avisoLocalizacao" runat="server" Text="Favor não inserir caracteres especiais" ForeColor="Red" Style="display: none;"></asp:Label>
                        </div>
                    </div>
                    <div class="d-flex">
                        <div class="form-group m-1 col-10" style="padding-right: 0px; padding-left: 0px">
                            <label for="txtObservacao">Observação</label>
                            <asp:TextBox ID="txtObservacao" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="txtValorItem">Valor *</label>
                            <div class="mt-4">
                                <asp:TextBox ID="txtValorItem" runat="server" Placeholder="0,00" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                                <asp:Label ID="avisoValor" runat="server" Text="Favor inserir um número" ForeColor="Red" Style="display: none;"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="d-flex justify-content-end">
            <asp:LinkButton ID="botaoCancelar" runat="server" CssClass="btn btn-danger m-3" OnClick="botaoCancelar_Click">Cancelar</asp:LinkButton>
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success m-3" OnClick="btnSalvar_Click" />
        </div>
    </asp:Panel>
    <div id="notificacaoDeSucesso" class="alert alert-success" style="display: none;" role="alert">
        Cadastro salvo com sucesso!
    </div>
    <div id="notificacaoDeCampoInvalido" class="alert alert-warning" style="display: none;" role="alert">
        Favor preencher todos os campos obrigatórios *!
    </div>
    <div id="notificacaoDeCancelar" class="alert alert-danger" style="display: none;" role="alert">
        Cadastro cancelado!
    </div>
    <div id="cadastroDuplicado" class="alert alert-danger" style="display: none;" role="alert">
        Cadastro duplicado!
    </div>
    <div id="limiteUltrapassadoDeCaracteres" class="alert alert-danger" style="display: none;" role="alert">
        Foi ultrapassado o valor limite de caracteres!
    </div>

    <script>
        function NotificaçãoCadastroSucesso() {
            var alertBox = document.getElementById('notificacaoDeSucesso');
            alertBox.style.display = 'block';
            setTimeout(function () {
                alertBox.style.display = 'none';
            }, 5000);
        }

        function LimiteUltrapassadoDeCaracteres() {
            var alertBox = document.getElementById('limiteUltrapassadoDeCaracteres');
            alertBox.style.display = 'block';
            setTimeout(function () {
                alertBox.style.display = 'none';
            }, 5000);
        }

        function CadastroDuplicado() {
            var alertBox = document.getElementById('cadastroDuplicado');
            alertBox.style.display = 'block';
            setTimeout(function () {
                alertBox.style.display = 'none';
            }, 5000);
        }

        function NotificaçãoCampoInvalido() {
            var alertBox = document.getElementById('notificacaoDeCampoInvalido');
            alertBox.style.display = 'block';
            setTimeout(function () {
                alertBox.style.display = 'none';
            }, 5000);
        }

        function NotificaçãoCadastroCancelar() {
            var alertBox = document.getElementById('notificacaoDeCancelar');
            alertBox.style.display = 'block';
            setTimeout(function () {
                alertBox.style.display = 'none';
            }, 5000);
        }
    </script>
</asp:Content>
