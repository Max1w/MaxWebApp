<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="MaxWebApp.teste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .input-group {
            position: relative;
        }

        .input {
            border: solid 1.5px #9e9e9e;
            border-radius: 1rem;
            background: none;
            padding: 1rem;
            font-size: 1rem;
            color: #f5f5f5;
            transition: border 150ms cubic-bezier(0.4,0,0.2,1);
        }

        .user-label {
            position: absolute;
            left: 15px;
            color: #e8e8e8;
            pointer-events: none;
            transform: translateY(1rem);
            transition: 150ms cubic-bezier(0.4,0,0.2,1);
        }

        .input:focus, .input:valid {
            outline: none;
            border: 1.5px solid #1a73e8;
        }

        .input:focus ~ .user-label, .input:valid ~ .user-label {
            transform: translateY(-50%) scale(0.8);
            background-color: #212121;
            padding: 0 .2em;
            color: #2196f3;
        }
    </style>

    <div class="form-group m-1 col-2 input-group" style="padding-right: 0px; padding-left: 0px">
        <asp:TextBox runat="server" ID="txtCodigoDoItem" CssClass="input" required="required" autocomplete="off"></asp:TextBox>
        <label class="user-label" for="txtCodigoDoItem">Código *</label>
    </div>
</asp:Content>
