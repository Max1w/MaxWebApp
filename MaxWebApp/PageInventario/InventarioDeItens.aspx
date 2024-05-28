<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InventarioDeItens.aspx.cs" Inherits="MaxWebApp.PageInventario.InventarioDeItens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div>
            <h1 style="margin-bottom: 20px;">Inventário</h1>
        </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="grid-large table table-striped mt-5 table-hover table-light" AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="true">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Placa" HeaderText="Placa" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:BoundField DataField="Grupo" HeaderText="Valor de Aquisição" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Localizacao" HeaderText="Data de Aquisição"  />
                <asp:BoundField DataField="Observacao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="ValorAquisicao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="DtAquisicao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:TemplateField>
                <ItemTemplate>
                <a runat="server" href="/PageEditar/Editar">Editar</a>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
