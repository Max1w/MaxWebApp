using MaxWebApp.Campos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaxWebApp.Modelo;


namespace MaxWebApp
{
	public partial class Entrada : System.Web.UI.Page
	{

		public void Page_Load(object sender, EventArgs e)
		{
		}
		//public void SalvarInformacoesNoBanco(string codigoDoItem, string placaDoItem, string descricaoDoItem, string dataAquisicao, string grupoDoItem, string conservacaoDoItem, string localizacoFisicaDoItem, string observacaoDoItem, string valorDoItem,
		//									 string tipoDoItem, string tipoAquisicao, string tipoComprovante, string numeroComprovante, string combustivel, string placaVeiculo, string modeloVeiculo, string vidaUtil, string depreciacaoAnual, string metodoDepreciacao,
		//									 string valorResidual, string valorDepreciavel, string valorDepreciado, string saldoDepreciar, string valorLiquido, string dataInicioDepreciacao, string responsavel, Page pagina)
		//{
		//	string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
		//	string query = @"INSERT INTO itens (codigo_item, placa_item, descricao_item, tipo_item, grupo_item, tipo_aquisicao, tipo_comprovante, numero_comprovante, estado_conservacao, tem_combustivel, placa_veiculo, modelo_veiculo, localizacao_fisica, responsavel, observacao, valor_aquisicao, metodo_depreciacao, valor_residual, valor_depreciavel, vida_util, depreciacao_anual, inicio_depreciacao, valor_depreciado, saldo_depreciar, valor_liquido, data_aquisicao) 
		//	VALUES (@codigo_item, @placa_item, @descricao_item, @tipo_item, @grupo_item, @tipo_aquisicao, @tipo_comprovante, @numero_comprovante, @estado_conservacao, @tem_combustivel, @placa_veiculo, @modelo_veiculo, @localizacao_fisica, @responsavel, @observacao, @valor_aquisicao, @metodo_depreciacao, @valor_residual, @valor_depreciavel, @vida_util, @depreciacao_anual, @inicio_depreciacao, @valor_depreciado, @saldo_depreciar, @valor_liquido, @data_aquisicao)";

		//	using (SqlConnection connection = new SqlConnection(connectionString))
		//	{
		//		connection.Open();

		//		using (SqlCommand command = new SqlCommand(query, connection))
		//		{
		//			command.Parameters.AddWithValue("@codigo_item", codigoDoItem);
		//			command.Parameters.AddWithValue("@placa_item", placaDoItem);
		//			command.Parameters.AddWithValue("@descricao_item", descricaoDoItem);
		//			command.Parameters.AddWithValue("@tipo_item", tipoDoItem);
		//			command.Parameters.AddWithValue("@grupo_item", grupoDoItem);
		//			command.Parameters.AddWithValue("@tipo_aquisicao", tipoAquisicao);
		//			command.Parameters.AddWithValue("@tipo_comprovante", tipoComprovante);
		//			command.Parameters.AddWithValue("@numero_comprovante", numeroComprovante);
		//			command.Parameters.AddWithValue("@estado_conservacao", conservacaoDoItem);
		//			command.Parameters.AddWithValue("@tem_combustivel", combustivel);
		//			command.Parameters.AddWithValue("@placa_veiculo", placaVeiculo);
		//			command.Parameters.AddWithValue("@modelo_veiculo", modeloVeiculo);
		//			command.Parameters.AddWithValue("@localizacao_fisica", localizacoFisicaDoItem);
		//			command.Parameters.AddWithValue("@responsavel", responsavel);
		//			command.Parameters.AddWithValue("@observacao", observacaoDoItem);
		//			command.Parameters.AddWithValue("@valor_aquisicao", valorDoItem);
		//			command.Parameters.AddWithValue("@metodo_depreciacao", metodoDepreciacao);
		//			command.Parameters.AddWithValue("@valor_residual", valorResidual);
		//			command.Parameters.AddWithValue("@valor_depreciavel", valorDepreciavel);
		//			command.Parameters.AddWithValue("@vida_util", vidaUtil);
		//			command.Parameters.AddWithValue("@depreciacao_anual", depreciacaoAnual);
		//			command.Parameters.AddWithValue("@inicio_depreciacao", Convert.ToDateTime(dataInicioDepreciacao));
		//			command.Parameters.AddWithValue("@valor_depreciado", valorDepreciado);
		//			command.Parameters.AddWithValue("@saldo_depreciar", saldoDepreciar);
		//			command.Parameters.AddWithValue("@valor_liquido", valorLiquido);
		//			command.Parameters.AddWithValue("@data_aquisicao", Convert.ToDateTime(dataAquisicao));
		//			command.Parameters.AddWithValue("@patrimonios_id", 1);

		//			int rowsAffected = command.ExecuteNonQuery();

		//			if (rowsAffected > 0)
		//			{
		//				ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), "NotificaçãoCadastroSucesso", "NotificaçãoCadastroSucesso();", true);
		//			}
		//			else
		//			{
		//				Console.WriteLine("Falha ao inserir dados!");
		//			}
		//		}
		//	}
		//}

		public bool VericarDuplicidade(string placaDoItem, string codigoDoItem)
		{

			List<ItemModelo> valida = new List<ItemModelo>();

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConectandoAoBD"].ConnectionString;
			string query = "SELECT codigo_item, placa_item FROM itens WHERE placa_item = " + placaDoItem + " or codigo_item = " + codigoDoItem;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader dr = command.ExecuteReader())
					{
						while (dr.Read())
						{
							ItemModelo camposAhValidar = new ItemModelo();
							camposAhValidar.CodigoItem = dr["codigo_item"].ToString();
							camposAhValidar.PlacaItem = dr["placa_item"].ToString();

							valida.Add(camposAhValidar);
						}
					}
				}
				if (valida.Count() == 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}
}