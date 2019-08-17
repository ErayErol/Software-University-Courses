function solve(arr) {
    let rotation = arr.pop();

    for (let i = 0; i < rotation % arr.length; i++) {
        let element = arr.pop();
        
        arr.unshift(element);
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