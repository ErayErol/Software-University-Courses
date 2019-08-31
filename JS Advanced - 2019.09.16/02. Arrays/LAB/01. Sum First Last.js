function solve(input) {
    let firstNumber = Number(input[0]);
    let lastNumber = Number(input[input.length - 1]);
    let sum = firstNumber + lastNumber;
    console.log(sum);
}

solve(['20', '30', '40']);

solve(['5']);