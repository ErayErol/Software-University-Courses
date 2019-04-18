function solve(n) {
    let number = +n; // let number = Number(n);

    for (let i = 1; i <= number; i++) {
        if (i % 2 === 0) {
            console.log(i);
        }
    }
}

solve(5);
solve(4);
solve(7);