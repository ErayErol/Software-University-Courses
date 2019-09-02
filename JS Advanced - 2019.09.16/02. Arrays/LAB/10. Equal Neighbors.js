function solve(matrix) {
    let equalNeighbors = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            const element = matrix[row][col];

            if (row < matrix.length - 1) {
                if (element === matrix[row + 1][col]) {
                    equalNeighbors++;
                }    
            }

            if (col < matrix[row].length - 1) {
                if (element === matrix[row][col + 1]) {
                    equalNeighbors++;                    
                }
            }
        }
    }

    console.log(equalNeighbors);
}

solve([['2', '3', '4', '7', '0'],
       ['4', '0', '5', '3', '4'],
       ['2', '3', '5', '4', '2'],
       ['9', '8', '7', '5', '4']]);

solve([['test', 'yes', 'yo', 'ho'],
       ['well', 'done', 'yo', '6'],
       ['not', 'done', 'yet', '5']]);