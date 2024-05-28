using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebApp.PageEditar
{
	public partial class Editar : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			listaItens();
		}

		protected void listaItens()
		{
			var operacao = new Operacao();
			List<Operacao.Item> listaItens = operacao.ListarItensDoBancoDeDados();
		}
	}
}