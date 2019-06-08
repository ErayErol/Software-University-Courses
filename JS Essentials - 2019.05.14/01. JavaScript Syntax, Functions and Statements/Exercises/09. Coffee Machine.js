function solve(arr) {
    let coffeeCaffeinePrice = 0.8;
    let coffeeDecafPrice = 0.9;
    let teaPrice = 0.8;
    let milkPrice = 0.1;
    let sugarPrice = 0.1;
    let totalPrice = 0.0;

    for (let i = 0; i < arr.length; i++) {
        let arrElement = arr[i].split(", ");

        let currentPrice = 0.0;
        let coinsInserted = 0.0;
        let typeOfDrink = "";
        let typeOfCoffee = "";

        for (let j = 0; j < arrElement.length; j++) {
            let currentInputElement = arrElement[j];

            if (j === 0) {
                coinsInserted = currentInputElement;
            } else if (j === 1) {
                typeOfDrink = currentInputElement;
            } else if (j === 2) {
                if (typeOfDrink === "tea") {
                    if (currentInputElement === "milk") {
                        currentPrice += milkPrice;
                    }
                    else if (currentInputElement >= 1 && currentInputElement <= 5) {
                        currentPrice += sugarPrice;
                    }
                    
                    currentPrice += teaPrice; 
                }else if (typeOfDrink === "coffee") {
                    typeOfCoffee = currentInputElement;
                }
            } else if (j === 3) {
                if (currentInputElement === "milk") {
                    currentPrice += milkPrice;
                }

                if (currentInputElement >= 1 && currentInputElement <= 5) {
                    currentPrice += sugarPrice;
                }

                if (typeOfCoffee === "caffeine") {
                    currentPrice += coffeeCaffeinePrice;
                } else if (typeOfCoffee === "decaf") {
                    currentPrice += coffeeDecafPrice;
                }
            } else if (j === 4) {
                if (currentInputElement >= 1 && currentInputElement <= 5) {
                    currentPrice += sugarPrice;
                }
            }
        }

        if (coinsInserted >= currentPrice) {
            let change = coinsInserted - currentPrice;
            console.log(`You ordered ${typeOfDrink}. Price: $${currentPrice.toFixed(2)} Change: $${change.toFixed(2)}`);
            totalPrice += currentPrice;
        } else {
            let change = currentPrice - coinsInserted;
            console.log(`Not enough money for ${typeOfDrink}. Need $${change.toFixed(2)} more.`);
        }
    }

    console.log(`Income Report: $${totalPrice.toFixed(2)}`);
}

solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);
solve(['8.00, coffee, decaf, 4', '1.00, tea, 2']);