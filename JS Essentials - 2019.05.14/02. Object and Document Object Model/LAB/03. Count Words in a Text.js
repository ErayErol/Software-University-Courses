function countWordInText(input) {
    let result = {}
    let splitPattern = /W/;

    let arrWords = input[0].split(splitPattern).filter(x => x);

    for (let word of arrWords) {
        if (result[word] === undefined) {
            result[word] = 0;
        }

        result[word]++;
    }

    console.log(JSON.stringify(result));
}

countWordInText(["Far too slow, you're far too slow."]);

countWordInText(["JS devs use Node.js for server-side JS.-- JS for devs"]);