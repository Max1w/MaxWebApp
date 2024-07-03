<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="InventarioDeItens.aspx.cs" Inherits="MaxWebApp.PageInventario.InventarioDeItens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container">
		<div>
			<h1 style="margin-top: 60px; text-align: center">Inventário</h1>
		</div>
		<style>
			.rounded-grid {
				border-radius: 20px;
				border-top: hidden;
				border-left: hidden;
				border-right: hidden;
				border-bottom: hidden;
			}
		</style>
		<asp:GridView ID="GridView1" runat="server" CssClass="grid-large table table-striped mt-5 table-hover table-light rounded-grid" AutoGenerateColumns="false" DataKeyNames="ID" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
    <Columns>
        <asp:BoundField DataField="codigo_item" HeaderText="Código" />
        <asp:BoundField DataField="placa_item" HeaderText="Placa" />
        <asp:BoundField DataField="descricao_item" HeaderText="Descrição" />
        <asp:BoundField DataField="grupo_item" HeaderText="Grupo" />
        <asp:BoundField DataField="localizacao_fisica" HeaderText="Localização" />
        <asp:BoundField DataField="observacao" HeaderText="Observação" />
        <asp:BoundField DataField="valor_aquisicao" HeaderText="Valor de Aquisição" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="data_aquisicao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:TemplateField>
            <ItemTemplate>
                <button type="button" data-toggle="modal" data-target="#modalCenter" onclick="CarregarItensNosCampos('<%# Eval("ID") %>')" class="btn btn-outline-primary">Editar</button>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle HorizontalAlign="Center" />
