function solve() {
   let ul = document.querySelector('#products > ul');

   let name = document.querySelector('#add-new > input[type=text]:nth-child(2)');
   let quantity = document.querySelector('#add-new > input[type=text]:nth-child(3)');
   let price = document.querySelector('#add-new > input[type=text]:nth-child(4)');

   let btnFilter = document.querySelector('#products > div > button');
   let filterInput = document.querySelector('#filter');

   sum = 0;

   let btnAdd = document.querySelector('#add-new > button');
   btnAdd.addEventListener('click', (e) => {
      e.preventDefault();

      let nameValue = name.value;
      name.value = '';
      let quantityValue = quantity.value;
      quantity.value = '';
      let priceValue = price.value;
      price.value = '';

      let li = document.createElement('li');

      let spanName = document.createElement('span');
      spanName.textContent = nameValue;

      let strongQuantity = document.createElement('strong');
      strongQuantity.textContent = `Available: ${quantityValue}`;

      li.appendChild(spanName);
      li.appendChild(strongQuantity);

      let divLi = document.createElement('div');

      let strongPrice = document.createElement('strong');
      strongPrice.textContent = priceValue;

      let btnAddToTheClients = document.createElement('button');
      btnAddToTheClients.textContent = 'Add to Client\'s List';

      divLi.appendChild(strongPrice);
      divLi.appendChild(btnAddToTheClients);

      li.appendChild(divLi);

      ul.appendChild(li);


      btnFilter.addEventListener('click', (e) => {

         for (const li of Array.from(ul.children)) {
            if (filterInput.value !== '') {

               let filterInputVar = filterInput.value.toUpperCase();
               let match = li.children[0].textContent.toUpperCase();

               if (match.indexOf(filterInputVar) === -1) {
                  li.style.display = 'none';
               }
            }
         }
      });


      btnAddToTheClients.addEventListener('click', (e) => {
         console.log(e.target.parentElement.parentElement.children);

         let available = +e.target.parentElement.parentElement.children[1].textContent.split(' ')[1];

         if (available === 0) {
            
         }

         e.target.parentElement.parentElement.children[1].textContent.split(' ')[1]--;

         let currPrice = +e.target.parentElement.parentElement.children[2].children[0].textContent;

         sum += currPrice;
         let totall = document.querySelector('body > h1:nth-child(4)');
         totall.textContent = `Total Price: ${sum.toFixed(2)}`;
         debugger;
         
         let myProductsUl = document.querySelector('#myProducts > ul');

         let li = document.createElement('li');
         li.textContent = e.target.parentElement.parentElement.children[0].textContent;
         
      });

   });
}