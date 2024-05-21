<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="MaxWebApp.Inventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Inventário</h1>

    <div style="margin-top: 200px">
        <asp:Literal ID="tabelaInventario" runat="server"></asp:Literal>
    </div>
    <div class="d-flex justify-content-start"style="margin-top: 150px">
        <a id="botaoCancelar" href="/" type="submit" class="btn btn-primary" style="margin-top: 5em;">Voltar</a>
    </div>
</asp:Content>
