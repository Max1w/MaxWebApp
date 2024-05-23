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

		protected void CkSelecionarTodos_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox ckSelecionarTodos = (CheckBox)sender;
			foreach (GridViewRow row in GridView1.Rows)
			{
				CheckBox ckSelecionados = (CheckBox)row.FindControl("ckSelecionados");
				if (ckSelecionados != null)
				{
					ckSelecionados.Checked = ckSelecionarTodos.Checked;
				}
			}
		}

		protected void ExcluirItensSelecionados_Click(object sender, EventArgs e)
		{
			List<string> idsParaExcluir = new List<string>();

			foreach (GridViewRow row in GridView1.Rows)
			{
				CheckBox ckSelecionados = (CheckBox)row.FindControl("ckSelecionados");
				if (ckSelecionados != null && ckSelecionados.Checked)
				{
					string id = GridView1.DataKeys[row.RowIndex].Value.ToString();
					idsParaExcluir.Add(id);
				}
			}
			if (idsParaExcluir.Count > 0)
			{
				ExcluirVeiculos(idsParaExcluir);
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
					cmd.Parameters.AddWithValue("@id", id);
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

		private void ExcluirVeiculos(List<string> ids)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query = "DELETE FROM itens WHERE id IN (" + string.Join(",", ids.ConvertAll(id => "'" + id + "'")) + ")";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
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
