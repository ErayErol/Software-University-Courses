function lockedProfile() {
    let buttons = document.getElementsByTagName('button');

    Array.from(buttons).forEach((button) => {
        button.addEventListener('click', () => {
            let user = button.parentNode;
            let unlock = user.children[4];
            let hidden = user.children[9];

            if (unlock.checked && button.textContent === 'Show more') {
                hidden.style.display = 'block';
                button.textContent = 'Hide it';
            } else if (unlock.checked && button.textContent === 'Hide it') {
                hidden.style.display = 'none';
                button.textContent = 'Show more';
            }
        });
    });
}