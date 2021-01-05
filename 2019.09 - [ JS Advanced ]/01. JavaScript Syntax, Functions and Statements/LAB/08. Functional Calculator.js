function solve(num1, num2, operator) {
    let calc = (num1, num2, operator) => operator(num1, num2);
    
    let add = (num1, num2) => num1 + num2;
    let sub = (num1, num2) => num1 - num2;
    let mult = (num1, num2) => num1 * num2;
    let div = (num1, num2) => num1 / num2;

    switch (operator) {
        case '+': return calc(num1, num2, add);
        case '-': return calc(num1, num2, sub);
        case '*': return calc(num1, num2, mult);
        case '/': return calc(num1, num2, div);
        default: console.log('error'); break;
    }
}

solve(2, 4, '+');