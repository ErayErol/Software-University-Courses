function solve(input) {
    let totalIncome = 0;

    for (let i = 0; i < input.length; i++) {
        let order = input[i].split(`, `);
        let money = Number(order.shift());
        let orderType = order.shift();
        let price = 0;

        if (orderType == `coffee`) {
            let coffeeType = order.shift();

            if (coffeeType == `caffeine`) {
                price = 0.80;
            } else if (coffeeType == `decaf`) {
                price = 0.90;
            }
        } else if (orderType == `tea`) {
            price = 0.80;
        }

        let addition = order.shift();

        if (addition == `milk`) {
            let milkPrice = Math.round(price) * 0.1;
            price += milkPrice;
            addition = order.shift();
        }

        if (addition > 0) {
            price += 0.1;
        }

        if (money >= price) {
            totalIncome += price;
            console.log(`You ordered ${orderType}. Price: $${price.toFixed(2)} Change: $${(money - price).toFixed(2)}`);
        } else {
            console.log(`Not enough money for ${orderType}. Need $${(price - money).toFixed(2)} more.`);
        }
    }

    console.log(`Income Report: $${totalIncome.toFixed(2)}`);
}

solve(['1.00, coffee, caffeine, milk, 4',
    '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']);

solve(['8.00, coffee, decaf, 4',
    '1.00, tea, 2']);