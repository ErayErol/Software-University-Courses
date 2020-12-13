function solve(matrix) {
    let biggestNum = (Number.MIN_SAFE_INTEGER);

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            const num = matrix[row][col];

            if (num > biggestNum) {
                biggestNum = num;
            }
        }
    }

    console.log(biggestNum);
}

solve([[20, 50, 10],
       [8, 33, 145]]);

solve([[3, 5, 7, 12],
       [-1, 4, 33, 2],
       [8, 3, 0, 4]]);