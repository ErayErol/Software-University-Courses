function solve(jaggedArr) {
    let pairs = 0;

    for (let row = 0; row < jaggedArr.length - 1; row++) {
        for (let col = 0; col < jaggedArr[row].length; col++) {
            if (jaggedArr[row][col] === jaggedArr[row + 1][col]) {
                pairs++;

                if (jaggedArr[row][col] === jaggedArr[row][col + 1]) {
                    pairs++;
                }
            } else if (jaggedArr[row][col] === jaggedArr[row][col + 1]) {
                pairs++;

                if (jaggedArr[row][col] === jaggedArr[row + 1][col]) {
                    pairs++;
                }
            }
        }
    }

    let lastRow = jaggedArr.length - 1;
    if (lastRow >= 0) {
        for (let row = lastRow; row < jaggedArr.length; row++) {
            for (let col = 0; col < jaggedArr[row].length; col++) {
                if (jaggedArr[row][col] === jaggedArr[row][col + 1]) {
                    pairs++;
                }
            }
        }
    }

    console.log(pairs);
}

solve(
    [['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
);

solve(
    [['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]
);

solve(
    [[2, 2, 5, 7, 4],
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]]
);

solve([
    [1, 1],
    [1, 1]]
);