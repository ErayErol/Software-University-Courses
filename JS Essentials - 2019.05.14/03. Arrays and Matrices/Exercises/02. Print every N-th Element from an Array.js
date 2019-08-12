function solve(arr) {
    let step = Number(arr.pop());

    for (let i = 0; i < arr.length; i+=step) {
        let element = arr[i];
        console.log(element);
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