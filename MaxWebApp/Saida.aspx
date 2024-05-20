<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Saida.aspx.cs" Inherits="MaxWebApp.Saida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Saída de item</h1>
    <div style="margin-top: 200px">
        <asp:Literal ID="tabelaSaida" runat="server"></asp:Literal>
    </div>
    <div class="d-flex justify-content-start" style="margin-top: 150px">
        <a id="botaoCancelar" href="/" type="submit" class="btn btn-primary" style="margin-top: 5em;">Voltar</a>
    </div>
</asp:Content>
