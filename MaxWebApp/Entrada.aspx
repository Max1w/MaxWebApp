<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="MaxWebApp.Entrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form id="meuFormulario">
        <h1>Cadastro de Itens</h1>
        <style>
            .notification {
                position: fixed;
                top: 10px;
                right: 10px;
                display: none;
                z-index: 9999;
            }
        </style>
        <div class="d-flex">
            <div class="form-group row m-1 col-2">
                <label for="text">Código *</label>
                <input type="text" class="form-control" id="codigoItem" runat="server" />
            </div>
            <div class="form-group row m-1 col-2">
                <label for="text">Placa *</label>
                <input type="text" class="form-control" id="placaItem" runat="server" />
            </div>
            <div class="form-group row m-1 col-8">
                <label for="text">Descrição *</label>
                <input type="text" class="form-control" id="descricaoItem" runat="server" />
            </div>
        </div>

        <div class="d-flex">
            <div class="form-group row m-1 col-2">
                <label for="text">Data da Aquisição *</label>
                <input type="date" class="form-control" id="dtAquisicao" runat="server" />
            </div>
            <div class="form-group row m-1 col-3">
                <label for="exemplo">Grupo</label>
                <select class="form-control" id="grupoItem" runat="server">
                    <option>Móvel</option>
                    <option>Imóvel</option>
                    <option>Dominical</option>
                </select>
            </div>
            <div class="form-group row m-1 col-3">
                <label for="exemplo">Estado de Conservação</label>
                <select class="form-control" id="conservacaoItem" runat="server">
                    <option>Ótimo</option>
                    <option>Bom</option>
                    <option>Regular</option>
                    <option>Ruim</option>
                    <option>Péssimo</option>
                </select>
            </div>
            <div class="form-group row m-1 col-4">
                <label for="text">Localização Física</label>
                <input type="text" class="form-control" id="localizacoFisicaItem" runat="server" />
            </div>
        </div>
        <div class="d-flex">
            <div class="form-group row m-2 col-10">
                <label for="teste">Observação</label>
                <textarea class="form-control" id="observacao" rows="3" runat="server"></textarea>
            </div>
            <div class="form-group row m-2 col-2">
                <label for="text">Valor *</label>
                <div class="input-group input-group-prepen">
                    <span class="input-group-text">R$</span>
                    <label id="lValorItem"></label>
                    <input id="cValorItem" type="text" placeholder="0,00" class="form-control" runat="server" />
                    <p id="aviso" style="color: red; display: none;">Favor inserir um numero</p>
                </div>
            </div>
        </div>

        <a id="botaoCancelar" href="/" type="submit" class="btn btn-danger m-3">Cancelar</a>

        <!-- Button trigger modal -->
        <button type="button" class="btn btn-success float-end m-3" data-toggle="modal" data-target="#exampleModal">
            Salvar
        </button>

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
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        <button id="btnEnviar" type="button" class="btn btn-success" runat="server" onserverclick="btnSalvar_Click">Salvar</button>
                    </div>
                </div>
            </div>
        </div>
    </form>


    <script>
        document.addEventListener('DOMContentLoaded', function () {

            const btnEnviar = document.getElementById('<%= btnEnviar.ClientID %>');
            btnEnviar.addEventListener('click', function () {
                alert("Cadastro salvo com sucesso!");
            });

            const valorInserido = document.getElementById('<%= cValorItem.ClientID %>');
            const aviso = document.getElementById('aviso');

            valorInserido.addEventListener('keydown', function (event) {
            
                if ([8, 13, 46, 37, 39, 110, 190].indexOf(event.keyCode) !== -1 ||
                    (event.keyCode === 65 && event.ctrlKey === true) ||
                    (event.keyCode === 88 && event.ctrlKey === true) ||
                    (event.keyCode === 86 && event.ctrlKey === true) ||
                    (event.keyCode === 67 && event.ctrlKey === true) ||
                    (event.keyCode >= 35 && event.keyCode <= 39)) {
                    return;
                }
                // Só Números
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                    aviso.style.display = 'block';
                } else {
                    aviso.style.display = 'none';
                }


            });
            valorInserido.addEventListener('input', function () {
                let valor = valorInserido.value;

                valor = valor.replace(/[^0-9,]/g, '');

                valorInserido.value = valor;
            });
            document.getElementById('meuFormulario').addEventListener('submit', function (event) {
                let valor = valorInserido.value;
                let numero = parseFloat(valor);

                if (isNaN(numero)) {
                    event.preventDefault();
                    aviso.style.display = 'block';
                    aviso.textContent = 'Favor, informar um valor numero!';
                } else {
                    aviso.style.display = 'none';
                }
            });
        });
    </script>
</asp:Content>
