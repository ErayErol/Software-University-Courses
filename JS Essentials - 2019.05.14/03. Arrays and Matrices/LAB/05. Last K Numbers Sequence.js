function solve(length, k) {
    let sequence = [1];

    while (length > 1) {
        let total = 0;
        let count = 0;
        for (let i = sequence.length - 1; i >= 0; i--) {
            if (count === k) {
                break;
            }
            count++;

            let currNum = sequence[i];
            if (currNum !== undefined) {
                total += Number(currNum);
            }
        }
        sequence.push(total);
        length--;
    }

    console.log(sequence.join(' '));
}

solve(6, 3);
solve(8, 2);