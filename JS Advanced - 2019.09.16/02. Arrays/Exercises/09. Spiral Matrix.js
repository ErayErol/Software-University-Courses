function solve(row, col) {
    let matrix = new Array(row).fill().map(() => new Array(col).fill(0)); // create empty n x n array

    let counter = 1;
    let startCol = 0;
    let endCol = col - 1;
    let startRow = 0;
    let endRow = row - 1;

    while (startCol <= endCol && startRow <= endRow) {
        for (let i = startCol; i <= endCol; i++) {
            matrix[startRow][i] = counter++;
        }

        startRow++;
        for (let j = startRow; j <= endRow; j++) {
            matrix[j][endCol] = counter++;
        }

        endCol--;
        for (let i = endCol; i >= startCol; i--){
            matrix[endRow][i] = counter++;
        }

        endRow--;
        for (let j = endRow; j >= startRow; j--){
            matrix[j][startCol] = counter++;
        }

        startCol++;
    }

    matrix.forEach(row => console.log(row.join(' ')));
}

solve(5, 5);

solve(3, 3);