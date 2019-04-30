function register() {
    let username = document.getElementById('username').value;
    let email = document.getElementById('email').value;
    let password = document.getElementById('password').value;

    let pattern = /(.+)@(.+).(com|bg)/gm;
    let validEmail = pattern.exec(email);

    if (username && password && validEmail) {
        let registrationElement = document.createElement('h1');
        registrationElement.textContent = 'Successful Registration!';

        let newLine = document.createElement('br');
        let secondNewLine = document.createElement('br');
        let sectionElement = document.getElementById('result');
        sectionElement.appendChild(registrationElement);
        sectionElement.innerHTML += `Username: ${username}`;
        sectionElement.appendChild(newLine);
        sectionElement.innerHTML += `Email: ${email}`;
        sectionElement.appendChild(secondNewLine);
        sectionElement.innerHTML += `Password: ${'*'.repeat(password.length)}`;

        setTimeout(() => {
            sectionElement.innerHTML = '';
        }, 5000);
    }
}