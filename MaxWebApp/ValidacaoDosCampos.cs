using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxWebApp
{
	public class ValidacaoDosCampos
	{
		public bool CampoVazioOuNull(string codigoDoItem, string placaDoItem, string descricaoDoItem,
										string dataAquisicao, string grupoDoItem, string conservacaoDoItem,
										string tipoDoItem, string tipoAquisicao, string metodoDepreciacao,
										string responsavel, string dataInicioDepreciacao, string valorResidual,
										string valorDepreciavel, string valorDepreciado, string saldoDepreciar,
										string valorLiquido, string valorDoItemS, string vidaUtilS, string depreciacaoAnualS)
		{
			if (!string.IsNullOrEmpty(codigoDoItem) && !string.IsNullOrEmpty(placaDoItem) && !string.IsNullOrEmpty(descricaoDoItem) && !string.IsNullOrEmpty(dataAquisicao) &&
				!string.IsNullOrEmpty(grupoDoItem) && !string.IsNullOrEmpty(conservacaoDoItem) && !string.IsNullOrEmpty(tipoDoItem) && !string.IsNullOrEmpty(tipoAquisicao) &&
				!string.IsNullOrEmpty(metodoDepreciacao) && !string.IsNullOrEmpty(responsavel) && !string.IsNullOrEmpty(dataInicioDepreciacao) && !string.IsNullOrEmpty(valorResidual) &&
				!string.IsNullOrEmpty(valorDepreciavel) && !string.IsNullOrEmpty(valorDepreciado) && !string.IsNullOrEmpty(saldoDepreciar) && !string.IsNullOrEmpty(valorLiquido) &&
				!string.IsNullOrEmpty(valorDoItemS) && !string.IsNullOrEmpty(valorLiquido) && !string.IsNullOrEmpty(vidaUtilS) && !string.IsNullOrEmpty(depreciacaoAnualS))
			{ return true; } else { return false; }
		}
		public bool TamanhoLimiteDeCaracteres(string codigoDoItem, string placaDoItem, string descricaoDoItem, string placaVeiculo, string modeloVeiculo,
												string responsavel, string valorResidual, string localizacoFisicaDoItem, string numeroComprovante,
												string valorDepreciavel, string valorDepreciado, string saldoDepreciar, string observacaoDoItem,
												string valorLiquido, string valorDoItemS, string vidaUtilS, string depreciacaoAnualS)
		{
			if (codigoDoItem.Length < 10 && placaDoItem.Length < 10 && descricaoDoItem.Length < 2000 && localizacoFisicaDoItem.Length < 2000 &&
				observacaoDoItem.Length < 4000 && numeroComprovante.Length < 20 && placaVeiculo.Length < 10 && modeloVeiculo.Length < 50 &&
				valorDoItemS.Length < 50 && vidaUtilS.Length < 50 && depreciacaoAnualS.Length < 50 && valorResidual.Length < 50 &&
				valorDepreciavel.Length < 50 && valorDepreciado.Length < 50 && saldoDepreciar.Length < 50 && valorLiquido.Length < 50 && responsavel.Length < 50)
			{return true; } else { return false; }
		}
	}
}