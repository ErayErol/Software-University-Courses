function solve() {
    let inputArr = JSON.parse(document.getElementById('arr').value);

    inputArr.forEach((word, index, arr) => {
       arr[index] =  word.split('').reverse().join('');
    });

    let resultArr = inputArr.map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ');

    let resultElement = document.getElementById('result');
    resultElement.textContent = resultArr;
}