let operators = ['+', '-', '*', '/', '%', '**'];

let operation = {
    '+': (x, y) => x + y,
    '-': (x, y) => x - y,
    '*': (x, y) => x * y,
    '/': (x, y) => x / y,
    '%': (x, y) => x % y,
    '**': (x, y) => x ** y,
};

let mathOperations = (operator, ...numbers) => {
    if (!operators.includes(operator)) {
        return "Try again with operator.";
    }

    let reducer = (accumulator, currentValue) => operation[operator](accumulator, currentValue);
    let initialValue = Number(numbers.shift()); 
    let sum = numbers.reduce(reducer, initialValue);
    return sum;
};

let result = mathOperations('+', 5, 6, 8, 9);
console.log(result);

let result2 = mathOperations('*', 3, 5.5);
console.log(result2);