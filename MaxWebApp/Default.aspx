<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MaxWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<main>
		<section class="row" aria-labelledby="aspnetTitle">
			<h1 id="aspnetTitle">Visão Geral</h1>
		</section>

		<div class="container-fluid">
			<div class="row justify-content-center align-items-center align-middle" style="margin-top: 10em; margin-bottom: 10em;">
				<div class="col-6 text-center">
					<h3 class="mb-4">Escolha uma opção</h3>
					<a id="btnEntrada" href="/Entrada" class="btn btn-primary custom-btn btn-lg btn-block w-100 mb-2">Entrada</a>
					<a id="btnInventario" href="/Inventario" class="btn btn-primary custom-btn btn-lg btn-block w-100 mb-2">Inventario</a>
					<a id="btnSaida" href="/Saida" class="btn btn-primary custom-btn btn-lg btn-block w-100 mb-2">Saída</a>
				</div>
			</div>
		</div>
	</main>
</asp:Content>
