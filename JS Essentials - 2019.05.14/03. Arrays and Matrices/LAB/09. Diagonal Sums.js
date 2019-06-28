function solve(jaggedArr) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    let colForSecondDiagonal = jaggedArr.length - 1;

    for (let row = 0; row < jaggedArr.length; row++) {
        for (let col = 0; col < jaggedArr[row].length; col++) {
            if (row === col) {
                firstDiagonal += jaggedArr[row][col];
            }

            if (colForSecondDiagonal === col) {
                secondDiagonal += jaggedArr[row][col];
                colForSecondDiagonal--;
            }
        }
    }

    console.log(firstDiagonal + ' ' + secondDiagonal);
}

solve([[20, 40],
[10, 60]]
);

solve([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]
);