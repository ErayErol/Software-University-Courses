function solve() {
	let createTitleElement = document.getElementById('createTitle');
	let createContentElement = document.getElementById('createContent');

	let createTitleValue = createTitleElement.value;
	let createContentValue = createContentElement.value;
	
	if(createTitleValue && createContentValue){
		let titleElement = document.createElement('h3');
		titleElement.textContent = createTitleValue;

		let contentElement = document.createElement('p');
		contentElement.textContent = createContentValue;

		let articleElement = document.createElement('article');
		articleElement.appendChild(titleElement);
		articleElement.appendChild(contentElement);

		let articlesElement = document.getElementById('articles');
		articlesElement.appendChild(articleElement);

		createTitleElement.value = '';
		createContentElement.value = '';
	}
}