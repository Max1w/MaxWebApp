<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InventarioDeItens.aspx.cs" Inherits="MaxWebApp.PageInventario.InventarioDeItens" %>

<%@ Register TagName="Campos" TagPrefix="cp" Src="~/Campos/CamposForm.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="configuracao.css" />
    <script src="Scripts/configuracao.js"></script>

    <body>
        <div class="container">
            <div>
                <h1 style="margin-bottom: 20px;">Inventário</h1>
            </div>

            <asp:GridView ID="GridView1" runat="server" CssClass="grid-large table table-striped mt-5 table-hover table-light " AutoGenerateColumns="false" DataKeyNames="ID" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand1">
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

            <cp:Campos runat="server" ID="camposDoFormSaida"></cp:Campos>

        </asp:Panel>

        <script>

            document.addEventListener('DOMContentLoaded', function () {

                //Campo Placa
                const cPlaca = document.getElementById('<%= camposDoFormSaida.TxtPlacaDoItem.ClientID %>');
                const avisoCampoPlaca = document.getElementById('avisoPlaca');

                //Campo Descrição
                const cDescricao = document.getElementById('<%= camposDoFormSaida.TxtDescricaoDoItem.ClientID %>');
                const avisoCampoDescricao = document.getElementById('avisoDescricao');

                //Campo Valor de Aquisição
                const cValor = document.getElementById('<%= camposDoFormSaida.TxtValorItem.ClientID %>');
                const avisoCampoValor = document.getElementById('avisoValor');

                //Campo Localização Física
                const cLocalizacao = document.getElementById('<%= camposDoFormSaida.TxtLocalizacaoFisica.ClientID %>');
                const avisoCampoLocalizacao = document.getElementById('avisoLocalizacao');

                //Campo Código
                const cCodigo = document.getElementById('<%= camposDoFormSaida.TxtCodigoDoItem.ClientID %>');
                const avisoCampoCodigo = document.getElementById('avisoCodigo');

                //Numero Comprovante
                const cNumComprovante = document.getElementById('<%= camposDoFormSaida.TxtNumeroComprovante.ClientID %>');
                const avisoNumComprovante = document.getElementById('avisoNumeroComprovante');

                //Placa do veículo
                const cPlacaVeiculo = document.getElementById('<%= camposDoFormSaida.TxtPlacaVeiculo.ClientID %>');
                const avisoPlacaVeiculo = document.getElementById('avisoPlacaVeiculo');

                //Modelo do veículo
                const cModeloVeiculo = document.getElementById('<%= camposDoFormSaida.TxtModeloVeiculo.ClientID %>');
                const avisoModeloVeiculo = document.getElementById('avisoModeloVeiculo');

                // Responsável
                const cResponsavel = document.getElementById('<%= camposDoFormSaida.TxtResponsavel.ClientID %>');
                const avisoResponsavel = document.getElementById('avisoResponsavel');

                // vida util
                const cVidaUtil = document.getElementById('<%= camposDoFormSaida.TxtVidaUtil.ClientID %>');
                const avisoVidaUtil = document.getElementById('avisoVidaUtil');

                //depreciação anual
                const cDepreAnual = document.getElementById('<%= camposDoFormSaida.TxtDepreciacaoAnual.ClientID %>');
                const avisoDepreAnual = document.getElementById('avisoDepreciacaoAnual');

                // valor residual
                const cValorResidual = document.getElementById('<%= camposDoFormSaida.TxtValorResidual.ClientID %>');
                const avisoValorResidual = document.getElementById('avisoValorResidual');

                ValidarCampoNumero(cPlaca, avisoCampoPlaca);
                ValidarCampoNumero(cNumComprovante, avisoNumComprovante);
                ValidarCampoNumero(cVidaUtil, avisoVidaUtil);
                ValidarCampoNumerico(cValor, avisoCampoValor);
                ValidarCampoNumerico(cDepreAnual, avisoDepreAnual);
                ValidarCampoNumerico(cValorResidual, avisoValorResidual);
                ValidarCampoDeTextoComNumeros(cDescricao, avisoCampoDescricao);
                ValidarCampoDeTextoComNumeros(cLocalizacao, avisoCampoLocalizacao);
                ValidarCampoDeTextoComNumeros(cCodigo, avisoCampoCodigo);
                ValidarCampoApenasNumeroELetras(cPlacaVeiculo, avisoPlacaVeiculo);
                ValidarCampoApenasNumeroELetras(cModeloVeiculo, avisoModeloVeiculo);
                ValidarCampoApenasLetras(cResponsavel, avisoResponsavel);

            });
        </script>

        <script src="../Scripts/Validacao.js"></script>
</asp:Content>
