function solve(arr) {
    let amountOfRotation = arr.pop();

    for (let i = 0; i < amountOfRotation % arr.length; i++) {
        let lastElement = arr.pop();
        arr.unshift(lastElement);
    }

    console.log(arr.join(' '));
}

solve(['1',
    '2',
    '3',
    '4',
    '2']
);

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']
);