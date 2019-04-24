function solve() {
    let textElement = document.getElementById('input');
    let text = textElement.textContent;
    let array = text.split('.').filter(function (x) { return x });

    let outputElement = document.getElementById('output');
    let startIndex = 0;
    let endIndex = 3;

    while (true) {
        let result = '';
        for (let i = startIndex; i < endIndex; i++) {
            let sentence = array[i];
            if (sentence !== undefined) {
                result += `${sentence}. `;
            }
        }

        let newElements = document.createElement('p');
        newElements.textContent = result.trim();
        outputElement.appendChild(newElements);

        if (endIndex > array.length) {
            break;
        }
        startIndex += 3;
        endIndex += 3;
    }
}