function solve(arr) {

    for (let i = 0; i < arr.length - 1; i++) {
        let element = arr[i];
        let element2 = arr[i + 1];

        if (element.length > element2.length) {
            arr[i] = element2;
            arr[i + 1] = element;
            i = -1;
        }
    }

    for (let i = 0; i < arr.length - 1; i++) {
        let element = arr[i];
        let element2 = arr[i + 1];

        if (element.length === element2.length) {

            for (let j = 0; j < element.length; j++) {
                let element3 = element[j].toLowerCase();
                let element4 = element2[j].toLowerCase();

                if (element3 > element4) {
                    arr[i] = element2;
                    arr[i + 1] = element;
                    i = -1;
                    break;
                } else if (element3 < element4) {
                    arr[i] = element;
                    arr[i + 1] = element2;
                    break;
                }
            }
        }
    }

    console.log(arr.join('\n'));
}

solve(['alpha',
    'beta',
    'gamma']
);

solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
);

solve(['test',
    'Deny',
    'omen',
    'Default']
);