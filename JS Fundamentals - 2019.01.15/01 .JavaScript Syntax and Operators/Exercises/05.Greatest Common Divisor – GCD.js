function solve(num1, num2) {

    let number1 = +num1;
    let number2 = +num2;

    while (number1 > 0 && number2 > 0) {
        if (number1 > number2) {
            number1 %= number2;
        }
        else {
            number2 %= number1;
        }
    }

    console.log(Math.max(number1, number2));
}

solve(6, 18);