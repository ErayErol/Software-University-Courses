function solve(num1, num2, operation) {

    let result;

    switch (operation) {
        case "+": return num1 + num2;
        case "-": return num1 - num2;
        case "*": return num1 * num2;
        case "/": return num1 / num2;
        case "%": return num1 % num2;
        case "**": return num1 ** num2;
    }

    console.log(result);
}

solve(2, 4, "+");