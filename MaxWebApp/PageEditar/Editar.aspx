<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="MaxWebApp.PageEditar.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

                <div class="d-flex">
                    <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                        <label for="text">Código *</label>
                        <input type="text" class="form-control shadow p-3 bg-light" id="codigoItem" runat="server" />
                        <p id="avisoCodigo" style="color: red; display: none;">Favor não inserir caracteres especiais</p>
                    </div>
                    <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                        <label for="text">Placa *</label>
                        <input type="text" class="form-control shadow p-3 bg-light" id="placaItem" runat="server" />
                        <p id="avisoPlaca" style="color: red; display: none;">Favor inserir um numero</p>
                    </div>
                    <div class="form-group m-1 col-8" style="padding-right: 0px; padding-left: 0px">
                        <label for="text">Descrição *</label>
                        <input type="text" class="form-control shadow p-3 bg-light" id="descricaoItem" runat="server" />
                        <p id="avisoDescricao" style="color: red; display: none;">Favor não inserir caracteres especiais</p>
                    </div>
                </div>

                <div class="d-flex">
                    <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                        <label for="text">Data da Aquisição *</label>
                        <input type="date" class="form-control shadow p-3 bg-light" id="dtAquisicao" runat="server" />
                    </div>
                    <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                        <label for="exemplo">Grupo</label>
                        <select class="form-control" id="grupoItem" runat="server">
                            <option>Móvel</option>
                            <option>Imóvel</option>
                            <option>Dominical</option>
                        </select>
                    </div>
                    <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                        <label for="exemplo">Estado de Conservação</label>
                        <select class="form-control" id="conservacaoItem" runat="server">
                            <option>Ótimo</option>
                            <option>Bom</option>
                            <option>Regular</option>
                            <option>Ruim</option>
                            <option>Péssimo</option>
                        </select>
                    </div>

                    <div class="form-group m-1 col-6" style="padding-right: 8px; padding-left: 0px">
                        <label for="text">Localização Física</label>
                        <input type="text" class="form-control shadow p-3 bg-light" id="localizacoFisicaItem" runat="server" />
                        <p id="avisoLocalizacao" style="color: red; display: none;">Favor não inserir caracteres especiais</p>
                    </div>
                </div>
                <div class="d-flex">
                    <div class="form-group m-1 col-10" style="padding-right: 0px; padding-left: 0px">
                        <label for="teste">Observação</label>
                        <textarea class="form-control shadow p-3 bg-light" id="observacao" rows="3" runat="server"></textarea>
                    </div>
                    <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                        <label for="text">Valor *</label>
                        <div class="mt-4">
                            <input id="cValorItem" type="text" placeholder="0,00" class="form-control shadow p-3 bg-light" runat="server" />
                            <p id="avisoValor" style="color: red; display: none;">Favor inserir um numero</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
