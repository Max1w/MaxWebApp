
using MaxWebApp.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;

namespace MaxWebApp
{
	public class Operacao
	{
		public List<ItemModelo> ListarItensDoBancoDeDados()
		{
			List<ItemModelo> itens = new List<ItemModelo>();

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "SELECT TOP 60 id, codigo_item, placa_item, descricao_item, grupo_item, localizacao_fisica, data_aquisicao, estado_conservacao, valor_aquisicao, observacao FROM itens";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader dr = command.ExecuteReader())
						{
							while (dr.Read())
							{
								ItemModelo item = new ItemModelo();
								item.Id = Convert.ToInt32(dr["id"]);
								item.codigo_item = dr["codigo_item"].ToString();
								item.placa_item = dr["placa_item"].ToString();
								item.descricao_item = dr["descricao_item"].ToString();
								item.grupo_item = dr["grupo_item"].ToString();
								item.localizacao_fisica = dr["localizacao_fisica"].ToString();
								item.data_aquisicao = Convert.ToDateTime(dr["data_aquisicao"]);
								item.estado_conservacao = dr["estado_conservacao"].ToString();
								item.valor_aquisicao = dr["valor_aquisicao"].ToString();
								item.observacao = dr["observacao"].ToString();
								itens.Add(item);
							}
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Erro: " + ex.Message);
				}
			}

			return itens;
		}
		public ItemModelo ObterItemPorId(string id)
		{
			ItemModelo item = null;
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "SELECT id, codigo_item, placa_item, descricao_item, tipo_item, grupo_item, tipo_aquisicao, tipo_comprovante, numero_comprovante, estado_conservacao, tem_combustivel, placa_veiculo, modelo_veiculo, localizacao_fisica, responsavel, observacao, valor_aquisicao, metodo_depreciacao, valor_residual, valor_depreciavel, vida_util, depreciacao_anual, inicio_depreciacao, valor_depreciado, saldo_depreciar, valor_liquido, data_aquisicao FROM itens WHERE id = @id";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@id", id);
				
				connection.Open();

				using (SqlDataReader reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						item = new ItemModelo
						{
							Id = Convert.ToInt32(reader["id"]),
							codigo_item = reader["codigo_item"].ToString(),
							placa_item = reader["placa_item"].ToString(),
							descricao_item = reader["descricao_item"].ToString(),
							grupo_item = reader["grupo_item"].ToString(),
							estado_conservacao = reader["estado_conservacao"].ToString(),
							tipo_item = reader["tipo_item"].ToString(),
							tipo_aquisicao = reader["tipo_aquisicao"].ToString(),
							tipo_comprovante = reader["tipo_comprovante"].ToString(),
							numero_comprovante = reader["numero_comprovante"].ToString(),
							tem_combustivel = reader["tem_combustivel"].ToString(),
							placa_veiculo = reader["placa_veiculo"].ToString(),
							modelo_veiculo = reader["modelo_veiculo"].ToString(),
							localizacao_fisica = reader["localizacao_fisica"].ToString(),
							responsavel = reader["responsavel"].ToString(),
							observacao = reader["observacao"].ToString(),
							valor_aquisicao = reader["valor_aquisicao"].ToString(),
							metodo_depreciacao = reader["metodo_depreciacao"].ToString(),
							valor_residual = reader["valor_residual"].ToString(),
							valor_depreciavel = reader["valor_depreciavel"].ToString(),
							vida_util = reader["vida_util"].ToString(),
							depreciacao_anual = reader["depreciacao_anual"].ToString(),
							inicio_depreciacao = Convert.ToDateTime(reader["inicio_depreciacao"]),
							valor_depreciado = reader["valor_depreciado"].ToString(),
							saldo_depreciar = reader["saldo_depreciar"].ToString(),
							valor_liquido = reader["valor_liquido"].ToString(),
							data_aquisicao = Convert.ToDateTime(reader["data_aquisicao"])
						};
					}
				}
			}
			return item;
		}
	}
}
