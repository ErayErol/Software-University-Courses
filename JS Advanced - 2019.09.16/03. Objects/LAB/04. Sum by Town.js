function solve(input) {
    let obj = {};
    for (let i = 0; i < input.length; i += 2) {
        const key = input[i];
        const value = Number(input[i + 1]);

        if (obj.hasOwnProperty(key)) {
            obj[key] += value;
        } else {
            obj[key] = value;
        }
    }

    let result = JSON.stringify(obj);
    console.log(result);
}

solve(['Sofia',
    '20',
    'Varna',
    '3',
    'Sofia',
    '5',
    'Varna',
    '4']
);

solve(['Sofia',
'20',
'Varna',
'3',
'sofia',
'5',
'varna',
'4']
);