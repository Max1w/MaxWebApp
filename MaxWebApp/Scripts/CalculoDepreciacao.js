function ValorResidual(valorAquisicao, vidaUtil) {
	let result = valorAquisicao * vidaUtil;
	let valorResidual = result / 100;
	return valorResidual;
}

function ValorDepreciavel(valorResidual, valorAquisicao) {
	let valorDepreciavel = valorAquisicao - valorResidual;
	return valorDepreciavel;
}

function ValorDepreciado(valorDepreciavel, depreciacaoAnual) {
	let valorDepreciado = valorDepreciavel * depreciacaoAnual / 100;
	return valorDepreciado;
}

function ValorLiquidoContabil(valorAquisicao, valorDepreciado) {
	let valorLiquidoContabil = valorAquisicao - valorDepreciado;
	return valorLiquidoContabil;
}

function SaldoADepreciar(valorDepreciavel, valorDepreciado) {
	let saldoADepreciar = valorDepreciavel - valorDepreciado;
	return saldoADepreciar;
}

function CalcularDepreciacao_Parte2(valorAquisicao, vidaUtil, valorDepreciado, valorDepreciavel) {
	let valorDepreciadoAcumulado = 0;
	let valorLiquido = 0;
	let saldoADepreciar = 0;

	for (let i = 0; i < 2; i++) {
		valorDepreciadoAcumulado += valorDepreciado;
		valorLiquido = ValorLiquidoContabil(valorAquisicao, valorDepreciadoAcumulado);
		saldoADepreciar = SaldoADepreciar(valorDepreciavel, valorDepreciadoAcumulado);
	}

	return {
		saldoADepreciar: saldoADepreciar,
		valorLiquido: valorLiquido,
		valorDepreciadoAcumulado: valorDepreciadoAcumulado
	};
}

function CalcularDepreciacao_Parte1(valorAquisicao, vidaUtil, depreciacaoAnual) {
	let valorResidual = ValorResidual(valorAquisicao, vidaUtil);
	let valorDepreciavel = ValorDepreciavel(valorResidual, valorAquisicao);
	let valorDepreciado = ValorDepreciado(valorDepreciavel, depreciacaoAnual);

	let parte2 = CalcularDepreciacao_Parte2(valorAquisicao, vidaUtil, valorDepreciado, valorDepreciavel);

	return {
		valorResidual: valorResidual,
		valorDepreciavel: valorDepreciavel,
		valorDepreciado: valorDepreciado,
		saldoADepreciar: parte2.saldoADepreciar,
		valorLiquido: parte2.valorLiquido,
		valorDepreciadoAcumulado: parte2.valorDepreciadoAcumulado
	};
}

// Calcular os valores
let resultado = CalcularDepreciacao_Parte1(valorAquisicao, vidaUtil, depreciacaoAnual);

// Exibir os resultados
document.getElementById("MainContent_txtValorResidual").value = resultado.valorResidual.toFixed(2);
document.getElementById("MainContent_txtValorDepreciavel").value = resultado.valorDepreciavel.toFixed(2);
document.getElementById("MainContent_txtValorDepreciado").value = resultado.valorDepreciado.toFixed(2);
document.getElementById("MainContent_txtSaldoDepreciar").value = resultado.saldoADepreciar.toFixed(2);
document.getElementById("MainContent_txtValorLiquido").value = resultado.valorLiquido.toFixed(2);