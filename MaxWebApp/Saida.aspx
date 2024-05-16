<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Saida.aspx.cs" Inherits="MaxWebApp.Saida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Saída de item</h1>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSourceSaida" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="placa_item" HeaderText="placa_item" SortExpression="placa_item" />
                <asp:BoundField DataField="descricao_item" HeaderText="descricao_item" SortExpression="descricao_item" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceSaida" runat="server" ConnectionString="<%$ ConnectionStrings:projetomvrConnectionString %>" DeleteCommand="DELETE FROM [itens] WHERE [id] = @id" InsertCommand="INSERT INTO [itens] ([placa_item], [descricao_item]) VALUES (@placa_item, @descricao_item)" SelectCommand="SELECT [id], [placa_item], [descricao_item] FROM [itens]" UpdateCommand="UPDATE [itens] SET [placa_item] = @placa_item, [descricao_item] = @descricao_item WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="placa_item" Type="Int32" />
                <asp:Parameter Name="descricao_item" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="placa_item" Type="Int32" />
                <asp:Parameter Name="descricao_item" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
