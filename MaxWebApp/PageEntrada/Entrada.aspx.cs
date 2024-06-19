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
			string query = "SELECT codigo_item, placa_item FROM itens WHERE placa_item = " + placaDoItem + " or codigo_item = " + codigoDoItem;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader dr = command.ExecuteReader())
					{
						while (dr.Read())
						{
							ItemModelo camposAhValidar = new ItemModelo();
							camposAhValidar.codigo_item = dr["codigo_item"].ToString();
							camposAhValidar.placa_item = dr["placa_item"].ToString();

							valida.Add(camposAhValidar);
						}
					}
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