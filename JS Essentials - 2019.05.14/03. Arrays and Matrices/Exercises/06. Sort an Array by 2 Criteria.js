function solve(arr) {
    for (let i = 0; i < arr.length - 1; i++) {
        let element = arr[i];
        let element2 = arr[i + 1];

        if (element.length > element2.length) {
            arr[i] = element2;
            arr[i + 1] = element;
            i = -1;
        }
        
    }
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