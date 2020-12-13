function solve(n, k) {
    let sequence = [1];
    let lastKNumbers = new Array(k).fill(0);

    for (let i = 0; i < n - 1; i++) {
        for (let j = 0; j < lastKNumbers.length - 1; j++) {
            lastKNumbers[j] = lastKNumbers[j + 1];
        }

        lastKNumbers[lastKNumbers.length - 1] = sequence[sequence.length - 1]; // last number of lastKNumbers === last number of sequence
        let number = lastKNumbers.reduce((a, b) => a + b, 0);
        sequence.push(number);
    }

    console.log(sequence.join(' '));
}

solve(6, 3);

solve(8, 2);