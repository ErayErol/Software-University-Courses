function solve() {
   document.getElementsByTagName('button')[0].addEventListener('click', () => {
      let table = Array.from(document.getElementsByTagName('table')[0].children);
      let search = document.getElementById('searchField');

      for (let i = 2; i < table.length; i++) {
         let rows = table[i].children;

         for (let j = 0; j < rows.length; j++) {
            let row = rows[j];
            
            if (row.className === 'selected') {
               row.style.backgroundColor = '';
               row.className = '';
            }
            
            for (let r of row.cells) {
               if (r.textContent.indexOf(search.value) > -1) {
                  row.style.backgroundColor = 'yellow';
                  row.className = 'selected';
               }
            }
         }
      }

      search.value = '';
   });
}

// judge -> 16/100 ; idk why??