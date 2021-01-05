function solve(num1, num2) {
    let arr = [num1, num2];
    let firstMin = Math.min(...arr);
    let min = Math.min(...arr) + 1;
    let max = Math.max(...arr);
    
    while (min-- > 0) {
        if (max % min === 0) {
            if (firstMin % min === 0) {
                console.log(min);
                return;
            }
        }
    }
}

solve(15, 5);

solve(2154, 458);