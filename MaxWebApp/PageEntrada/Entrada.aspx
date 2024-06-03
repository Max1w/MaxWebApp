<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="MaxWebApp.Entrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <header>
        <h1>CADASTRO DE ITENS</h1>
    </header>

    <div>
        <asp:Button runat="server" Text="+Item" OnClick="Unnamed_Click" CssClass="btn btn-success m-3 mt-5" />
    </div>

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

    <asp:Panel ID="ExibirCastroDosItens" runat="server" Visible="false">
        <div class="container-fluid">
            <div class="d-flex row justify-content-center align-items-center align-middle" style="margin-top: 5em; margin-bottom: 7em;">
                <div class="col-12">

                    <div class="d-flex">
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Código *</label>
                            <asp:TextBox runat="server" ID="txtCodigoDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <p id="avisoCodigo" style="color: red; display: none;">Favor não inserir caracteres especiais</p>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Placa *</label>
                            <asp:TextBox runat="server" ID="txtPlacaDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <p id="avisoPlaca" style="color: red; display: none;">Favor inserir um numero</p>
                        </div>
                        <div class="form-group m-1 col-8" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Descrição *</label>
                            <asp:TextBox runat="server" ID="txtDescricaoDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <p id="avisoDescricao" style="color: red; display: none;">Favor não inserir caracteres especiais</p>
                        </div>
                    </div>

                    <div class="d-flex">
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Data da Aquisição *</label>
                            <asp:TextBox runat="server" ID="txtDataAquisicao" TextMode="Date" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
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
                            <p id="avisoLocalizacao" style="color: red; display: none;">Favor não inserir caracteres especiais</p>
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
                                <p id="avisoValor" style="color: red; display: none;">Favor inserir um numero</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="d-flex justify-content-end">
            <a id="botaoCancelar" href="/" class="btn btn-danger m-3">Cancelar</a>
            <button type="button" class="btn btn-success m-3" data-toggle="modal" data-target="#exampleModal">
                Salvar
            </button>
        </div>
    </asp:Panel>
    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Cadastro</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Deseja salvar esse cadastro?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="NotificaçãoCadastroCancelar()">Cancelar</button>
                    <button id="btnEnviar" type="button" class="btn btn-success" runat="server" onserverclick="btnSalvar_Click">Salvar</button>
                </div>
            </div>
        </div>
    </div>
    <div id="notificacaoDeSucesso" class="alert alert-success" role="alert">
        Cadastro salvo com sucesso!
    </div>
    <div id="notificacaoDeCampoInvalido" class="alert alert-warning" role="alert">
        Favor preencher todos os campos obrigatórios *!
    </div>
    <div id="notificacaoDeCancelar" class="alert alert-danger" role="alert">
        Cadastro cancelado!
    </div>
    <div id="cadastroDuplicado" class="alert alert-danger" role="alert">
        Cadastro duplicado!
    </div>
    <div id="limiteUltrapassadoDeCaracteres" class="alert alert-danger" role="alert">
        Foi ultrapassado o valor limite de caracteres!
    </div>

    <script>
        function NotificaçãoCadastroSucesso() {
            alert("opa")
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

        function ValidarCampoNumero(campo, aviso) {
            const cValor = document.getElementById('<%= txtValorItem.ClientID %>');
            campo.addEventListener('keydown', function (event) {

                if ([8, 13, 46, 37, 39, 110, 190, 160, 161].indexOf(event.keyCode) !== -1 ||
                    (event.keyCode === 65 && event.ctrlKey === true) ||
                    (event.keyCode === 88 && event.ctrlKey === true) ||
                    (event.keyCode === 86 && event.ctrlKey === true) ||
                    (event.keyCode === 67 && event.ctrlKey === true) ||
                    (event.keyCode >= 35 && event.keyCode <= 39)) {
                    return;
                }
                // Só Números
                if (event.shiftKey ||
                    (event.keyCode < 48 || event.keyCode > 57) &&
                    (event.keyCode < 96 || event.keyCode > 105) &&
                    event.ctrlKey === false && event.keyCode !== 20 &&
                    event.keyCode !== 9) {

                    event.preventDefault();
                    aviso.style.display = 'block';
                } else {
                    aviso.style.display = 'none';
                }
            });
            campo.addEventListener('input', function () {
                let valor = campo.value;

                valor = valor.replace(/[^0-9,]/g, '');

                campo.value = valor;
            });
        }

        function ValidarCampoNumerico(campo, aviso) {
            campo.addEventListener('keydown', function (event) {
                if ([8, 13, 46, 37, 39, 110, 188, 190, 160, 161].indexOf(event.keyCode) !== -1 ||
                    (event.keyCode === 65 && event.ctrlKey === true) ||
                    (event.keyCode === 88 && event.ctrlKey === true) ||
                    (event.keyCode === 86 && event.ctrlKey === true) ||
                    (event.keyCode === 67 && event.ctrlKey === true) ||
                    (event.keyCode >= 35 && event.keyCode <= 39)) {
                    return;
                }

                if (event.shiftKey ||
                    (event.keyCode < 48 || event.keyCode > 57) &&
                    (event.keyCode < 96 || event.keyCode > 105) &&
                    (event.keyCode !== 188 && event.keyCode !== 190) &&
                    event.ctrlKey === false && event.keyCode !== 20 &&
                    event.keyCode !== 9) {

                    event.preventDefault();
                    aviso.style.display = 'block';
                } else {
                    aviso.style.display = 'none';
                }
            });

            campo.addEventListener('blur', function () {
                let valor = campo.value;

                campo.value = parseFloat(valor.replace(',', '.')).toLocaleString('pt-BR', {
                    style: 'currency',
                    currency: 'BRL'
                })
            });
        }
        function ValidarCampoDeTextoComNumeros(campo, aviso) {
            campo.addEventListener('keydown', function (event) {

                if ([8, 13, 46, 37, 39, 110, 190].indexOf(event.keyCode) !== -1 ||
                    (event.keyCode === 65 && event.ctrlKey === true) ||
                    (event.keyCode === 88 && event.ctrlKey === true) ||
                    (event.keyCode === 86 && event.ctrlKey === true) ||
                    (event.keyCode === 67 && event.ctrlKey === true) ||
                    (event.keyCode >= 35 && event.keyCode <= 39)) {
                    return;
                }

                if (event.key === '@' || event.key === '#' || event.key === '<' || event.key === '>') {
                    event.preventDefault();
                    aviso.style.display = 'block';
                } else {
                    aviso.style.display = 'none';
                }
            });
            campo.addEventListener('input', function () {
                let valor = campo.value;

                valor = valor.replace(/[@#><]/g, '');

                campo.value = valor;
            });
        }
    </script>

</asp:Content>
