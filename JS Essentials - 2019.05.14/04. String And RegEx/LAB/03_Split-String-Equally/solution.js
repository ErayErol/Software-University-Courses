function solve() {
    let string = document.getElementById("text").value;
    let n = parseInt(document.getElementById("number").value);

    function splitStringEqually(string, n) {
        debugger;
        let arr = [];
        let indexCounter = 0;
        if (string.length % n !== 0) {
            let len = string.length;
            let symbolsCount = 0;

            while (len % n !== 0) {
                len %= n;
                len++;
                symbolsCount++;
            }

            for (let i = 0; i < symbolsCount; i++) {
                string += string[indexCounter];
                indexCounter++;
            }
        }

        for (let i = 0; i < string.length; i += n) {
            arr.push(string.substr(i, n));
        }

        document.getElementById("result").innerHTML = arr.join(" ");
    }

    splitStringEqually(string, n);
}