using MaxWebApp.Campos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaxWebApp.Modelo;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Services;

namespace MaxWebApp.PageInventario
{
	public partial class InventarioDeItens : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindGridView();
			}
		}

		public async void BindGridView()
		{
			string url = "https://localhost:7279/v1/TodosOsItens";
			List<ItemModelo> listaItens = await MetodosBancoDeDadosApi.CarregarItensDoInventarioGET(url);
			GridView1.DataSource = listaItens;
			GridView1.DataBind();
		}

		protected async void btnSalvarAlteracoes_Click(object sender, EventArgs e)
		{
			var item = new ItemModelo()
			{
				Id = int.Parse(hfItemId.Value),
				codigo_item = txtCodigoDoItem.Text,
				placa_item = txtPlacaDoItem.Text,
				descricao_item = txtDescricaoDoItem.Text,
				data_aquisicao = DateTime.Parse(txtDataAquisicao.Text),
				inicio_depreciacao = DateTime.Parse(txtDataDepreciacao.Text),
				grupo_item = ddlGrupoItem.SelectedValue,
				estado_conservacao = ddlConservacaoItem.SelectedValue,
				localizacao_fisica = txtLocalizacaoFisica.Text,
				observacao = txtObservacao.Text,
				valor_aquisicao = txtValorAquisicao.Text,
				tipo_item = ddlTipoItem.SelectedValue,
				tipo_aquisicao = ddlTipoAquisicao.SelectedValue,
				tipo_comprovante = ddlTipoComprovante.SelectedValue,
				numero_comprovante = txtNumeroComprovante.Text,
				placa_veiculo = txtPlacaVeiculo.Text,
				modelo_veiculo = txtModeloVeiculo.Text,
				vida_util = txtVidaUtil.Text,
				depreciacao_anual = txtDepreciacaoAnual.Text,
				metodo_depreciacao = ddlMetodoDepreciacao.SelectedValue,
				tem_combustivel = ddlCombustivel.SelectedValue,
				responsavel = txtResponsavel.Text,
				valor_residual = txtValorResidual.Text,
				valor_depreciavel = txtValorDepreciavel.Text,
				valor_depreciado = txtValorDepreciado.Text,
				saldo_depreciar = txtSaldoDepreciar.Text,
				valor_liquido = txtValorLiquido.Text
			};
			var valida = new ValidacaoDosCampos();
			if (valida.CampoVazioOuNull(item.codigo_item, item.placa_item, item.descricao_item, item.data_aquisicao.ToString(), item.grupo_item, item.estado_conservacao, item.tipo_item,
										item.tipo_aquisicao, item.metodo_depreciacao, item.responsavel, item.inicio_depreciacao.ToString(), item.valor_residual, item.valor_depreciavel,
										item.valor_depreciado, item.saldo_depreciar, item.valor_liquido, item.valor_aquisicao, item.vida_util, item.depreciacao_anual))
			{
				if (valida.TamanhoLimiteDeCaracteres(item.codigo_item, item.placa_item, item.descricao_item, item.placa_veiculo, item.modelo_veiculo,
													 item.responsavel, item.valor_residual, item.localizacao_fisica, item.numero_comprovante,
													 item.valor_depreciavel, item.valor_depreciado, item.saldo_depreciar, item.observacao,
													 item.valor_liquido, item.valor_aquisicao, item.vida_util, item.depreciacao_anual))
				{
					if (VericarDuplicidade(item.placa_item, item.codigo_item, item.Id))
					{
						Page pagina = this.Page;
						string url = $"https://localhost:7279/v1/TodosOsItens/{item.Id}";
						await MetodosBancoDeDadosApi.AtualizarItemPUT(url, item);
						ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificaçãoCadastroSucesso", "NotificaçãoCadastroSucesso();", true);
					}
					else
					{ ScriptManager.RegisterStartupScript(this, this.GetType(), "CadastroDuplicado", "CadastroDuplicado();", true); }
				}
				else
				{
					ScriptManager.RegisterStartupScript(this, this.GetType(), "LimiteUltrapassadoDeCaracteres", "LimiteUltrapassadoDeCaracteres();", true);
				}
			}
			else
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificaçãoCampoInvalido", "NotificaçãoCampoInvalido();", true);
			}

			BindGridView();
		}

		public bool VericarDuplicidade(string placaDoItem, string codigoDoItem, int id)
		{
			List<ItemModelo> valida = new List<ItemModelo>();

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "SELECT codigo_item, placa_item FROM itens WHERE (placa_item = @placa_item OR codigo_item = @codigo_item) AND id <> @id";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					// Adicionando os parâmetros para evitar SQL Injection
					command.Parameters.AddWithValue("@placa_item", placaDoItem);
					command.Parameters.AddWithValue("@codigo_item", codigoDoItem);
					command.Parameters.AddWithValue("@id", id);

					using (SqlDataReader dr = command.ExecuteReader())
					{
						while (dr.Read())
						{
							ItemModelo camposAhValidar = new ItemModelo
							{
								codigo_item = dr["codigo_item"].ToString(),
								placa_item = dr["placa_item"].ToString()
							};

							valida.Add(camposAhValidar);
						}
					}
				}
			}

			// Verifica se a lista contém exatamente um item, indicando duplicidade
			return valida.Count == 0;
		}

		protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GridView1.PageIndex = e.NewPageIndex;
			BindGridView();
		}
	}
}
