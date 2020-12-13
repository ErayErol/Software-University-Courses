function solve(matrix) {
    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;

    matrix = matrix.map(row => row.split(' '));

    for (let i = 0; i < matrix.length; i++) {
        leftDiagonalSum += Number(matrix[i][i]);
    }

    for (let i = matrix.length - 1, j = 0; i >= 0; i-- , j++) {
        rightDiagonalSum += Number(matrix[j][i]);
    }

    if (leftDiagonalSum === rightDiagonalSum) {
        for (let i = 0, k = matrix.length - 1; i < matrix.length; i++ , k--) {
            for (let j = 0; j < matrix[i].length; j++) {
                if (i !== j && k !== j) {
                    matrix[i][j] = leftDiagonalSum;
                }
            }
        }
    }

    matrix.forEach(row => console.log(row.join(' ')));
}

solve([
    '5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1'
]);

solve([
    '1 1 1',
    '1 1 1',
    '1 1 0'
]);