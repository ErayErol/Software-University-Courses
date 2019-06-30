function solve(arr) {
    let delimiter = arr.splice(arr.length - 1, 2);

    console.log(arr.join(delimiter));
}

solve(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']
);

solve(['How about no?',
    'I',
    'will',
    'not',
    'do',
    'it!',
    '_']
);