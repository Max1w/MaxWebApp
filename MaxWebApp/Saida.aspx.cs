﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebApp
{
	public partial class Saida : System.Web.UI.Page
	{
		public int ID { get; set; }
		public string codigo { get; set; }
		public string placa { get; set; }
		public string descricao { get; set; }
		public string grupo { get; set; }
		public string localizacao { get; set; }
		public string dtAquisicao { get; set; }
		public string estadoConservacao { get; set; }
		public string valorAquisicao { get; set; }
		public string observacao { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				SaidaDeItens();
			}
		}
		private List<Inventario> SaidaDeItens()
		{
			StringBuilder html = new StringBuilder();
			List<Inventario> listaSaida = new List<Inventario>();

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "select id, codigo_item, placa_item, descricao_item, grupo_item, localizacao_fisica, data_aquisicao, estado_conservacao, valor_aquisicao, observacao FROM itens";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					SqlDataReader dr = command.ExecuteReader();

					while (dr.Read())
					{
						Inventario objLista = new Inventario();
						objLista.ID = Convert.ToInt32(dr["ID"]);
						objLista.codigo = dr["codigo_item"].ToString();
						objLista.placa = dr["placa_item"].ToString();
						objLista.descricao = dr["descricao_item"].ToString();
						objLista.grupo = dr["grupo_item"].ToString();
						objLista.localizacao = dr["localizacao_fisica"].ToString();
						objLista.dtAquisicao = dr["data_aquisicao"].ToString();
						objLista.estadoConservacao = dr["estado_conservacao"].ToString();
						objLista.valorAquisicao = dr["valor_aquisicao"].ToString();
						objLista.observacao = dr["observacao"].ToString();
						listaSaida.Add(objLista);

					}
					html.Append("<table class='table table-light table-striped table-hover table-bordered'>");
					html.Append($"<tr>" +
					$"<th>Código</th>" +
					$"<th>Placa</th>" +
					$"<th>Descrição</th>" +
					$"<th>Valor de Aquisição</th>" +
					$"<th>Data de Aquisição</th>" +
					$"<th>Opções</th>" +
					$"</tr>");

					foreach (var produto in listaSaida)
					{
						html.Append("<tr>");
						html.AppendFormat("<td>{0}</td>", produto.codigo);
						html.AppendFormat("<td>{0}</td>", produto.placa);
						html.AppendFormat("<td>{0}</td>", produto.descricao);
						html.AppendFormat("<td>{0}</td>", produto.valorAquisicao);
						html.AppendFormat("<td>{0:C}</td>", produto.dtAquisicao);
						html.Append("<td><button id='btnExcluir_" + produto.ID.ToString() + "' type='button' class='btn btn-danger mx-1' runat='server' onserverclick='ExcluirRegistroDaTabela'>Excluir</button>");
						html.Append("<button id='btnEditar_"+ produto.ID.ToString() +"' type='button' class='btn btn-primary mx-1' runat='server' onserverclick='btnEditar_Click'>Editar</button></td>");
						html.Append("</tr>");
					}

					html.Append("</table>");

					tabelaSaida.Text = html.ToString();
					return listaSaida;
				}
			}
		}
		protected void ExcluirRegistroDaTabela(object sender, EventArgs e)
		{
		}
		/*
		protected void SalvarInformacoesNoBanco(int ID)
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
		}*/
	}
}