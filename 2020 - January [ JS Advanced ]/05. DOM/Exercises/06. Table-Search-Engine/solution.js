function solve() {
   const input = document.getElementById('searchField');
   const row = document.getElementsByClassName('select');
   const rows = Array.from(document.querySelector("table tbody").children);
   
   const btn = document.getElementById('searchBtn');
   btn.addEventListener('click', search);

   function search() {
      Array.from(row).forEach(row => row.classList.remove('select'));

      for (const row of rows) {
         const cells = Array.from(row.children);

         for (const cell of cells) {
            const isMatch = cell.textContent.toLowerCase().includes(input.value.toLowerCase());

            if (isMatch) {
               row.classList.add('select');
            }
         }
      }

      input.value = '';
   }
}