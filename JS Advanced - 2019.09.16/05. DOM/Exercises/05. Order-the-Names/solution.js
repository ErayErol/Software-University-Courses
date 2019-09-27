function solve() {
    let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', order);

    function order() {
        let input = document.getElementsByTagName('input')[0];
        let inputValue = document.getElementsByTagName('input')[0].value;

        let firstLetter = inputValue[0].toLocaleUpperCase();
        let name = firstLetter + inputValue.toLowerCase().substr(1);

        let charCode = firstLetter[0].charCodeAt(0);
        let row = document.getElementsByTagName('li')[charCode - 65];

        row.textContent.length === 0
            ? row.textContent = name
            : row.textContent += `, ${name}`;

        input.value = '';
    }
}