function solve() {
    function calculate(x, operator, y) {
        let sum = 0;

        switch (operator) {
            case '+': sum = x + y; break;
            case '-': sum = x - y; break;
            case '*': sum = x * y; break;
            case '/': sum = x / y; break;
        }

        output.textContent = sum;
    }

    let input = document.getElementById('expressionOutput');
    let output = document.getElementById('resultOutput');
    let operator = ['+', '-', '*', '/'];

    document.body.addEventListener('click', (e) => {
        let value = e.target.value;

        if (value === 'Clear') {
            output.textContent = '';
            input.textContent = '';
        } else if (operator.includes(value)) {
            input.textContent += ` ${value} `;
        } else if (value === '=') {
            let splitInput = input.textContent.split(' ');

            if (splitInput.length === 3) {

                if (Number(splitInput[0] && Number(splitInput[2] && operator.includes(splitInput[1])))) {
                    let x = Number(splitInput[0]);
                    let operator = splitInput[1];
                    let y = Number(splitInput[2]);

                    calculate(x, operator, y);
                } else {
                    output.textContent = NaN;
                }
            } else {
                output.textContent = NaN;
            }
        } else {
            input.textContent += value;
        }
    });
}