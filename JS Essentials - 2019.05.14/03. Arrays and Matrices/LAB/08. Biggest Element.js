function solve(jaggedArr) {
    let maxRow = jaggedArr.map(function (row) {
        return Math.max.apply(Math, row);
    });

    let max = Math.max.apply(null, maxRow);
    console.log(max);
}

solve([[20, 50, 10],
[8, 33, 145]]
);

solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
);