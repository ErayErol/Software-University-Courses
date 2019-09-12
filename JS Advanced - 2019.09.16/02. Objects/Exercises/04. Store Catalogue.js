function storeCatalogue(input) {
    let map = new Map();

    for(let line of input){
        let tokens = line.split(' : ');
        let firstLetterOfName = tokens[0][0].toUpperCase();
        let name = firstLetterOfName + tokens[0].substr(1);
        let price = tokens[1];
        map.set(name, price);
    }

    let initials = new Set();
    Array.from(map.keys()).forEach(k => initials.add(k[0]));

    let sortLetters = Array.from(initials.keys()).sort();
    let sortProducts = Array.from(map.keys()).sort();

    for(let char of sortLetters) {
        console.log(char);

        for(let product of sortProducts){
            if(product.startsWith(char)) {
                console.log(`  ${product}: ${map.get(product)}`);
            }
        }
    }
}

storeCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'anti-Bug Spray : 15',
    'T-Shirt : 10']
);

storeCatalogue(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
);