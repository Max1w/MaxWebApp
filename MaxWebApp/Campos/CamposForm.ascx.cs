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
			if (Session["CampoEntradaID"] != null)
			{
				string entradaOuInventario = Session["CampoEntradaID"].ToString();
				if (entradaOuInventario == "camposDoFormEntrada")
				{
					pnlEntradaCancelar.Visible = true;
					pnlInventarioCancelar.Visible = false;

					pnlEntradaMensagem.Visible = true;
					pnlInventariooMensagem.Visible = false;

					pnlEntradaSalvar.Visible = true;
					pnlInventarioSalvar.Visible = false;
				}
				else if (entradaOuInventario == "camposDoFormSaida")
				{
					pnlEntradaCancelar.Visible = false;
					pnlInventarioCancelar.Visible = true;

					pnlEntradaMensagem.Visible = false;
					pnlInventariooMensagem.Visible = true;

					pnlEntradaSalvar.Visible = false;
					pnlInventarioSalvar.Visible = true;
				}
			}
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

		// Inventario

		public void CarregarDetalhesDoItem(string id)
		{
			var inv = new InventarioDeItens();
			var operacao = new Operacao();
			var item = operacao.ObterItemPorId(id);

			if (item != null)
			{
				var IdRandom = item.ID.ToString();
				txtCodigoDoItem.Text = item.Codigo.ToString();
				txtPlacaDoItem.Text = item.Placa.ToString();
				txtDescricaoDoItem.Text = item.Descricao;
				txtDataAquisicao.Text = item.DtAquisicao.ToString("yyyy-MM-dd");
				ddlGrupoItem.Text = item.Grupo;
				ddlConservacaoItem.Text = item.EstadoConservacao;
				txtLocalizacaoFisica.Text = item.Localizacao;
				txtObservacao.Text = item.Observacao;
				txtValorAquisicao.Text = item.ValorAquisicao.ToString();
				ddlTipoItem.Text = item.Tipo.ToString();
				ddlTipoAquisicao.Text = item.TipoAquisicao.ToString();
				ddlTipoComprovante.Text = item.TipoComprovante.ToString();
				txtNumeroComprovante.Text = item.NumeroComprovante.ToString();
				txtPlacaVeiculo.Text = item.PlacaVeiculo.ToString();
				txtModeloVeiculo.Text = item.ModeloVeiculo.ToString();
				txtVidaUtil.Text = item.VidaUtil.ToString();
				txtDepreciacaoAnual.Text = item.DepreciacaoAnual.ToString();
				ddlMetodoDepreciacao.Text = item.MetodoDepreciacao.ToString();
				ddlCombustivel.Text = item.TemCombustivel.ToString();
				txtResponsavel.Text = item.Responsavel.ToString();
				txtDataDepreciacao.Text = item.InicioDepreciacao.ToString("yyyy-MM-dd");
				txtValorResidual.Text = item.ValorResidual.ToString();
				txtValorDepreciavel.Text = item.ValorDepreciavel.ToString();
				txtValorDepreciado.Text = item.ValorDepreciado.ToString();
				txtSaldoDepreciar.Text = item.SaldoDepreciar.ToString();
				txtValorLiquido.Text = item.ValorLiquido.ToString();

				inv.AtivarPainel();
			}
		}

		protected void botaoCancelarInventario_Click(object sender, EventArgs e)
		{
			var inv = new InventarioDeItens();
			inv.DesativarPainel();
		}

		protected void btnSalvarAlteracoes_Click(object sender, EventArgs e)
		{
			var inv = new InventarioDeItens();
			var operacao = new Operacao();
			var item = new Operacao.Item()
			{
				ID = int.Parse(IdRandom.ToString()),
				Codigo = txtCodigoDoItem.Text,
				Placa = txtPlacaDoItem.Text,
				Descricao = txtDescricaoDoItem.Text,
				DtAquisicao = DateTime.Parse(txtDataAquisicao.Text),
				InicioDepreciacao = DateTime.Parse(txtDataDepreciacao.Text),
				Grupo = ddlGrupoItem.SelectedValue,
				EstadoConservacao = ddlConservacaoItem.SelectedValue,
				Localizacao = txtLocalizacaoFisica.Text,
				Observacao = txtObservacao.Text,
				ValorAquisicao = txtValorAquisicao.Text,
				Tipo = ddlTipoItem.SelectedValue,
				TipoAquisicao = ddlTipoAquisicao.SelectedValue,
				TipoComprovante = ddlTipoComprovante.SelectedValue,
				NumeroComprovante = TxtNumeroComprovante.Text,
				PlacaVeiculo = TxtPlacaVeiculo.Text,
				ModeloVeiculo = TxtModeloVeiculo.Text,
				VidaUtil = TxtVidaUtil.Text,
				DepreciacaoAnual = TxtDepreciacaoAnual.Text,
				MetodoDepreciacao = ddlMetodoDepreciacao.SelectedValue,
				TemCombustivel = ddlCombustivel.SelectedValue,
				Responsavel = TxtResponsavel.Text,
				ValorResidual = txtValorResidual.Text,
				ValorDepreciavel = txtValorDepreciavel.Text,
				ValorDepreciado = txtValorDepreciado.Text,
				SaldoDepreciar = txtSaldoDepreciar.Text,
				ValorLiquido = txtValorLiquido.Text

			};
			if (!string.IsNullOrEmpty(item.Codigo) && !string.IsNullOrEmpty(item.Placa) && !string.IsNullOrEmpty(item.Descricao) && !string.IsNullOrEmpty(item.ValorAquisicao) && !string.IsNullOrEmpty(item.Grupo) && !string.IsNullOrEmpty(item.EstadoConservacao) && !string.IsNullOrEmpty(item.Tipo) && !string.IsNullOrEmpty(item.TipoAquisicao) && !string.IsNullOrEmpty(item.DepreciacaoAnual) && !string.IsNullOrEmpty(item.MetodoDepreciacao) && !string.IsNullOrEmpty(item.ValorResidual) && !string.IsNullOrEmpty(item.Responsavel))
			{
				if ((item.Codigo.Length < 10) && (item.Placa.Length < 10) && (item.Descricao.Length < 2000) && (item.Localizacao.Length < 2000) && (item.Observacao.Length < 4000) && (item.ValorAquisicao.Length < 999999) && (item.NumeroComprovante.Length < 20) && (item.PlacaVeiculo.Length < 10) && (item.ModeloVeiculo.Length < 50) && (item.VidaUtil.Length < 5) && (item.DepreciacaoAnual.Length < 10) && (item.ValorResidual.Length < 999999) && (item.ValorDepreciavel.Length < 999999) && (item.ValorDepreciado.Length < 999999) && (item.SaldoDepreciar.Length < 999999) && (item.ValorLiquido.Length < 999999) && (item.Responsavel.Length < 161))
				{
					if (inv.VericarDuplicidade(item.Placa, item.ID))
					{
						Page pagina = this.Page;
						inv.AtualizarItem(item, pagina);
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

			inv.DesativarPainel();
			inv.BindGridView();
		}
	}
}