
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
			public string EstadoConservacao { get; set; }
			public string ValorAquisicao { get; set; }
			public string Observacao { get; set; }
		}

		public List<Item> ListarItensDoBancoDeDados()
		{
			List<Item> itens = new List<Item>();

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "SELECT id, codigo_item, placa_item, descricao_item, grupo_item, localizacao_fisica, data_aquisicao, estado_conservacao, valor_aquisicao, observacao FROM itens";

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
			string query = "SELECT id, codigo_item, placa_item, descricao_item, grupo_item, localizacao_fisica, data_aquisicao, estado_conservacao, valor_aquisicao, observacao FROM itens WHERE id = @id";

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
							Localizacao = reader["localizacao_fisica"].ToString(),
							DtAquisicao = Convert.ToDateTime(reader["data_aquisicao"]),
							EstadoConservacao = reader["estado_conservacao"].ToString(),
							ValorAquisicao = reader["valor_aquisicao"].ToString(),
							Observacao = reader["observacao"].ToString()
						};
					}
				}
			}
			return item;
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
				command.ExecuteNonQuery();
			}
		}
	}
}
