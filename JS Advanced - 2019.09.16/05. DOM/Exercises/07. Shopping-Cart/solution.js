function solve() {
   let prices = [];
   let products = [];

   let buttons = document.getElementsByTagName('button');
   let textArea = document.getElementsByTagName('textarea')[0];

   Array.from(buttons).forEach(btn => {
      btn.addEventListener('click', function (e) {

         let target = e.target;

         target.className === 'add-product'
            ? addProduct(target, textArea, prices, products)
            : checkout(products, textArea, prices, buttons);
      });
   });

   function addProduct(target, textArea, prices, products) {
      let product = target.parentNode.parentNode;
      let name = product.children[1].children[0].textContent;
      let price = Number(product.children[3].textContent);

      textArea.textContent += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;

      prices.push(price);
      products.push(name);
   }

   function checkout(products, textArea, prices, buttons) {
      let set = new Set(products);
      products = Array.from(set);
      let totalSum = prices.reduce((a, b) => a + b, 0);

      textArea.textContent += `You bought ${products.join(', ')} for ${totalSum.toFixed(2)}.`;
      Array.from(buttons).forEach(btn => btn.disabled = true);
   }
}