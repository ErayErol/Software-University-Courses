function addItem() {
    let newItemText = document.getElementById('newItemText');
    let newItemValue = document.getElementById('newItemValue');

    let option = document.createElement('option');
    option.textContent = newItemText.value;
    option.value = newItemValue.value;
    
    let select = document.getElementById('menu');
    select.add(option);

    newItemText.value = '';
    newItemValue.value = '';
}