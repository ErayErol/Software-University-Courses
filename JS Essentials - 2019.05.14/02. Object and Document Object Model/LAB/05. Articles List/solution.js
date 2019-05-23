function createArticle() {
	let titleElement = document.getElementById("createTitle").value;
	let contentElement = document.getElementById("createContent").value;
	let articles = document.getElementById("articles");

	if (titleElement && contentElement) {
		let currentArticle = document.createElement("article");

		let createTitleElement = document.createElement("h3");
		createTitleElement.textContent = titleElement;
		currentArticle.appendChild(createTitleElement);

		let createContentElement = document.createElement("p");
		createContentElement.textContent = contentElement;
		currentArticle.appendChild(createContentElement);

		articles.appendChild(currentArticle);

		document.getElementById("createTitle").value = "";
		document.getElementById("createContent").value = "";
	}
}