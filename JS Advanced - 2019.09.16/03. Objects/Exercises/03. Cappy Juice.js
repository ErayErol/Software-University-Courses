function cappyJuice(input) {
    let quantities = {};
    let bottles = {};

    for(let line of input) {
        let tokens = line.split(" => ");
        let fruit = tokens[0];
        let quantity = Number(tokens[1]);

        if(quantities.hasOwnProperty(fruit) == false) {
            quantities[fruit] = 0;
        }
        quantities[fruit] += quantity;

        if(quantities[fruit] >= 1000) {
            bottles[fruit] = parseInt(quantities[fruit]/1000);
        }
    }

    for(let key of Object.keys(bottles)) {
        console.log(`${key} => ${bottles[key]}`);
    }
}

cappyJuice(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
);

cappyJuice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
);