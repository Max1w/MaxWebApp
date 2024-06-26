document.getElementById('toggle-dark-mode').addEventListener('click', function (event) {
    event.preventDefault(); // Impede o postback
    document.body.classList.toggle('dark-mode');
    localStorage.setItem('dark-mode', document.body.classList.contains('dark-mode'));
});

// Verifica a preferência salva do usuário
if (localStorage.getItem('dark-mode') === 'true') {
    document.body.classList.add('dark-mode');
}