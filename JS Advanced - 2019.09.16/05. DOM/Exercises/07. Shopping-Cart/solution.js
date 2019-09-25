function solve() {
   let totalSum = 0;
   let products = [];
   let disable = true;
   
   let buttons = document.getElementsByTagName('button');
   let textArea = document.getElementsByTagName('textarea')[0];

   Array.from(buttons).forEach(add => {
      add.addEventListener('click', function (e) {
         if (disable === true) {
            let t = e.target;
            
            if (t.className === 'add-product') {
               let product = t.parentNode.parentNode;
               let name = product.children[1].children[0].textContent;
               let money = Number(product.children[3].textContent);
   
               textArea.textContent += `Added ${name} for ${money.toFixed(2)} to the cart.\n`;
   
               totalSum += money;
               products.push(name);
            } else {
               disable = false;
               let set = new Set(products);
               products = Array.from(set);
               textArea.textContent += `You bought ${products.join(', ')} for ${totalSum.toFixed(2)}.`;
            }
         }
      });
   });
}