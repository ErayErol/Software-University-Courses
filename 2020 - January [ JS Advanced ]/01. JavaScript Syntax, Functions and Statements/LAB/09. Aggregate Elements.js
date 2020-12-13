function solve(elements) {
    let sum = elements.reduce((a, b) => a + b);
    let inverseValues = elements.reduce((a, b) => a + (1 / b), 0);
    let join = elements.reduce((a, b) => `${a}${b}`, '');

    console.log(sum);
    console.log(inverseValues);
    console.log(join);
}

solve([1, 2, 3]);

solve([2, 4, 8, 16]);