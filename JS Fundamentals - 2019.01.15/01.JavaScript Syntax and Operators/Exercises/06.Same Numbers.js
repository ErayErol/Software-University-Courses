function solve(num) {
    num = num.toString();
    let result = true;

    let firstElement = num[0];
    let sum = +firstElement;

    for (i = 1; i < num.length; i++) {
        if (num[i] !== firstElement) {
            result = false;
        }
        sum += +num[i];
    }

    console.log(result);
    console.log(sum);
}

solve(666);