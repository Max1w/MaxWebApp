<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="MaxWebApp.teste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="d-flex row justify-content-center align-items-center align-middle" style="margin-top: 5em; margin-bottom: 7em;">
            <div class="col-12">
                <asp:HiddenField ID="hfItemId" runat="server" />
                <div class="d-flex rounded justify-content-center mb-2" style="background: rgb(177, 174, 174, 0.5);">

                    <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                        <label class="mt-2" for="text">Placa *</label>
                        <asp:TextBox runat="server" ID="txtPlacaDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                        <div id="avisoPlaca" class="invalid-feedback">Favor inserir apenas numero</div>
                        <asp:RequiredFieldValidator ID="rfvPlacaDoItem" runat="server" ControlToValidate="txtPlacaDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group m-1 col-9" style="padding-right: 0px; padding-left: 0px">
                        <label class="mt-2" for="text">Descrição *</label>
                        <asp:TextBox runat="server" ID="txtDescricaoDoItem" TextMode="MultiLine" Rows="1" CssClass="form-control col-12 shadow p-3 bg-light"></asp:TextBox>
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

                        <div class="d-flex rounded justify-content-center mb-2 mt-5">
                            <div class="form-group m-1 col-4" style="padding-right: 0px; padding-left: 0px">
                                <label for="exemplo">Tipo *</label>
                                <asp:DropDownList runat="server" ID="ddlTipoItem" CssClass="form-control col-12">
                                    <asp:ListItem>Móvel</asp:ListItem>
                                    <asp:ListItem>Imóvel</asp:ListItem>
                                    <asp:ListItem>Dominical</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group m-1 col-4" style="padding-right: 0px; padding-left: 0px">
                                <label for="exemplo">Grupo *</label>
                                <asp:DropDownList runat="server" ID="ddlGrupoItem" CssClass="form-control col-12">
                                    <asp:ListItem>Móvel Mobiliario</asp:ListItem>
                                    <asp:ListItem>Imóvel residencia</asp:ListItem>
                                    <asp:ListItem>Móvel Veículo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px">
                                <label for="exemplo">Estado de Conservação *</label>
                                <asp:DropDownList runat="server" ID="ddlConservacaoItem" CssClass="form-control col-12">
                                    <asp:ListItem>Ótimo</asp:ListItem>
                                    <asp:ListItem>Bom</asp:ListItem>
                                    <asp:ListItem>Regular</asp:ListItem>
                                    <asp:ListItem>Ruim</asp:ListItem>
                                    <asp:ListItem>Péssimo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="d-flex rounded justify-content-center" style="margin-bottom: -15px">
                            <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                                <label for="text">Data da Aquisição *</label>
                                <asp:TextBox runat="server" ID="txtDataAquisicao" TextMode="Date" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDataAquisicao" runat="server" ControlToValidate="txtDataAquisicao" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px">
                                <label for="exemplo">Tipo de Aquisição *</label>
                                <asp:DropDownList runat="server" ID="ddlTipoAquisicao" CssClass="form-control">
                                    <asp:ListItem>Compra</asp:ListItem>
                                    <asp:ListItem>Doação</asp:ListItem>
                                    <asp:ListItem>Emprestado</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px">
                                <label for="exemplo">Tipo de Comprovante</label>
                                <asp:DropDownList runat="server" ID="ddlTipoComprovante" CssClass="form-control">
                                    <asp:ListItem>Nota Fiscal</asp:ListItem>
                                    <asp:ListItem>Cupom Fiscal</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group m-1" style="padding-right: 0px; padding-left: 0px; width: 269px">
                                <label for="text">Nº do Comprovante</label>
                                <asp:TextBox runat="server" ID="txtNumeroComprovante" CssClass="form-control col-12 shadow p-3 bg-light"></asp:TextBox>
                                <div id="avisoNumeroComprovante" class="invalid-feedback">Favor inserir apenas numero</div>
                           </div>
                        </div>
                        <div class="d-flex rounded justify-content-center mb-2">
                            <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                                <label for="exemplo">Usa Combustível?</label>
                                <asp:DropDownList runat="server" ID="ddlCombustivel" CssClass="form-control">
                                    <asp:ListItem Text="1">Sim</asp:ListItem>
                                    <asp:ListItem Text="0">Não</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                                <label for="text">Placa do Veículo</label>
                                <asp:TextBox runat="server" ID="txtPlacaVeiculo" CssClass="form-control col-12 shadow p-3 bg-light"></asp:TextBox>
                                <div id="avisoPlacaVeiculo" class="invalid-feedback">Favor inserir apenas numero e letras</div>
                            </div>
                            <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                                <label for="text">Modelo do Veículo</label>
                                <asp:TextBox runat="server" ID="txtModeloVeiculo" CssClass="form-control col-12 shadow p-3 bg-light"></asp:TextBox>
                                <div id="avisoModeloVeiculo" class="invalid-feedback">Favor inserir apenas numero e letras</div>
                            </div>
                            <div class="form-group m-1" style="padding-right: 8px; padding-left: 0px; width: 453px">
                                <label for="text">Localização Física</label>
                                <asp:TextBox runat="server" ID="txtLocalizacaoFisica" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                <div id="avisoLocalizacao" class="invalid-feedback">Favor inserir um caracter válido</div>
                            </div>
                        </div>
                        <div class="d-flex rounded justify-content-center mb-2">
                            <div class="form-group m-1" style="padding-right: 0px; padding-left: 0px; width: 530px">
                                <label for="teste">Observação</label>
                                <asp:TextBox runat="server" ID="txtObservacao" TextMode="MultiLine" Rows="1" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                            </div>
                            <div class="form-group m-1" style="padding-right: 8px; padding-left: 0px; width: 500px">
                                <label for="text">Responsável *</label>
                                <asp:TextBox runat="server" ID="txtResponsável" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                <div id="" class="invalid-feedback">Favor inserir apenas letras</div>
                            </div>
                        </div>
                        <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px">
                            <label for="text">Código *</label>
                            <asp:TextBox runat="server" ID="txtCodigoDoItem" CssClass="form-control shadow p-3 bg-light"></asp:TextBox>
                            <div id="avisoCodigo" class="invalid-feedback">Favor inserir um caracter válido</div>
                            <asp:RequiredFieldValidator ID="rfvCodigoDoItem" runat="server" ControlToValidate="txtCodigoDoItem" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="tab-pane fade d-flex rounded justify-content-center mt-5" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                        <div class="form-group m-1" style="padding-right: 0px; padding-left: 0px">

                            <div class="d-flex justify-content-center">
                                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
                                    <label for="text">Valor de Aquisição *</label>
                                    <asp:TextBox runat="server" ID="txtValorAquisicao" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                    <div id="avisoValor" class="invalid-feedback">Favor inserir um valor (R$)</div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDataAquisicao" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
                                    <label for="text">Vida Útil</label>
                                    <asp:TextBox runat="server" ID="txtVidaUtil" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                    <div id="avisoVidaUtil" class="invalid-feedback">Favor inserir Apenas numeros</div>
                                </div>
                                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
                                    <label for="text">Depreciação Anual *</label>
                                    <asp:TextBox runat="server" ID="txtDepreciacaoAnual" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                    <div id="avisoDepreciacaoAnual" class="invalid-feedback">Favor inserir um valor (R$)</div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDepreciacaoAnual" ErrorMessage="Este campo é obrigatório" CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group m-1 col-4" style="padding-right: 0px; padding-left: 0px;">
                                    <label for="exemplo">Método de Depreciação *</label>
                                    <asp:DropDownList runat="server" ID="ddlMetodoDepreciacao" CssClass="form-control col-12">
                                        <asp:ListItem>Método Linear ou Cotas Constantes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="d-flex justify-content-center">
                                <div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px;">
                                    <label for="text">Valor residual</label>
                                    <asp:TextBox runat="server" ID="txtValorResidual" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                    <div id="avisoValorResidual" class="invalid-feedback">Favor inserir um valor (R$)</div>
                                </div>
                                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
                                    <label for="text">Valor depreciável</label>
                                    <asp:TextBox runat="server" ID="txtValorDepreciavel" CssClass="form-control shadow p-3 bg-light col-12" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px;">
                                    <label for="text">Valor depreciado</label>
                                    <asp:TextBox runat="server" ID="txtValorDepreciado" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                </div>
                                <div class="form-group m-1 col-2" style="padding-right: 0px; padding-left: 0px;">
                                    <label for="text">Ínicio da depreciação *</label>
                                    <asp:TextBox runat="server" ID="txtDataDepreciacao" TextMode="Date" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                </div>
                            </div>
                            <div class="d-flex justify-content-center">
                                <div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px;">
                                    <label for="text">Saldo a depreciar</label>
                                    <asp:TextBox runat="server" ID="txtSaldoDepreciar" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                </div>
                                <div class="form-group m-1 col-3" style="padding-right: 0px; padding-left: 0px; width: 408px">
                                    <label for="text">Valor líquido</label>
                                    <asp:TextBox runat="server" ID="txtValorLiquido" CssClass="form-control shadow p-3 bg-light col-12"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>--%>
