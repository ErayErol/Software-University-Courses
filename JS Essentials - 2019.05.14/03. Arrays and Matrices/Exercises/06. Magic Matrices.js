function solve(matrix) {
    let sum = 0;

    for (let row = 0; row < matrix.length; row++) {
        let currSum = 0;

        for (let col = 0; col < matrix[row].length; col++) {
            currSum += matrix[row][col];
        }

        if (row === 0) {
            sum = currSum;
        }

        if (sum !== currSum) {
            console.log('false');
            return;
        }
    }

    console.log('true');
}

solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
);

solve([[1, 2, 6],
[6, 5, 4],
[5, 2, 1]]
);