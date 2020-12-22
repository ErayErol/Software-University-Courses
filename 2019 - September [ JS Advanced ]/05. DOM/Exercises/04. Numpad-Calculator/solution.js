function solve() {
    let input = document.getElementById('expressionOutput');
    let output = document.getElementById('resultOutput');

    const operators = ['+', '-', '*', '/'];

    document.body.addEventListener('click', (e) => {
        const value = e.target.value;
        if (value === 'Clear') {
            clear();
        } else if (operators.includes(value)) {
            addOperator(value);
        } else if (value === '=') {
            result();
        } else {
            addNumber(value);
        }
    });

    function result() {
        let expField = input.textContent
            .split(' ')
            .filter(x => x !== '');

        expField.length === 3
            ? calculate(expField[0], expField[1], expField[2])
            : output.textContent = NaN;
    }

    function addNumber(value) {
        input.textContent += value;
    }

    function addOperator(value) {
        input.textContent += ` ${value} `;
    }

    function clear() {
        output.textContent = '';
        input.textContent = '';
    }

    function calculate(x, operator, y) {
        x = Number(x);
        y = Number(y);

        let operations = {
            '+': x + y,
            '-': x - y,
            '*': x * y,
            '/': x / y,
        };

        let sum = operations[operator];
        output.textContent = sum;
    }
}