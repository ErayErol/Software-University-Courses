function getArticleGenerator(articles) {
	let content = document.getElementById('content');

	return () => {
		if (articles.length > 0) {
			let p = document.createElement('p');
			p.innerHTML = articles.shift();

			let article = document.createElement('article');
			article.appendChild(p);
			
			content.appendChild(article);
		}
	};
}