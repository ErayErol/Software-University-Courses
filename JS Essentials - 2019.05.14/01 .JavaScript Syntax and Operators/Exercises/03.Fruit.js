function solve(fruit, kg, money) {
    let weight = Number(kg);
    let price = Number(money);

    let sum = weight * price;

    sum = sum / 1000;
    weight = weight / 1000;

    console.log(`I need ${sum.toFixed(2)} leva to buy ${weight.toFixed(2)} kilograms ${fruit}.`)
}

solve('orange', 2500, 1.80);
solve('apple', 1563, 2.35);
