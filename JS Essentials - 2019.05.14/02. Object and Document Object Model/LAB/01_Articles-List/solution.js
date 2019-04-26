function solve() {

	let createTitleElement = document.getElementById("createTitle");
	let createContentElement = document.getElementById("createContent");

	let titleElementValue = createTitleElement.value;
	let contentElementValue = createContentElement.value;

    if (titleElementValue && contentElementValue){

		let titleValue = document.createElement("h3");
		titleValue.textContent = titleElementValue;

		let contentText = document.createElement("p");
		contentText.textContent = contentElementValue;

        let newArticleElement = document.createElement("article");
		newArticleElement.appendChild(titleValue);
		newArticleElement.appendChild(contentText);

        let articlesElement = document.getElementById("articles");
		articlesElement.appendChild(newArticleElement);

        createTitleElement.value = "";
		createContentElement.value = "";
	}
}