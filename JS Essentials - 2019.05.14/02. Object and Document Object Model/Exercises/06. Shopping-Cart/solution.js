function solve() {
   let textArea = document.getElementsByTagName("textarea")[0];
   let boughtProducts = new Set([]);
   let totalPrice = 0.0;

   let productAddButton = document.getElementsByClassName("add-product");
   Array.from(productAddButton).forEach((addButton) => {
      addButton.addEventListener("click", clickEvent);
   });

   function clickEvent(e) {
      let currentTargetPrice = Number(e.currentTarget.parentElement.parentNode.children[3].innerHTML).toFixed(2);
      let currentTargetName = e.currentTarget.parentElement.parentNode.children[1].children[0].innerHTML;

      textArea.innerHTML += `Added ${currentTargetName} for ${currentTargetPrice} to the cart.\n`;

      boughtProducts.add(currentTargetName);
      totalPrice += Number(currentTargetPrice);
   }

   let checkOutBtn = document.getElementsByClassName("checkout")[0];
   checkOutBtn.addEventListener("click", result);

   function result() {
      let split = Array.from(boughtProducts).join(", ");
      textArea.innerHTML += `You bought ${split} for ${Number(totalPrice).toFixed(2)}.`;

      document.querySelectorAll('button').forEach(elem => {
         elem.disabled = true;
      });
   }
}