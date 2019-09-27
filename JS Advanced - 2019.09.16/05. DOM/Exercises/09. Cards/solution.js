function solve() {
   let cards = document.getElementsByTagName('img');
   
   let div = document.getElementsByTagName('div');
   let history = div[3];
   let result = div[1];
   
   let playerFirst = '';
   let playerSecond = '';
   
   Array.from(cards).forEach(card => {
      card.addEventListener('click', (e) => {
         
         let card = e.target;
         let parent = card.parentNode.id;
         card.src = 'images/whiteCard.jpg';

         let spanFirst = result.children[0];
         let spanSecond = result.children[2];
         
         if (parent === 'player1Div') {
            spanFirst.textContent = card.name;
            playerFirst = card;
         } else if (parent === 'player2Div') {
            spanSecond.textContent = card.name;
            playerSecond = card;
         }
         
         const isBattle = spanFirst.textContent !== '' && spanSecond.textContent !== '';
         
         if (isBattle) {
            let card1 = Number(spanFirst.textContent);
            let card2 = Number(spanSecond.textContent);
            let winner = playerFirst;
            let looser = playerSecond;
            
            if (card2 > card1) {
               winner = playerSecond;
               looser = playerFirst;
            }
            
            winner.style.border = '2px solid green';
            looser.style.border = '2px solid red';
            
            history.textContent += `[${card1} vs ${card2}] `;

            spanFirst.textContent = '';
            spanSecond.textContent = '';
         }
      });
   });
}