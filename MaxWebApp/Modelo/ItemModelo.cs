using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxWebApp.Modelo
{
	public class ItemModelo
	{
		public int Id { get; set; }
		public string CodigoItem { get; set; }
		public string PlacaItem { get; set; }
		public string DescricaoItem { get; set; }
		public string TipoItem { get; set; }
		public string GrupoItem { get; set; }
		public string EstadoConservacao { get; set; }
		public string TipoAquisicao { get; set; }
		public string ValorAquisicao { get; set; }
		public string MetodoDepreciacao { get; set; }
		public string ValorResidual { get; set; }
		public string Responsavel { get; set; }
		public string VidaUtil { get; set; }
		public string DepreciacaoAnual { get; set; }
		public DateTime InicioDepreciacao { get; set; }
		public DateTime DataAquisicao { get; set; }
		public string ValorDepreciavel { get; set; }
		public string ValorDepreciado { get; set; }
		public string SaldoDepreciar { get; set; }
		public string ValorLiquido { get; set; }
		public string TipoComprovante { get; set; }
		public string NumeroComprovante { get; set; }
		public string TemCombustivel { get; set; }
		public string PlacaVeiculo { get; set; }
		public string ModeloVeiculo { get; set; }
		public string LocalizacaoFisica { get; set; }
		public string Observacao { get; set; }
		public int PatrimoniosId { get; set; }
	}
}