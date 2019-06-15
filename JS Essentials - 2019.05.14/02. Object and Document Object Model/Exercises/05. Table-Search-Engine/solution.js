function solve() {
   let searchField = document.getElementById("searchField");
   let rows = Array.from(document.querySelector("table tbody").children);
   
   let searchButtonElement = document.getElementById("searchBtn");
   searchButtonElement.addEventListener("click", clickEvent);
   
   function clickEvent() {
      let selectedRows = document.getElementsByClassName("select");
      Array.from(selectedRows).forEach(row => row.classList.remove("select"));

      for (let row of rows) {
         let cells = Array.from(row.children);

         for (let cell of cells) {
            if (cell.textContent.toLowerCase().includes(searchField.value.toLowerCase())) {
               row.classList.add("select");
            }
         }
      }

      searchField.value = "";
   }
}