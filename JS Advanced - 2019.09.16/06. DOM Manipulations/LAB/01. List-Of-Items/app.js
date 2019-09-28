function addItem() {
    let newItemText = document.getElementById('newItemText');
    
    let li = document.createElement('li');
    li.textContent = newItemText.value;

    let items = document.getElementById('items');
    items.appendChild(li);
    
    newItemText.value = '';
}