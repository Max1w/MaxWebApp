using MaxWebApp.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MaxWebApp
{
	public class ValidacaoDosCampos
	{
		public bool CampoVazioOuNull(ItemModelo item)
		{
			return !string.IsNullOrEmpty(item.codigo_item) && !string.IsNullOrEmpty(item.placa_item) && !string.IsNullOrEmpty(item.descricao_item) && !string.IsNullOrEmpty(item.data_aquisicao.ToString()) &&
				   !string.IsNullOrEmpty(item.grupo_item) && !string.IsNullOrEmpty(item.estado_conservacao) && !string.IsNullOrEmpty(item.tipo_item) && !string.IsNullOrEmpty(item.tipo_aquisicao) &&
				   !string.IsNullOrEmpty(item.metodo_depreciacao) && !string.IsNullOrEmpty(item.responsavel) && !string.IsNullOrEmpty(item.inicio_depreciacao.ToString()) && !string.IsNullOrEmpty(item.valor_residual) &&
				   !string.IsNullOrEmpty(item.valor_depreciavel) && !string.IsNullOrEmpty(item.valor_depreciado) && !string.IsNullOrEmpty(item.saldo_depreciar) && !string.IsNullOrEmpty(item.valor_liquido) &&
				   !string.IsNullOrEmpty(item.valor_aquisicao) && !string.IsNullOrEmpty(item.vida_util) && !string.IsNullOrEmpty(item.depreciacao_anual);
		}
		public bool TamanhoLimiteDeCaracteres(ItemModelo item)
		{
			return item.codigo_item.Length < 10 && item.placa_item.Length < 10 && item.descricao_item.Length < 2000 && item.localizacao_fisica.Length < 2000 &&
				   item.observacao.Length < 4000 && item.numero_comprovante.Length < 20 && item.placa_veiculo.Length < 10 && item.modelo_veiculo.Length < 50 &&
				   item.valor_aquisicao.Length < 50 && item.vida_util.Length < 50 && item.depreciacao_anual.Length < 50 && item.valor_residual.Length < 50 &&
				   item.valor_depreciavel.Length < 50 && item.valor_depreciado.Length < 50 && item.saldo_depreciar.Length < 50 && item.valor_liquido.Length < 50 && item.responsavel.Length < 50;
		}
		public bool VericarDuplicidade(string placaDoItem, string codigoDoItem, int? id = null)
		{
			List<ItemModelo> valida = new List<ItemModelo>();

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "SELECT codigo_item, placa_item FROM itens WHERE (placa_item = @placa_item OR codigo_item = @codigo_item)";

			if (id.HasValue)
			{
				query += " AND id <> @id";
			}

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@placa_item", placaDoItem);
						command.Parameters.AddWithValue("@codigo_item", codigoDoItem);

						if (id.HasValue)
						{
							command.Parameters.AddWithValue("@id", id.Value);
						}

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
				catch (SqlException ex)
				{
					Console.WriteLine("SQL Error: " + ex.Message);
					return false;
				}
				catch (Exception ex)
				{
					Console.WriteLine("General Error: " + ex.Message);
					return false;
				}
			}
			return valida.Count == 0;
		}

	}
}