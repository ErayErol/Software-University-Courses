function solve(fruit, weight, price) {
    let money = weight * price / 1000;
    weight = weight / 1000;
    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80);

solve('apple', 1563, 2.35);