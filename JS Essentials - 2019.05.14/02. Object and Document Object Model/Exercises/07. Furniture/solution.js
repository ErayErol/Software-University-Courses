function solve() {
  let table = document.getElementsByClassName("table")[0];

  let textArea = document.getElementsByTagName("textarea");
  let inputArea = textArea[0];
  let outputArea = textArea[1];

  let buttons = document.getElementsByTagName("button");
  let generateBtn = buttons[0];
  let buyBtn = buttons[1];

  generateBtn.addEventListener("click", generate);

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

  let checkboxs = document.getElementsByTagName('input');
  checkboxs[0].outerHTML = "<input type=\"checkbox\">";

  buyBtn.addEventListener("click", buy);

  let boughtFurnitures = [];
  let totalPrice = 0;
  let totalDecFactor = 0;

  function buy() {
    for (const checkbox of checkboxs) {
      debugger;
      if (checkbox.checked) {
        let currentRow = checkbox.parentElement.parentElement;
        let name = currentRow.children[1].children[0].textContent;
        let price = Number(currentRow.children[2].children[0].textContent);
        let decFactor = Number(currentRow.children[3].children[0].textContent);

        boughtFurnitures.push(name);
        totalPrice += Number(price);
        totalDecFactor += Number(decFactor);
      }
    }
    
    outputArea.value = `Bought furniture: ${boughtFurnitures.join(" ")}\n`;
    outputArea.value += `Total price: ${totalPrice.toFixed(2)}`;
    
    
  }
}