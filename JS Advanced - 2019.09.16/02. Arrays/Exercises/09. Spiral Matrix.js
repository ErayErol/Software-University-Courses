function solve(row, col) {
    let result = new Array(row).fill().map(() => new Array(row).fill(0)); // create empty n x n array
    let counter = 1;
    let startCol = 0;
    let endCol = row - 1;
    let startRow = 0;
    let endRow = row - 1;

    while (startCol <= endCol && startRow <= endRow) {
        for (let i = startCol; i <= endCol; i++) {
            result[startRow][i] = counter;
            counter++;
        }

        startRow++;
        for (let j = startRow; j <= endRow; j++) {
            result[j][endCol] = counter;
            counter++;
        }

        endCol--;
        for (let i = endCol; i >= startCol; i--) {
            result[endRow][i] = counter;
            counter++;
        }

        endRow--;
        for (let i = endRow; i >= startRow; i--) {
            result[i][startCol] = counter;
            counter++;
        }

        startCol++;
    }

    for (let row of result) {
        console.log(row.join(' '));
    }

    // result.forEach(row => console.log(row.join(' ')));
}

solve(5, 5);

solve(3, 3);