<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MaxWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Visão Geral</h1>
        </section>

        <div class="container-fluid d-flex justify-content-center text-center" style="margin-top:100px">
            
            <div class="card m-4 rounded" style="width: 18rem; cursor: pointer">
            <a href="/PageEntrada/Entrada" class="btn" style="background: #5CB85C"><img src="Imagens/EntradaI.png" class="card-img-top" alt="Imagem"></a>
                <div class="card-body rounded" style="background: #a0dea0">
                    <h5 class="card-title">Entrada</h5>
                    <p class="card-text">Cadastro de Itens</p>
                </div>
            </div>

            <div class="card m-4 rounded" style="width: 18rem; cursor: pointer">
            <a href="/PageInventario/InventarioDeItens" class="btn" style="background: #5CB85C"><img src="Imagens/InventarioI.png" class="card-img-top" alt="Imagem"></a>
                <div class="card-body rounded" style="background: #a0dea0">
                    <h5 class="card-title">Inventário</h5>
                    <p class="card-text">Relação de todos os itens cadastrados</p>
                </div>
            </div>

            <div class="card m-4 rounded" style="width: 18rem; cursor: pointer">
            <a href="/PageSaida/Saida" class="btn" style="background: #5CB85C"><img src="Imagens/SaidaI.png" class="card-img-top" alt="Imagem"></a>
                <div class="card-body rounded" style="background: #a0dea0">
                    <h5 class="card-title">Saída</h5>
                    <p class="card-text">Baixa dos itens</p>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
