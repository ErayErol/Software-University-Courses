function solve(arr) {
    let result = [];
    arr = arr.map((element, index) => {
        if (index % 2 === 1) {
            let doubled = element * 2;
            result.push(doubled);
        }
    });

    let reversed = result.reverse();
    console.log(reversed);
}

solve([10, 15, 20, 25]);
solve([3, 0, 10, 4, 7, 3]);