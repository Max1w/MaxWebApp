<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Saida.aspx.cs" Inherits="MaxWebApp.Saida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<link rel="stylesheet" href="configuracao.css" />
	<script src="Scripts/configuracao.js"></script>

	<div class="container">
		<div>
			<h1 style="margin-top: 60px; text-align: center">Saída de Itens</h1>
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
		<asp:GridView ID="GridView1" runat="server" CssClass="grid-large table table-striped mt-5 table-light table-responsive-sm table-hover rounded-grid" AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
			<Columns>
				<asp:TemplateField>
					<HeaderTemplate>
						<input type="checkbox" id="ckSelecionarTodos" class="form-check-input" style="margin-left: 0px">
					</HeaderTemplate>
					<ItemTemplate>
						<asp:CheckBox ID="ckSelecionados" CssClass="ckSelecionados" runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField DataField="codigo_item" HeaderText="Código" />
				<asp:BoundField DataField="placa_item" HeaderText="Placa" />
				<asp:BoundField DataField="descricao_item" HeaderText="Descrição" />
				<asp:BoundField DataField="valor_aquisicao" HeaderText="Valor de Aquisição" DataFormatString="{0:N2}" />
				<asp:BoundField DataField="data_aquisicao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
			</Columns>

			<PagerStyle HorizontalAlign="Center" />
			<PagerSettings Mode="NextPreviousFirstLast" NextPageText="Próximo >" PreviousPageText="< Anterior" />
		</asp:GridView>

		<div class="d-flex justify-content-end mt-5">
			<a id="botaoCancelar" href="/" class="btn btn-primary m-3">Voltar</a>
			<button type="button" class="btn btn-danger m-3" data-toggle="modal" data-target="#exampleModal">
				Excluir
			</button>
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
					<div class="modal-body">
						Deseja realmente excluir este cadastro?
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-danger" data-dismiss="modal" onclick="NotificaçãoCadastroCancelar()">Cancelar</button>
						<asp:Button ID="ExcluirItensSelecionados" runat="server" Text="Excluir" OnClick="ExcluirItensSelecionados_Click" CssClass="btn btn-warning" />
					</div>
				</div>
			</div>
		</div>
	</div>
	<script>
		document.addEventListener("DOMContentLoaded", function () {
			var ckSelecionarTodos = document.getElementById('ckSelecionarTodos');
			ckSelecionarTodos.addEventListener('change', function () {
				var checkboxes = document.querySelectorAll('#<%= GridView1.ClientID %> .ckSelecionados input[type="checkbox"]');
				checkboxes.forEach(function (checkbox) {
					checkbox.checked = ckSelecionarTodos.checked;
				});
			});
		});
	</script>


</asp:Content>
