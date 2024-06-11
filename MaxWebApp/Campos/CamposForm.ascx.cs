using MaxWebApp.PageInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease;

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

		public void ValidarCampos()
		{
			var entrada = new Entrada();
			var calc = new CalculoDepreciacaoDosItens();

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
			var valorDoItem = Convert.ToDecimal(txtValorAquisicao.Text);
			var vidaUtil = Convert.ToInt32(TxtVidaUtil.Text);
			var depreciacaoAnual = Convert.ToInt32(TxtDepreciacaoAnual.Text);
			var metodoDepreciacao = ddlMetodoDepreciacao.Text.ToString();
			var combustivel = ddlCombustivel.Text.ToString();
			var responsavel = TxtResponsavel.Text.ToString();
			var dataInicioDepreciacao = txtDataDepreciacao.Text.ToString();

			var resultadoDepreciacao_pt1 = calc.CalcularDepreciacao_Parte1(valorDoItem, vidaUtil, depreciacaoAnual);

			var resultadoDepreciacao_pt2 = calc.CalcularDepreciacao_Parte2(valorDoItem, vidaUtil, resultadoDepreciacao_pt1.Item3, resultadoDepreciacao_pt1.Item2);

			txtValorResidual.Text = resultadoDepreciacao_pt1.Item1.ToString();
			txtValorDepreciavel.Text = resultadoDepreciacao_pt1.Item2.ToString();
			txtValorDepreciado.Text = resultadoDepreciacao_pt2.Item3.ToString();
			txtSaldoDepreciar.Text = resultadoDepreciacao_pt2.Item1.ToString();
			txtValorLiquido.Text = resultadoDepreciacao_pt2.Item2.ToString();

			var valorResidual = resultadoDepreciacao_pt1.Item1.ToString();
			var valorDepreciavel = resultadoDepreciacao_pt1.Item2.ToString();
			var valorDepreciado = resultadoDepreciacao_pt2.Item3.ToString();
			var saldoDepreciar = resultadoDepreciacao_pt2.Item1.ToString();
			var valorLiquido = resultadoDepreciacao_pt2.Item2.ToString();
			string valorDoItemS = valorDoItem.ToString();
			string depreciacaoAnualS = depreciacaoAnual.ToString();
			string vidaUtilS = vidaUtil.ToString();


			if (!string.IsNullOrEmpty(codigoDoItem) && !string.IsNullOrEmpty(placaDoItem) && !string.IsNullOrEmpty(descricaoDoItem) && !string.IsNullOrEmpty(dataAquisicao) && !string.IsNullOrEmpty(valorDoItemS) && !string.IsNullOrEmpty(grupoDoItem) && !string.IsNullOrEmpty(conservacaoDoItem) && !string.IsNullOrEmpty(tipoDoItem) && !string.IsNullOrEmpty(tipoAquisicao) && !string.IsNullOrEmpty(depreciacaoAnualS) && !string.IsNullOrEmpty(metodoDepreciacao) && !string.IsNullOrEmpty(valorResidual) && !string.IsNullOrEmpty(responsavel) && !string.IsNullOrEmpty(dataInicioDepreciacao))
			{
				if ((codigoDoItem.Length < 10) && (placaDoItem.Length < 10) && (descricaoDoItem.Length < 2000) && (localizacoFisicaDoItem.Length < 2000) && (observacaoDoItem.Length < 4000) && (valorDoItemS.Length < 999999) && (numeroComprovante.Length < 20) && (placaVeiculo.Length < 10) && (modeloVeiculo.Length < 50) && (vidaUtilS.Length < 5) && (depreciacaoAnualS.Length < 10) && (valorResidual.Length < 999999) && (valorDepreciavel.Length < 999999) && (valorDepreciado.Length < 999999) && (saldoDepreciar.Length < 999999) && (valorLiquido.Length < 999999) && (responsavel.Length < 161))
				{
					if (entrada.VericarDuplicidade(placaDoItem, codigoDoItem))
					{
						Page pagina = this.Page;
						entrada.SalvarInformacoesNoBanco(codigoDoItem, placaDoItem, descricaoDoItem, dataAquisicao, grupoDoItem, conservacaoDoItem, localizacoFisicaDoItem, observacaoDoItem, valorDoItemS, tipoDoItem, tipoAquisicao, tipoComprovante, numeroComprovante, combustivel, placaVeiculo, modeloVeiculo, vidaUtilS, depreciacaoAnualS, metodoDepreciacao, valorResidual, valorDepreciavel, valorDepreciado, saldoDepreciar, valorLiquido, dataInicioDepreciacao, responsavel, pagina);
					}
					else
					{ ScriptManager.RegisterStartupScript(this, this.GetType(), "CadastroDuplicado", "CadastroDuplicado();", true); }
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
				// Lidar com erros de conversão de formato
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ErroConversao", "alert('Erro na conversão dos valores. Verifique os campos e tente novamente.');", true);
			}
			catch (Exception ex)
			{
				// Lidar com outros tipos de erros
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ErroGeral", $"alert('Ocorreu um erro: {ex.Message}');", true);
			}
		}
	}
}