function solve(matrix) {
    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        leftDiagonalSum += Number(matrix[i][i]);
    }

    for (let i = matrix.length - 1, j = 0; i >= 0; i-- , j++) {
        rightDiagonalSum += Number(matrix[j][i]);
    }

    console.log(`${leftDiagonalSum} ${rightDiagonalSum}`);
}

solve([[20, 40],
       [10, 60]]);

solve([[3, 5, 17],
       [-1, 7, 14],
       [1, -8, 89]]);