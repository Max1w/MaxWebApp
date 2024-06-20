
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaxWebApp.Modelo;

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
			List<ItemModelo> listaItens = operacao.ListarItensDoBancoDeDados();
			GridView1.DataSource = listaItens;
			GridView1.DataBind();
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
		protected async void ExcluirItensSelecionados_Click(object sender, EventArgs e)
		{
			List<int> idsParaExcluir = new List<int>();

			foreach (GridViewRow row in GridView1.Rows)
			{
				CheckBox ckSelecionados = (CheckBox)row.FindControl("ckSelecionados");
				if (ckSelecionados != null && ckSelecionados.Checked)
				{
					int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
					idsParaExcluir.Add(id);
				}
			}
			if (idsParaExcluir.Count > 0)
			{
				await MetodosBancoDeDadosApi.DeletarItemDELETEemLote("https://localhost:7279/v1/TodosOsItens", idsParaExcluir);
				BindGridView();
			}

		}

		private async void ExcluirVeiculo(string id)
		{
			var url = $"https://localhost:7279/v1/TodosOsItens/{id}";
			await MetodosBancoDeDadosApi.DeletarItemDELETE(url);
		}

		protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GridView1.PageIndex = e.NewPageIndex;
			BindGridView();
		}
	}
}
