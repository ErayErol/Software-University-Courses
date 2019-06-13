function solve() {
    let selectMenuTo = document.getElementById("selectMenuTo");

    let binaryOptionElement = document.createElement("option");
    let hexadecimalOptionElement = document.createElement("option");

    binaryOptionElement.text = "Binary";
    binaryOptionElement.value = "binary";
    hexadecimalOptionElement.text = "Hexadecimal";
    hexadecimalOptionElement.value = "hexadecimal";

    selectMenuTo.add(binaryOptionElement); // .add(binaryOptionElement, selectMenuTo[1])
    selectMenuTo.add(hexadecimalOptionElement); // .add(hexadecimalOptionElement, selectMenuTo[2]

    document.querySelector("button").addEventListener("click", clickEvent);
    function clickEvent() {
        let selectMenuToElementValue = document.getElementById('selectMenuTo').value;
        let decimalElementValue = document.getElementById('input').value;
        let resultElement = document.getElementById('result');

        if (selectMenuToElementValue === 'binary') {
            resultElement.value = Number(decimalElementValue).toString(2);
        }
        else if (selectMenuToElementValue === 'hexadecimal') {
            resultElement.value = Number(decimalElementValue).toString(16).toUpperCase();
        }
    }
}