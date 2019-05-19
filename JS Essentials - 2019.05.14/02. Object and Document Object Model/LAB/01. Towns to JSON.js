function townsToJSON(inputArray) {
    let tableHeadArray = inputArray.shift().split('|').filter(x => x !== "");
    let townHead = tableHeadArray[0].trim();
    
}

townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);

townsToJSON(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
);