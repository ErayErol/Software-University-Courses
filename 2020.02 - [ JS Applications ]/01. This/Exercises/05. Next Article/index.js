function getArticleGenerator(articles) {
    const content = document.querySelector('#content');
    const data = [...articles];
    return function () {
        const article = document.createElement('article');
        if (data.length > 0) {
            article.textContent = data.shift();
            content.appendChild(article);
        }
    };
}