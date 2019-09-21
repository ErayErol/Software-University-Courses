function solve() {
    let menuFrom = document.querySelectorAll('#selectMenuFrom option')[0];

    let binary = menuFrom.cloneNode(true);
    binary.value = 'binary';
    binary.textContent = 'Binary';

    let hexadecimal = menuFrom.cloneNode(true);
    hexadecimal.value = 'hexadecimal';
    hexadecimal.textContent = 'Hexadecimal';

    let menuTo = document.getElementById('selectMenuTo');
    menuTo.add(binary);
    menuTo.add(hexadecimal);

    let input = document.getElementById('input');
    let result = document.getElementById('result');
    document.querySelector('button').addEventListener('click', () => {
        let convertBinary = (Number(input.value)).toString(2);
        let convertHexadecimal = (Number(input.value)).toString(16);

        if (menuTo.value === 'binary') {
            result.value = convertBinary;
        } else if (menuTo.value === 'hexadecimal') {
            result.value = convertHexadecimal.toLocaleUpperCase();
        }
    });
}