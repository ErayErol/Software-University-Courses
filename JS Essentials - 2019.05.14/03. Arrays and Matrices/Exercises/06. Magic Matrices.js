function solve(matrix) {
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            
            console.log(matrix[row][col]);
        }
    }
}

solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
);