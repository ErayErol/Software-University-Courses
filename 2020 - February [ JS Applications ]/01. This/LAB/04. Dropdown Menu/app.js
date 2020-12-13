function solve() {
    let dropdown = document.querySelector('#dropdown-ul');
    let box = document.getElementById('box');
    let chooseBtn = document.getElementById('dropdown');

    chooseBtn.addEventListener('click', (e) => {
         (dropdown.style.display === 'block') 
            ? dropdown.style.display = 'none'
            : dropdown.style.display = 'block';

        let li = document.getElementsByTagName('li');

        [...li].forEach((li) => {
            li.addEventListener('click', (i) => {
                let currentColor = i.target.textContent;
                box.style.backgroundColor = currentColor;
            });
        });
    });
}