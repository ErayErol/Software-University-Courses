function solve(arr) {
    let min1 = Math.min.apply(Math, arr);

    let index = arr.indexOf(min1);
    arr.splice(index, 1);

    let min2 = Math.min.apply(Math, arr);

    console.log(min1 + ' ' + min2);
}

solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);