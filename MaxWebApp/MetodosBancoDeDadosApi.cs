using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using MaxWebApp.Modelo;
using System.Security.Policy;
using System.Text;
using System.Web.UI;
using System;


namespace MaxWebApp
{
	public class MetodosBancoDeDadosApi
	{
		public static async Task<List<ItemModelo>> CarregarItensDoInventarioGET(string url, string id = "")
		{
			using (HttpClient client = new HttpClient())
			{
				var fullUrl = string.IsNullOrEmpty(id) ? url : $"{url}/{id}";
				HttpResponseMessage response = await client.GetAsync(fullUrl);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ItemModelo>>(responseBody);
			}
		}

		public static async Task AdicionarItemPOST(string url, ItemModelo item)
		{
			using (HttpClient client = new HttpClient())
			{
				var json = JsonConvert.SerializeObject(item);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				HttpResponseMessage responseMessage = await client.PostAsync(url, content);
				var responseContent = await responseMessage.Content.ReadAsStringAsync();
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

		public static async Task DeletarItemDELETEemLote(string url, List<int> ids)
		{
			using (var httpClient = new HttpClient())
			{
				var json = JsonConvert.SerializeObject(ids);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Delete,
					RequestUri = new Uri(url),
					Content = content
				};

				var response = await httpClient.SendAsync(request);

				if (response.IsSuccessStatusCode)
				{
					Console.WriteLine("Itens deletados com sucesso!");
				}
				else
				{
					Console.WriteLine("Erro ao deletar itens: " + response.StatusCode);
				}
			}
		}

	}
}