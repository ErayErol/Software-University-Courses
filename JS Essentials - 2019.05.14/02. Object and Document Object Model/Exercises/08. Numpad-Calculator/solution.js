function solve() {
    function clearFields() {
        expressionOutput.textContent = '';
        resultOutput.textContent = '';
    }

    function showValue() {
        if (this.value === '/' || this.value === '-' || this.value === '*' || this.value === '+') {
            expressionOutput.textContent += ` ${this.value} `;
        } else {
            expressionOutput.textContent += this.value;
        }
    }

    function showResult() {
        let pattern = /^(\d+(.\d+)?) (\+|-|\*|\/) (\d+(.\d+)?)$/;
        let match = pattern.exec(expressionOutput.textContent);

        if (match) {
            let leftOperand = +match[1];
            let operator = match[3];
            let rightOperand = +match[4];
            let result;

            switch (operator) {
                case '+':
                    result = leftOperand + rightOperand;
                    break;

                case '-':
                    result = leftOperand - rightOperand;
                    break;

                case '*':
                    result = leftOperand * rightOperand;
                    break;

                case '/':
                    result = leftOperand / rightOperand;
                    break;
            }

            resultOutput.textContent = result;
        } else {
            resultOutput.textContent = 'NaN';
        }
    }

    let expressionOutput = document.getElementById('expressionOutput');
    let resultOutput = document.getElementById('resultOutput');

    let buttons = document.getElementsByTagName('button');
    buttons[0].addEventListener('click', clearFields);

    for (let i = 1; i < buttons.length; i++) {
        if (i === 15) {
            buttons[i].addEventListener('click', showResult)
        } else {
            buttons[i].addEventListener('click', showValue);
        }
    }
}