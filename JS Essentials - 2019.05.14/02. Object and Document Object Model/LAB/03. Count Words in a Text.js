function solve(input){
    let arr = input[0].split(/\W/).filter(x => x);

    let obj = {}
    for (const word of arr) {
        if (!obj[word]) {
            obj[word] = 0;
        }

        obj[word]++;
    }

    console.log(JSON.stringify(obj));
}

solve("Far too slow, you're far too slow.");