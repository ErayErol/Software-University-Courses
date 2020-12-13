function arrayMap(arr, func) {
    let res = [];
    for (let i = 0; i < arr.length; i++) {
        let e = arr[i];

        res.push(func(e));
    }

    return res;
}

let nums = [1, 2, 3, 4, 5];
console.log(arrayMap(nums, (item) => item * 2)); // [ 2, 4, 6, 8, 10 ]

let letters = ["a", "b", "c"];
console.log(arrayMap(letters, (l) => l.toLocaleUpperCase())); // [ 'A', 'B', 'C' ]