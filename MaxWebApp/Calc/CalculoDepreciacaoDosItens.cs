using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxWebApp
{
	public class CalculoDepreciacaoDosItens
	{
		public decimal ValorResidual(decimal valorAquisicao, int vidaUtil, int depreciacaoAnual)
		{
			decimal result = valorAquisicao * vidaUtil;
			decimal valorResidual = result / 100;
			ValorDepreciavel(valorResidual, valorAquisicao, depreciacaoAnual);
			return valorResidual;
		}

		public decimal ValorDepreciavel(decimal valorResidual, decimal valorAquisicao, int depreciacaoAnual)
		{
			decimal valorDepreciavel = valorAquisicao - valorResidual;
			ValorDepreciado(valorDepreciavel, valorAquisicao, depreciacaoAnual);
			return valorDepreciavel;
		}

		public decimal ValorDepreciado(decimal valorDepreciavel, decimal valorAquisicao, int depreciacaoAnual)
		{
			decimal valorDepreciado = valorDepreciavel * depreciacaoAnual / 100;
			return valorDepreciado;
		}

		public decimal ValorLiquidoContabil(decimal valorAquisicao, decimal valorDepreciado)
		{
			decimal valorLiquidoContabil = valorAquisicao - valorDepreciado;
			return valorLiquidoContabil;
		}

		public decimal SaldoADepreciar(decimal valorDepreciavel, decimal valorDepreciado)
		{
			decimal saldoADepreciar = valorDepreciavel - valorDepreciado;
			return saldoADepreciar;
		}

		public (decimal, decimal, decimal) CalcularDepreciacao_Parte2(decimal valorAquisicao, int vidaUtil, decimal valorDepreciado, decimal valorDepreciavel)
		{
			decimal valorDepreciadoAcumulado = 0;
			decimal valorLiquido = 0;
			decimal saldoADepreciar = 0;

			for (int i = 0; i < 2; i++)
			{
				valorDepreciadoAcumulado += valorDepreciado;
				valorLiquido = ValorLiquidoContabil(valorAquisicao, valorDepreciadoAcumulado);
				saldoADepreciar = SaldoADepreciar(valorDepreciavel, valorDepreciadoAcumulado);
			}

			return (saldoADepreciar, valorLiquido, valorDepreciadoAcumulado);
		}
		public (decimal, decimal, decimal) CalcularDepreciacao_Parte1(decimal valorAquisicao, int vidaUtil, int depreciacaoAnual)
		{

			decimal valorResidual = ValorResidual(valorAquisicao, vidaUtil, depreciacaoAnual);
			decimal valorDepreciavel = ValorDepreciavel(valorResidual, valorAquisicao, depreciacaoAnual);
			decimal valorDepreciado = ValorDepreciado(valorDepreciavel, valorAquisicao, depreciacaoAnual);

			CalcularDepreciacao_Parte2(valorAquisicao, vidaUtil, valorDepreciado, valorDepreciavel);

			return (valorResidual, valorDepreciavel, valorDepreciado);
		}

	}
}