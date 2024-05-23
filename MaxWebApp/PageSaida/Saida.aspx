<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Saida.aspx.cs" Inherits="MaxWebApp.Saida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div>
            <h1 style="margin-bottom: 20px;">Saída de Itens</h1>
        </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="grid-large table table-striped mt-5 table-hover table-light" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand1" DataKeyNames="ID">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="ckSelecionarTodos" runat="server" AutoPostBack="true" OnCheckedChanged="CkSelecionarTodos_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckSelecionados" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Placa" HeaderText="Placa" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:BoundField DataField="ValorAquisicao" HeaderText="Valor de Aquisição" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="DtAquisicao" HeaderText="Data de Aquisição" DataFormatString="{0:yyyy-MM-dd}" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="ExcluirItensSelecionados" runat="server" Text="Excluir Itens Selecionados" OnClick="ExcluirItensSelecionados_Click" CssClass="btn btn-success" style="margin-top: 20px;"/>
    </div>
</asp:Content>
