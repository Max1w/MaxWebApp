﻿using MaxWebApp.Campos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaxWebApp.Modelo;

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

		protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Editar")
			{
				string id = e.CommandArgument.ToString();
				pnlEdit.Visible = true;
				CarregarDetalhesDoItem(id);
			}
		}

		public async void CarregarDetalhesDoItem(string id)
		{
			string url = $"https://localhost:7279/v1/TodosOsItens{id}";
			List<ItemModelo> listaItens = await MetodosBancoDeDadosApi.CarregarItensDoInventarioGET(url);

			if (listaItens != null && listaItens.Count > 0)
			{
				ItemModelo item = listaItens[0]; // Supondo que você quer o primeiro item da lista

				hfItemId.Value = item.Id.ToString();
				txtCodigoDoItem.Text = item.codigo_item;
				txtPlacaDoItem.Text = item.placa_item;
				txtDescricaoDoItem.Text = item.descricao_item;
				txtDataAquisicao.Text = item.data_aquisicao.ToString("yyyy-MM-dd");
				ddlConservacaoItem.SelectedValue = item.estado_conservacao;
				ddlGrupoItem.SelectedValue = item.grupo_item;
				txtLocalizacaoFisica.Text = item.localizacao_fisica;
				txtObservacao.Text = item.observacao;
				txtValorAquisicao.Text = item.valor_aquisicao.ToString();
				ddlTipoItem.SelectedValue = item.tipo_item;
				ddlTipoAquisicao.SelectedValue = item.tipo_aquisicao;
				ddlTipoComprovante.SelectedValue = item.tipo_comprovante;
				txtNumeroComprovante.Text = item.numero_comprovante;
				txtPlacaVeiculo.Text = item.placa_veiculo;
				txtModeloVeiculo.Text = item.modelo_veiculo;
				txtVidaUtil.Text = item.vida_util.ToString();
				txtDepreciacaoAnual.Text = item.depreciacao_anual.ToString();
				ddlMetodoDepreciacao.SelectedValue = item.metodo_depreciacao;
				ddlCombustivel.SelectedValue = item.tem_combustivel;
				txtResponsavel.Text = item.responsavel;
				txtDataDepreciacao.Text = item.inicio_depreciacao.ToString("yyyy-MM-dd");
				txtValorResidual.Text = item.valor_residual.ToString();
				txtValorDepreciavel.Text = item.valor_depreciavel.ToString();
				txtValorDepreciado.Text = item.valor_depreciado.ToString();
				txtSaldoDepreciar.Text = item.saldo_depreciar.ToString();
				txtValorLiquido.Text = item.valor_liquido.ToString();

				pnlEdit.Visible = true;
			}
		}


		protected void botaoCancelarInventario_Click(object sender, EventArgs e)
		{
			pnlEdit.Visible = false;
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

			if (!string.IsNullOrEmpty(item.codigo_item) && !string.IsNullOrEmpty(item.placa_item) && !string.IsNullOrEmpty(item.descricao_item) && !string.IsNullOrEmpty(item.valor_aquisicao) && !string.IsNullOrEmpty(item.grupo_item) && !string.IsNullOrEmpty(item.estado_conservacao) && !string.IsNullOrEmpty(item.tipo_item) && !string.IsNullOrEmpty(item.tipo_aquisicao) && !string.IsNullOrEmpty(item.depreciacao_anual) && !string.IsNullOrEmpty(item.metodo_depreciacao) && !string.IsNullOrEmpty(item.valor_residual) && !string.IsNullOrEmpty(item.responsavel))
			{
				if ((item.codigo_item.Length < 10) && (item.placa_item.Length < 10) && (item.descricao_item.Length < 2000) && (item.localizacao_fisica.Length < 2000) && (item.observacao.Length < 4000) && (item.valor_aquisicao.Length < 999999) && (item.numero_comprovante.Length < 20) && (item.placa_veiculo.Length < 10) && (item.modelo_veiculo.Length < 50) && (item.vida_util.Length < 5) && (item.depreciacao_anual.Length < 10) && (item.valor_residual.Length < 999999) && (item.valor_depreciavel.Length < 999999) && (item.valor_depreciado.Length < 999999) && (item.saldo_depreciar.Length < 999999) && (item.valor_liquido.Length < 999999) && (item.responsavel.Length < 161))
				{
					if (VericarDuplicidade(item.placa_item, item.Id))
					{
						Page pagina = this.Page;
						string url = $"https://localhost:7279/v1/TodosOsItens/{item.Id}";
						await MetodosBancoDeDadosApi.AtualizarItemPUT(url, item);
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

			List<ItemModelo> valida = new List<ItemModelo>();

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
								ItemModelo camposAhValidar = new ItemModelo();
								camposAhValidar.placa_item = dr["placa_item"].ToString();

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

		public void AtualizarItem(ItemModelo item, Page pagina)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "UPDATE itens SET placa_item = @placa_item, descricao_item = @descricao_item, grupo_item = @grupo_item, localizacao_fisica = @localizacao_fisica, data_aquisicao = @data_aquisicao, estado_conservacao = @estado_conservacao, valor_aquisicao = @valor_aquisicao, observacao = @observacao, tipo_item = @tipo_item, tipo_aquisicao = @tipo_aquisicao, tipo_comprovante = @tipo_comprovante, numero_comprovante = @numero_comprovante, tem_combustivel = @tem_combustivel, placa_veiculo = @placa_veiculo, modelo_veiculo = @modelo_veiculo, responsavel = @responsavel, vida_util = @vida_util, depreciacao_anual = @depreciacao_anual, metodo_depreciacao = @metodo_depreciacao, inicio_depreciacao = @inicio_depreciacao, valor_residual = @valor_residual, valor_depreciavel = @valor_depreciavel, valor_depreciado = @valor_depreciado, saldo_depreciar = @saldo_depreciar, valor_liquido = @valor_liquido WHERE id = " + item.Id + "";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@placa_item", item.placa_item);
				command.Parameters.AddWithValue("@descricao_item", item.descricao_item);
				command.Parameters.AddWithValue("@data_aquisicao", Convert.ToDateTime(item.data_aquisicao));
				command.Parameters.AddWithValue("@grupo_item", item.grupo_item);
				command.Parameters.AddWithValue("@estado_conservacao", item.estado_conservacao);
				command.Parameters.AddWithValue("@localizacao_fisica", item.localizacao_fisica);
				command.Parameters.AddWithValue("@observacao", item.observacao);
				command.Parameters.AddWithValue("@valor_aquisicao", item.valor_aquisicao);
				command.Parameters.AddWithValue("@tipo_item", item.tipo_item);
				command.Parameters.AddWithValue("@tipo_aquisicao", item.tipo_aquisicao);
				command.Parameters.AddWithValue("@tipo_comprovante", item.tipo_comprovante);
				command.Parameters.AddWithValue("@numero_comprovante", item.numero_comprovante);
				command.Parameters.AddWithValue("@tem_combustivel", item.tem_combustivel);
				command.Parameters.AddWithValue("@placa_veiculo", item.placa_veiculo);
				command.Parameters.AddWithValue("@modelo_veiculo", item.modelo_veiculo);
				command.Parameters.AddWithValue("@responsavel", item.responsavel);
				command.Parameters.AddWithValue("@vida_util", item.vida_util);
				command.Parameters.AddWithValue("@depreciacao_anual", item.depreciacao_anual);
				command.Parameters.AddWithValue("@metodo_depreciacao", item.metodo_depreciacao);
				command.Parameters.AddWithValue("@inicio_depreciacao", item.inicio_depreciacao);
				command.Parameters.AddWithValue("@valor_residual", item.valor_residual);
				command.Parameters.AddWithValue("@valor_depreciavel", item.valor_depreciavel);
				command.Parameters.AddWithValue("@valor_depreciado", item.valor_depreciado);
				command.Parameters.AddWithValue("@saldo_depreciar", item.saldo_depreciar);
				command.Parameters.AddWithValue("@valor_liquido", item.valor_liquido);

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
