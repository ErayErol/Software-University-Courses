function solve() {
    let elements = {
        task: document.getElementById("task"),
        description: document.getElementById("description"),
        date: document.getElementById("date"),
    }
    let sections = document.getElementsByTagName("section");
    let open = sections[1];
    let inProgress = sections[2];
    let complete = sections[3];

    addButton = document.getElementById("add");
    addButton.addEventListener("click", (event) => {
        event.preventDefault();
        if (elements.task.value && elements.description.value && elements.date.value) {
            let article = document.createElement("article");
            article.innerHTML = `
            <h3>${elements.task.value}</h3>
            <p>Description: ${elements.description.value}</p>
            <p>Due Date: ${elements.date.value}</p>
            <div class="flex">
                <button class="green">Start</button>
                <button class="red">Delete</button>
            </div>
            `;

            let startBtnOpen = article.children[3].children[0];
            startBtnOpen.addEventListener("click", (event2) => {
                let moveArticleTask = event2.target.parentNode.parentNode.children[0].textContent;
                let moveArticleDesc = event2.target.parentNode.parentNode.children[1].textContent;
                let moveArticleDate = event2.target.parentNode.parentNode.children[2].textContent;

                let moveArticle = document.createElement("article");
                moveArticle.innerHTML = `
                <h3>${moveArticleTask}</h3>
                <p>Description: ${moveArticleDesc}</p>
                <p>Due Date: ${moveArticleDate}</p>
                <div class="flex">
                    <button class="red">Delete</button>
                    <button class="orange">Finish</button>
                </div>`;

                let delBtnInProgress = moveArticle.children[3].children[0];
                delBtnInProgress.addEventListener("click", (event4) => {
                    event4.target.parentNode.parentNode.remove();
                });

                let finishBtnInProgress = moveArticle.children[3].children[1];
                finishBtnInProgress.addEventListener("click", (event5) => {
                    let finishArticleTask = event5.target.parentNode.parentNode.children[0].textContent;
                    let finishArticleDesc = event5.target.parentNode.parentNode.children[1].textContent;
                    let finishArticleDate = event5.target.parentNode.parentNode.children[2].textContent;

                    let finistArticle = document.createElement("article");
                    finistArticle.innerHTML = `
                    <h3>${finishArticleTask}</h3>
                    <p>Description: ${finishArticleDesc}</p>
                    <p>Due Date: ${finishArticleDate}</p>`;

                    complete.children[1].appendChild(finistArticle);
                    event5.target.parentNode.parentNode.remove();
                });


                inProgress.children[1].appendChild(moveArticle);
                event2.target.parentNode.parentNode.remove();
            });

            let delBtnOpen = article.children[3].children[1];
            delBtnOpen.addEventListener("click", (event3) => {
                event3.target.parentNode.parentNode.remove();
            });

            open.children[1].appendChild(article);
        }
    });
}