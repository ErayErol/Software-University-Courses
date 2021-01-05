function solve(input) {
    let towns = [];
    let splitPattern = /\s*\|\s*/;

    for (let i = 1; i < input.length; i++) {
        let town = {};
        let args = input[i].split(splitPattern).filter(x => x);

        town["Town"] = args[0];
        town["Latitude"] = Number(args[1]);
        town["Longitude"] = Number(args[2]);

        towns.push(town);
    }

    let result = JSON.stringify(towns);
    console.log(result);
}

solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);

solve(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
);