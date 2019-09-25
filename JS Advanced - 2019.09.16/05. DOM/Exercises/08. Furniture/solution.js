function solve() {
  let tbody = document.getElementsByTagName('tbody')[0];
  let rows = document.querySelectorAll('tbody tr')[0];
  rows.cells[4].children[0].disabled = false;
  
  let textAreas = document.getElementsByTagName('textarea');
  let btn = document.getElementsByTagName('button');
  
  let generate = btn[0];
  let generateArea = textAreas[0];
  
  generate.addEventListener('click', () => {
    let furniture = JSON.parse(generateArea.value);

    let row = rows.cloneNode(true);
    row.cells[0].children[0].src = furniture[0].img;
    row.cells[1].children[0].textContent = furniture[0].name;
    row.cells[2].children[0].textContent = furniture[0].price;
    row.cells[3].children[0].textContent = furniture[0].decFactor;
    row.cells[4].children[0].disabled = false;

    tbody.appendChild(row);
  });


  let buy = btn[1];
  let buyArea = textAreas[1];

  buy.addEventListener('click', () => {
    let avrg = 0;
    let totalPrice = 0;
    let boughtFurnitures = [];

    for (let row of tbody.children) {

      if (row.cells[4].children[0].checked == true) {
        totalPrice += Number(row.cells[2].children[0].textContent);
        boughtFurnitures.push(row.cells[1].children[0].textContent);
        avrg += Number(row.cells[3].children[0].textContent);
      }
    }

    buyArea.textContent += `Bought furniture: ${boughtFurnitures.join(', ')}\n`;
    buyArea.textContent += `Total price: ${totalPrice.toFixed(2)}\n`;
    buyArea.textContent += `Average decoration factor: ${avrg / boughtFurnitures.length}`;
  });
}