using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebApp
{
	public partial class Saida : System.Web.UI.Page
	{
		
		public List<Inventario> inventarios = new List<Inventario>(); 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				SaidaDeItens();
			}
		}

		private void SaidaDeItens()
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
					//html.Append("<table class='table table-light table-striped table-hover table-bordered'>");
					//html.Append($"<tr>" +
					//$"<th>Código</th>" +
					//$"<th>Placa</th>" +
					//$"<th>Descrição</th>" +
					//$"<th>Valor de Aquisição</th>" +
					//$"<th>Data de Aquisição</th>" +
					//$"<th>Opções</th>" +
					//$"</tr>");

					//foreach (var produto in listaSaida)
					//{
					//	html.Append("<tr>");
					//	html.AppendFormat("<td>{0}</td>", produto.codigo);
					//	html.AppendFormat("<td>{0}</td>", produto.placa);
					//	html.AppendFormat("<td>{0}</td>", produto.descricao);
					//	html.AppendFormat("<td>{0}</td>", produto.valorAquisicao);
					//	html.AppendFormat("<td>{0:C}</td>", produto.dtAquisicao);
					//	html.Append("<td><button id='btnExcluir_" + produto.ID.ToString() + "' type='button' class='btn btn-danger mx-1' runat='server' onserverclick='ExcluirRegistroDaTabela'>Excluir</button>");
					//	html.Append("<button id='btnEditar_"+ produto.ID.ToString() +"' type='button' class='btn btn-primary mx-1' runat='server' onserverclick='btnEditar_Click'>Editar</button></td>");
					//	html.Append("</tr>");
					//}

					//html.Append("</table>");

					//tabelaSaida.Text = html.ToString();
					inventarios = listaSaida;
				}
			}
		}
	}
}