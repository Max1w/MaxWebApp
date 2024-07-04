using MaxWebApp.Modelo;
using System;
using System.Web.UI;


namespace MaxWebApp
{
	public partial class Entrada : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		protected void btnSalvar_Click(object sender, EventArgs e)
		{
			if (ValidarCampos())
			{
				SalvarInformacoesNoBanco();
			}
		}
		
		protected async void SalvarInformacoesNoBanco()
		{
			string apiUrl = "https://localhost:7279/v1/TodosOsItens";
			var novoItem = CriarItemModelo();
			await MetodosBancoDeDadosApi.AdicionarItemPOST(apiUrl, novoItem);
			ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificacaoCadastroSucesso", "NotificacaoCadastroSucesso();", true);
		}
		private ItemModelo CriarItemModelo()
		{
			return new ItemModelo
			{
				codigo_item = txtCodigoDoItem.Text.ToUpper(),
				placa_item = txtPlacaDoItem.Text,
				descricao_item = txtDescricaoDoItem.Text,
				tipo_item = ddlTipoItem.Text,
				grupo_item = ddlGrupoItem.Text,
				estado_conservacao = ddlConservacaoItem.Text,
				tipo_aquisicao = ddlTipoAquisicao.Text,
				valor_aquisicao = txtValorAquisicao.Value,
				metodo_depreciacao = ddlMetodoDepreciacao.Text,
				valor_residual = txtValorResidual.Text,
				responsavel = txtResponsavel.Text.ToUpper(),
				vida_util = txtVidaUtil.Value,
				depreciacao_anual = txtDepreciacaoAnual.Value,
				inicio_depreciacao = Convert.ToDateTime(txtDataDepreciacao.Text),
				data_aquisicao = Convert.ToDateTime(txtDataAquisicao.Text),
				valor_depreciavel = txtValorDepreciavel.Text,
				valor_depreciado = txtValorDepreciado.Text,
				saldo_depreciar = txtSaldoDepreciar.Text,
				valor_liquido = txtValorLiquido.Text,
				tipo_comprovante = ddlTipoComprovante.Text,
				numero_comprovante = txtNumeroComprovante.Text,
				tem_combustivel = ddlCombustivel.Text,
				placa_veiculo = txtPlacaVeiculo.Text,
				modelo_veiculo = txtModeloVeiculo.Text,
				localizacao_fisica = txtLocalizacaoFisica.Text,
				observacao = txtObservacao.Text,
				patrimonios_id = 1
			};
		}

		private bool ValidarCampos()
		{
			var calc = new CalculoDepreciacaoDosItens();

			try
			{
				var valorDoItem = Convert.ToDecimal(txtValorAquisicao.Value);
				var vidaUtil = Convert.ToInt32(txtVidaUtil.Value);
				var depreciacaoAnual = Convert.ToInt32(txtDepreciacaoAnual.Value);

				var resultadoDepreciacao_pt1 = calc.CalcularDepreciacao_Parte1(valorDoItem, vidaUtil, depreciacaoAnual);
				var resultadoDepreciacao_pt2 = calc.CalcularDepreciacao_Parte2(valorDoItem, vidaUtil, resultadoDepreciacao_pt1.Item3, resultadoDepreciacao_pt1.Item2);

				PreencherCamposDepreciacao(resultadoDepreciacao_pt1, resultadoDepreciacao_pt2);

				var itemModelo = CriarItemModelo();

				itemModelo.valor_residual = resultadoDepreciacao_pt1.Item1.ToString();
				itemModelo.valor_depreciavel = resultadoDepreciacao_pt1.Item2.ToString();
				itemModelo.valor_depreciado = resultadoDepreciacao_pt2.Item3.ToString();
				itemModelo.saldo_depreciar = resultadoDepreciacao_pt2.Item1.ToString();
				itemModelo.valor_liquido = resultadoDepreciacao_pt2.Item2.ToString();

				var valida = new ValidacaoDosCampos();
				if (valida.CampoVazioOuNull(itemModelo))
				{
					if (valida.TamanhoLimiteDeCaracteres(itemModelo))
					{
						if (valida.VericarDuplicidade(txtPlacaDoItem.Text, txtCodigoDoItem.Text))
						{
							return true;
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
					ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificacaoCampoInvalido", "NotificacaoCampoInvalido();", true);
				}
			}
			catch (FormatException ex)
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ErroConversao", "alert('Erro na conversão dos valores. Verifique os campos e tente novamente.');", true);
			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ErroGeral", $"alert('Ocorreu um erro: {ex.Message}');", true);
			}

			return false;
		}

		private void PreencherCamposDepreciacao((decimal, decimal, decimal) resultadoDepreciacao_pt1, (decimal, decimal, decimal) resultadoDepreciacao_pt2)
		{
			txtValorResidual.Text = resultadoDepreciacao_pt1.Item1.ToString();
			txtValorDepreciavel.Text = resultadoDepreciacao_pt1.Item2.ToString();
			txtValorDepreciado.Text = resultadoDepreciacao_pt2.Item3.ToString();
			txtSaldoDepreciar.Text = resultadoDepreciacao_pt2.Item1.ToString();
			txtValorLiquido.Text = resultadoDepreciacao_pt2.Item2.ToString();
		}

		protected void botaoCalcular_ServerClick(object sender, EventArgs e)
		{
			var calc = new CalculoDepreciacaoDosItens();

			try
			{
				var valorDoItem = Convert.ToDecimal(txtValorAquisicao.Value);
				var vidaUtil = Convert.ToInt32(txtVidaUtil.Value);
				var depreciacaoAnual = Convert.ToInt32(txtDepreciacaoAnual.Value);

				var resultadoDepreciacao_pt1 = calc.CalcularDepreciacao_Parte1(valorDoItem, vidaUtil, depreciacaoAnual);
				var resultadoDepreciacao_pt2 = calc.CalcularDepreciacao_Parte2(valorDoItem, vidaUtil, resultadoDepreciacao_pt1.Item3, resultadoDepreciacao_pt1.Item2);

				txtValorResidual.Text = resultadoDepreciacao_pt1.Item1.ToString();
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