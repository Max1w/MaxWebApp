using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static MaxWebApp.Operacao;

namespace MaxWebApp
{
	public partial class Entrada : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnSalvar_Click(object sender, EventArgs e)
		{
			ValidarCampos();
		}

		private void ValidarCampos()
		{
			var codigoDoItem = codigoItem.Value;
			var placaDoItem = placaItem.Value;
			var descricaoDoItem = descricaoItem.Value;
			var dataAquisicao = dtAquisicao.Value;
			var grupoDoItem = grupoItem.Value;
			var conservacaoDoItem = conservacaoItem.Value;
			var localizacoFisicaDoItem = localizacoFisicaItem.Value;
			var observacaoDoItem = observacao.Value;
			var valorDoItem = cValorItem.Value;

			if (!string.IsNullOrEmpty(codigoDoItem) && !string.IsNullOrEmpty(placaDoItem) && !string.IsNullOrEmpty(descricaoDoItem) && !string.IsNullOrEmpty(dataAquisicao))
			{
				if (VericarDuplicidade(placaDoItem, codigoDoItem))
				{ SalvarInformacoesNoBanco(codigoDoItem, placaDoItem, descricaoDoItem, dataAquisicao, grupoDoItem, conservacaoDoItem, localizacoFisicaDoItem, observacaoDoItem, valorDoItem); }
				else
				{ClientScript.RegisterStartupScript(this.GetType(), "CadastroDuplicado", "CadastroDuplicado();", true); }
			}
			else
			{
				ClientScript.RegisterStartupScript(this.GetType(), "NotificaçãoCadastroInvalido", "NotificaçãoCadastroInvalido();", true);
			}
		}

		protected void SalvarInformacoesNoBanco(string codigoDoItem, string placaDoItem, string descricaoDoItem, string dataAquisicao, string grupoDoItem, string conservacaoDoItem, string localizacoFisicaDoItem, string observacaoDoItem, string valorDoItem)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "INSERT INTO itens (codigo_item, placa_item, descricao_item, data_aquisicao, grupo_item, estado_conservacao, localizacao_fisica, observacao, valor_aquisicao, patrimonios_id) VALUES (@codigo_item, @placa_item, @descricao_item, @data_aquisicao, @grupo_item, @estado_conservacao, @localizacao_fisica, @observacao, @valor_aquisicao, @patrimonios_id)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@codigo_item", codigoDoItem);
					command.Parameters.AddWithValue("@placa_item", placaDoItem);
					command.Parameters.AddWithValue("@descricao_item", descricaoDoItem);
					command.Parameters.AddWithValue("@data_aquisicao", Convert.ToDateTime(dataAquisicao));
					command.Parameters.AddWithValue("@grupo_item", grupoDoItem);
					command.Parameters.AddWithValue("@estado_conservacao", conservacaoDoItem);
					command.Parameters.AddWithValue("@localizacao_fisica", localizacoFisicaDoItem);
					command.Parameters.AddWithValue("@observacao", observacaoDoItem);
					command.Parameters.AddWithValue("@valor_aquisicao", valorDoItem);
					command.Parameters.AddWithValue("@patrimonios_id", 1);

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
		}

		protected void Unnamed_Click(object sender, EventArgs e)
		{
			ExibirCastroDosItens.Visible = true;
		}

		protected bool VericarDuplicidade(string placaDoItem, string codigoDoItem)
		{

			List<Item> valida = new List<Item>();

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "SELECT codigo_item, placa_item FROM itens WHERE placa_item = "+placaDoItem+ " or codigo_item = "+codigoDoItem;

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
								camposAhValidar.Codigo = dr["codigo_item"].ToString();
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