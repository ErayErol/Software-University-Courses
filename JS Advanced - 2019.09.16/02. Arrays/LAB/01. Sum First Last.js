function solve(arr) {
    let sum = 0;
    let last = 0;
    let first = Number(arr.shift());

    if (arr.length === 0) {
        sum = first + first;
    } else {
        last = Number(arr.pop());
        sum = first + last;
    }

    console.log(sum);
}

solve(['20', '30', '40']);

solve(['5']);