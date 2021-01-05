function argumentInfo() {
    let typeCounter = {};

    for (const argument of arguments) {

        let type = typeof (argument);
        console.log(`${type}: ${argument}`);

        if (typeCounter.hasOwnProperty(type) == false) {
            typeCounter[type] = 0;
        }
        typeCounter[type]++;
    }

    Object
        .entries(typeCounter)
        .sort((a, b) => b[1] - a[1])
        .forEach((element) => console.log(`${element[0]} = ${element[1]}`));
}

argumentInfo('cat', 42, function () { console.log('Hello world!'); });