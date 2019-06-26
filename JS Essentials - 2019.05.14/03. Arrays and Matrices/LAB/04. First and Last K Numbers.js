function solve(arr) {
  let result = [];
  let numberK = arr[0];

  let firstKElement = arr.slice(1, numberK + 1);
  result.push(firstKElement);
  let lastKElement = arr.splice(arr.length - numberK, numberK);
  result.push(lastKElement);

  for (const e of result) {
    console.log(e);
  }
}

solve([2,
  7, 8, 9]
);

solve([3,
  6, 7, 8, 9]
);