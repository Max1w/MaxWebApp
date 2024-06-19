using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using MaxWebApp.Modelo;
using System.Security.Policy;
using System.Text;
using System.Web.UI;


namespace MaxWebApp
{
	public class MetodosBancoDeDadosApi
	{
		public static async Task<List<ItemModelo>> CarregarItensDoInventarioGET(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ItemModelo>>(responseBody);
			}
		}
		public static async Task AdicionarItemPOST(string url, ItemModelo item, Page pag)
		{
			using (HttpClient client = new HttpClient())
			{
				var json = JsonConvert.SerializeObject(item);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				HttpResponseMessage responseMessage = await client.PostAsync(url, content);
				var responseContent = await responseMessage.Content.ReadAsStringAsync();
				if (!responseMessage.IsSuccessStatusCode)
				{
					ScriptManager.RegisterStartupScript(pag, pag.GetType(), "CadastroDuplicado", "CadastroDuplicado();", true);
				}
				responseMessage.EnsureSuccessStatusCode();
			}
		}

		public static async Task AtualizarItemPUT(string url, ItemModelo item)
		{
			using (HttpClient client = new HttpClient())
			{
				var json = JsonConvert.SerializeObject(item);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				HttpResponseMessage responseMessage = await client.PutAsync(url, content);
				responseMessage.EnsureSuccessStatusCode();
			}
		}
		public static async Task DeletarItemDELETE(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage responseMessage = await client.DeleteAsync(url);
				responseMessage.EnsureSuccessStatusCode();
			}
		}
	}
}