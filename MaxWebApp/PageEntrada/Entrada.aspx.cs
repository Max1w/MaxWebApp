using MaxWebApp.Campos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaxWebApp.Modelo;


namespace MaxWebApp
{
	public partial class Entrada : System.Web.UI.Page
	{

		public void Page_Load(object sender, EventArgs e)
		{
		}
		public bool VericarDuplicidade(string placaDoItem, string codigoDoItem)
		{
			List<ItemModelo> valida = new List<ItemModelo>();

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "SELECT codigo_item, placa_item FROM itens WHERE placa_item = @placa_item OR codigo_item = @codigo_item";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						// Adicionando os parâmetros para evitar SQL Injection
						command.Parameters.AddWithValue("@placa_item", placaDoItem);
						command.Parameters.AddWithValue("@codigo_item", codigoDoItem);

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
					// Trate a exceção de SQL aqui (ex: logar o erro)
					Console.WriteLine("SQL Error: " + ex.Message);
					return false;
				}
				catch (Exception ex)
				{
					// Trate outras exceções aqui
					Console.WriteLine("General Error: " + ex.Message);
					return false;
				}
			}

			// Verifica se a lista está vazia
			return valida.Count == 0;
		}


	}
}