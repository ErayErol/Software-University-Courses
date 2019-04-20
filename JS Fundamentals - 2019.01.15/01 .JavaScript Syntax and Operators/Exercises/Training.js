function solve(type, weight, price) {
    weight = Number(weight) / 1000;
    price = Number(price);

    let sum = weight * price;

    console.log(`I need ${sum.toFixed(2)} leva to buy ${weight.toFixed(2)} kilograms ${type}.`)
}
solve('orange', 2500, 1.80);
solve('apple', 1563, 2.35);