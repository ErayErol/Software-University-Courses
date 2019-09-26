function solve() {
  let firstCheckbox = document.getElementsByTagName('input')[0];
  firstCheckbox.outerHTML = "<input type=\"checkbox\">";

  let table = document.getElementsByClassName("table")[0];

  let textArea = document.getElementsByTagName("textarea");
  let inputArea = textArea[0];
  let outputArea = textArea[1];

  let buttons = document.getElementsByTagName("button");
  let generateBtn = buttons[0];
  let buyBtn = buttons[1];

  generateBtn.addEventListener("click", generate);
  buyBtn.addEventListener("click", buy);

  function generate() {
    let furnitureList = JSON.parse(inputArea.value);

    for (let furniture of furnitureList) {

      let row = table.insertRow();

      let cell = row.insertCell();
      let img = document.createElement("img");
      img.setAttribute("src", furniture.img);
      cell.appendChild(img);

      cell = row.insertCell();
      let name = document.createElement("p");
      name.innerHTML = furniture.name;
      cell.appendChild(name);

      cell = row.insertCell();
      let price = document.createElement("p");
      price.innerHTML = furniture.price;
      cell.appendChild(price);

      cell = row.insertCell();
      let decFactor = document.createElement("p");
      decFactor.innerHTML = furniture.decFactor;
      cell.appendChild(decFactor);

      cell = row.insertCell();
      let checkbox = document.createElement("input");
      checkbox.setAttribute("type", "checkbox");
      cell.appendChild(checkbox);
    }
  }

  function buy() {
    let totalPrice = 0;
    let avgDecFactor = 0;
    let boughtFurnitures = [];

    let tbody = document.getElementsByTagName('tbody')[0];

    for (let row of tbody.children) {
      let checkbox = row.cells[4].children[0];

      if (checkbox.checked) {
        let name = row.cells[1].children[0].textContent;
        let price = row.cells[2].children[0].textContent;
        let decFactor = row.cells[3].children[0].textContent;

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
}