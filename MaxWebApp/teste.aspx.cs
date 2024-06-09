//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace MaxWebApp
//{
//	public partial class teste : System.Web.UI.Page
//	{
//		public TextBox TxtCodigoDoItem
//		{
//			get { return this.txtCodigoDoItem; }
//		}
//		public TextBox TxtPlacaDoItem
//		{
//			get { return this.txtPlacaDoItem; }
//		}
//		public TextBox TxtDescricaoDoItem
//		{
//			get { return this.txtDescricaoDoItem; }
//		}
//		public TextBox TxtValorItem
//		{
//			get { return this.txtValorAquisicao; }
//		}
//		public TextBox TxtLocalizacaoFisica
//		{
//			get { return this.txtLocalizacaoFisica; }
//		}

//		public string idDeMudanca { get; set; }

//		protected void Page_Load(object sender, EventArgs e)
//		{

//		}
//		protected void btnSalvar_Click(object sender, EventArgs e)
//		{
//			ValidarCampos();
//		}
//		public void ValidarCampos()
//		{

//			var codigoDoItem = TxtCodigoDoItem.Text.ToString();
//			var placaDoItem = TxtPlacaDoItem.Text.ToString(); 
//			var descricaoDoItem = TxtDescricaoDoItem.Text.ToString(); 
//			var dataAquisicao = txtDataAquisicao.Text.ToString();
//			var grupoDoItem = ddlGrupoItem.Text.ToString();
//			var conservacaoDoItem = ddlConservacaoItem.Text.ToString(); 
//			var localizacoFisicaDoItem = TxtLocalizacaoFisica.Text.ToString(); 
//			var observacaoDoItem = txtObservacao.Text;
//			var valorDoItem = txtValorAquisicao.Text.ToString(); 
			
//			var tipoDoItem = ddlTipoItem.Text.ToString(); 
//			var tipoAquisicao = ddlTipoAquisicao.Text.ToString(); 
//			var tipoComprovante = ddlTipoComprovante.Text.ToString();
//			var numeroComprovante = txtNumeroComprovante.Text.ToString();
//			var placaVeiculo = txtPlacaVeiculo.Text.ToString();
//			var modeloVeiculo = txtModeloVeiculo.Text.ToString();
//			var vidaUtil = txtVidaUtil.Text.ToString();
//			var depreciacaoAnual = txtDepreciacaoAnual.Text.ToString(); 
//			var metodoDepreciacao = ddlMetodoDepreciacao.Text.ToString(); 
//			var valorResidual = txtValorResidual.Text.ToString(); 
//			var valorDepreciavel = txtValorDepreciavel.Text.ToString();
//			var valorDepreciado = txtValorDepreciado.Text.ToString();
//			var saldoDepreciar = txtSaldoDepreciar.Text.ToString();
//			var valorLiquido = txtValorLiquido.Text.ToString();
//			var combustivel = ddlCombustivel.Text.ToString();
//			var responsavel = txtResponsável.Text.ToString(); 
//			var dataInicioDepreciacao = txtDataDepreciacao.Text.ToString();

//			var entrada = new Entrada();

//			if (!string.IsNullOrEmpty(codigoDoItem) && !string.IsNullOrEmpty(placaDoItem) && !string.IsNullOrEmpty(descricaoDoItem) && !string.IsNullOrEmpty(dataAquisicao) && !string.IsNullOrEmpty(valorDoItem) && !string.IsNullOrEmpty(grupoDoItem) && !string.IsNullOrEmpty(conservacaoDoItem) && !string.IsNullOrEmpty(tipoDoItem) && !string.IsNullOrEmpty(tipoAquisicao) && !string.IsNullOrEmpty(depreciacaoAnual) && !string.IsNullOrEmpty(metodoDepreciacao) && !string.IsNullOrEmpty(valorResidual) && !string.IsNullOrEmpty(responsavel) && !string.IsNullOrEmpty(dataInicioDepreciacao))
//			{
//				if ((codigoDoItem.Length < 10) && (placaDoItem.Length < 10) && (descricaoDoItem.Length < 2000) && (localizacoFisicaDoItem.Length < 2000) && (observacaoDoItem.Length < 4000) && (valorDoItem.Length < 999999) && (numeroComprovante.Length < 20) && (placaVeiculo.Length < 10) && (modeloVeiculo.Length < 50) && (vidaUtil.Length < 5) && (depreciacaoAnual.Length < 10) && (valorResidual.Length < 999999) &&(valorDepreciavel.Length < 999999) && (valorDepreciado.Length < 999999) && (saldoDepreciar.Length < 999999) && (valorLiquido.Length < 999999) && (responsavel.Length < 161))
//				{
//					if (entrada.VericarDuplicidade(placaDoItem, codigoDoItem))
//					{
//						Page pagina = this.Page;
//						entrada.SalvarInformacoesNoBanco(codigoDoItem, placaDoItem, descricaoDoItem, dataAquisicao, grupoDoItem, conservacaoDoItem, localizacoFisicaDoItem, observacaoDoItem, valorDoItem, tipoDoItem, tipoAquisicao, tipoComprovante, numeroComprovante, combustivel, placaVeiculo, modeloVeiculo, vidaUtil, depreciacaoAnual, metodoDepreciacao, valorResidual, valorDepreciavel, valorDepreciado, saldoDepreciar, valorLiquido, dataInicioDepreciacao, responsavel, pagina);
//					}
//					else
//					{ ScriptManager.RegisterStartupScript(this, this.GetType(), "CadastroDuplicado", "CadastroDuplicado();", true); }
//				}
//				else
//				{
//					ScriptManager.RegisterStartupScript(this, this.GetType(), "LimiteUltrapassadoDeCaracteres", "LimiteUltrapassadoDeCaracteres();", true);
//				}
//			}
//			else
//			{
//				ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificaçãoCampoInvalido", "NotificaçãoCampoInvalido();", true);
//			}
//		}
//	}
//}