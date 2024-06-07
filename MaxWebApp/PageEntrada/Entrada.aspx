<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="MaxWebApp.Entrada" %>

<%@ Register TagName="Campos" TagPrefix="cp" Src="~/Campos/CamposForm.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<link rel="stylesheet" href="configuracao.css" />
<script src="Scripts/configuracao.js"></script>

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

            ValidarCampoNumero(cPlaca, avisoCampoPlaca);
            ValidarCampoNumerico(cValor, avisoCampoValor);
            ValidarCampoDeTextoComNumeros(cDescricao, avisoCampoDescricao);
            ValidarCampoDeTextoComNumeros(cLocalizacao, avisoCampoLocalizacao);
            ValidarCampoDeTextoComNumeros(cCodigo, avisoCampoCodigo);

        });
    </script>

    <script src="../Scripts/Validacao.js"></script>

</asp:Content>
