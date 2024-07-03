using MaxWebApp.Modelo;
using System;
using System.Collections.Generic;
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

		public async void BindGridView()
		{
			string url = "https://localhost:7279/v1/TodosOsItens";
			List<ItemModelo> listaItens = await MetodosBancoDeDadosApi.CarregarItensDoInventarioGET(url);
			GridView1.DataSource = listaItens;
			GridView1.DataBind();
		}

		protected async void btnSalvarAlteracoes_Click(object sender, EventArgs e)
		{
			ItemModelo item = CriarItemModelo();

			var valida = new ValidacaoDosCampos();

			if (valida.CampoVazioOuNull(item))
			{
				if (valida.TamanhoLimiteDeCaracteres(item))
				{
					if (valida.VericarDuplicidade(item.placa_item, item.codigo_item, item.Id))
					{
						string url = $"https://localhost:7279/v1/TodosOsItens/{item.Id}";
						await MetodosBancoDeDadosApi.AtualizarItemPUT(url, item);
						ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificaçãoCadastroSucesso", "NotificaçãoCadastroSucesso();", true);
					}
					else
					{
						ScriptManager.RegisterStartupScript(this, this.GetType(), "CadastroDuplicado", "CadastroDuplicado();", true);
					}
				}
				else
				{
					ScriptManager.RegisterStartupScript(this, this.GetType(), "LimiteUltrapassadoDeCaracteres", "LimiteUltrapassadoDeCaracteres();", true);
				}
			}
			else
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificaçãoCampoInvalido", "NotificaçãoCampoInvalido();", true);
			}

			BindGridView();
		}

		private ItemModelo CriarItemModelo()
		{
			return new ItemModelo
			{
				Id = int.Parse(hfItemId.Value),
				codigo_item = txtCodigoDoItem.Text,
				placa_item = txtPlacaDoItem.Text,
				descricao_item = txtDescricaoDoItem.Text,
				data_aquisicao = DateTime.Parse(txtDataAquisicao.Text),
				inicio_depreciacao = DateTime.Parse(txtDataDepreciacao.Text),
				grupo_item = ddlGrupoItem.SelectedValue,
				estado_conservacao = ddlConservacaoItem.SelectedValue,
				localizacao_fisica = txtLocalizacaoFisica.Text,
				observacao = txtObservacao.Text,
				valor_aquisicao = txtValorAquisicao.Value,
				tipo_item = ddlTipoItem.SelectedValue,
				tipo_aquisicao = ddlTipoAquisicao.SelectedValue,
				tipo_comprovante = ddlTipoComprovante.SelectedValue,
				numero_comprovante = txtNumeroComprovante.Text,
				placa_veiculo = txtPlacaVeiculo.Text,
				modelo_veiculo = txtModeloVeiculo.Text,
				vida_util = txtVidaUtil.Value,
				depreciacao_anual = txtDepreciacaoAnual.Value,
				metodo_depreciacao = ddlMetodoDepreciacao.SelectedValue,
				tem_combustivel = ddlCombustivel.SelectedValue,
				responsavel = txtResponsavel.Text,
				valor_residual = txtValorResidual.Text,
				valor_depreciavel = txtValorDepreciavel.Text,
				valor_depreciado = txtValorDepreciado.Text,
				saldo_depreciar = txtSaldoDepreciar.Text,
				valor_liquido = txtValorLiquido.Text
			};
		}

		protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GridView1.PageIndex = e.NewPageIndex;
			BindGridView();
		}
	}
}
