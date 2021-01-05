function solve(arr) {
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        const command = arr[i];
        
        if (command === 'add') {
            result.push(i + 1);
        } else if (command === 'remove') {
            result.pop();
        }
    }

    if (result.length === 0) {
        console.log('Empty');
    } else {
        console.log(result.join('\n'));
    }
}

solve(['add',
    'add',
    'add',
    'add']
);

solve(['add',
    'add',
    'remove',
    'add',
    'add']
);

solve(['remove',
    'remove',
    'remove']
);