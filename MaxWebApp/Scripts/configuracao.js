document.addEventListener('DOMContentLoaded', function () {
    const corMode = document.getElementById('colormode');
    const body = document.getElementById('body');

    // Verificar se há uma preferência armazenada
    const themePreference = localStorage.getItem('themePreference');
    if (themePreference === 'dark') {
        body.classList.add('dark-mode');
        corMode.checked = true;
    } else {
        body.classList.add('white-mode');
    }

    // Adicionar evento de mudança para o switch de modo de cor
    corMode.addEventListener('change', () => {
        if (corMode.checked) {
            body.classList.remove('white-mode');
            body.classList.add('dark-mode');
            localStorage.setItem('themePreference', 'dark');
        } else {
            body.classList.remove('table-dark');
            localStorage.setItem('themePreference', 'light');
        }
    });
});
