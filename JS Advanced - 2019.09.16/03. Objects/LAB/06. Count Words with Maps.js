function solve(input) {
    input = JSON.stringify(input);
    let wordsCounter = {};
    let words = input.toLowerCase().split(/\W+/).filter(w => w != "");

    for (let word of words) {
        if (wordsCounter.hasOwnProperty(word) === false) {
            wordsCounter[word] = 0;
        }

        wordsCounter[word]++;
    }
    
    const sorted = {};
    Object.keys(wordsCounter).sort().forEach(function (key) {
        sorted[key] = wordsCounter[key];
    });

    for (const key in sorted) {
        if (sorted.hasOwnProperty(key)) {
            const value = sorted[key];
            console.log(`'${key}' -> ${value} times`);
        }
    }
}

solve('Far too slow, you\'re far too slow.');

solve('JS devs use Node.js for server-side JS. JS devs use JS. -- JS for devs --');