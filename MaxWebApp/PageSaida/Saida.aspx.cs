using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebApp
{
	public partial class Saida : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindGridView();
			}
		}

		private void BindGridView()
		{
			var operacao = new Operacao();
			List<Operacao.Item> listaItens = operacao.ListarItensDoBancoDeDados();
			GridView1.DataSource = listaItens;
			GridView1.DataBind();
		}

		protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Excluir")
			{
				string id = e.CommandArgument.ToString();
				ExcluirVeiculo(id);
				BindGridView();
			}
		}

		protected void SelecionarTodos(object sender, EventArgs e)
		{ 
			CheckBox ckSelecionarTodos = (CheckBox)sender;
			foreach (GridViewRow row in GridView1.Rows)
			{
				CheckBox ckSelecionados = (CheckBox)row.FindControl("ckSelecionados");)
				{ 
					ckSelecionados.Checked = ckSelecionarTodos.Checked;
				}
			}
		}

		protected void ExcluirItensSelecionados_Click(object sender, EventArgs e)
		{
			List<string> placasParaExcluir = new List<string>();

			foreach (GridViewRow row in GridView1.Rows) 
			{
				CheckBox ckSelecionados = (CheckBox)row.FindControl("ckSelecionado");
				if (ckSelecionados != null && ckSelecionados.Checked)
				{ 
					string placa = GridView1.DataKeys[row.RowIndex].Value.ToString();
					placasParaExcluir.Add(placa);
				}
			}
			if (placasParaExcluir.Count > 0)
			{
				ExcluirVeiculo(placasParaExcluir);
				BindGridView();
			}
		}

		private void ExcluirVeiculo(string id)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query = "DELETE FROM itens WHERE id = @id";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", string.Join(",", id));
					try
					{
						conn.Open();
						cmd.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						Response.Write("Erro: " + ex.Message);
					}
				}
			}
		}
	}
}
