let solution = (function () {

    function isEnough(recipe, quantity, statistic) {
        for (const microelement in recipe) {
            const value = recipe[microelement];
            let sum = value * quantity;

            if (statistic[microelement] < sum) {
                return `Error: not enough ${microelement} in stock`;
            }
        }

        return true;
    }

    function calculate(recipe, quantity, statistic) {
        for (const microelement in recipe) {
            const value = recipe[microelement];
            statistic[microelement] -= value * quantity;
        }
    }

    const apple = {
        carbohydrate: 1,
        flavour: 2
    };

    const lemonade = {
        carbohydrate: 10,
        flavour: 20
    };

    const burger = {
        carbohydrate: 5,
        fat: 7,
        flavour: 3
    };

    const eggs = {
        protein: 5,
        fat: 1,
        flavour: 1
    };

    const turkey = {
        protein: 10,
        carbohydrate: 10,
        fat: 10,
        flavour: 10
    };

    let statistic = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    return function () {
        let tokens = arguments[0].split();
        let inputArr = Array.from(tokens[0].split(' '));

        if (inputArr[0] === 'restock') {
            const microelement = inputArr[1];
            const quantity = Number(inputArr[2]);

            statistic[microelement] += quantity;
            return 'Success';

        } else if (inputArr[0] === 'prepare') {
            const recipe = inputArr[1];
            const quantity = Number(inputArr[2]);

            if (recipe === 'burger') {
                let result = isEnough(burger, quantity, statistic);
                if (result === true) {
                    calculate(burger, quantity, statistic);
                    return 'Success';
                }

                return result;
            } else if (recipe === 'apple') {
                let result = isEnough(apple, quantity, statistic);
                if (result === true) {
                    calculate(apple, quantity, statistic);
                    return 'Success';
                }

                return result;
            } else if (recipe === 'lemonade') {
                let result = isEnough(lemonade, quantity, statistic);
                if (result === true) {
                    calculate(lemonade, quantity, statistic);
                    return 'Success';
                }

                return result;
            } else if (recipe === 'eggs') {
                let result = isEnough(eggs, quantity, statistic);
                if (result === true) {
                    calculate(eggs, quantity, statistic);
                    return 'Success';
                }

                return result;
            } else if (recipe === 'turkey') {
                let result = isEnough(turkey, quantity, statistic);
                if (result === true) {
                    calculate(turkey, quantity, statistic);
                    return 'Success';
                }

                return result;
            }
        } else if (inputArr[0] === 'report') {
            let result = [];
            for (let key in statistic) {
                let value = statistic[key];
                result.push(`${key}=${value}`);
            }

            return result.join(' ');
        }
    };
});

let manager = solution();
console.log(manager('prepare turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));