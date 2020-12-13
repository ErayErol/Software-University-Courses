function autoEngineeringCompany(input) {
    let cars = new Map();

    for (const line of input) {
        let tokens = line.split(' | ');
        let brand = tokens[0];
        let model = tokens[1];
        let count = Number(tokens[2]);

        if (cars.has(brand) == false) {
            cars.set(brand, new Map());
        }
        if (cars.get(brand).has(model) == false) {
            cars.get(brand).set(model, 0);
        }

        cars.get(brand).set(model, cars.get(brand).get(model) + count);
    }

    for (let [brand, modelCount] of cars) {
        console.log(`${brand}`);

        for (let [model, count] of modelCount) {
            console.log(`###${model} -> ${count}`);
        }
    }
}

autoEngineeringCompany([
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]);

// Audi
// ###Q7 -> 1000
// ###Q6 -> 100
// BMW
// ###X5 -> 1000
// ###X6 -> 100
// Citroen
// ###C4 -> 145
// ###C5 -> 10
// Volga
// ###GAZ-24 -> 1000000
// Lada
// ###Niva -> 1000000
// ###Jigula -> 1000000