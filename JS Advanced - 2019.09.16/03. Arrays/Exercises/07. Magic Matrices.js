function solve(matrix) {
    for (let row = 1; row < matrix.length - 1; row++) {
        let sum1 = matrix[row].reduce((a, b) => a + b, 0);
        let sum2 = matrix[row + 1].reduce((a, b) => a + b, 0);

        if (sum1 !== sum2) {
            console.log('false');
            return;
        }
    }

    function sum(a, b) {
        return a
        .map((v, i) => 
        v + (b[i] || 0));
    }

    let columsSum = matrix
    .reduce((a, b) => 
    a.length > b.length 
    ? sum(a, b) : sum(b, a));

    let result = columsSum
    .every((val, i, arr) => 
    val === arr[0]);

    console.log(result);
}

solve(
    [[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);

solve(
    [[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
);

solve(
    [[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
);