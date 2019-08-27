function getArticleGenerator(articles) {
	let content = document.getElementById('content');

	return function () {
		if (articles.length > 0) {
			let p = document.createElement('p');
			p.textContent = articles.shift();

			let article = document.createElement('article');
			article.appendChild(p);

			content.appendChild(article);
		}
	};
}