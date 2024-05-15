<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="MaxWebApp.Entrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Cadastro de Itens</h1>
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
				<input id="valorItem" type="text" oninput="FormatarParaDecimal()" class="form-control"  runat="server"/>
				<label id="exibirMensagemeErro"></label>
			</div>
		</div>
	</div>

	<script>
		function FormatarParaDecimal()
		{
			let campoValorDoItem = document.getElementById("MainContent_valorItem");
			let numero = parseFloat(campoValorDoItem.value)

			if (isNaN(numero))
			{
				return " ";
			}
			return numero.toFixed(2);
		}

    </script>

	<%--<button id="btnEnviar" class="btn btn-success" runat="server" text="Enviar" onserverclick="btnSalvar_Click">Salvar</button>--%>
	<button id="btnEnviar" class="btn btn-success float-end m-3" runat="server" onserverclick="btnSalvar_Click">Salvar</button>
	<a id="botaoCancelar" href="/" type="button" class="btn btn-danger m-3">Cancelar</a>
</asp:Content>
