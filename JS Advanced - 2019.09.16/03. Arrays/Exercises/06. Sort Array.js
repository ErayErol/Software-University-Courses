function solve(arr) {
    arr = arr
        .sort(function (a, b) {
            return a.length - b.length || a.localeCompare(b);
        })
        .forEach((x) => console.log(x));
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