function solve() {
  let table = document.getElementsByClassName("table")[0];

  let textArea = document.getElementsByTagName("textarea");
  let inputArea = textArea[0];
  let outputArea = textArea[1];
  
  let rowForCopy = document.getElementsByClassName("table")[0].children[1].children[0];

  let checkbox = document.getElementsByClassName("table")[0].children[1].children[0].children[4].children[0];
  
  let buttons = document.getElementsByTagName("button");
  let generateBtn = buttons[0];
  let buyBtn = buttons[1];
  
  let newRow = rowForCopy.cloneNode(true);
  // let r = newRow.children[1].children;
  // r[0].textContent = "r";
  // table.children[1].appendChild(newRow);
  
  
}