function populationInTowns(input) {
    let result = {};

    for (let sentences of input) {
        let split = sentences.split(" <-> ");

        let name = split[0];
        let population = Number(split[1]);

        if (result.hasOwnProperty(name) === false) {
            result[name] = 0;
        }

        result[name] += population;
    }

    for (let town of Object.entries(result)) {
        console.log(`${town[0]} : ${town[1]}`);
    }
}

populationInTowns(["Sofia <-> 1200000",
    "Montana <-> 20000",
    "New York <-> 10000000",
    "Washington <-> 2345000",
    "Las Vegas <-> 1000000",
]);

populationInTowns(["Istanbul <-> 100000",
    "Honk Kong <-> 2100004",
    "Jerusalem <-> 2352344",
    "Mexico City <-> 23401925",
    "Istanbul <-> 1000",
]);