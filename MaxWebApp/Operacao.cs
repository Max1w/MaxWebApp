using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
	}
}
