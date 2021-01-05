function create(words) {
   let content = document.getElementById('content');

   for (const word of words) {
      let div = document.createElement('div');
      let p = document.createElement('p');
      p.style.display = 'none';
      p.textContent = word;

      div.appendChild(p);
      div.addEventListener('click', show);
      content.appendChild(div);
   }
   
   function show() {
      this.children[0].style.display = 'block';
   }
}