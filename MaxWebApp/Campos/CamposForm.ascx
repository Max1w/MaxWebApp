<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CamposForm.ascx.cs" Inherits="MaxWebApp.Campos.CamposForm" %>

<div class="container-fluid">
    <div class="d-flex row justify-content-center align-items-center align-middle" style="margin-top: 5em; margin-bottom: 7em;">
        <div class="col-12">
            <asp:HiddenField ID="hfItemId" runat="server" />
            <div class="d-flex">
                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                    <label for="text">Código *</label>
                    <asp:TextBox runat="server" ID="txtCodigoDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                    <div id="avisoCodigo" class="invalid-feedback">Favor inserir um caracter válido</div>
                    <asp:RequiredFieldValidator ID="rfvCodigoDoItem" runat="server" ControlToValidate="txtCodigoDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                    <label for="text">Placa *</label>
                    <asp:TextBox runat="server" ID="txtPlacaDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                    <div id="avisoPlaca" class="invalid-feedback">Favor inserir um numero </div>
                    <asp:RequiredFieldValidator ID="rfvPlacaDoItem" runat="server" ControlToValidate="txtPlacaDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group m-1 col-8" style="padding-right: 0px; padding-left: 0px">
                    <label for="text">Descrição *</label>
                    <asp:TextBox runat="server" ID="txtDescricaoDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                    <div id="avisoDescricao" class="invalid-feedback">Favor inserir um caracter válido</div>
                    <asp:RequiredFieldValidator ID="rfvDescricaoDoItem" runat="server" ControlToValidate="txtDescricaoDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="d-flex">
                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                    <label for="text">Data da Aquisição *</label>
                    <asp:TextBox runat="server" ID="txtDataAquisicao" TextMode="Date" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDataAquisicao" runat="server" ControlToValidate="txtDataAquisicao" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                    <label for="exemplo">Grupo</label>
                    <asp:DropDownList runat="server" ID="ddlGrupoItem" CssClass="form-control">
                        <asp:ListItem>Móvel</asp:ListItem>
                        <asp:ListItem>Imóvel</asp:ListItem>
                        <asp:ListItem>Dominical</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                    <label for="exemplo">Estado de Conservação</label>
                    <asp:DropDownList runat="server" ID="ddlConservacaoItem" CssClass="form-control">
                        <asp:ListItem>Ótimo</asp:ListItem>
                        <asp:ListItem>Bom</asp:ListItem>
                        <asp:ListItem>Regular</asp:ListItem>
                        <asp:ListItem>Ruim</asp:ListItem>
                        <asp:ListItem>Péssimo</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group m-1 col-6" style="padding-right: 8px; padding-left: 0px">
                    <label for="text">Localização Física</label>
                    <asp:TextBox runat="server" ID="txtLocalizacaoFisica" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                    <div id="avisoLocalizacao" class="invalid-feedback">Favor inserir um caracter válido</div>
                </div>
            </div>
            <div class="d-flex">
                <div class="form-group m-1 col-10" style="padding-right: 0px; padding-left: 0px">
                    <label for="teste">Observação</label>
                    <asp:TextBox runat="server" ID="txtObservacao" TextMode="MultiLine" Rows="3" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                </div>
                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                    <label for="text">Valor *</label>
                    <div class="mt-4">
                        <asp:TextBox runat="server" ID="txtValorItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                        <div id="avisoValor" class="invalid-feedback">Favor inserir um valor (R$)</div>
                        <asp:RequiredFieldValidator ID="rfvalorItem" runat="server" ControlToValidate="txtValorItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="d-flex justify-content-end" id="btnCancelar">
    <a id="botaoCancelar" href="/" class="btn btn-danger m-3">Cancelar</a> <%-------%>
    <button type="button" class="btn btn-success m-3" data-toggle="modal" data-target="#exampleModal">
        Salvar
    </button>
</div>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Cadastro</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body" id="descriocaoDoModal">
                Deseja salvar esse cadastro? <%-------%>
            </div>
            <div class="modal-footer" id="btnSalvar">
                <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="NotificaçãoCadastroCancelar()">Cancelar</button>
                <button id="btnEnviar" type="button" class="btn btn-success" runat="server" onserverclick="btnSalvar_Click">Salvar</button> <%-------%>
            </div>
        </div>
    </div>
</div>

<div id="notificacaoDeSucesso" class="alert alert-success" role="alert">
    Cadastro salvo com sucesso!
</div>
<div id="notificacaoDeCampoInvalido" class="alert alert-warning" role="alert">
    Favor preencher todos os campos obrigatórios *!
</div>
<div id="notificacaoDeCancelar" class="alert alert-danger" role="alert">
    Cadastro cancelado!
</div>
<div id="cadastroDuplicado" class="alert alert-danger" role="alert">
    Cadastro duplicado!
</div>
<div id="limiteUltrapassadoDeCaracteres" class="alert alert-danger" role="alert">
    Foi ultrapassado o valor limite de caracteres!
</div>

<script src="../Scripts/Notificacao.js"></script>
