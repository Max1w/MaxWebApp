using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
				SalvarInformacoesNoBanco(codigoDoItem, placaDoItem, descricaoDoItem, dataAquisicao, grupoDoItem, conservacaoDoItem, localizacoFisicaDoItem, observacaoDoItem, valorDoItem);
			}
			else
			{
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRO: ", "alert('Os campos obrigatórios não podem ser vazios')", true);
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
						Console.WriteLine("Dados inseridos com sucesso!");
					}
					else
					{
						Console.WriteLine("Falha ao inserir dados!");
					}
				}
			}
		}

	}
}