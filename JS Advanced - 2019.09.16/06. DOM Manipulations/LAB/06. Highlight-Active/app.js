function focus() {
    let inputFields = document.getElementsByTagName('input');

    Array.from(inputFields).forEach((input) => {
        input.addEventListener('focus', focusEvent);
        input.addEventListener('blur', blurEvent);
    });

    function focusEvent() {
        this.parentNode.className = 'focused';
    }

    function blurEvent() {
        this.parentNode.classList.remove('focused');
    }
}