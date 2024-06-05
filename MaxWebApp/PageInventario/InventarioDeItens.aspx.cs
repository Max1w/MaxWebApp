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

		private void BindGridView()
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
				CarregarDetalhesDoItem(id);
			}
		}

		private void CarregarDetalhesDoItem(string id)
		{
			var operacao = new Operacao();
			var item = operacao.ObterItemPorId(id);

			if (item != null)
			{
				hfItemId.Value = item.ID.ToString();
				txtCodigoDoItem.Text = item.Codigo;
				txtPlacaDoItem.Text = item.Placa;
				txtDescricaoDoItem.Text = item.Descricao;
				txtDataAquisicao.Text = item.DtAquisicao.ToString("yyyy-MM-dd");
				ddlGrupoItem.SelectedValue = item.Grupo;
				ddlConservacaoItem.SelectedValue = item.EstadoConservacao;
				txtLocalizacaoFisica.Text = item.Localizacao;
				txtObservacao.Text = item.Observacao;
				txtValorItem.Text = item.ValorAquisicao.ToString();
				pnlEdit.Visible = true;
			}
		}

		protected void botaoCancelar_Click(object sender, EventArgs e)
		{
			pnlEdit.Visible = false;
		}

		protected void btnSalvar_Click(object sender, EventArgs e)
		{
			var operacao = new Operacao();
			var item = new Operacao.Item()
			{
				ID = int.Parse(hfItemId.Value),
				Codigo = txtCodigoDoItem.Text,
				Placa = txtPlacaDoItem.Text,
				Descricao = txtDescricaoDoItem.Text,
				DtAquisicao = DateTime.Parse(txtDataAquisicao.Text),
				Grupo = ddlGrupoItem.SelectedValue,
				EstadoConservacao = ddlConservacaoItem.SelectedValue,
				Localizacao = txtLocalizacaoFisica.Text,
				Observacao = txtObservacao.Text,
				ValorAquisicao = txtValorItem.Text
			};
			if (!string.IsNullOrEmpty(item.Codigo) || !string.IsNullOrEmpty(item.Placa) || !string.IsNullOrEmpty(item.Descricao) || !string.IsNullOrEmpty(item.ValorAquisicao))
			{
				if ((item.Codigo.Length < 10) || (item.Placa.Length < 10) || (item.Descricao.Length < 2000) || (item.Localizacao.Length < 2000) || (item.Observacao.Length < 4000) || (item.ValorAquisicao.Length < 999999999))
				{
					if (VericarDuplicidade(item.Placa, item.ID))
					{ AtualizarItem(item); }
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
		public void AtualizarItem(Item item)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "UPDATE itens SET placa_item = @placa_item, descricao_item = @descricao_item, grupo_item = @grupo_item, localizacao_fisica = @localizacao_fisica, data_aquisicao = @data_aquisicao, estado_conservacao = @estado_conservacao, valor_aquisicao = @valor_aquisicao, observacao = @observacao WHERE id = " + item.ID + "";

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

				connection.Open();

				int rowsAffected = command.ExecuteNonQuery();

				if (rowsAffected > 0)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "NotificaçãoCadastroSucesso", "NotificaçãoCadastroSucesso();", true);
				}
				else
				{
					Console.WriteLine("Falha ao inserir dados!");
				}
			}
		}
		protected bool VericarDuplicidade(string placaDoItem, int id)
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
	}
}
