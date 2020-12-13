function solve() {
    let currentText = '';

    function append(string) {
        currentText += string;
    }

    function removeStart(n) {
        currentText = currentText.substring(n);
    }

    function removeEnd(n) {
        currentText = currentText.substring(0, currentText.length - n);
    }

    function print() {
        console.log(currentText);
    }

    return {
        append,
        removeStart,
        removeEnd,
        print
    }
}

let firstZeroTest = solve();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();