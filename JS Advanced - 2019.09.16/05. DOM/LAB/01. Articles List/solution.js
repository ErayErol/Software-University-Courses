function createArticle() {
	let createTitle = document.getElementById('createTitle');
	let createContent = document.getElementById('createContent');

	if (createTitle.value !== '' && createContent.value !== '') {
		let h3 = document.createElement('h3');
		h3.textContent = createTitle.value;

		let p = document.createElement('p');
		p.textContent = createContent.value;

		let articles = document.getElementById('articles');
		let article = document.createElement('article');
		article.appendChild(h3);
		article.appendChild(p);

		articles.appendChild(article);

		createTitle.value = '';
		createContent.value = '';
	}
}