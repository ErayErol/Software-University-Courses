function solve(input) {
    let towns = {};
    
    for (let town of input) {
        let name = town.split(' <-> ')[0];
        let population = Number(town.split(' <-> ')[1]);

        if (towns.hasOwnProperty(name) == false) {
            towns[name] = 0;
        }

        towns[name] += population;
    }
    
    for (let townPopulation of Object.entries(towns)) {
        let town = townPopulation[0];
        let population = townPopulation[1];
        console.log(`${town} : ${population}`);
    }
}

solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);

solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
);