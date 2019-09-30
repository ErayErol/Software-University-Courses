function focus() {
    let inputFields = document.getElementsByTagName('input');

    [...inputFields].forEach((input) => {
        input.addEventListener('focus', focusEvent);
        input.addEventListener('blur', blurEvent);
    });

    function focusEvent() {
        this.parentNode.classList.add('focused');
    }

    function blurEvent() {
        this.parentNode.classList.remove('focused');
    }
}