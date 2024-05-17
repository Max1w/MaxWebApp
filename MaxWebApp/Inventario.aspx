<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="MaxWebApp.Inventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Inventário</h1>
    <div style="margin-top: 10em; margin-bottom: 10em;">
    <label class="d-flex row justify-content-center"><h4>Tabela de Itens</h4></label>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" DataSourceID="SqlDataSourceInventario" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="codigo_item" HeaderText="codigo_item" SortExpression="codigo_item" />
                <asp:BoundField DataField="placa_item" HeaderText="placa_item" SortExpression="placa_item" />
                <asp:BoundField DataField="descricao_item" HeaderText="descricao_item" SortExpression="descricao_item" />
                <asp:BoundField DataField="valor_aquisicao" HeaderText="valor_aquisicao" SortExpression="valor_aquisicao" />
                <asp:BoundField DataField="data_aquisicao" HeaderText="data_aquisicao" SortExpression="data_aquisicao" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceInventario" runat="server" ConnectionString="<%$ ConnectionStrings:ConectandoAoBD %>" SelectCommand="SELECT [codigo_item], [placa_item], [descricao_item], [valor_aquisicao], [data_aquisicao] FROM [itens]"></asp:SqlDataSource>
    </div>
    <a id="botaoCancelar" href="/" type="submit" class="btn btn-primary" style="margin-top: 5em; background:">Voltar</a>
</asp:Content>
