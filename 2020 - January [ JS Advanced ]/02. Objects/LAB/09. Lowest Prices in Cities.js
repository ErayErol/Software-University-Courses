function solve(input) {
    let datas = {};
    for (const element of input) {
        let town = element.split(' | ')[0];
        let productName = element.split(' | ')[1];
        let productPrice = Number(element.split(' | ')[2]);

        let data = {
            Town: town,
            ProductName: productName,
            ProductPrice: productPrice
        };

        if (datas.hasOwnProperty(data.ProductName) == false) {
            datas[data.ProductName] = {};
        }
        datas[data.ProductName][data.Town] = data.ProductPrice;
    }

    for (const product in datas) {

        let lowestPrice = Number.MAX_SAFE_INTEGER;
        let townWithLowestPrice = '';

        for (const town in datas[product]) {

            const currPrice = datas[product][town];

            if (currPrice < lowestPrice) {
                lowestPrice = currPrice;
                townWithLowestPrice = town;
            }
        }
        
        console.log(`${product} -> ${lowestPrice} (${townWithLowestPrice})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
);