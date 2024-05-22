<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Saida.aspx.cs" Inherits="MaxWebApp.Saida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div>
            <h1>Genaro Veículos</h1>
            <h2>Seu Estoque</h2>
        </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="grid-large" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand1">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="ckSelecionarTodos" runat="server" AutoPostBack="true" OnCheckedChanged="SelecionarTodos" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckSelecionados" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Codigo" HeaderText="Código do Item" />
                <asp:BoundField DataField="Placa" HeaderText="Placa do Item" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição do Item" />
                <asp:BoundField DataField="ValorAquisicao" HeaderText="Valor de Aquisição" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="DtAquisicao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CommandName="Excluir" CommandArgument='<%# Eval("ID") %>' CssClass="button" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
