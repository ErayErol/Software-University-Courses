function solve(arr) {
    let sortedArr = [];
    
    arr = arr.map((element) => {
      if (element >= 0) {
        sortedArr.push(element);
      }else {
        sortedArr.unshift(element);
      }
    });
  
    console.log(sortedArr.join('\n'));
  }
  
  solve([7, -2, 8, 9]);
  solve([3, -2, 0, -1]);