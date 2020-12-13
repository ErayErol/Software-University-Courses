function deleteByEmail() {
    input = document.getElementsByTagName('input')[0];
    result = document.getElementById('result');
    
    let hasDelete = false;
    let emails = document.querySelectorAll("#customers tr td:nth-child(2)");
    
    for (let cell of emails) {
        let email = cell.textContent;

        if (email === input.value) {
            cell.parentNode.remove();
            hasDelete = true;
        }
    }

    hasDelete === true
        ? result.textContent = 'Deleted.'
        : result.textContent = 'Not found.';
}