function solve() {
   document.getElementById('send').addEventListener('click', () => {
      let input = document.getElementById('chat_input');
      let message = document.getElementsByClassName('message my-message')[0];

      let cloneMessage = message.cloneNode(true);
      cloneMessage.textContent = input.value;

      let newMessage = document.getElementById('chat_messages');
      newMessage.appendChild(cloneMessage);
      input.value = '';
   });
}