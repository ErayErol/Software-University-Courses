function calculate(number) {
    let sum = number;

    add.toString = function () {
        return sum;
    };
    function add(nextNumber) {
        sum += nextNumber;
        return add;
    }
    
    
    return add;
}

console.log(calculate(17)(22)(54)(6));