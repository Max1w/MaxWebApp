<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Saida.aspx.cs" Inherits="MaxWebApp.Saida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="configuracao.css" />
    <script src="Scripts/configuracao.js"></script>

    <body>
        <div class="container">
            <div>
                <h1 style="margin-bottom: 20px;">Saída de Itens</h1>
            </div>
            <asp:GridView ID="GridView1" runat="server" CssClass="grid-large table table-striped mt-5 table-hover table-light" AutoGenerateColumns="False"  DataKeyNames="ID" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                                <input type="checkbox" id="ckSelecionarTodos" class="form-check-input" style="margin-left: 0px">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="ckSelecionados" CssClass="ckSelecionados" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Codigo" HeaderText="Código" />
                    <asp:BoundField DataField="Placa" HeaderText="Placa" />
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="ValorAquisicao" HeaderText="Valor de Aquisição" DataFormatString="{0:N2}" />
                    <asp:BoundField DataField="DtAquisicao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
                </Columns>
            </asp:GridView>

            <div class="d-flex justify-content-end">
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
    </body>

    <script>
		document.addEventListener("DOMContentLoaded", function () {
			var ckSelecionarTodos = document.getElementById('ckSelecionarTodos');
			ckSelecionarTodos.addEventListener('change', function () {
				var checkboxes = document.querySelectorAll('#<%= GridView1.ClientID %> .ckSelecionados input[type="checkbox"]');
            checkboxes.forEach(function(checkbox) {
                checkbox.checked = ckSelecionarTodos.checked;
            });
        });

        document.getElementById('ExcluirItensSelecionados').addEventListener('click', function() {
            var idsDosItensSelecionadosParaAExclusao = [];
            var checkboxes = document.querySelectorAll('#<%= GridView1.ClientID %> .ckSelecionados input[type="checkbox"]');
			checkboxes.forEach(function (checkbox) {
				if (checkbox.checked) {
					var linha = checkbox.closest('tr');
					var id = linha.querySelector('input[data-key]').dataset.key;
					idsDosItensSelecionadosParaAExclusao.push(id);
				}
			});

			if (idsDosItensSelecionadosParaAExclusao.length > 0) {
				var req = new XMLHttpRequest();
				req.open('POST', 'SeuCaminhoParaExcluir', true);
				req.setRequestHeader('Content-Type', 'application/json');
				req.onreadystatechange = function () {
					if (req.readyState === 4 && req.status === 200) {
						var response = JSON.parse(req.responseText);
						if (response.success) {
							// Atualize o GridView ou faça algo após a exclusão bem-sucedida
							location.reload();
						} else {
							alert('Erro ao excluir itens.');
						}
					} else if (req.readyState === 4) {
						console.error('Erro:', req.statusText);
					}
				};
				req.send(JSON.stringify({ ids: idsDosItensSelecionadosParaAExclusao }));
			} else {
				alert('Nenhum item selecionado.');
			}
		});
	});
	</script>


</asp:Content>
