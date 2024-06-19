using MaxWebApp.Modelo;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebApp.Campos
{
	public partial class CamposForm : System.Web.UI.UserControl
	{
		public TextBox TxtCodigoDoItem
		{
			get { return this.txtCodigoDoItem; }
		}
		public TextBox TxtPlacaDoItem
		{
			get { return this.txtPlacaDoItem; }
		}
		public TextBox TxtDescricaoDoItem
		{
			get { return this.txtDescricaoDoItem; }
		}
		public TextBox TxtValorItem
		{
			get { return this.txtValorAquisicao; }
		}
		public TextBox TxtLocalizacaoFisica
		{
			get { return this.txtLocalizacaoFisica; }
		}
		public TextBox TxtNumeroComprovante
		{
			get { return this.txtNumeroComprovante; }
		}
		public TextBox TxtPlacaVeiculo
		{
			get { return this.txtPlacaVeiculo; }
		}
		public TextBox TxtModeloVeiculo
		{
			get { return this.txtModeloVeiculo; }
		}
		public TextBox TxtResponsavel
		{
			get { return this.txtResponsavel; }
		}
		public TextBox TxtVidaUtil
		{
			get { return this.txtVidaUtil; }
		}
		public TextBox TxtDepreciacaoAnual
		{
			get { return this.txtDepreciacaoAnual; }
		}
		public TextBox TxtValorResidual
		{
			get { return this.txtValorResidual; }
		}
		public string CampoEntradaID { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
		}
		protected void btnSalvar_Click(object sender, EventArgs e)
		{
			ValidarCampos();
		}

		protected async void SalvarInformacoesNoBanco()
		{
			string apiUrl = "https://localhost:7279/v1/TodosOsItens";
			var novoItem = new ItemModelo()
			{
				codigo_item = txtCodigoDoItem.Text.ToString(),
				placa_item = txtPlacaDoItem.Text.ToString(),
				descricao_item = txtDescricaoDoItem.Text.ToString(),
				tipo_item = ddlTipoItem.Text.ToString(),
				grupo_item = ddlGrupoItem.Text.ToString(),
				estado_conservacao = ddlConservacaoItem.Text.ToString(),
				tipo_aquisicao = ddlTipoAquisicao.Text.ToString(),
				valor_aquisicao = txtValorAquisicao.Text.ToString(),
				metodo_depreciacao = ddlMetodoDepreciacao.Text.ToString(),
				valor_residual = txtValorResidual.Text.ToString(),
				responsavel = txtResponsavel.Text.ToString(),
				vida_util = txtVidaUtil.Text.ToString(),
				depreciacao_anual = txtDepreciacaoAnual.Text.ToString(),
				inicio_depreciacao = Convert.ToDateTime(txtDataDepreciacao.Text),
				data_aquisicao = Convert.ToDateTime(txtDataAquisicao.Text),
				valor_depreciavel = txtValorDepreciavel.Text.ToString(),
				valor_depreciado = txtValorDepreciado.Text.ToString(),
				saldo_depreciar = txtSaldoDepreciar.Text.ToString(),
				valor_liquido = txtValorLiquido.Text.ToString(),
				tipo_comprovante = ddlTipoComprovante.Text.ToString(),
				numero_comprovante = txtNumeroComprovante.Text.ToString(),
				tem_combustivel = ddlCombustivel.Text.ToString(),
				placa_veiculo = txtPlacaVeiculo.Text.ToString(),
				modelo_veiculo = txtModeloVeiculo.Text.ToString(),
				localizacao_fisica = txtLocalizacaoFisica.Text.ToString(),
				observacao = txtObservacao.Text.ToString(),
				patrimonios_id = 1
			};
			Page pag = new Page();
			await MetodosBancoDeDadosApi.AdicionarItemPOST(apiUrl, novoItem, pag);
		}


		public void ValidarCampos()
		{
			var entrada = new Entrada();
			var calc = new CalculoDepreciacaoDosItens();

			var valorDoItem = Convert.ToDecimal(txtValorAquisicao.Text);
			var vidaUtil = Convert.ToInt32(TxtVidaUtil.Text);
			var depreciacaoAnual = Convert.ToInt32(TxtDepreciacaoAnual.Text);

			var resultadoDepreciacao_pt1 = calc.CalcularDepreciacao_Parte1(valorDoItem, vidaUtil, depreciacaoAnual);
			var resultadoDepreciacao_pt2 = calc.CalcularDepreciacao_Parte2(valorDoItem, vidaUtil, resultadoDepreciacao_pt1.Item3, resultadoDepreciacao_pt1.Item2);

			var codigoDoItem = TxtCodigoDoItem.Text.ToString();
			var placaDoItem = TxtPlacaDoItem.Text.ToString();
			var descricaoDoItem = TxtDescricaoDoItem.Text.ToString();
			var dataAquisicao = txtDataAquisicao.Text.ToString();
			var grupoDoItem = ddlGrupoItem.Text.ToString();
			var conservacaoDoItem = ddlConservacaoItem.Text.ToString();
			var localizacoFisicaDoItem = TxtLocalizacaoFisica.Text.ToString();
			var observacaoDoItem = txtObservacao.Text;
			var tipoDoItem = ddlTipoItem.Text.ToString();
			var tipoAquisicao = ddlTipoAquisicao.Text.ToString();
			var tipoComprovante = ddlTipoComprovante.Text.ToString();
			var numeroComprovante = TxtNumeroComprovante.Text.ToString();
			var placaVeiculo = TxtPlacaVeiculo.Text.ToString();
			var modeloVeiculo = TxtModeloVeiculo.Text.ToString();
			var metodoDepreciacao = ddlMetodoDepreciacao.Text.ToString();
			var combustivel = ddlCombustivel.Text.ToString();
			var responsavel = TxtResponsavel.Text.ToString();
			var dataInicioDepreciacao = txtDataDepreciacao.Text.ToString();
			var valorResidual = resultadoDepreciacao_pt1.Item1.ToString();
			var valorDepreciavel = resultadoDepreciacao_pt1.Item2.ToString();
			var valorDepreciado = resultadoDepreciacao_pt2.Item3.ToString();
			var saldoDepreciar = resultadoDepreciacao_pt2.Item1.ToString();
			var valorLiquido = resultadoDepreciacao_pt2.Item2.ToString();
			string valorDoItemS = valorDoItem.ToString();
			string depreciacaoAnualS = depreciacaoAnual.ToString();
			string vidaUtilS = vidaUtil.ToString();


			if (!string.IsNullOrEmpty(codigoDoItem) &&
				!string.IsNullOrEmpty(placaDoItem) &&
				!string.IsNullOrEmpty(descricaoDoItem) &&
				!string.IsNullOrEmpty(dataAquisicao) &&
				!string.IsNullOrEmpty(grupoDoItem) &&
				!string.IsNullOrEmpty(conservacaoDoItem) &&
				!string.IsNullOrEmpty(tipoDoItem) &&
				!string.IsNullOrEmpty(tipoAquisicao) &&
				!string.IsNullOrEmpty(metodoDepreciacao) &&
				!string.IsNullOrEmpty(responsavel) &&
				!string.IsNullOrEmpty(dataInicioDepreciacao) &&
				codigoDoItem.Length < 10 &&
				placaDoItem.Length < 10 &&
				descricaoDoItem.Length < 2000 &&
				localizacoFisicaDoItem.Length < 2000 &&
				observacaoDoItem.Length < 4000 &&
				valorDoItem < 999999 &&
				numeroComprovante.Length < 20 &&
				placaVeiculo.Length < 10 &&
				modeloVeiculo.Length < 50 &&
				vidaUtil < 150 &&
				depreciacaoAnual < 100)
			{
				if (entrada.VericarDuplicidade(placaDoItem, codigoDoItem))
				{
					SalvarInformacoesNoBanco();
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

		protected void botaoCalcular_ServerClick(object sender, EventArgs e)
		{
			var calc = new CalculoDepreciacaoDosItens();

			try
			{
				var valorDoItem = Convert.ToDecimal(TxtValorItem.Text);
				var vidaUtil = Convert.ToInt32(TxtVidaUtil.Text);
				var depreciacaoAnual = Convert.ToInt32(TxtDepreciacaoAnual.Text);

				var resultadoDepreciacao_pt1 = calc.CalcularDepreciacao_Parte1(valorDoItem, vidaUtil, depreciacaoAnual);
				var resultadoDepreciacao_pt2 = calc.CalcularDepreciacao_Parte2(valorDoItem, vidaUtil, resultadoDepreciacao_pt1.Item3, resultadoDepreciacao_pt1.Item2);

				TxtValorResidual.Text = resultadoDepreciacao_pt1.Item1.ToString();
				txtValorDepreciavel.Text = resultadoDepreciacao_pt1.Item2.ToString();
				txtValorDepreciado.Text = resultadoDepreciacao_pt2.Item3.ToString();

				txtSaldoDepreciar.Text = resultadoDepreciacao_pt2.Item1.ToString();
				txtValorLiquido.Text = resultadoDepreciacao_pt2.Item2.ToString();
			}
			catch (FormatException ex)
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ErroConversao", "alert('Erro na conversão dos valores. Verifique os campos e tente novamente.');", true);
			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ErroGeral", $"alert('Ocorreu um erro: {ex.Message}');", true);
			}
		}
	}
}