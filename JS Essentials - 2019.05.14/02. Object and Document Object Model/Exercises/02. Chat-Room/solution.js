function solve() {
   let chatInput = document.getElementById('chat_input');
   let chatMessages = document.getElementById('chat_messages');
   
   document.getElementById('send').addEventListener('click', clickEvent);
   function clickEvent() {
       let divElement = document.createElement('div');
       divElement.textContent = chatInput.value;

       if (divElement.textContent !== "") {
          divElement.setAttribute('class', 'message my-message');
          chatMessages.appendChild(divElement);
          
          chatInput.value = '';
       }
   }
}


// function solve() {
//    let targetDiv = document.getElementsByClassName("my-message")[0];
//    let textArea = document.getElementById("chat_input");
//    let chatMessageArea = document.getElementById('chat_messages');
   
//    document.getElementById("send").addEventListener("click", clickEvent);
   
//    function clickEvent() {
//       let targetDivClone = targetDiv.cloneNode(true);
//       let textAreaContent = textArea.value;
      
//       if (textAreaContent !== "") {
//          targetDivClone.textContent = textAreaContent;
//          chatMessageArea.appendChild(targetDivClone);
   
//          textArea.value = "";
//       }
//    }
// }