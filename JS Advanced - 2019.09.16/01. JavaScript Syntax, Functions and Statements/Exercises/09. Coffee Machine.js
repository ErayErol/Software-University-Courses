function solve(arr) {
    let totalSum = 0;
    for (let i = 0; i < arr.length; i++) {
        const order = arr[i].split(', ');

        let sumOfCurrOrder = 0;
        let currPrice = Number(order[0]);
        let typeOfDrink = order[1];

        if (typeOfDrink === 'coffee') {
            if (order.length === 5) {
                let typeOfCoffee = order[2];

                if (typeOfCoffee === 'caffeine') {
                    sumOfCurrOrder += 0.8;
                } else if (typeOfCoffee === 'decaf') {
                    sumOfCurrOrder += 0.9;
                }

                sumOfCurrOrder = Number((sumOfCurrOrder * 1.1).toFixed(1));

                let sugar = order[4];

                if (sugar > 0) {
                    sumOfCurrOrder += 0.1;
                }
            } else if (order.length === 4) {
                let typeOfCoffee = order[2];

                if (typeOfCoffee === 'caffeine') {
                    sumOfCurrOrder += 0.8;
                } else if (typeOfCoffee === 'decaf') {
                    sumOfCurrOrder += 0.9;
                }

                let sugar = order[3];

                if (sugar > 0) {
                    sumOfCurrOrder += 0.1;
                }
            }
        } else if (typeOfDrink === 'tea') {
            sumOfCurrOrder += 0.8;
            if (order.length === 4) {
                sumOfCurrOrder = Number((sumOfCurrOrder * 1.1).toFixed(1));

                let sugar = order[3];

                if (sugar > 0) {
                    sumOfCurrOrder += 0.1;
                }

            } else if (order.length === 3) {
                let sugar = order[2];

                if (sugar > 0) {
                    sumOfCurrOrder += 0.1;
                }
            }
        }

        if (sumOfCurrOrder > currPrice) {
            let diff = sumOfCurrOrder - currPrice;
            console.log(`Not enough money for ${typeOfDrink}. Need $${diff.toFixed(2)} more.`);
        } else {
            let diff = currPrice - sumOfCurrOrder;
            console.log(`You ordered ${typeOfDrink}. Price: $${sumOfCurrOrder.toFixed(2)} Change: $${diff.toFixed(2)}`);
            totalSum += sumOfCurrOrder;
        }
    }

    console.log(`Income Report: $${totalSum.toFixed(2)}`);
}

solve(['1.00, coffee, caffeine, milk, 4',
    '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']);

solve(['8.00, coffee, decaf, 4',
    '1.00, tea, 2']);