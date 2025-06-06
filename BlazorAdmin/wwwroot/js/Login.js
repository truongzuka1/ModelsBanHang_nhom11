window.LoginFrom = () => {
    const loginEmail = document.getElementById('loginEmail');
    const rememberMe = document.getElementById('rememberMe');
    const rememberedEmail = localStorage.getItem('rememberedEmail');

    if (rememberedEmail && loginEmail) {
        loginEmail.value = rememberedEmail;
        rememberMe.checked = true;
    }

    document.addEventListener('DOMContentLoaded', () => {
        const loginForm = document.getElementById('loginForm');
        const loginEmail = document.getElementById('loginEmail');
        const loginPassword = document.getElementById('loginPassword');
        const rememberMe = document.getElementById('rememberMe');

        const rememberedEmail = localStorage.getItem('rememberedEmail');
        if (rememberedEmail && loginEmail && rememberMe) {
            loginEmail.value = rememberedEmail;
            rememberMe.checked = true;
        }

        function showError(input, message) {
            input.style.borderColor = 'red';
            clearError(input);
            const error = document.createElement('div');
            error.classList.add('error-msg');
            error.style.color = 'red';
            error.style.fontSize = '12px';
            error.textContent = message;
            input.parentNode.insertBefore(error, input.nextSibling);
        }

        function clearError(input) {
            if (input.nextElementSibling && input.nextElementSibling.classList.contains('error-msg')) {
                input.nextElementSibling.remove();
            }
            input.style.borderColor = '#aaa';
        }

        if (loginForm) {
            loginForm.addEventListener('submit', function (e) {
                e.preventDefault();
                let valid = true;

                clearError(loginEmail);
                clearError(loginPassword);

                if (!loginEmail.value.includes("@")) {
                    showError(loginEmail, "Enter a valid email.");
                    valid = false;
                }

                if (loginPassword.value.length < 6) {
                    showError(loginPassword, "Password must be at least 6 characters.");
                    valid = false;
                }

                if (valid) {
                    if (rememberMe.checked) {
                        localStorage.setItem('rememberedEmail', loginEmail.value);
                    } else {
                        localStorage.removeItem('rememberedEmail');
                    }

                    loginForm.style.display = 'none';
                    const success = document.createElement('div');
                    success.className = 'success-message';
                    success.innerHTML = '✅ Login Successful!';
                    document.querySelector('.signup-container')?.appendChild(success);
                } else {
                    loginForm.classList.add('shake');
                    setTimeout(() => loginForm.classList.remove('shake'), 300);
                }
            });
        }
    });
};

