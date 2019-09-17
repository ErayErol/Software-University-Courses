function calculate(number) {
    let sum = number;

    function add(nextNumber) {
        sum += nextNumber;
        return add;
    }
    
    add.toString = function () {
        return sum;
    };
    
    return add;
}

console.log(calculate(17)(22)(54)(6).toString());