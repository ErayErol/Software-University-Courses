function deleteByEmail() {
    input = document.getElementsByTagName('input')[0];
    result = document.getElementById('result');

    let hasDelete = false;
    let secondColumn = document.querySelectorAll("#customers tr td:nth-child(2)");
    for (let td of secondColumn) {
        if (td.textContent.includes(input.value)) {
            let parent = td.parentNode;
            hasDelete = true;
            parent.remove();
        }
    }

    hasDelete === true
        ? result.textContent = 'Deleted.'
        : result.textContent = 'Not found.';
}