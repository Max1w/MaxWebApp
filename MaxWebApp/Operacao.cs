
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
								item.CodigoItem = dr["codigo_item"].ToString();
								item.PlacaItem = dr["placa_item"].ToString();
								item.DescricaoItem = dr["descricao_item"].ToString();
								item.GrupoItem = dr["grupo_item"].ToString();
								item.LocalizacaoFisica = dr["localizacao_fisica"].ToString();
								item.DataAquisicao = Convert.ToDateTime(dr["data_aquisicao"]);
								item.EstadoConservacao = dr["estado_conservacao"].ToString();
								item.ValorAquisicao = dr["valor_aquisicao"].ToString();
								item.Observacao = dr["observacao"].ToString();
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
							CodigoItem = reader["codigo_item"].ToString(),
							PlacaItem = reader["placa_item"].ToString(),
							DescricaoItem = reader["descricao_item"].ToString(),
							GrupoItem = reader["grupo_item"].ToString(),
							EstadoConservacao = reader["estado_conservacao"].ToString(),
							TipoItem = reader["tipo_item"].ToString(),
							TipoAquisicao = reader["tipo_aquisicao"].ToString(),
							TipoComprovante = reader["tipo_comprovante"].ToString(),
							NumeroComprovante = reader["numero_comprovante"].ToString(),
							TemCombustivel = reader["tem_combustivel"].ToString(),
							PlacaVeiculo = reader["placa_veiculo"].ToString(),
							ModeloVeiculo = reader["modelo_veiculo"].ToString(),
							LocalizacaoFisica = reader["localizacao_fisica"].ToString(),
							Responsavel = reader["responsavel"].ToString(),
							Observacao = reader["observacao"].ToString(),
							ValorAquisicao = reader["valor_aquisicao"].ToString(),
							MetodoDepreciacao = reader["metodo_depreciacao"].ToString(),
							ValorResidual = reader["valor_residual"].ToString(),
							ValorDepreciavel = reader["valor_depreciavel"].ToString(),
							VidaUtil = reader["vida_util"].ToString(),
							DepreciacaoAnual = reader["depreciacao_anual"].ToString(),
							InicioDepreciacao = Convert.ToDateTime(reader["inicio_depreciacao"]),
							ValorDepreciado = reader["valor_depreciado"].ToString(),
							SaldoDepreciar = reader["saldo_depreciar"].ToString(),
							ValorLiquido = reader["valor_liquido"].ToString(),
							DataAquisicao = Convert.ToDateTime(reader["data_aquisicao"])
						};
					}
				}
			}
			return item;
		}
	}
}
