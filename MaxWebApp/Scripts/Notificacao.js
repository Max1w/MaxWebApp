function exibirNotificacao(alertId) {
    var alertBox = document.getElementById(alertId);
    alertBox.style.display = 'block';
    setTimeout(function () {
        alertBox.style.display = 'none';
    }, 3000);
}

function NotificacaoCadastroSucesso() {
    exibirNotificacao('notificacaoDeSucesso');
}

function NotificacaoSaida() {
    exibirNotificacao('notificacaoDeSaida');
}

function LimiteUltrapassadoDeCaracteres() {
    exibirNotificacao('limiteUltrapassadoDeCaracteres');
}

function CadastroDuplicado() {
    exibirNotificacao('cadastroDuplicado');
}

function NotificacaoCampoInvalido() {
    exibirNotificacao('notificacaoDeCampoInvalido');
}

function NotificacaoCadastroCancelar() {
    exibirNotificacao('notificacaoDeCancelar');
}
