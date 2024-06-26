﻿﻿﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CamposForm.ascx.cs" Inherits="MaxWebApp.Campos.CamposForm" %>

<style>
	.nav-tabs {
		position: relative;
		display: flex;
		border-radius: 0.5rem;
		background-color: #5CB85C;
		box-sizing: border-box;
		font-size: 14px;
		width: 100%;
		padding: 1rem 1rem 0 1rem;
	}

		.nav-tabs .nav-item {
			cursor: pointer;
			align-items: center;
			justify-content: center;
			border-top-left-radius: 0.5rem;
			border-top-right-radius: 0.5rem;
			border: none;
			padding: 0.5rem 0.8rem;
			color: #fff;
			transition: all 0.15s ease-in-out;
			position: relative;
		}

			.nav-tabs .nav-item.active {
				background-color: #e8e8e8;
				font-weight: 600;
			}

			.nav-tabs .nav-item:hover {
				background-color: #1d1d29;
			}

			.nav-tabs .nav-item.active::after,
			.nav-tabs .nav-item.active::before {
				content: "";
				position: absolute;
				width: 10px;
				height: 10px;
				background-color: #5CB85C;
				bottom: 0;
			}

			.nav-tabs .nav-item.active::after {
				right: -10px;
				border-bottom-left-radius: 300px;
				box-shadow: -1px 1px 0px 0px #e8e8e8;
			}

			.nav-tabs .nav-item.active::before {
				left: -10px;
				border-bottom-right-radius: 300px;
				box-shadow: 1px 1px 0px 0px #e8e8e8;
			}
</style>

<div class="container-fluid">
	<div class="d-flex row justify-content-center align-items-center align-middle" style="margin-top: 5em; margin-bottom: 7em;">
		<div class="col-12">
			<asp:HiddenField ID="IdRandom" runat="server" />
			<div class="d-flex rounded justify-content-center" style="background: rgb(177, 174, 174, 0.1);">

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
				<%--inicio--%>
				<div class="nav nav-tabs" id="nav-tab" role="tablist">
					<a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Item</a>
					<a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Valor</a>
				</div>
			</nav>
			<%--fim--%>
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
							<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtResponsavel" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
						</div>
					</div>
				</div>
				<div class="tab-pane fade d-flex rounded justify-content-center mt-5" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
					<%--inicio--%>
					<div class="form-group m-1" style="padding-right: 0px; padding-left: 0px">

						<div class="d-flex justify-content-center">
							<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
								<label for="text">Valor de Aquisição *</label>
								<asp:TextBox runat="server" ID="txtValorAquisicao" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
								<div id="avisoValor" class="invalid-feedback">Favor inserir um valor (R$)</div>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDataAquisicao" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
							</div>
							<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
								<label for="text">Vida Útil</label>
								<asp:TextBox runat="server" ID="txtVidaUtil" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
								<div id="avisoVidaUtil" class="invalid-feedback">Favor inserir Apenas numeros</div>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVidaUtil" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
							</div>
							<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
								<label for="text">Depreciação Anual *</label>
								<asp:TextBox runat="server" ID="txtDepreciacaoAnual" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
								<div id="avisoDepreciacaoAnual" class="invalid-feedback">Favor inserir um valor (R$)</div>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDepreciacaoAnual" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
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
								<asp:TextBox runat="server" ID="txtValorResidual" CssClass="form-control shadow p-3 col-12" Enabled="false"></asp:TextBox>
							</div>
							<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
								<label for="text">Valor depreciável</label>
								<asp:TextBox runat="server" ID="txtValorDepreciavel" CssClass="form-control shadow p-3 col-12" Enabled="false"></asp:TextBox>
							</div>
							<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px;">
								<label for="text">Valor depreciado</label>
								<asp:TextBox runat="server" ID="txtValorDepreciado" CssClass="form-control shadow p-3 col-12" Enabled="false"></asp:TextBox>
							</div>
							<div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
								<label for="text">Ínicio da depreciação *</label>
								<asp:TextBox runat="server" ID="txtDataDepreciacao" TextMode="Date" CssClass="form-control shadow p-3 col-12"></asp:TextBox>
							</div>
						</div>
						<div class="d-flex justify-content-center">
							<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px;">
								<label for="text">Saldo a depreciar</label>
								<asp:TextBox runat="server" ID="txtSaldoDepreciar" CssClass="form-control shadow p-3 col-12" Enabled="false"></asp:TextBox>
							</div>
							<div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px; width: 408px">
								<label for="text">Valor líquido</label>
								<asp:TextBox runat="server" ID="txtValorLiquido" CssClass="form-control shadow p-3 col-12" Enabled="false"></asp:TextBox>
							</div>
						</div>
						<div class="d-flex justify-content-end mt-5" id="btnCancelar">
							<button id="botaoCalcular" class="btn btn-danger m-3" runat="server" onserverclick="botaoCalcular_ServerClick">calcular</button>
							<a id="botaoCancelar" href="/" class="btn btn-danger m-3">Cancelar</a>
							<button type="button" class="btn btn-success m-3" data-toggle="modal" data-target="#exampleModal">Salvar</button>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
	<div class="modal-dialog" role="document">
		<div class="modal-content">
			<div class="modal-header">
				<h5 class="modal-title" id="exampleModalLabel">Confirmação</h5>
				<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
			</div>
			<div class="modal-body" id="descriocaoDoModal">
				Deseja salvar esse cadastro?
			</div>
			<div class="modal-footer" id="btnSalvar">
				<button type="button" class="btn btn-danger" data-dismiss="modal" onclick="NotificaçãoCadastroCancelar()">Cancelar</button>
				<button id="btnEnviarEntrada" type="button" class="btn btn-success" runat="server" onserverclick="btnSalvar_Click">Salvar</button>
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
</script>