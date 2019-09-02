function solve(arr) {
    arr = arr
        .sort(function (a, b) {
            return a > b;
        })
        .sort(function (a, b) {
            return a.length - b.length;
        });

    console.log(arr.join('\n'));
}

solve(['alpha',
    'beta',
    'gamma']
);

solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
);

solve(['test',
    'Deny',
    'omen',
    'Default']
);