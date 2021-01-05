function solve(input) {
    let towns = [];
    for (let town of input) {
        let name = town.split(' -> ')[0];
        let product = town.split(' -> ')[1];
        let split = town.split(' -> ')[2].split(' : ');
        let amountOfSales = Number(split[0]);
        let priceForOneUnit = Number(split[1]);

        town = {
            'Name': name,
            'Product': product,
            "TotalIncome": amountOfSales * priceForOneUnit
        };

        towns.push(town);
    }

    let name = '';
    for (const town of towns) {
        
        if (name !== town.Name) {
            console.log(`Town - ${town.Name}`);
            console.log(`$$$${town.Product} : ${town.TotalIncome}`);
        } else {
            console.log(`$$$${town.Product} : ${town.TotalIncome}`);
        }

        name = town.Name;
    }
}

solve(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3']
);