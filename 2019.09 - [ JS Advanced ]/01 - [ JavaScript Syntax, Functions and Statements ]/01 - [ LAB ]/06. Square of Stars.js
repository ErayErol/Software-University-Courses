function solve(numberOfStars = 5) {
    let arr = [];
    for (let row = 0; row < numberOfStars; row++) {
        let currRow = '';
        for (let col = 0; col < numberOfStars; col++) {
            currRow += '* ';
        }
        arr.push(currRow);
    }
    
    console.log(arr.join('\n'));
}

solve(1);

solve(2);

solve(5);

solve();