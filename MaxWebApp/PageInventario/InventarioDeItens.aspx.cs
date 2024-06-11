using MaxWebApp.Campos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using static MaxWebApp.Operacao;

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

		public void BindGridView()
		{
			var operacao = new Operacao();
			List<Operacao.Item> listaItens = operacao.ListarItensDoBancoDeDados();
			GridView1.DataSource = listaItens;
			GridView1.DataBind();
		}

		protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Editar")
			{
				string id = e.CommandArgument.ToString();
				pnlEdit.Visible = true;
				CarregarDetalhesDoItem(id);
			}
		}

		public void CarregarDetalhesDoItem(string id)
		{
			var inv = new InventarioDeItens();
			var operacao = new Operacao();
			var item = operacao.ObterItemPorId(id);

			if (item != null)
			{
				hfItemId.Value = item.ID.ToString();
				txtCodigoDoItem.Text = item.Codigo.ToString();
				txtPlacaDoItem.Text = item.Placa.ToString();
				txtDescricaoDoItem.Text = item.Descricao;
				txtDataAquisicao.Text = item.DtAquisicao.ToString("yyyy-MM-dd");
				ddlGrupoItem.Text = item.Grupo.ToString();
				ddlConservacaoItem.Text = item.EstadoConservacao.ToString();
				txtLocalizacaoFisica.Text = item.Localizacao.ToString();
				txtObservacao.Text = item.Observacao;
				txtValorAquisicao.Text = item.ValorAquisicao.ToString();
				ddlTipoItem.Text = item.Tipo.ToString();
				ddlTipoAquisicao.Text = item.TipoAquisicao.ToString();
				ddlTipoComprovante.Text = item.TipoComprovante.ToString();
				txtNumeroComprovante.Text = item.NumeroComprovante.ToString();
				txtPlacaVeiculo.Text = item.PlacaVeiculo.ToString();
				txtModeloVeiculo.Text = item.ModeloVeiculo.ToString();
				txtVidaUtil.Text = item.VidaUtil.ToString();
				txtDepreciacaoAnual.Text = item.DepreciacaoAnual.ToString();
				ddlMetodoDepreciacao.Text = item.MetodoDepreciacao.ToString();
				ddlCombustivel.Text = item.TemCombustivel.ToString();
				txtResponsavel.Text = item.Responsavel.ToString();
				txtDataDepreciacao.Text = item.InicioDepreciacao.ToString("yyyy-MM-dd");
				txtValorResidual.Text = item.ValorResidual.ToString();
				txtValorDepreciavel.Text = item.ValorDepreciavel.ToString();
				txtValorDepreciado.Text = item.ValorDepreciado.ToString();
				txtSaldoDepreciar.Text = item.SaldoDepreciar.ToString();
				txtValorLiquido.Text = item.ValorLiquido.ToString();

				pnlEdit.Visible = true;
			}
		}

		protected void botaoCancelarInventario_Click(object sender, EventArgs e)
		{
			pnlEdit.Visible = false;
		}

		protected void btnSalvarAlteracoes_Click(object sender, EventArgs e)
		{
			var operacao = new Operacao();
			var item = new Operacao.Item()
			{
				ID = int.Parse(hfItemId.Value),
				Codigo = txtCodigoDoItem.Text,
				Placa = txtPlacaDoItem.Text,
				Descricao = txtDescricaoDoItem.Text,
				DtAquisicao = DateTime.Parse(txtDataAquisicao.Text),
				InicioDepreciacao = DateTime.Parse(txtDataDepreciacao.Text),
				Grupo = ddlGrupoItem.SelectedValue,
				EstadoConservacao = ddlConservacaoItem.SelectedValue,
				Localizacao = txtLocalizacaoFisica.Text,
				Observacao = txtObservacao.Text,
				ValorAquisicao = txtValorAquisicao.Text,
				Tipo = ddlTipoItem.SelectedValue,
				TipoAquisicao = ddlTipoAquisicao.SelectedValue,
				TipoComprovante = ddlTipoComprovante.SelectedValue,
				NumeroComprovante = txtNumeroComprovante.Text,
				PlacaVeiculo = txtPlacaVeiculo.Text,
				ModeloVeiculo = txtModeloVeiculo.Text,
				VidaUtil = txtVidaUtil.Text,
				DepreciacaoAnual = txtDepreciacaoAnual.Text,
				MetodoDepreciacao = ddlMetodoDepreciacao.SelectedValue,
				TemCombustivel = ddlCombustivel.SelectedValue,
				Responsavel = txtResponsavel.Text,
				ValorResidual = txtValorResidual.Text,
				ValorDepreciavel = txtValorDepreciavel.Text,
				ValorDepreciado = txtValorDepreciado.Text,
				SaldoDepreciar = txtSaldoDepreciar.Text,
				ValorLiquido = txtValorLiquido.Text

			};

			if (!string.IsNullOrEmpty(item.Codigo) && !string.IsNullOrEmpty(item.Placa) && !string.IsNullOrEmpty(item.Descricao) && !string.IsNullOrEmpty(item.ValorAquisicao) && !string.IsNullOrEmpty(item.Grupo) && !string.IsNullOrEmpty(item.EstadoConservacao) && !string.IsNullOrEmpty(item.Tipo) && !string.IsNullOrEmpty(item.TipoAquisicao) && !string.IsNullOrEmpty(item.DepreciacaoAnual) && !string.IsNullOrEmpty(item.MetodoDepreciacao) && !string.IsNullOrEmpty(item.ValorResidual) && !string.IsNullOrEmpty(item.Responsavel))
			{
				if ((item.Codigo.Length < 10) && (item.Placa.Length < 10) && (item.Descricao.Length < 2000) && (item.Localizacao.Length < 2000) && (item.Observacao.Length < 4000) && (item.ValorAquisicao.Length < 999999) && (item.NumeroComprovante.Length < 20) && (item.PlacaVeiculo.Length < 10) && (item.ModeloVeiculo.Length < 50) && (item.VidaUtil.Length < 5) && (item.DepreciacaoAnual.Length < 10) && (item.ValorResidual.Length < 999999) && (item.ValorDepreciavel.Length < 999999) && (item.ValorDepreciado.Length < 999999) && (item.SaldoDepreciar.Length < 999999) && (item.ValorLiquido.Length < 999999) && (item.Responsavel.Length < 161))
				{
					if (VericarDuplicidade(item.Placa, item.ID))
					{
						Page pagina = this.Page;
						AtualizarItem(item, pagina);
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

			pnlEdit.Visible = false;
			BindGridView();
		}

		protected void botaoCalcular_ServerClick(object sender, EventArgs e)
		{
			var calc = new CalculoDepreciacaoDosItens();

			try
			{
				var valorDoItem = Convert.ToDecimal(txtValorAquisicao.Text);
				var vidaUtil = Convert.ToInt32(txtValorAquisicao.Text);
				var depreciacaoAnual = Convert.ToInt32(txtValorAquisicao.Text);

				var resultadoDepreciacao_pt1 = calc.CalcularDepreciacao_Parte1(valorDoItem, vidaUtil, depreciacaoAnual);
				var resultadoDepreciacao_pt2 = calc.CalcularDepreciacao_Parte2(valorDoItem, vidaUtil, resultadoDepreciacao_pt1.Item3, resultadoDepreciacao_pt1.Item2);

				txtValorResidual.Text = resultadoDepreciacao_pt1.Item1.ToString();
				txtValorDepreciavel.Text = resultadoDepreciacao_pt1.Item2.ToString();
				txtValorDepreciado.Text = resultadoDepreciacao_pt2.Item3.ToString();

				txtSaldoDepreciar.Text = resultadoDepreciacao_pt2.Item1.ToString();
				txtValorLiquido.Text = resultadoDepreciacao_pt2.Item2.ToString();
			}
			catch (FormatException ex)
			{
				// Lidar com erros de conversão de formato
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ErroConversao", "alert('Erro na conversão dos valores. Verifique os campos e tente novamente.');", true);
			}
			catch (Exception ex)
			{
				// Lidar com outros tipos de erros
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ErroGeral", $"alert('Ocorreu um erro: {ex.Message}');", true);
			}
		}
		public bool VericarDuplicidade(string placaDoItem, int id)
		{

			List<Item> valida = new List<Item>();

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "SELECT codigo_item, placa_item FROM itens WHERE placa_item = " + placaDoItem + " AND id <> " + id;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader dr = command.ExecuteReader())
						{
							//var opa = dr.Read();
							while (dr.Read())
							{
								Item camposAhValidar = new Item();
								camposAhValidar.Placa = dr["placa_item"].ToString();

								valida.Add(camposAhValidar);
							}
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Erro: " + ex.Message);
				}

				if (valida.Count() == 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public void AtualizarItem(Item item, Page pagina)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "UPDATE itens SET placa_item = @placa_item, descricao_item = @descricao_item, grupo_item = @grupo_item, localizacao_fisica = @localizacao_fisica, data_aquisicao = @data_aquisicao, estado_conservacao = @estado_conservacao, valor_aquisicao = @valor_aquisicao, observacao = @observacao, tipo_item = @tipo_item, tipo_aquisicao = @tipo_aquisicao, tipo_comprovante = @tipo_comprovante, numero_comprovante = @numero_comprovante, tem_combustivel = @tem_combustivel, placa_veiculo = @placa_veiculo, modelo_veiculo = @modelo_veiculo, responsavel = @responsavel, vida_util = @vida_util, depreciacao_anual = @depreciacao_anual, metodo_depreciacao = @metodo_depreciacao, inicio_depreciacao = @inicio_depreciacao, valor_residual = @valor_residual, valor_depreciavel = @valor_depreciavel, valor_depreciado = @valor_depreciado, saldo_depreciar = @saldo_depreciar, valor_liquido = @valor_liquido WHERE id = " + item.ID + "";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@placa_item", item.Placa);
				command.Parameters.AddWithValue("@descricao_item", item.Descricao);
				command.Parameters.AddWithValue("@data_aquisicao", Convert.ToDateTime(item.DtAquisicao));
				command.Parameters.AddWithValue("@grupo_item", item.Grupo);
				command.Parameters.AddWithValue("@estado_conservacao", item.EstadoConservacao);
				command.Parameters.AddWithValue("@localizacao_fisica", item.Localizacao);
				command.Parameters.AddWithValue("@observacao", item.Observacao);
				command.Parameters.AddWithValue("@valor_aquisicao", item.ValorAquisicao);
				command.Parameters.AddWithValue("@tipo_item", item.Tipo);
				command.Parameters.AddWithValue("@tipo_aquisicao", item.TipoAquisicao);
				command.Parameters.AddWithValue("@tipo_comprovante", item.TipoComprovante);
				command.Parameters.AddWithValue("@numero_comprovante", item.NumeroComprovante);
				command.Parameters.AddWithValue("@tem_combustivel", item.TemCombustivel);
				command.Parameters.AddWithValue("@placa_veiculo", item.PlacaVeiculo);
				command.Parameters.AddWithValue("@modelo_veiculo", item.ModeloVeiculo);
				command.Parameters.AddWithValue("@responsavel", item.Responsavel);
				command.Parameters.AddWithValue("@vida_util", item.VidaUtil);
				command.Parameters.AddWithValue("@depreciacao_anual", item.DepreciacaoAnual);
				command.Parameters.AddWithValue("@metodo_depreciacao", item.MetodoDepreciacao);
				command.Parameters.AddWithValue("@inicio_depreciacao", item.InicioDepreciacao);
				command.Parameters.AddWithValue("@valor_residual", item.ValorResidual);
				command.Parameters.AddWithValue("@valor_depreciavel", item.ValorDepreciavel);
				command.Parameters.AddWithValue("@valor_depreciado", item.ValorDepreciado);
				command.Parameters.AddWithValue("@saldo_depreciar", item.SaldoDepreciar);
				command.Parameters.AddWithValue("@valor_liquido", item.ValorLiquido);

				connection.Open();

				int rowsAffected = command.ExecuteNonQuery();

				if (rowsAffected > 0)
				{
					ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), "NotificaçãoCadastroSucesso", "NotificaçãoCadastroSucesso();", true);
				}
				else
				{
					Console.WriteLine("Falha ao inserir dados!");
				}
			}
		}

		protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GridView1.PageIndex = e.NewPageIndex;
			BindGridView();
		}
	}
}
