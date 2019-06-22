function solve() {
    let addBtn = document.getElementsByTagName('button')[0];
    addBtn.addEventListener('click', clickEvent);
    
    function clickEvent() {
        let input = document.getElementsByTagName('input')[0];
        let inputValue = input.value;
        let name = inputValue[0].toUpperCase() + inputValue.slice(1).toLowerCase();

        let charCode = name.charCodeAt(0);
        let row = document.getElementsByTagName('li')[charCode - 65];

        let names = row.textContent.split(', ').filter(n => n);
        names.push(name);
        row.textContent = names.join(', ');

        input.value = '';
    }
}