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

        campo.value = parseFloat(valor.replace(',', '.')).toLocaleString('pt-BR', {
            style: 'currency',
            currency: 'BRL'
        })
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
}