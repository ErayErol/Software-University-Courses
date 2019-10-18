function acceptance() {
	let fields = document.getElementById('fields');
	let company = fields.children[0].children[0];
	let product = fields.children[1].children[0];
	let quantity = fields.children[2].children[0];
	let scrape = fields.children[3].children[0];

	let warehouse = document.getElementById('warehouse');
	let deleteButtons = warehouse.getElementsByTagName('button');

	let button = document.getElementById('acceptance');
	button.addEventListener('click', event);

	function event() {
		add();
		company.value = '';
		product.value = '';
		quantity.value = '';
		scrape.value = '';
		remove();
	}

	function remove() {
		Array.from(deleteButtons).forEach(function (btn) {
			btn.addEventListener('click', removeFunc);
	
			function removeFunc() {
				let child = btn.parentNode;
				let parent = child.parentNode;
				parent.removeChild(child);
	
			}
		});
	}

	function add() {
		if (product.value !== '' && company.value !== '' && Number(quantity.value) && Number(scrape.value) && Number(quantity.value) > Number(scrape.value)) {
			let pieces = Number(quantity.value) - Number(scrape.value);

			let p = document.createElement('p');
			p.textContent = `[${company.value}] ${product.value} - ${pieces} pieces`;

			let btn = document.createElement('button');
			btn.setAttribute('type', 'button');
			btn.textContent = 'Out of stock';

			let div = document.createElement('div');
			div.appendChild(p);
			div.appendChild(btn);
			warehouse.appendChild(div);
		}
	}
}