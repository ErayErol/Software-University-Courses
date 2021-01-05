function solve(arr) {
    let rows = arr[0];
    let cols = arr[1];
    let x = arr[2];
    let y = arr[3];

    let matrix = new Array(rows).fill().map(() => new Array(cols).fill(0));
    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = Math.max(Math.abs(row - x), Math.abs(col - y)) + 1;
        }
    }

    matrix.forEach(row => console.log(row.join(' ')));
}

solve([4, 4, 0, 0]);

solve([5, 5, 2, 2]);

solve([3, 3, 2, 2]);