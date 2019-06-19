function solve() {
  let table = document.getElementsByClassName("table")[0];

  let textArea = document.getElementsByTagName("textarea");
  let inputArea = textArea[0];
  let outputArea = textArea[1];

  let buttons = document.getElementsByTagName("button");
  let generateBtn = buttons[0];
  let buyBtn = buttons[1];

  let firstCheckbox = document.getElementsByTagName('input')[0];
  firstCheckbox.outerHTML = "<input type=\"checkbox\">";

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
    let boughtFurnitures = [];
    let totalPrice = 0;
    let avgDecFactor = 0;

    let rows = Array.from(document.getElementsByTagName('tr'));

    for (let i = 1; i < rows.length; i++) {
      let checkbox = rows[i].children[4].children[0];
      
      if (checkbox.checked) {
        let name = rows[i].children[1].textContent.trim();
        let price = rows[i].children[2].textContent;
        let decFactor = rows[i].children[3].textContent;

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