function solution() {
    let str = '';

    return {
        append: (word) => str += word,
        removeStart: (n) => str = str.substring(n),
        removeEnd: (n) => str = str.substring(0, str.length - n),
        print: () => console.log(str)

    };
}