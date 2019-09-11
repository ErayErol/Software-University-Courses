function uniqueSequences(input) {
    let arraysSet = [];

    for (const line of input) {
        let tokens = JSON.parse(line);
        arraysSet.push(tokens.map(Number).sort((a, b) => b - a));
    }

    for (let i = 0; i < arraysSet.length; i++) {

        for (let j = i + 1; j < arraysSet.length; j++) {
            if (compareArrays(arraysSet[i], arraysSet[j])) {
                arraysSet.splice(j, 1);
                j--;
            }
        }
    }

    arraysSet.sort((a, b) => a.length - b.length);
    arraysSet.forEach(a => console.log("[" + a.join(", ") + "]"));

    function compareArrays(arr1, arr2) {
        if (arr1.length != arr2.length) {
            return false;
        } else {
            for (let i = 0; i < arr1.length; i++) {
                if (arr1[i] != arr2[i]) {
                    return false;
                }
            }
            return true;
        }
    }
}

uniqueSequences(["[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"]
);

uniqueSequences(["[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"]
);