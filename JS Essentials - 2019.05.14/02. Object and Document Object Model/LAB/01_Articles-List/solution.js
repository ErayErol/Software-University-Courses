function solve() {

	let createTitleElement = document.getElementById("createTitle");
    let createContentElement = document.getElementById("createContent");

    let createTitleValue = createTitleElement.value;
    let createContentValue = createContentElement.value;

    if (createTitleValue && createContentValue){
        let createTitle = document.createElement("h3");
        createTitle.textContent = createTitleValue;

        let createContent = document.createElement("p");
        createContent.textContent=createContentValue;

        let articleElement = document.createElement("article");
        articleElement.appendChild(createTitle);
        articleElement.appendChild(createContent);

        let articles = document.getElementById("articles");
        articles.appendChild(articleElement);

        createTitleElement.value = "";
        createContentElement.value = "";
	}
}