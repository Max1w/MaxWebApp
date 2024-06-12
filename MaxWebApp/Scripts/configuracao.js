window.onload = function () {
	var darkModeCheckbox = document.getElementById('checkboxTheme');
	if (localStorage.getItem('DarkMode') === 'true') {
		document.body.classList.add('dark-mode');
		document.body.classList.remove('white-mode');
		darkModeCheckbox.checked = true;
	}
}

function toggleDarkMode() {
	var darkModeCheckbox = document.getElementById('checkboxTheme');
	if (darkModeCheckbox.checked) {
		localStorage.setItem('DarkMode', 'true');
		document.body.classList.add('dark-mode');
	} else {
		localStorage.setItem('DarkMode', 'false');
		document.body.classList.add('white-mode');
		document.body.classList.remove('dark-mode');
	}
}