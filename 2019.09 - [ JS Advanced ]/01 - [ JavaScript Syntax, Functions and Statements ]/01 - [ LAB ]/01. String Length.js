// let getLength = (...params) => {
//     let sum = params.reduce((a, b) => a + b.length, 0);
//     let average = Math.floor(sum / params.length);

//     return [sum, average].join('\n');
// };

// let result = getLength('chocolate', 'ice cream', 'cake');
// console.log(result);

let result = ((a) => {
    return 1 + a;
})(10);

console.log(result);