</asp:GridView>

	</div>
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
	<div class="modal fade" id="modalCenter" tabindex="-1" role="dialog" aria-labelledby="modalCenterTitle" aria-hidden="true">
		<div class="modal-dialog modal-xl modal-dialog-centered" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
					<button type="button" class="close" data-dismiss="modal" aria-label="Close">
						<span aria-hidden="true">&times;</span>
					</button>
				</div>
				<div class="modal-body">

					<div class="container-fluid">
						<div class="d-flex row justify-content-center align-items-center align-middle" style="margin-top: 5em; margin-bottom: 7em;">
							<div class="col-12">
								<asp:HiddenField ID="hfItemId" runat="server" />
								<div class="d-flex rounded justify-content-center mb-2" style="background: rgb(177, 174, 174, 0.1);">

									<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
										<label class="mt-2" for="text">Placa *</label>
										<asp:TextBox runat="server" ID="txtPlacaDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
										<div id="avisoPlaca" class="invalid-feedback">Favor inserir apenas numero</div>
										<asp:RequiredFieldValidator ID="rfvPlacaDoItem" runat="server" ControlToValidate="txtPlacaDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
									</div>

									<div class="form-group m-1 col-9" style="padding-right: 0px; padding-left: 0px">
										<label class="mt-2" for="text">Descrição *</label>
										<asp:TextBox runat="server" ID="txtDescricaoDoItem" TextMode="MultiLine" Rows="1" CssClass="form-control col-12 shadow p-3 bg-light"></asp:TextBox>
										<div id="avisoDescricao" class="invalid-feedback">Favor inserir um caracter válido</div>
										<asp:RequiredFieldValidator ID="rfvDescricaoDoItem" runat="server" ControlToValidate="txtDescricaoDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
									</div>
								</div>
								<nav>
									<div class="nav nav-tabs" id="nav-tab" role="tablist">
										<a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Item</a>
										<a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Valor</a>
									</div>
								</nav>
								<div class="tab-content" id="nav-tabContent">
									<div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">

										<div class="d-flex rounded justify-content-center mb-2 mt-5">
											<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
												<label for="text">Código *</label>
												<asp:TextBox runat="server" ID="txtCodigoDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
												<div id="avisoCodigo" class="invalid-feedback">Favor inserir um caracter válido</div>
												<asp:RequiredFieldValidator ID="rfvCodigoDoItem" runat="server" ControlToValidate="txtCodigoDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
											</div>
											<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px">
												<label for="exemplo">Tipo *</label>
												<asp:DropDownList runat="server" ID="ddlTipoItem" CssClass="form-control col-12">
													<asp:ListItem>Móvel</asp:ListItem>
													<asp:ListItem>Imóvel</asp:ListItem>
													<asp:ListItem>Dominical</asp:ListItem>
												</asp:DropDownList>
											</div>
											<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px">
												<label for="exemplo">Grupo *</label>
												<asp:DropDownList runat="server" ID="ddlGrupoItem" CssClass="form-control col-12" onchange="teste()">
													<asp:ListItem>Móvel Mobiliario</asp:ListItem>
													<asp:ListItem>Imóvel residencia</asp:ListItem>
													<asp:ListItem>Móvel Veículo</asp:ListItem>
												</asp:DropDownList>
											</div>
											<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px">
												<label for="exemplo">Estado de Conservação *</label>
												<asp:DropDownList runat="server" ID="ddlConservacaoItem" CssClass="form-control col-12">
													<asp:ListItem>Ótimo</asp:ListItem>
													<asp:ListItem>Bom</asp:ListItem>
													<asp:ListItem>Regular</asp:ListItem>
													<asp:ListItem>Ruim</asp:ListItem>
													<asp:ListItem>Péssimo</asp:ListItem>
												</asp:DropDownList>
											</div>
										</div>

										<div class="d-flex rounded justify-content-center" style="margin-bottom: -15px">
											<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
												<label for="text">Data da Aquisição *</label>
												<asp:TextBox runat="server" ID="txtDataAquisicao" TextMode="Date" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
												<asp:RequiredFieldValidator ID="rfvDataAquisicao" runat="server" ControlToValidate="txtDataAquisicao" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
											</div>
											<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px">
												<label for="exemplo">Tipo de Aquisição *</label>
												<asp:DropDownList runat="server" ID="ddlTipoAquisicao" CssClass="form-control">
													<asp:ListItem>Compra</asp:ListItem>
													<asp:ListItem>Doação</asp:ListItem>
													<asp:ListItem>Emprestado</asp:ListItem>
												</asp:DropDownList>
											</div>
											<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px">
												<label for="exemplo">Tipo de Comprovante</label>
												<asp:DropDownList runat="server" ID="ddlTipoComprovante" CssClass="form-control">
													<asp:ListItem>Nota Fiscal</asp:ListItem>
													<asp:ListItem>Cupom Fiscal</asp:ListItem>
												</asp:DropDownList>
											</div>
											<div class="form-group m-1" style="padding-right: 0px; padding-left: 0px; width: 269px">
												<label for="text">Nº do Comprovante</label>
												<asp:TextBox runat="server" ID="txtNumeroComprovante" CssClass="form-control col-12 shadow p-3 bg-light"></asp:TextBox>
												<div id="avisoNumeroComprovante" class="invalid-feedback">Favor inserir apenas numero</div>
											</div>
										</div>
										<div class="d-flex rounded justify-content-center mb-2">
											<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
												<label for="exemplo">Usa Combustível?</label>
												<asp:DropDownList runat="server" ID="ddlCombustivel" CssClass="form-control" disabled="true" onchange="teste()">
													<asp:ListItem Text=" " Value=" "></asp:ListItem>
													<asp:ListItem Text="Sim" Value="Sim"></asp:ListItem>
													<asp:ListItem Text="Não" Value="Não"></asp:ListItem>
												</asp:DropDownList>
											</div>
											<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
												<label for="text">Placa do Veículo</label>
												<asp:TextBox runat="server" ID="txtPlacaVeiculo" CssClass="form-control col-12 shadow p-3" disabled="true"></asp:TextBox>
												<div id="avisoPlacaVeiculo" class="invalid-feedback">Favor inserir apenas numero e letras</div>
											</div>
											<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
												<label for="text">Modelo do Veículo</label>
												<asp:TextBox runat="server" ID="txtModeloVeiculo" CssClass="form-control col-12 shadow p-3" disabled="true"></asp:TextBox>
												<div id="avisoModeloVeiculo" class="invalid-feedback">Favor inserir apenas numero e letras</div>
											</div>
											<div class="form-group m-1" style="padding-right: 8px; padding-left: 0px; width: 453px">
												<label for="text">Localização Física</label>
												<asp:TextBox runat="server" ID="txtLocalizacaoFisica" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
												<div id="avisoLocalizacao" class="invalid-feedback">Favor inserir um caracter válido</div>
											</div>
										</div>
										<div class="d-flex rounded justify-content-center mb-2">
											<div class="form-group m-1" style="padding-right: 0px; padding-left: 0px; width: 530px">
												<label for="teste">Observação</label>
												<asp:TextBox runat="server" ID="txtObservacao" TextMode="MultiLine" Rows="1" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
											</div>
											<div class="form-group m-1" style="padding-right: 8px; padding-left: 0px; width: 500px">
												<label for="text">Responsável *</label>
												<asp:TextBox runat="server" ID="txtResponsavel" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
												<div id="avisoResponsavel" class="invalid-feedback">Favor inserir apenas letras</div>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtResponsavel" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
											</div>
										</div>
									</div>
									<div class="tab-pane fade d-flex rounded justify-content-center mt-5" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
										<div class="form-group m-1 " style="padding-right: 0px; padding-left: 0px">

											<div class="d-flex justify-content-center">
												<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
													<label for="txtValorAquisicao">Valor de Aquisição *</label>
													<input runat="server" class="form-control shadow p-3 bg-light col-12" type="text" id="txtValorAquisicao" oninput="calucularDepreciacao()" required/>
													<div id="avisoValor" class="invalid-feedback">Favor inserir um valor (R$)</div>
												</div>
												<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
													<label for="txtVidaUtil">Vida Útil</label>
													<input runat="server" type="text" class="form-control shadow p-3 bg-light col-12" id="txtVidaUtil" oninput="calucularDepreciacao()" required/>
													<div id="avisoVidaUtil" class="invalid-feedback">Favor inserir Apenas numeros</div>
												</div>
												<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
													<label for="txtDepreciacaoAnual">Depreciação Anual *</label>
													<input runat="server" class="form-control shadow p-3 bg-light col-12" type="text" id="txtDepreciacaoAnual" oninput="calucularDepreciacao()" required/>
													<div id="avisoDepreciacaoAnual" class="invalid-feedback">Favor inserir um valor (R$)</div>
												</div>
												<div class="form-group m-1 col-4" style="padding-right: 0px; padding-left: 0px;">
													<label for="exemplo">Método de Depreciação *</label>
													<asp:DropDownList runat="server" ID="ddlMetodoDepreciacao" CssClass="form-control col-12">
														<asp:ListItem>Método Linear ou Cotas Constantes</asp:ListItem>
													</asp:DropDownList>
												</div>
											</div>
											<div class="d-flex justify-content-center">
												<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px;">
													<label for="text">Valor residual</label>
													<asp:TextBox runat="server" ID="txtValorResidual" CssClass="form-control shadow p-3 col-12"></asp:TextBox>
												</div>
												<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
													<label for="text">Valor depreciável</label>
													<asp:TextBox runat="server" ID="txtValorDepreciavel" CssClass="form-control shadow p-3 col-12"></asp:TextBox>
												</div>
												<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px;">
													<label for="text">Valor depreciado</label>
													<asp:TextBox runat="server" ID="txtValorDepreciado" CssClass="form-control shadow p-3 col-12"></asp:TextBox>
												</div>
												<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
													<label for="text">Ínicio da depreciação *</label>
													<asp:TextBox runat="server" ID="txtDataDepreciacao" TextMode="Date" CssClass="form-control shadow p-3 col-12"></asp:TextBox>
												</div>
											</div>
											<div class="d-flex justify-content-center">
												<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px;">
													<label for="text">Saldo a depreciar</label>
													<asp:TextBox runat="server" ID="txtSaldoDepreciar" CssClass="form-control shadow p-3 col-12"></asp:TextBox>
												</div>
												<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px; width: 408px">
													<label for="text">Valor líquido</label>
													<asp:TextBox runat="server" ID="txtValorLiquido" CssClass="form-control shadow p-3 col-12"></asp:TextBox>
												</div>
											</div>
											<div class="d-flex justify-content-end mt-5" id="btnCancelar">
												<asp:LinkButton ID="btnCancelarInventario" runat="server" data-dismiss="modal" CssClass="btn btn-danger m-3">Cancelar</asp:LinkButton>
												<button runat="server" type="button" class="btn btn-success m-3" data-toggle="modal" data-target="#exampleModal" onserverclick="btnSalvarAlteracoes_Click" >Salvar</button>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
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

	<script src="../Scripts/Notificacao.js"></script>

	<script>

		function calucularDepreciacao() {
			
			let valorAquisicao = parseFloat(document.getElementById('<%= txtValorAquisicao.ClientID %>').value)
			let vidaUtil = parseInt(document.getElementById('<%= txtVidaUtil.ClientID %>').value)
			let depreciacaoAnual = parseInt(document.getElementById('<%= txtDepreciacaoAnual.ClientID %>').value)

			if (isNaN(valorAquisicao) || isNaN(vidaUtil) || isNaN(depreciacaoAnual)) {
				return true;
			}

			function ValorResidual(valorAquisicao, vidaUtil) {
				let result = valorAquisicao * vidaUtil;
				let valorResidual = result / 100;
				return valorResidual;
			}

			function ValorDepreciavel(valorResidual, valorAquisicao) {
				let valorDepreciavel = valorAquisicao - valorResidual;
				return valorDepreciavel;
			}

			function ValorDepreciado(valorDepreciavel, depreciacaoAnual) {
				let valorDepreciado = valorDepreciavel * depreciacaoAnual / 100;
				return valorDepreciado;
			}

			function ValorLiquidoContabil(valorAquisicao, valorDepreciado) {
				let valorLiquidoContabil = valorAquisicao - valorDepreciado;
				return valorLiquidoContabil;
			}

			function SaldoADepreciar(valorDepreciavel, valorDepreciado) {
				let saldoADepreciar = valorDepreciavel - valorDepreciado;
				return saldoADepreciar;
			}

			function CalcularDepreciacao_Parte2(valorAquisicao, vidaUtil, valorDepreciado, valorDepreciavel) {
				let valorDepreciadoAcumulado = 0;
				let valorLiquido = 0;
				let saldoADepreciar = 0;

				for (let i = 0; i < 2; i++) {
					valorDepreciadoAcumulado += valorDepreciado;
					valorLiquido = ValorLiquidoContabil(valorAquisicao, valorDepreciadoAcumulado);
					saldoADepreciar = SaldoADepreciar(valorDepreciavel, valorDepreciadoAcumulado);
				}

				return {
					saldoADepreciar: saldoADepreciar,
					valorLiquido: valorLiquido,
					valorDepreciadoAcumulado: valorDepreciadoAcumulado
				};
			}

			function CalcularDepreciacao_Parte1(valorAquisicao, vidaUtil, depreciacaoAnual) {
				let valorResidual = ValorResidual(valorAquisicao, vidaUtil);
				let valorDepreciavel = ValorDepreciavel(valorResidual, valorAquisicao);
				let valorDepreciado = ValorDepreciado(valorDepreciavel, depreciacaoAnual);

				let parte2 = CalcularDepreciacao_Parte2(valorAquisicao, vidaUtil, valorDepreciado, valorDepreciavel);

				return {
					valorResidual: valorResidual,
					valorDepreciavel: valorDepreciavel,
					valorDepreciado: valorDepreciado,
					saldoADepreciar: parte2.saldoADepreciar,
					valorLiquido: parte2.valorLiquido,
					valorDepreciadoAcumulado: parte2.valorDepreciadoAcumulado
				};
			}

			// Calcular os valores
			let resultado = CalcularDepreciacao_Parte1(valorAquisicao, vidaUtil, depreciacaoAnual);

			// Exibir os resultados
			document.getElementById("MainContent_txtValorResidual").value = resultado.valorResidual.toFixed(2);
			document.getElementById("MainContent_txtValorDepreciavel").value = resultado.valorDepreciavel.toFixed(2);
			document.getElementById("MainContent_txtValorDepreciado").value = resultado.valorDepreciadoAcumulado.toFixed(2);
			document.getElementById("MainContent_txtSaldoDepreciar").value = resultado.saldoADepreciar.toFixed(2);
			document.getElementById("MainContent_txtValorLiquido").value = resultado.valorLiquido.toFixed(2);
		}

		function CarregarItensNosCampos(id) {
			console.log('Starting AJAX request with id:', id);
			$.ajax({
				url: 'https://localhost:7279/v1/TodosOsItens/' + id,
				type: 'GET',
				contentType: 'application/json; charset=utf-8',
				dataType: 'json',
				success: function (response) {
					$('#<%= hfItemId.ClientID %>').val(response.id);
					$('#<%= txtCodigoDoItem.ClientID %>').val(response.codigo_item);
					$('#<%= txtPlacaDoItem.ClientID %>').val(response.placa_item);
					$('#<%= txtDescricaoDoItem.ClientID %>').val(response.descricao_item);
					$('#<%= txtDataAquisicao.ClientID %>').val(new Date(response.data_aquisicao).toISOString().substring(0, 10));
					$('#<%= txtDataDepreciacao.ClientID %>').val(new Date(response.inicio_depreciacao).toISOString().substring(0, 10));
					$('#<%= ddlGrupoItem.ClientID %>').val(response.grupo_item);
					$('#<%= ddlConservacaoItem.ClientID %>').val(response.estado_conservacao);
					$('#<%= txtLocalizacaoFisica.ClientID %>').val(response.localizacao_fisica);
					$('#<%= txtObservacao.ClientID %>').val(response.observacao);
					$('#<%= txtValorAquisicao.ClientID %>').val(response.valor_aquisicao);
					$('#<%= ddlTipoItem.ClientID %>').val(response.tipo_item);
					$('#<%= ddlTipoAquisicao.ClientID %>').val(response.tipo_aquisicao);
					$('#<%= ddlTipoComprovante.ClientID %>').val(response.tipo_comprovante);
					$('#<%= txtNumeroComprovante.ClientID %>').val(response.numero_comprovante);
					$('#<%= txtPlacaVeiculo.ClientID %>').val(response.placa_veiculo);
					$('#<%= txtModeloVeiculo.ClientID %>').val(response.modelo_veiculo);
					$('#<%= txtVidaUtil.ClientID %>').val(response.vida_util);
					$('#<%= txtDepreciacaoAnual.ClientID %>').val(response.depreciacao_anual);
					$('#<%= ddlMetodoDepreciacao.ClientID %>').val(response.metodo_depreciacao);
					$('#<%= ddlCombustivel.ClientID %>').val(response.tem_combustivel);
					$('#<%= txtResponsavel.ClientID %>').val(response.responsavel);
					$('#<%= txtValorResidual.ClientID %>').val(response.valor_residual);
					$('#<%= txtValorDepreciavel.ClientID %>').val(response.valor_depreciavel);
					$('#<%= txtValorDepreciado.ClientID %>').val(response.valor_depreciado);
					$('#<%= txtSaldoDepreciar.ClientID %>').val(response.saldo_depreciar);
					$('#<%= txtValorLiquido.ClientID %>').val(response.valor_liquido);
				},
				error: function (xhr, status, error) {
					console.error('Erro ao carregar detalhes do item:', error);
					console.log('Status:', status);
					console.log('XHR:', xhr);
				}
			});
		}

		function teste() {
			var grupo = document.getElementById('<%= ddlGrupoItem.ClientID %>');
			var combustivel = document.getElementById('<%= ddlCombustivel.ClientID %>');
			var placaVeiculo = document.getElementById('<%= txtPlacaVeiculo.ClientID %>');
			var modeloVeiculo = document.getElementById('<%= txtModeloVeiculo.ClientID %>');

			if (grupo.value == "Móvel Veículo") {
				combustivel.disabled = false;
				combustivel.classList.remove("disabled");
			} else {
				combustivel.disabled = true;
				combustivel.classList.add("disabled");
				combustivel.value = "Não";
				placaVeiculo.value = "";
				modeloVeiculo.value = "";
			}

			if (combustivel.value == "Sim") {

				placaVeiculo.disabled = false;
				placaVeiculo.classList.remove("disabled");
				placaVeiculo.classList.add("bg-light");

				modeloVeiculo.disabled = false;
				modeloVeiculo.classList.remove("disabled");
				modeloVeiculo.classList.add("bg-light");

			} else if (combustivel.value == "Não") {

				placaVeiculo.disabled = true;
				placaVeiculo.classList.add("disabled");
				placaVeiculo.classList.remove("bg-light");

				placaVeiculo.value = "";
				modeloVeiculo.value = "";

				modeloVeiculo.disabled = true;
				modeloVeiculo.classList.add("disabled");
				modeloVeiculo.classList.remove("bg-light");
			}
		}

		document.addEventListener('DOMContentLoaded', function () {

			//Campo Placa
			const cPlaca = document.getElementById('<%= txtPlacaDoItem.ClientID %>');
			const avisoCampoPlaca = document.getElementById('avisoPlaca');

			//Campo Descrição
			const cDescricao = document.getElementById('<%= txtDescricaoDoItem.ClientID %>');
			const avisoCampoDescricao = document.getElementById('avisoDescricao');

			//Campo Valor de Aquisição
			const cValor = document.getElementById('<%= txtValorAquisicao.ClientID %>');
			const avisoCampoValor = document.getElementById('avisoValor');

			//Campo Localização Física
			const cLocalizacao = document.getElementById('<%= txtLocalizacaoFisica.ClientID %>');
			const avisoCampoLocalizacao = document.getElementById('avisoLocalizacao');

			//Campo Código
			const cCodigo = document.getElementById('<%= txtCodigoDoItem.ClientID %>');
			const avisoCampoCodigo = document.getElementById('avisoCodigo');

			//Numero Comprovante
			const cNumComprovante = document.getElementById('<%= txtNumeroComprovante.ClientID %>');
			const avisoNumComprovante = document.getElementById('avisoNumeroComprovante');

			//Placa do veículo
			const cPlacaVeiculo = document.getElementById('<%= txtPlacaVeiculo.ClientID %>');
			const avisoPlacaVeiculo = document.getElementById('avisoPlacaVeiculo');

			//Modelo do veículo
			const cModeloVeiculo = document.getElementById('<%= txtModeloVeiculo.ClientID %>');
			const avisoModeloVeiculo = document.getElementById('avisoModeloVeiculo');

			// Responsável
			const cResponsavel = document.getElementById('<%= txtResponsavel.ClientID %>');
			const avisoResponsavel = document.getElementById('avisoResponsavel');

			// vida util
			const cVidaUtil = document.getElementById('<%= txtVidaUtil.ClientID %>');
			const avisoVidaUtil = document.getElementById('avisoVidaUtil');

			//depreciação anual
			const cDepreAnual = document.getElementById('<%= txtDepreciacaoAnual.ClientID %>');
			const avisoDepreAnual = document.getElementById('avisoDepreciacaoAnual');

			// valor residual
			const cValorResidual = document.getElementById('<%= txtValorResidual.ClientID %>');
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
