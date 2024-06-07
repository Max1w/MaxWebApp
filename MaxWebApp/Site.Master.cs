using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebApp
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// Verifica se o modo escuro está ativado na sessão
				if (Session["DarkMode"] != null && (bool)Session["DarkMode"])
				{
					// Aplica o modo escuro ao carregar a página
					body.Attributes.Add("class", "dark-mode"); // body é o ID do elemento body na sua página HTML
				}
			}
		}

		// Método para alternar o modo escuro
		protected void ToggleDarkMode(object sender, EventArgs e)
		{
			if (Session["DarkMode"] == null)
			{
				// Se a variável de sessão não estiver inicializada, defina-a como false
				Session["DarkMode"] = false;
			}

			// Alterna o estado do modo escuro na sessão
			Session["DarkMode"] = !(bool)Session["DarkMode"];

			// Recarrega a página para aplicar as alterações
			Response.Redirect(Request.Url.AbsoluteUri);
		}

	}
}