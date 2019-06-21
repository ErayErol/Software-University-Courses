function solve() {
    let buttonElement = document.getElementsByTagName('button')[0];
    buttonElement.addEventListener('click', addToList);

    function addToList() {
        let input = document.getElementsByTagName('input')[0].value.toLowerCase();
        let name = input[0].toUpperCase() + input.slice(1);

        let charCode = name.charCodeAt(0);
        let row = document.getElementsByTagName('li')[charCode - 65];

        let names = row.textContent.split(', ').filter(n => n);
        names.push(name);
        row.textContent = names.join(', ');

        document.getElementsByTagName('input')[0].value = '';
    }
}