function NotificaçãoCadastroSucesso() {
    alert("olá");
    var alertBox = document.getElementById('notificacaoDeSucesso');
    alertBox.style.display = 'block';
    setTimeout(function () {
        alertBox.style.display = 'none';
    }, 5000);
}

function LimiteUltrapassadoDeCaracteres() {
    var alertBox = document.getElementById('limiteUltrapassadoDeCaracteres');
    alertBox.style.display = 'block';
    setTimeout(function () {
        alertBox.style.display = 'none';
    }, 5000);
}

function CadastroDuplicado() {
    var alertBox = document.getElementById('cadastroDuplicado');
    alertBox.style.display = 'block';
    setTimeout(function () {
        alertBox.style.display = 'none';
    }, 5000);
}

function NotificaçãoCampoInvalido() {
    var alertBox = document.getElementById('notificacaoDeCampoInvalido');
    alertBox.style.display = 'block';
    setTimeout(function () {
        alertBox.style.display = 'none';
    }, 5000);
}

function NotificaçãoCadastroCancelar() {
    var alertBox = document.getElementById('notificacaoDeCancelar');
    alertBox.style.display = 'block';
    setTimeout(function () {
        alertBox.style.display = 'none';
    }, 5000);
}