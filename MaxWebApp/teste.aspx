<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="MaxWebApp.teste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="codigo_item" HeaderText="codigo_item" SortExpression="codigo_item" />
            <asp:BoundField DataField="placa_item" HeaderText="placa_item" SortExpression="placa_item" />
            <asp:BoundField DataField="descricao_item" HeaderText="descricao_item" SortExpression="descricao_item" />
            <asp:BoundField DataField="grupo_item" HeaderText="grupo_item" SortExpression="grupo_item" />
            <asp:BoundField DataField="localizacao_fisica" HeaderText="localizacao_fisica" SortExpression="localizacao_fisica" />
            <asp:BoundField DataField="data_aquisicao" HeaderText="data_aquisicao" SortExpression="data_aquisicao" />
            <asp:BoundField DataField="estado_conservacao" HeaderText="estado_conservacao" SortExpression="estado_conservacao" />
            <asp:BoundField DataField="valor_aquisicao" HeaderText="valor_aquisicao" SortExpression="valor_aquisicao" />
            <asp:BoundField DataField="observacao" HeaderText="observacao" SortExpression="observacao" />
            <asp:BoundField DataField="patrimonios_id" HeaderText="patrimonios_id" SortExpression="patrimonios_id" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:projetomvrConnectionString %>" DeleteCommand="DELETE FROM [itens] WHERE [id] = @id" InsertCommand="INSERT INTO [itens] ([codigo_item], [placa_item], [descricao_item], [grupo_item], [localizacao_fisica], [data_aquisicao], [estado_conservacao], [valor_aquisicao], [observacao], [patrimonios_id]) VALUES (@codigo_item, @placa_item, @descricao_item, @grupo_item, @localizacao_fisica, @data_aquisicao, @estado_conservacao, @valor_aquisicao, @observacao, @patrimonios_id)" SelectCommand="SELECT * FROM [itens]" UpdateCommand="UPDATE [itens] SET [codigo_item] = @codigo_item, [placa_item] = @placa_item, [descricao_item] = @descricao_item, [grupo_item] = @grupo_item, [localizacao_fisica] = @localizacao_fisica, [data_aquisicao] = @data_aquisicao, [estado_conservacao] = @estado_conservacao, [valor_aquisicao] = @valor_aquisicao, [observacao] = @observacao, [patrimonios_id] = @patrimonios_id WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="codigo_item" Type="String" />
            <asp:Parameter Name="placa_item" Type="Int32" />
            <asp:Parameter Name="descricao_item" Type="String" />
            <asp:Parameter Name="grupo_item" Type="String" />
            <asp:Parameter Name="localizacao_fisica" Type="String" />
            <asp:Parameter DbType="Date" Name="data_aquisicao" />
            <asp:Parameter Name="estado_conservacao" Type="String" />
            <asp:Parameter Name="valor_aquisicao" Type="String" />
            <asp:Parameter Name="observacao" Type="String" />
            <asp:Parameter Name="patrimonios_id" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="codigo_item" Type="String" />
            <asp:Parameter Name="placa_item" Type="Int32" />
            <asp:Parameter Name="descricao_item" Type="String" />
            <asp:Parameter Name="grupo_item" Type="String" />
            <asp:Parameter Name="localizacao_fisica" Type="String" />
            <asp:Parameter DbType="Date" Name="data_aquisicao" />
            <asp:Parameter Name="estado_conservacao" Type="String" />
            <asp:Parameter Name="valor_aquisicao" Type="String" />
            <asp:Parameter Name="observacao" Type="String" />
            <asp:Parameter Name="patrimonios_id" Type="Int32" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>
