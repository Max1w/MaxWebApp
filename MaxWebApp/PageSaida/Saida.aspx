<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Saida.aspx.cs" Inherits="MaxWebApp.Saida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Saída de item</h1>
    <div style="margin-top: 200px">
        <%--<asp:Literal ID="tabelaSaida" runat="server"></asp:Literal>--%>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Código</th>
                    <th scope="col">Placa</th>
                    <th scope="col">Descrição</th>
                    <th scope="col">Valor de Aquisição</th>
                    <th scope="col">Data de Aquisição</th>
                    <th scope="col">Opções</th>
                </tr>
            </thead>
            <tbody>
                <%
                    foreach (registro in inventarios)
                    {
                %>
                <tr>
                    <td>Mark</td>
                    <td>Otto</td>
                    <td>@mdo</td>
                    <td>info1</td>
                    <td>info2</td>
                    <td>info3</td>
                </tr>
                <%
                    }
                %>
            </tbody>
        </table>
    </div>
    <div class="d-flex justify-content-start" style="margin-top: 150px">
        <a id="botaoCancelar" href="/" type="submit" class="btn btn-primary" style="margin-top: 5em;">Voltar</a>
    </div>
</asp:Content>
