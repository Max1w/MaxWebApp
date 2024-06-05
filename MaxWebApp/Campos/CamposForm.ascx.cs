using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
			get { return this.txtValorItem; }
		}
		public TextBox TxtLocalizacaoFisica
		{
			get { return this.txtLocalizacaoFisica; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void btnSalvar_Click(object sender, EventArgs e)
		{
			ValidarCampos();
		}
		public void ValidarCampos()
		{
			
			var codigoDoItem = TxtCodigoDoItem.Text.ToString();
			var placaDoItem = TxtPlacaDoItem.Text.ToString();
			var descricaoDoItem = TxtDescricaoDoItem.Text.ToString();
			var dataAquisicao = txtDataAquisicao.Text;
			var grupoDoItem = ddlGrupoItem.Text;
			var conservacaoDoItem = ddlConservacaoItem.Text;
			var localizacoFisicaDoItem = TxtLocalizacaoFisica.Text.ToString();
			var observacaoDoItem = txtObservacao.Text;
			var valorDoItem = TxtValorItem.Text.ToString();

			var entrada = new Entrada();

			if (!string.IsNullOrEmpty(codigoDoItem) && !string.IsNullOrEmpty(placaDoItem) && !string.IsNullOrEmpty(descricaoDoItem) && !string.IsNullOrEmpty(dataAquisicao) && !string.IsNullOrEmpty(valorDoItem))
			{
				if ((codigoDoItem.Length < 10) && (placaDoItem.Length < 10) && (descricaoDoItem.Length < 2000) && (localizacoFisicaDoItem.Length < 2000) && (observacaoDoItem.Length < 4000) && (valorDoItem.Length < 999999999))
				{
					if (entrada.VericarDuplicidade(placaDoItem, codigoDoItem))
					{
						Page pagina = this.Page;
						entrada.SalvarInformacoesNoBanco(codigoDoItem, placaDoItem, descricaoDoItem, dataAquisicao, grupoDoItem, conservacaoDoItem, localizacoFisicaDoItem, observacaoDoItem, valorDoItem, pagina);
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
	}
}