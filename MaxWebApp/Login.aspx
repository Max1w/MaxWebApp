<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MaxWebApp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<head>

    <link rel="stylesheet" href="LoginEstilo.css" />

</head>

<body>

    <div class="wrapper">
        <form action="">
            <h1>Login</h1>
            <div class="input-box">
                <input type="text" placeholder="Usuário" />
            </div>
            <div class="input-box">
                <input type="password" placeholder="Senha" />
            </div>

            <div class="remember-forgot">
                <label><input type="checkbox"/>Lembra</
                label>
                <a href="#">Forgot password?</a>
            </div>

            <button type="submit" class="btn">Login</button>

            <div class="register-link">
                <p>Não possui conta? <a href="#">Register</a></p>
            </div>
        </form>
    </div>
</body>  
</asp:Content>
