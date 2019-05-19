function townsToJSON(inputArray) {
   let tableHeadArray = inputArray.shift().split('|').filter(x => x !== '');
   let firstTableName = tableHeadArray[0].trim();
   let secondTableName = tableHeadArray[1].trim();
   let thirdTableName = tableHeadArray[2].trim();

   let resultArray = [];

   for (let i = 0; i < inputArray.length; i++) {
       let currentRow = inputArray[i].split('|').filter(x => x !== '');
       let currentLat = +currentRow[1];
       let currentLong = +currentRow[2];

       let currentObject =  {
           [firstTableName] : currentRow[0].trim(),
           [secondTableName] : currentLat,
           [thirdTableName] : currentLong,
       };

       resultArray.push(currentObject);
   }

   console.log(JSON.stringify(resultArray));
}

townsToJSON(['| TAwn | Latitude | Longitude |',
   '| Sofia | 42.696552 | 23.32601 |',
   '| Beijing | 39.913818 | 116.363625 |']
);

townsToJSON(['| Town | Latitude | Longitude |',
   '| Veliko Turnovo | 43.0757 | 25.6172 |',
   '| Monatevideo | 34.50 | 56.11 |']
);