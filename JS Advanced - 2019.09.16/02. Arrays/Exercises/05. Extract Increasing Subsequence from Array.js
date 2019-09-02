function solve(arr) {
    let sequence = [arr[0]];

    for (let i = 1; i < arr.length; i++) {
        const element = arr[i];

        if (element > sequence[sequence.length - 1]) {
            sequence.push(element);
        }
    }

    console.log(sequence.join('\n'));
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