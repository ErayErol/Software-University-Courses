
function townsToJSON(input) {
    let result = [];
    let splitPattern = /\s*\|\s*/;

    for (let i = 1; i < input.length; i++) {
        let currentTown = {};
        let currentString = input[i].split(splitPattern).filter(x => x);

        currentTown["Town"] = currentString[0];
        currentTown["Latitude"] = Number(currentString[1]);
        currentTown["Longitude"] = Number(currentString[2]);

        result.push(currentTown);
    }

    console.log(JSON.stringify(result));
}

townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);

townsToJSON(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
);