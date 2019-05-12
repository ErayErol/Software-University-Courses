function solve() {
  let inputText = JSON.parse(document.getElementById('arr').value);
  let evenNums = [];

  for (let i = 0; i < inputText.length; i++) {
      if (i % 2 == 0) {
          evenNums.push(inputText[i]);
      }
  }

  let resultDiv = document.getElementById('result');
  let resultText = evenNums.join(' x ');

  resultDiv.textContent = resultText;
}