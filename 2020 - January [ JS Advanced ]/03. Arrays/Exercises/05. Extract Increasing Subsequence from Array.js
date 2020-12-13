function solve(numbers) {
    let lastNumber = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < numbers.length; i++) {
        if (numbers[i] >= lastNumber) {
            lastNumber = numbers[i];
            console.log(lastNumber);
        }
    }
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
);

solve([1,
    2,
    3,
    4]
);

solve([20,
    3,
    2,
    15,
    6,
    1]
);