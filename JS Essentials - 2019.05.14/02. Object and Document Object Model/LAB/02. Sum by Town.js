function sumByTown(input) {
    let obj = {};
    
    for (let i = 0; i < input.length; i+=2) {
            if (obj[input[i]] === undefined) {
                obj[input[i]] = 0;
        }

        obj[input[i]] += Number(input[i + 1]);
    }

    console.log(JSON.stringify(obj));
}

sumByTown(["Sofia",
    "20",
    "Varna",
    "3",
    "Sofia",
    "5",
    "Varna",
    "4"
]);

sumByTown(["Sofia",
    "20",
    "Varna",
    "3",
    "sofia",
    "5",
    "varna",
    "4"
    ])