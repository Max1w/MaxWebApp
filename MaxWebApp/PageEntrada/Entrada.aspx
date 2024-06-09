<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="MaxWebApp.Entrada" %>

<%@ Register TagName="Campos" TagPrefix="cp" Src="~/Campos/CamposForm.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<link rel="stylesheet" href="configuracao.css" />
<script src="Scripts/configuracao.js"></script>

<body>
    <header>
        <h1>CADASTRO DE ITENS</h1>
    </header>

    <style>
        input, select, textarea {
            max-width: none;
        }

        .alert {
            position: fixed;
            top: 100px;
            right: 10px;
            display: none;
        }
    </style>
    
    <cp:Campos runat="server" ID="camposDoFormEntrada"></cp:Campos>
</body>
    <script>

        document.addEventListener('DOMContentLoaded', function () {

            //Campo Placa
            const cPlaca = document.getElementById('<%= camposDoFormEntrada.TxtPlacaDoItem.ClientID %>');
            const avisoCampoPlaca = document.getElementById('avisoPlaca');

            //Campo Descrição
            const cDescricao = document.getElementById('<%= camposDoFormEntrada.TxtDescricaoDoItem.ClientID %>');
            const avisoCampoDescricao = document.getElementById('avisoDescricao');

            //Campo Valor de Aquisição
            const cValor = document.getElementById('<%= camposDoFormEntrada.TxtValorItem.ClientID %>');
            const avisoCampoValor = document.getElementById('avisoValor');

            //Campo Localização Física
            const cLocalizacao = document.getElementById('<%= camposDoFormEntrada.TxtLocalizacaoFisica.ClientID %>');
            const avisoCampoLocalizacao = document.getElementById('avisoLocalizacao');

            //Campo Código
            const cCodigo = document.getElementById('<%= camposDoFormEntrada.TxtCodigoDoItem.ClientID %>');
            const avisoCampoCodigo = document.getElementById('avisoCodigo');

            //Numero Comprovante
            const cNumComprovante = document.getElementById('<%= camposDoFormEntrada.TxtNumeroComprovante.ClientID %>');
            const avisoNumComprovante = document.getElementById('avisoNumeroComprovante');

            //Placa do veículo
            const cPlacaVeiculo = document.getElementById('<%= camposDoFormEntrada.TxtPlacaVeiculo.ClientID %>');
            const avisoPlacaVeiculo = document.getElementById('avisoPlacaVeiculo');

            //Modelo do veículo
            const cModeloVeiculo = document.getElementById('<%= camposDoFormEntrada.TxtModeloVeiculo.ClientID %>');
            const avisoModeloVeiculo = document.getElementById('avisoModeloVeiculo');

            // Responsável
            const cResponsavel = document.getElementById('<%= camposDoFormEntrada.TxtResponsavel.ClientID %>');
            const avisoResponsavel = document.getElementById('avisoResponsavel');

            // vida util
            const cVidaUtil = document.getElementById('<%= camposDoFormEntrada.TxtVidaUtil.ClientID %>');
            const avisoVidaUtil = document.getElementById('avisoVidaUtil');

            //depreciação anual
            const cDepreAnual = document.getElementById('<%= camposDoFormEntrada.TxtDepreciacaoAnual.ClientID %>');
            const avisoDepreAnual = document.getElementById('avisoDepreciacaoAnual');

            // valor residual
            const cValorResidual = document.getElementById('<%= camposDoFormEntrada.TxtValorResidual.ClientID %>');
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
