<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MaxWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<link href="AnimacaoCard.css" rel="stylesheet">

	<main>
		<section class="row" aria-labelledby="aspnetTitle">
			<h1 id="aspnetTitle">Visão Geral</h1>
		</section>

		<div class="container-fluid d-flex justify-content-center text-center">
			<div class="container-fluid d-flex justify-content-center text-center" style="margin-top: 50px">
				<div class="wrapper">
					<div class="box-area">
						<a href="PageEntrada/Entrada" class="box">
							<img src="Imagens/EntradaI.png" alt="">
							<div class="overlay">
								<h3>Entrada</h3>
								<p>Cadastra novo item</p>
							</div>
						</a>
						<a href="PageInventario/InventarioDeItens" class="box">
							<img src="Imagens/InventarioI.png" alt="">
							<div class="overlay">
								<h3>Inventario</h3>
								<p>Relação de todos os itens cadastrados</p>
							</div>
						</a>
						<a href="PageSaida/Saida" class="box">
							<img src="Imagens/SaidaI.png" alt="">
							<div class="overlay">
								<h3>Saida</h3>
								<p>Saída do Item</p>
							</div>
						</a>
					</div>
				</div>
			</div>
		</div>
	</main>
</asp:Content>
