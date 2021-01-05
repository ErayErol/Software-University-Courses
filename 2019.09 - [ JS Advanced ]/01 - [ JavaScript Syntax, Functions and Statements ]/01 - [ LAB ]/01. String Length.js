// function solve(word0, word1, word2) {
//     let sum = word0.length + word1.length + word2.length;
//     let averageLength = Math.round(sum / 3);

//     console.log(sum);
//     console.log(averageLength);
// }

// solve('chocolate', 'ice cream', 'cake');
// solve('pasta', '5', '22.3');

function solve2(...params) {
    let sum = params.reduce((a, b) => a + b.length, 0);
    let average = Math.floor(sum / params.length);

    return [sum, average].join('\n');
}

let result = solve2('chocolate', 'ice cream', 'cake');
console.log(result);