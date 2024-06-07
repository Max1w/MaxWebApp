<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="MaxWebApp.teste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="d-flex row justify-content-center align-items-center align-middle" style="margin-top: 5em; margin-bottom: 7em;">
            <div class="col-12">
                <asp:HiddenField ID="hfItemId" runat="server" />
                <div class="d-flex rounded justify-content-center mb-2" style="background: rgb(177, 174, 174, 0.5);">
                    <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                        <label class="mt-2" for="text">Placa *</label>
                        <asp:TextBox runat="server" ID="txtPlacaDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                        <div id="avisoPlaca" class="invalid-feedback">Favor inserir um numero </div>
                        <asp:RequiredFieldValidator ID="rfvPlacaDoItem" runat="server" ControlToValidate="txtPlacaDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group m-1 col-9" style="padding-right: 0px; padding-left: 0px">
                        <label class="mt-2" for="text">Descrição *</label>
                        <asp:TextBox runat="server" ID="txtDescricaoDoItem" CssClass="form-control col-12 shadow p-3 bg-light"></asp:TextBox>
                        <div id="avisoDescricao" class="invalid-feedback">Favor inserir um caracter válido</div>
                        <asp:RequiredFieldValidator ID="rfvDescricaoDoItem" runat="server" ControlToValidate="txtDescricaoDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <nav>
                    <div class="nav nav-tabs" id="nav-tab" role="tablist">
                        <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Item</a>
                        <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Valor</a>
                    </div>
                </nav>
                <div class="tab-content" id="nav-tabContent">
                    <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                        <div class="d-flex">
                            <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                                <label for="exemplo">Tipo</label>
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
                            <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                                <label for="text">Data da Aquisição *</label>
                                <asp:TextBox runat="server" ID="txtDataAquisicao" TextMode="Date" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDataAquisicao" runat="server" ControlToValidate="txtDataAquisicao" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="d-flex">
                            <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                                <label for="exemplo">Grupo</label>
                                <asp:DropDownList runat="server" ID="DropDownList1" CssClass="form-control">
                                    <asp:ListItem>Móvel Mobiliario</asp:ListItem>
                                    <asp:ListItem>Imóvel residencia</asp:ListItem>
                                    <asp:ListItem>Móvel Veículo</asp:ListItem>
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
                        </div>

                    </div>
                    <div class="tab-pane fade d-flex" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
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
    </div>
</asp:Content>
