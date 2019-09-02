function solve(arr) {
    let result = [];

    for (let i = 0; i < arr.length; i += 2) {
        result.push(arr[i]);
    }

    console.log(result.join(' '));
}

solve(['20', '30', '40']);

solve(['5', '10']);