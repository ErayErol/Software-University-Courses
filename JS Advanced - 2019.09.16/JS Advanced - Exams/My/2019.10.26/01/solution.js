function solve() {
   const [filter, name, quantity, price] = [...document.getElementsByTagName('input')];
   const [filterBtn, addBtn, buyBtn] = [...document.getElementsByTagName('button')];

   let h1 = document.getElementsByTagName('h1')[1];
   let productsUl = document.getElementsByTagName('ul');

   let sum = 0;

   addBtn.addEventListener('click', addFunc);
   function addFunc(e) {
      e.preventDefault();
      let li = document.createElement('li');

      let span = document.createElement('span');
      span.textContent = name.value;
      li.appendChild(span);

      let strongQuantity = document.createElement('strong');
      strongQuantity.textContent = `Available: ${Number(quantity.value)}`;
      li.appendChild(strongQuantity);

      let div = document.createElement('div');

      let strongPrice = document.createElement('strong');
      strongPrice.textContent = Number(price.value).toFixed(2);
      div.appendChild(strongPrice);

      let btnAddToTheClients = document.createElement('button');
      btnAddToTheClients.textContent = "Add to Client's List";
      div.appendChild(btnAddToTheClients);

      li.appendChild(div);
      productsUl[0].appendChild(li);

      btnAddToTheClients.addEventListener('click', (e) => {
         let currentQuantitySplit = e.target.parentNode.parentNode.children[1].textContent.split(':')[1];
         let currentQuantity = Number(currentQuantitySplit.substr(currentQuantitySplit.indexOf(' ') + 1));

         if (currentQuantity > 0) {
            let li = document.createElement('li');
            li.textContent = e.target.parentNode.parentNode.children[0].textContent;

            let strongPriceMy = document.createElement('strong');
            strongPriceMy.textContent = Number(e.target.parentNode.parentNode.children[2].children[0].textContent).toFixed(2);
            li.appendChild(strongPriceMy);

            productsUl[1].appendChild(li);

            sum += Number(strongPriceMy.textContent);
            h1.textContent = `Total Price: ${sum.toFixed(2)}`;
            e.target.parentNode.parentNode.children[1].textContent = `Available: ${--currentQuantity}`;

            if (currentQuantity === 0) {
               e.target.parentNode.parentNode.remove();
            }
         }
      });
   }

   filterBtn.addEventListener('click', filterFunc);
   function filterFunc(e) {
      let spans = document.getElementsByTagName('span');

      [...spans].forEach((s) => {
         if (!s.textContent.toLowerCase().includes(filter.value.toLowerCase())) {
            s.parentNode.style.display = 'none';
         }
      });
   }

   buyBtn.addEventListener('click', buyFunc);
   function buyFunc(e) {
      h1.textContent = `Total Price: 0.00`;
      console.log(document.querySelectorAll('#myProducts ul li').length);

      productsUl[1].textContent = '';
   }
}