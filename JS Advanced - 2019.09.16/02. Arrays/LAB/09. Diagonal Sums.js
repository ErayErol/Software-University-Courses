function solve(matrix) {
    let sum1 = 0;
    let sum2 = 0;

    let indexForSum2 = matrix.length - 1;
    for (let row = 0; row < matrix.length; row++) {
        
        for (let col = 0; col < matrix[row].length; col++) {
            const element = matrix[row][col];
            
            if (row === col) {
                sum1 += element;
            }

            if (col === indexForSum2) {
                sum2+= element;
                indexForSum2--;
            }
        }
    }

    console.log(sum1 + ' ' + sum2);
}

solve([[20, 40],
       [10, 60]]);

solve([[3, 5, 17],
       [-1, 7, 14],
       [1, -8, 89]]);