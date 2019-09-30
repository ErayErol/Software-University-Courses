function subtract() {
    let x = Number(document.getElementById('firstNumber').value);
    let y = Number(document.getElementById('secondNumber').value);
    let result = document.getElementById('result');
    result.textContent = x - y;
}