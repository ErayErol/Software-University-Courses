function solve() {
   const createFields = {
      creator: () => document.getElementById("creator"),
      title: () => document.getElementById("title"),
      category: () => document.getElementById("category"),
      content: () => document.getElementById("content"),
      btn: () => document.getElementsByClassName("create")[0]
   };

   let mainSection = document.querySelector(".site-content>main>section");
   let archiveSection = document.querySelector(".archive-section");

   createFields.btn().addEventListener("click", (event) => {
      event.preventDefault();

      let article = document.createElement("article");
      article.innerHTML = `<h1>${createFields.title().value}</h1><p>Category:  <strong>${createFields.category().value}</strong></p><p>Creator: <strong>${createFields.creator().value}</strong></p><p>${createFields.content().value}</p><div class="buttons"><button class="btn delete">Delete</button><button class="btn archive">Archive</button></div>`;
      mainSection.appendChild(article);

      article.children[4].children[1].addEventListener("click", (event2) => {
         let li = document.createElement("li");
         li.textContent = event2.target.parentNode.parentNode.children[0].textContent;
         archiveSection.children[1].appendChild(li);
         event2.target.parentNode.parentNode.remove();
         sortList(archiveSection.children[1]);

         function sortList(ul) {
            Array.from(ul.getElementsByTagName("LI"))
               .sort((a, b) => a.textContent.localeCompare(b.textContent))
               .forEach(li => ul.appendChild(li));
         }
      });

      article.children[4].children[0].addEventListener("click", (event3) => {
         event3.target.parentNode.parentNode.remove();
      });
   });
}