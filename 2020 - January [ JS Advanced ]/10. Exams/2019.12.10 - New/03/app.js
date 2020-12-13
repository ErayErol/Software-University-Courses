class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }
    set budget(budget) {
        if (budget < 0) {
            throw Error("The budget cannot be a negative number");
        }
        this._budget = budget;
    }

    shopping(product) {
        let [type, price] = product;
        if (this.budget < price) {
            throw Error("Not enough money to buy this product");
        }

        this.budget -= price;
        this.products.push(type);
        return `You have successfully bought ${type}!`;
    }

    recipes(recipe) {
        let { recipeName, productsList } = recipe;

        for (const product of productsList) {
            let find = this.products.find(p => p === product);
            if (!find) {
                throw new Error("We do not have this product");
            }
        }

        this.dishes.push(recipe);
        return `${recipeName} has been successfully cooked!`;
    }

    inviteGuests(guestName, dish) {
        let currDish = this.dishes.find(d => d.recipeName === dish);
        if (!currDish) {
            throw new Error("We do not have this dish");
        }
        let guestNames = Object.keys(this.guests);
        let currGuestName = guestNames.find(g => g.name === guestName);
        if (currGuestName) {
            throw new Error("This guest has already been invited");
        }
        let result = Object.keys(this.guests)
            .map(function (key) {
                return {
                    nameGuest: key,
                    dish: this.guest[key]
                };
            });
        console.log(result);

        this.guests[guestName] = dish;
        return `You have successfully invited ${guestName}!`;
    }

    showAttendance() {
        let output = [];
        for (let guest in this.guests) {
            let recipe = this.guests[guest];
            let dish = this.dishes.find(d => d.recipeName === recipe);
            output.push(`${guest} will eat ${recipe}, which consists of ${dish.productsList.join(", ")}`);
        }
        return output.join("\n");
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());


// Ivan will eat Oshav, which consists of Fruits, Honey
// Petar will eat Folded cabbage leaves filled with rice, which consists of Cabbage, Rice, Salt, Savory
// Georgi will eat Peppers filled with beans, which consists of Beans, Peppers, Salt