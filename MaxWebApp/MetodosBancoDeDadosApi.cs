using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using static MaxWebApp.Operacao;
using System.Security.Policy;
using System.Text;

namespace MaxWebApp
{
	public class MetodosBancoDeDadosApi
	{
		public static async Task<List<Item>> CarregarItensDoInventarioGET(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Item>>(responseBody);
			}
		}
		public static async Task AdicionarItemPOST(string url, Item item)
		{
			using (HttpClient client = new HttpClient())
			{
				var json = JsonConvert.SerializeObject(item);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				HttpResponseMessage responseMessage = await client.PostAsync(url, content);
				responseMessage.EnsureSuccessStatusCode();
			}
		}
		public static async Task AtualizarItemPUT(string url, Item item)
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