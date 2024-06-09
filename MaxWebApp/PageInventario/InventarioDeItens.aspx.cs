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
			var c = new CamposForm();
			c.CampoEntradaID = camposDoFormSaida.ID;
			Session["CampoEntradaID"] = c.CampoEntradaID;

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
			var c = new CamposForm();

			if (e.CommandName == "Editar")
			{
				string id = e.CommandArgument.ToString();
				c.CarregarDetalhesDoItem(id);
			}
		}

		public void AtivarPainel()
		{
			pnlEdit.Visible = true;
		}
		public void DesativarPainel()
		{
			pnlEdit.Visible = false;
		}
		
		public void AtualizarItem(Item item, Page pagina)
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
					ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), "NotificaçãoCadastroSucesso", "NotificaçãoCadastroSucesso();", true);
				}
				else
				{
					Console.WriteLine("Falha ao inserir dados!");
				}
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

		protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GridView1.PageIndex = e.NewPageIndex;
			BindGridView();
		}
	}
}
