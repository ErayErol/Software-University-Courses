function solve() {
   Array
      .from(document
         .getElementsByTagName('tr'))
      .splice(1)
      .forEach((tr) => {
         tr.addEventListener('click', (row) => {
            if (row.currentTarget.hasAttribute('style')) {
               row.currentTarget.removeAttribute('style');
            } else {
               Array.from(row.currentTarget.parentNode.children).forEach((row) => {
                  row.removeAttribute('style');
               });
               row.currentTarget.style.backgroundColor = '#413f5e';
            }
         });
      });
}