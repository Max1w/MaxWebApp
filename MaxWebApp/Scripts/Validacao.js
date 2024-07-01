function removerEspacosExcesso(valor) {
    return valor.replace(/\s+/g, ' ').trim();
}

function ValidarCampoNumero(campo, aviso) {
    campo.addEventListener('keydown', function (event) {
        if ([8, 13, 46, 37, 39, 110, 190, 160, 161].indexOf(event.keyCode) !== -1 ||
            (event.keyCode === 65 && event.ctrlKey === true) ||
            (event.keyCode === 88 && event.ctrlKey === true) ||
            (event.keyCode === 86 && event.ctrlKey === true) ||
            (event.keyCode === 67 && event.ctrlKey === true) ||
            (event.keyCode >= 35 && event.keyCode <= 39)) {
            return;
        }
        // Só Números
        if (event.shiftKey ||
            (event.keyCode < 48 || event.keyCode > 57) &&
            (event.keyCode < 96 || event.keyCode > 105) &&
            event.ctrlKey === false && event.keyCode !== 20 &&
            event.keyCode !== 9) {

            event.preventDefault();
            aviso.style.display = 'block';
        } else {
            aviso.style.display = 'none';
        }
    });
    campo.addEventListener('input', function () {
        let valor = campo.value;

        valor = valor.replace(/[^0-9,]/g, '');

        campo.value = valor;
    });
    campo.addEventListener('blur', function () {
        campo.value = removerEspacosExcesso(campo.value);
    });
}

function ValidarCampoNumerico(campo, aviso) {
    campo.addEventListener('keydown', function (event) {
        if ([8, 13, 46, 37, 39, 110, 188, 190, 160, 161].indexOf(event.keyCode) !== -1 ||
            (event.keyCode === 65 && event.ctrlKey === true) ||
            (event.keyCode === 88 && event.ctrlKey === true) ||
            (event.keyCode === 86 && event.ctrlKey === true) ||
            (event.keyCode === 67 && event.ctrlKey === true) ||
            (event.keyCode >= 35 && event.keyCode <= 39)) {
            return;
        }

        if (event.shiftKey ||
            (event.keyCode < 48 || event.keyCode > 57) &&
            (event.keyCode < 96 || event.keyCode > 105) &&
            (event.keyCode !== 188 && event.keyCode !== 190) &&
            event.ctrlKey === false && event.keyCode !== 20 &&
            event.keyCode !== 9) {

            event.preventDefault();
            aviso.style.display = 'block';
        } else {
            aviso.style.display = 'none';
        }
    });

    campo.addEventListener('blur', function () {
        let valor = campo.value;

        let valorSemFormatacao = valor.replace(/[^0-9,]/g, '');

        campo.value = removerEspacosExcesso(valorSemFormatacao);
    });
}

function ValidarCampoDeTextoComNumeros(campo, aviso) {
    campo.addEventListener('keydown', function (event) {

        if ([8, 13, 46, 37, 39, 110, 190].indexOf(event.keyCode) !== -1 ||
            (event.keyCode === 65 && event.ctrlKey === true) ||
            (event.keyCode === 88 && event.ctrlKey === true) ||
            (event.keyCode === 86 && event.ctrlKey === true) ||
            (event.keyCode === 67 && event.ctrlKey === true) ||
            (event.keyCode >= 35 && event.keyCode <= 39)) {
            return;
        }

        if (event.key === '@' || event.key === '#' || event.key === '<' || event.key === '>') {
            event.preventDefault();
            aviso.style.display = 'block';
        } else {
            aviso.style.display = 'none';
        }
    });
    campo.addEventListener('input', function () {
        let valor = campo.value;

        valor = valor.replace(/[@#><]/g, '');

        campo.value = valor;
    });
    campo.addEventListener('blur', function () {
        campo.value = removerEspacosExcesso(campo.value);
    });
}

function ValidarCampoApenasNumeroELetras(campo, aviso) {
    campo.addEventListener('keydown', function (event) {
        if ([8, 13, 46, 37, 39, 110, 190].indexOf(event.keyCode) !== -1 ||
            (event.keyCode === 65 && event.ctrlKey === true) || // Ctrl+A
            (event.keyCode === 88 && event.ctrlKey === true) || // Ctrl+X
            (event.keyCode === 86 && event.ctrlKey === true) || // Ctrl+V
            (event.keyCode === 67 && event.ctrlKey === true) || // Ctrl+C
            (event.keyCode >= 35 && event.keyCode <= 39)) { // Home, End, setas
            return;
        }

        if (!(event.keyCode >= 48 && event.keyCode <= 57) &&  // números
            !(event.keyCode >= 65 && event.keyCode <= 90) &&  // letras maiúsculas
            !(event.keyCode >= 97 && event.keyCode <= 122) && event.keyCode !== 9 &&
            event.ctrlKey === false && !event.keyCode == 32) { // letras minúsculas
            event.preventDefault();
            aviso.style.display = 'block';
        } else {
            aviso.style.display = 'none';
        }
    });

    campo.addEventListener('input', function () {
        let valor = campo.value;
        valor = valor.replace(/[^a-zA-Z0-9 ]/g, '');
        campo.value = valor;
    });
    campo.addEventListener('blur', function () {
        campo.value = removerEspacosExcesso(campo.value);
    });
}

function ValidarCampoApenasLetras(campo, aviso) {
    campo.addEventListener('keydown', function (event) {
        if ([8, 13, 46, 37, 39, 110, 190].indexOf(event.keyCode) !== -1 ||
            (event.keyCode === 65 && event.ctrlKey === true) || // Ctrl+A
            (event.keyCode === 88 && event.ctrlKey === true) || // Ctrl+X
            (event.keyCode === 86 && event.ctrlKey === true) || // Ctrl+V
            (event.keyCode === 67 && event.ctrlKey === true) || // Ctrl+C
            (event.keyCode >= 35 && event.keyCode <= 39)) { // Home, End, setas
            return;
        }

        if (!(event.keyCode >= 65 && event.keyCode <= 90) &&  // letras maiúsculas
            !(event.keyCode >= 97 && event.keyCode <= 122) && event.keyCode !== 9 &&
            event.ctrlKey === false && !event.keyCode == 32) { // letras minúsculas
            event.preventDefault();
            aviso.style.display = 'block';
        } else {
            aviso.style.display = 'none';
        }
    });

    campo.addEventListener('input', function () {
        let valor = campo.value;
        valor = valor.replace(/[^a-zA-Z ]/g, '');
        campo.value = valor;
    });
    campo.addEventListener('blur', function () {
        campo.value = removerEspacosExcesso(campo.value);
    });
}
