function solve() {
   let firstPlayerCardElements = document.querySelectorAll("#player1Div img");
   let result = document.querySelectorAll("#result span");

   let firstPlayerCardPower = 0;

   for (let firstPlayerCardElement of firstPlayerCardElements) {
      firstPlayerCardElement.addEventListener("click", function myFunc() {

         firstPlayerCardPower = Number(firstPlayerCardElement.name);

         let createCardNumber = document.createElement("span");
         createCardNumber.textContent = firstPlayerCardPower;
         
         result[0].appendChild(createCardNumber);
         firstPlayerCardElement.src = "images/whiteCard.jpg";
         
         firstPlayerCardElement.removeEventListener("click", myFunc, false);
      });

   }


   let secondPlayerCardElements = document.querySelectorAll("#player2Div img");

   let secondPlayerCardPower = 0;

   for (let secondPlayerCardElement of secondPlayerCardElements) {
      secondPlayerCardElement.addEventListener("click", function myFunc() {

         secondPlayerCardPower = Number(secondPlayerCardElement.name);

         let createCardNumber = document.createElement("span");
         createCardNumber.textContent = secondPlayerCardPower;
         
         result[2].appendChild(createCardNumber);
         secondPlayerCardElement.src = "images/whiteCard.jpg";
         
         secondPlayerCardElement.removeEventListener("click", myFunc, false);
      });

   }
}