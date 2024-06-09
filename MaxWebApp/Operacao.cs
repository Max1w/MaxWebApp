
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;

namespace MaxWebApp
{
	public class Operacao
	{
		public class Item
		{
			public int ID { get; set; }
			public string Codigo { get; set; }
			public string Placa { get; set; }
			public string Descricao { get; set; }
			public string Grupo { get; set; }
			public string Localizacao { get; set; }
			public DateTime DtAquisicao { get; set; }
            public DateTime InicioDepreciacao { get; set; }
			public string EstadoConservacao { get; set; }
			public string ValorAquisicao { get; set; }
			public string Observacao { get; set; }
            public string Tipo { get; set; }
            public string TipoAquisicao { get; set; }
            public string TipoComprovante { get; set; }
            public string NumeroComprovante { get; set; }
            public string TemCombustivel { get; set; }
            public string PlacaVeiculo { get; set; }
            public string ModeloVeiculo { get; set; }
            public string Responsavel { get; set; }
            public string MetodoDepreciacao { get; set; }
            public string ValorResidual { get; set; }
            public string ValorDepreciavel { get; set; }
            public string VidaUtil { get; set; }
            public string DepreciacaoAnual { get; set; }
            public string ValorDepreciado { get; set; }
            public string SaldoDepreciar { get; set; }
            public string ValorLiquido { get; set; }
        }

		public List<Item> ListarItensDoBancoDeDados()
		{
			List<Item> itens = new List<Item>();

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
								Item item = new Item();
								item.ID = Convert.ToInt32(dr["id"]);
								item.Codigo = dr["codigo_item"].ToString();
								item.Placa = dr["placa_item"].ToString();
								item.Descricao = dr["descricao_item"].ToString();
								item.Grupo = dr["grupo_item"].ToString();
								item.Localizacao = dr["localizacao_fisica"].ToString();
								item.DtAquisicao = Convert.ToDateTime(dr["data_aquisicao"]);
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
		public Item ObterItemPorId(string id)
		{
			Item item = null;
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
						item = new Item
						{
							ID = Convert.ToInt32(reader["id"]),
							Codigo = reader["codigo_item"].ToString(),
							Placa = reader["placa_item"].ToString(),
							Descricao = reader["descricao_item"].ToString(),
							Grupo = reader["grupo_item"].ToString(),
							EstadoConservacao = reader["estado_conservacao"].ToString(),
							Tipo = reader["tipo_item"].ToString(),
							TipoAquisicao = reader["tipo_aquisicao"].ToString(),
							TipoComprovante = reader["tipo_comprovante"].ToString(),
							NumeroComprovante = reader["numero_comprovante"].ToString(),
							TemCombustivel = reader["tem_combustivel"].ToString(),
							PlacaVeiculo = reader["placa_veiculo"].ToString(),
							ModeloVeiculo = reader["modelo_veiculo"].ToString(),
							Localizacao = reader["localizacao_fisica"].ToString(),
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
							DtAquisicao = Convert.ToDateTime(reader["data_aquisicao"])
						};
					}
				}
			}
			return item;
		}
	}
}
