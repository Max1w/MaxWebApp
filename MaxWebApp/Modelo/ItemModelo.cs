using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxWebApp.Modelo
{
	public class ItemModelo
	{
		public int Id { get; set; }
		public string codigo_item { get; set; }
		public string placa_item { get; set; }
		public string descricao_item { get; set; }
		public string tipo_item { get; set; }
		public string grupo_item { get; set; }
		public string estado_conservacao { get; set; }
		public string tipo_aquisicao { get; set; }
		public string valor_aquisicao { get; set; }
		public string metodo_depreciacao { get; set; }
		public string valor_residual { get; set; }
		public string responsavel { get; set; }
		public string vida_util { get; set; }
		public string depreciacao_anual { get; set; }
		public DateTime inicio_depreciacao { get; set; }
		public DateTime data_aquisicao { get; set; }
		public string valor_depreciavel { get; set; }
		public string valor_depreciado { get; set; }
		public string saldo_depreciar { get; set; }
		public string valor_liquido { get; set; }
		public string tipo_comprovante { get; set; }
		public string numero_comprovante { get; set; }
		public string tem_combustivel { get; set; }
		public string placa_veiculo { get; set; }
		public string modelo_veiculo { get; set; }
		public string localizacao_fisica { get; set; }
		public string observacao { get; set; }
		public int patrimonios_id { get; set; }
	}
}