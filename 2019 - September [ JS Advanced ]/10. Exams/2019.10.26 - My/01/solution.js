function solve() {
   const [filter, name, quantity, price] = Array.from(document.getElementsByTagName('input'));
   const [availableProducts, myProducts] = Array.from(document.getElementsByTagName('ul'));
   const [filterBtn, addBtn, buyBtn] = Array.from(document.getElementsByTagName('button'));

   let h1 = document.getElementsByTagName('h1')[1];

   addBtn.addEventListener('click', addFunc);
   function addFunc(e) {
      e.preventDefault();
      const li = createElement("li");
      const nameSpan = createElement("span", name.value);
      const quantityStrong = createElement("strong", `Available: ${Number(quantity.value)}`);
      const div = createElement("div");
      const numberStrong = createElement("strong", Number(price.value).toFixed(2));
      const addToClientBtn = createElement("button", "Add to Client's List");
      appendChildToParent(div, [numberStrong, addToClientBtn]);
      appendChildToParent(li, [nameSpan, quantityStrong, div]);
      appendChildToParent(availableProducts, [li]);

      addToClientBtn.addEventListener('click', (event) => {
         let quantity = Number(event.target.parentNode.parentNode.children[1].textContent.split(" ")[1]);
         if (quantity > 0) {
            quantity = calculate(event, quantity);
            checkQuantityIsZero(quantity, event);
            addingToMyProducts(event);
         }

         function addingToMyProducts(event) {
            let li = createElement("li", event.target.parentNode.parentNode.children[0].textContent);
            let strong = createElement("strong", event.target.parentNode.parentNode.children[2].children[0].textContent);
            li.appendChild(strong);
            myProducts.appendChild(li);
         }
   
         function checkQuantityIsZero(quantity, event) {
            if (quantity === 0) {
               event.target.parentNode.parentNode.remove();
            }
         }
   
         function calculate(event, quantity) {
            let totalPrice = Number(h1.textContent.split(" ")[2]);
            let currentPrice = Number(event.target.parentNode.parentNode.children[2].children[0].textContent);
            let currentTotalPrice = totalPrice + currentPrice;
            h1.textContent = `Total Price: ${currentTotalPrice.toFixed(2)}`;
            event.target.parentNode.parentNode.children[1].textContent = `Available: ${--quantity}`;
            return quantity;
         }
      });
   }

   filterBtn.addEventListener('click', filterFunc);
   function filterFunc() {
      const spans = document.getElementsByTagName('span');
      [...spans].forEach((span) => {
         if (!span.textContent.toLowerCase().includes(filter.value.toLowerCase())) {
            span.parentNode.style.display = 'none';
         }
      });
   }

   buyBtn.addEventListener('click', buyFunc);
   function buyFunc() {
      h1.textContent = `Total Price: 0.00`;
      myProducts.textContent = '';
   }

   function appendChildToParent(parent, childs) {
      [...childs].forEach((child) => parent.appendChild(child));
   }

   function createElement(tagName, textContent) {
      const element = document.createElement(tagName);
      if (textContent) {
         element.textContent = textContent;
      }
      return element;
   }
}