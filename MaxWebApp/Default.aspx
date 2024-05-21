<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MaxWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Visão Geral</h1>
        </section>

        <div class="container-fluid">
            <div class="d-flex row justify-content-center align-items-center align-middle" style="margin-top: 10em; margin-bottom: 10em;">
                <div class="col-6 text-center">
                    <h3 class="mb-4">Escolha uma opção</h3>

                    <div class="d-flex align-items-center mb-2">
                        <img src="Imagens/Entrada.png" alt="Imagem" class="mr-2 mb-2">
                        <a id="btnEntrada" href="/PageEntrada/Entrada" class="btn custom-btn btn-lg btn-block w-100 mb-2" style="height: 52px; background: #42FF00;"><strong>Entrada</strong></a>
                    </div>

                    <div class="d-flex align-items-center mb-2">
                        <img src="Imagens/Inventario.png" alt="Imagem" class="mr-2 mb-2">
                        <a id="btnInventario" href="/PageInventario/Inventario" class="btn custom-btn btn-lg btn-block w-100 mb-2" style="background: #42FF00"><strong>Inventario</strong></a>
                    </div>

                    <div class="d-flex align-items-center mb-2">
                        <img src="Imagens/Saida.png" alt="Imagem" class="mr-2 mb-2">
                        <a id="btnSaida" href="/PageSaida/Saida" class="btn custom-btn btn-lg btn-block w-100 mb-2" style="background: #42FF00"><strong>Saída</strong></a>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
