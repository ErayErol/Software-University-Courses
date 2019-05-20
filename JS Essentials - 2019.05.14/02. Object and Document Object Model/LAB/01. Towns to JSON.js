function townsToJSON(inputArray) {

    let tableHeadArray = inputArray.shift().split("|").filter(x => x !== "");
    let town = tableHeadArray[0].trim();
    let latitude = tableHeadArray[1].trim();
    let longitude = tableHeadArray[2].trim();

    let obj = {};
    let allTowns = [];
    let allLat = [];
    let allLon = [];

    for (let i = 0; i < inputArray.length; i++) {
        let currentRow = inputArray[i].split("|").filter(x => x !== "");

        allTowns.push(`${currentRow[0].trim()}`);
        allLat.push(`${currentRow[1].trim()}`);
        allLon.push(`${currentRow[2].trim()}`);

        obj[town] = allTowns;
        obj[latitude] = allLat;
        obj[longitude] = allLon;
    }
    
    console.log(`${JSON.stringify(obj)}`);
}

townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);

townsToJSON(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
);