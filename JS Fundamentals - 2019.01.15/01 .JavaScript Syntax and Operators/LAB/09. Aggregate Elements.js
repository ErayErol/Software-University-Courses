function solve(array) {

    let sum = 0;
    let sum2 = 0;
    let concat = "";

    for (let i = 0; i < array.length; i++) {
        sum = sum + array[i];
        sum2 = sum2 + ( 1 / array[i]);
        concat = concat + array[i].toString();
    }

    console.log(sum);
    console.log(sum2);
    console.log(concat);
}

solve([2, 4, 8, 16]);