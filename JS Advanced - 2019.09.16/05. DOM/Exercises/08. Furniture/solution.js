function solve() {
  let firstCheckbox = document.getElementsByTagName('input')[0];
  firstCheckbox.outerHTML = '<input type=\"checkbox\">';

  let tbody = document.getElementsByTagName('tbody')[0];

  let textArea = document.getElementsByTagName('textarea');
  let inputArea = textArea[0];
  let outputArea = textArea[1];

  let buttons = document.getElementsByTagName('button');
  let generateBtn = buttons[0];
  let buyBtn = buttons[1];

  generateBtn.addEventListener('click', generate);
  buyBtn.addEventListener('click', buy);

  function generate() {
    let furnitureList = JSON.parse(inputArea.value);

    for (let furniture of furnitureList) {
      tbody.appendChild(document.getElementsByTagName('tr')[1].cloneNode(true));
      debugger;
      addFurniture(furniture);
    }
  }

  function buy() {
    let totalPrice = 0;
    let avgDecFactor = 0;
    let boughtFurnitures = [];

    let rows = Array.from(document.getElementsByTagName('tr'));

    for (let i = 1; i < rows.length; i++) {
      let td = rows[i].children;
      let checkbox = td[4].children[0];

      if (checkbox.checked) {
        let name = td[1].textContent.trim();
        let price = td[2].textContent;
        let decFactor = td[3].textContent;

        boughtFurnitures.push(name);
        totalPrice += Number(price);
        avgDecFactor += Number(decFactor);
      }
    }

    avgDecFactor /= boughtFurnitures.length;

    outputArea.value =
      `Bought furniture: ${boughtFurnitures.join(', ')}\n` +
      `Total price: ${totalPrice.toFixed(2)}\n` +
      `Average decoration factor: ${avgDecFactor}`;
  }

  function addFurniture(furniture) {
    let tr = document.getElementsByTagName("tr");
    let td = tr[tr.length - 1];
    td.getElementsByTagName('td')[0].innerHTML = `<img src=${furniture['img']}>`;
    td.getElementsByTagName('td')[1].innerHTML = `<p>${furniture['name']}</p>`;
    td.getElementsByTagName('td')[2].innerHTML = `<p>${furniture['price']}</p>`;
    td.getElementsByTagName('td')[3].innerHTML = `<p>${furniture['decFactor']}</p>`;
    td.getElementsByTagName('td')[4].innerHTML = `<input type="checkbox"/>`;
  }
}