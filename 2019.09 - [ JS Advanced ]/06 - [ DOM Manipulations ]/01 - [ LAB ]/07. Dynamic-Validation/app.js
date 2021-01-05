function validate() {
    let email = document.getElementById('email');
    let regex = /[a-z]+@[a-z]+.[a-z]+/;

    email.addEventListener('change', (event) => {
        if (email.value.match(regex)) {
            event.target.className = '';
        }else {
            event.target.className = 'error';
        }
    });
}