function solve(arr) {
    let result = [];
    
    if (arr.length > 0) {
        result.push(arr[0]);
    }

    for (let i = 1; i < arr.length; i++) {
        let currNum = Number(arr[i]);

        let currBiggestNum = result[result.length - 1];

        if (currNum >= currBiggestNum) {
            result.push(currNum);
        }
    }

    console.log(result.join('\n'));
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