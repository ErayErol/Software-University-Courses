function solve(arr) {
    let firstNum = arr[0];
    let lastNum = arr[arr.length - 1];

    let sum = Number(firstNum) + Number(lastNum);
    console.log(sum);
}

solve(['20', '30', '40']);
solve(['5', '10']);