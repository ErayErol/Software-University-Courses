function solve(arr) {
    let n = Number(arr.pop());

    for (let i = 0; i < arr.length; i += n) {
        console.log(arr[i]);
    }
}

solve(['5',
    '20',
    '31',
    '4',
    '20',
    '2']
);

solve(['dsa',
    'asd',
    'test',
    'tset',
    '2']
);

solve(['1',
    '2',
    '3',
    '4',
    '5',
    '6']
);