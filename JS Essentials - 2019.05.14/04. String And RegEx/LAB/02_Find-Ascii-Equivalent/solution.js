function solve() {
  let input = document.getElementById('text').value;
  let result = document.getElementById('result');

  function ascii(input) {
    let inputElemets = input.split(' ').filter(a => a !== '');
    let output = '';

    for (const element of inputElemets) {
      if (Number(element)) {
        output += (String.fromCharCode(element));
      } else {
        let numbers = [];

        for (let i = 0; i < element.length; i++) {
          let charToNum = element[i].charCodeAt(0);
          numbers.push(charToNum);
        }

        let p = document.createElement('p');
        p.innerHTML = numbers.join(' ');
        result.appendChild(p);
      }
    }

    let p = document.createElement('p');
    p.innerHTML = output;
    result.appendChild(p);
  }

  ascii(input);
}