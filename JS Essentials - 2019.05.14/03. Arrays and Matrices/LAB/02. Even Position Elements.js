function solve(arr) {
  let evenPositionArr = [];
  
  arr = arr.map((element, index) => {
    if (index % 2 === 0) {
      evenPositionArr.push(element);
    }
  });

  console.log(evenPositionArr.join(' '));
}

solve(['20', '30', '40']);
solve(['5', '10']);