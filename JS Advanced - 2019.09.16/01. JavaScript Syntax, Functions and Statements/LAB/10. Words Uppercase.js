function solve(text) {
    let textToUpper = text.toUpperCase();
    let pattern = new RegExp('\\w+', 'g');
    let words = textToUpper.match(pattern);
    console.log(words.join(', '));
}

solve('Hi, how are you?');

solve('hello');