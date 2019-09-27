function addItem() {
    let ul = document.getElementById('items');

    let newItemText = document.getElementById('newItemText');
    let li = document.createElement('li');
    li.textContent = newItemText.value;

    ul.appendChild(li);
    newItemText.value = '';
}