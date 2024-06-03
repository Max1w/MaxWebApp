using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebApp.PageInventario
{
	public partial class InventarioDeItens : System.Web.UI.Page
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
			if (e.CommandName == "Editar")
			{
				string id = e.CommandArgument.ToString();
				CarregarDetalhesDoItem(id);
			}
		}

		private void CarregarDetalhesDoItem(string id)
		{
			var operacao = new Operacao();
			var item = operacao.ObterItemPorId(id);

			if (item != null)
			{
				txtCodigoDoItem.Text = item.Codigo;
				txtPlacaItem.Text = item.Placa;
				txtDescricaoItem.Text = item.Descricao;
				txtDtAquisicao.Text = item.DtAquisicao.ToString("yyyy-MM-dd");
				ddlGrupoItem.SelectedValue = item.Grupo;
				ddlConservacaoItem.SelectedValue = item.EstadoConservacao;
				txtLocalizacoFisicaItem.Text = item.Localizacao;
				txtObservacao.Text = item.Observacao;
				txtValorItem.Text = item.ValorAquisicao.ToString();
				pnlEdit.Visible = true;
			}
		}

		protected void botaoCancelar_Click(object sender, EventArgs e)
		{
			pnlEdit.Visible = false;
		}

		protected void btnSalvar_Click(object sender, EventArgs e)
		{
			var operacao = new Operacao();
			var item = new Operacao.Item()
			{
				Codigo = txtCodigoDoItem.Text,
				Placa = txtPlacaItem.Text,
				Descricao = txtDescricaoItem.Text,
				DtAquisicao = DateTime.Parse(txtDtAquisicao.Text),
				Grupo = ddlGrupoItem.SelectedValue,
				EstadoConservacao = ddlConservacaoItem.SelectedValue,
				Localizacao = txtLocalizacoFisicaItem.Text,
				Observacao = txtObservacao.Text,
				ValorAquisicao = txtValorItem.Text
			};

			operacao.AtualizarItem(item);
			pnlEdit.Visible = false;
			BindGridView();
		}
	}
}
