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
        </style>
        <div class="container-fluid">
            <div class="d-flex row justify-content-center align-items-center align-middle" style="margin-top: 5em; margin-bottom: 7em;">
                <div class="col-12">
                    <asp:HiddenField ID="hfItemId" runat="server" />
                    <div class="d-flex">
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Código *</label>
                            <asp:TextBox runat="server" ID="txtCodigoDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <div id="avisoCodigo" class="invalid-feedback">Favor inserir um caracter válido</div>
                            <asp:RequiredFieldValidator ID="rfvCodigoDoItem" runat="server" ControlToValidate="txtCodigoDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Placa *</label>
                            <asp:TextBox runat="server" ID="txtPlacaDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <div id="avisoPlaca" class="invalid-feedback">Favor inserir um numero </div>
                            <asp:RequiredFieldValidator ID="rfvPlacaDoItem" runat="server" ControlToValidate="txtPlacaDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group m-1 col-8" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Descrição *</label>
                            <asp:TextBox runat="server" ID="txtDescricaoDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <div id="avisoDescricao" class="invalid-feedback">Favor inserir um caracter válido</div>
                            <asp:RequiredFieldValidator ID="rfvDescricaoDoItem" runat="server" ControlToValidate="txtDescricaoDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="d-flex">
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Data da Aquisição *</label>
                            <asp:TextBox runat="server" ID="txtDataAquisicao" TextMode="Date" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDataAquisicao" runat="server" ControlToValidate="txtDataAquisicao" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="exemplo">Grupo</label>
                            <asp:DropDownList runat="server" ID="ddlGrupoItem" CssClass="form-control">
                                <asp:ListItem>Móvel</asp:ListItem>
                                <asp:ListItem>Imóvel</asp:ListItem>
                                <asp:ListItem>Dominical</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="exemplo">Estado de Conservação</label>
                            <asp:DropDownList runat="server" ID="ddlConservacaoItem" CssClass="form-control">
                                <asp:ListItem>Ótimo</asp:ListItem>
                                <asp:ListItem>Bom</asp:ListItem>
                                <asp:ListItem>Regular</asp:ListItem>
                                <asp:ListItem>Ruim</asp:ListItem>
                                <asp:ListItem>Péssimo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group m-1 col-6" style="padding-right: 8px; padding-left: 0px">
                            <label for="text">Localização Física</label>
                            <asp:TextBox runat="server" ID="txtLocalizacaoFisica" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <div id="avisoLocalizacao" class="invalid-feedback">Favor inserir um caracter válido</div>
                        </div>
                    </div>
                    <div class="d-flex">
                        <div class="form-group m-1 col-10" style="padding-right: 0px; padding-left: 0px">
                            <label for="teste">Observação</label>
                            <asp:TextBox runat="server" ID="txtObservacao" TextMode="MultiLine" Rows="3" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Valor *</label>
                            <div class="mt-4">
                                <asp:TextBox runat="server" ID="txtValorItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                                <div id="avisoValor" class="invalid-feedback">Favor inserir um valor (R$)</div>
                                <asp:RequiredFieldValidator ID="rfvalorItem" runat="server" ControlToValidate="txtValorItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
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
    <div id="notificacaoDeSucesso" class="alert alert-success" style="display: none; position: fixed; top: 100px; right: 10px; display: none;" role="alert">
        Cadastro salvo com sucesso!
    </div>
    <div id="notificacaoDeCampoInvalido" class="alert alert-warning" style="display: none; position: fixed; top: 100px; right: 10px; display: none;" role="alert">
        Favor preencher todos os campos obrigatórios *!
    </div>
    <div id="notificacaoDeCancelar" class="alert alert-danger" style="display: none; position: fixed; top: 100px; right: 10px; display: none;" role="alert">
        Cadastro cancelado!
    </div>
    <div id="cadastroDuplicado" class="alert alert-danger" style="display: none; position: fixed; top: 100px; right: 10px; display: none;" role="alert">
        Cadastro duplicado!
    </div>
    <div id="limiteUltrapassadoDeCaracteres" class="alert alert-danger" style="display: none; position: fixed; top: 100px; right: 10px; display: none;" role="alert">
        Foi ultrapassado o valor limite de caracteres!
    </div>

    <script src="../Scripts/Notificacao.js"></script>

    <script>

        document.addEventListener('DOMContentLoaded', function () {

            //Campo Placa
            const cPlaca = document.getElementById('<%= txtPlacaDoItem.ClientID %>');
            const avisoCampoPlaca = document.getElementById('avisoPlaca');

            //Campo Descrição
            const cDescricao = document.getElementById('<%= txtDescricaoDoItem.ClientID %>');
            const avisoCampoDescricao = document.getElementById('avisoDescricao');

            //Campo Valor de Aquisição
            const cValor = document.getElementById('<%= txtValorItem.ClientID %>');
            const avisoCampoValor = document.getElementById('avisoValor');

            //Campo Localização Física
            const cLocalizacao = document.getElementById('<%= txtLocalizacaoFisica.ClientID %>');
            const avisoCampoLocalizacao = document.getElementById('avisoLocalizacao');

            //Campo Código
            const cCodigo = document.getElementById('<%= txtCodigoDoItem.ClientID %>');
            const avisoCampoCodigo = document.getElementById('avisoCodigo');

            ValidarCampoNumero(cPlaca, avisoCampoPlaca);
            ValidarCampoNumerico(cValor, avisoCampoValor);
            ValidarCampoDeTextoComNumeros(cDescricao, avisoCampoDescricao);
            ValidarCampoDeTextoComNumeros(cLocalizacao, avisoCampoLocalizacao);
            ValidarCampoDeTextoComNumeros(cCodigo, avisoCampoCodigo);

        });
    </script>

    <script src="../Scripts/Validacao.js"></script>
</asp:Content>
