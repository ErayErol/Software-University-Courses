function townsToJSON(inputArray) {
    let tableHeadArray = inputArray.shift().split("|").filter(x => x !== "");
    let town = tableHeadArray[0].trim();
    let latitude = tableHeadArray[1].trim();
    let longitude = tableHeadArray[2].trim();

    let resultArray = [];

    for (let i = 0; i < inputArray.length; i++) {
        let currentRow = inputArray[i].split("|").filter(x => x !== "");

        let currentTown = currentRow[0].trim();
        let currentLat = Number(currentRow[1].trim());
        let currentLon = Number(currentRow[2].trim());

        let currentObj = {
            [town] : currentTown,
            [latitude] : currentLat,
            [longitude] : currentLon
        };

        resultArray.push(currentObj);
    }

    console.log(JSON.stringify(resultArray));
}

townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);

townsToJSON(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
);