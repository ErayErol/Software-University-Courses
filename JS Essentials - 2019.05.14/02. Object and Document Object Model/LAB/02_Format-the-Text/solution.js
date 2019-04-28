function solve() {
    let getInput = document.getElementById("input").textContent;

    let sentences = getInput.split('.').filter(function (x) { return x });

    let output = document.getElementById("output");
    let start = 0;
    let end = 3;

    while (true){
        let result = "";

        for (let i = start; i < end; i++) {

            let currentSentences = sentences[i];

            if (currentSentences !== undefined){
                result += `${currentSentences}. `;
            }
        }

        let createElement = document.createElement("p");
        createElement.textContent = result.trim();

        output.appendChild(createElement);

        if (start > sentences.length) {
            break;
        }

        start += 3;
        end += 3;
    }
}