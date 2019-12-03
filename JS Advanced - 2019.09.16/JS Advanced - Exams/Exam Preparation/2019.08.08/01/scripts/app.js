function solve() {
    let sum = 0;
    let profit = document.getElementsByTagName('h1')[1];
    let [_, oldBooks, newBooks] = Array.from(document.getElementsByTagName('div'));
    let [bookTitle, bookYear, bookPrice] = Array.from(document.getElementsByTagName('input'));
    let btnAddNewBook = document.getElementsByTagName('button')[0];

    btnAddNewBook.addEventListener('click', addNewBook);
    function addNewBook(e) {
        e.preventDefault();

        if (bookTitle.value && bookYear.value > 0 && bookPrice.value > 0) {
            let p = document.createElement('p');
            p.textContent = `${bookTitle.value} [${bookYear.value}]`;
            
            let div = document.createElement('div');
            div.className = 'book';
            div.appendChild(p);

            if (bookYear.value > 1999) {
                let btnBuyNewBook = document.createElement('button');
                btnBuyNewBook.textContent = `Buy it only for ${Number(bookPrice.value).toFixed(2)} BGN`;
                div.appendChild(btnBuyNewBook);

                btnBuyNewBook.addEventListener('click', buyNewBook);
                function buyNewBook(e) {
                    let split = e.target.textContent.split(' ');
                    sum += +split[split.length - 2];
                    profit.textContent = `Total Store Profit: ${sum.toFixed(2)} BGN`;

                    e.target.parentNode.parentNode.removeChild(e.target.parentNode);                    
                }

                let btnMoveToOld = document.createElement('button');
                btnMoveToOld.textContent = `Move to old section`;
                div.appendChild(btnMoveToOld);

                btnMoveToOld.addEventListener('click', moveToOldSection);
                function moveToOldSection(e) {
                    let split = div.children[1].textContent.split(' ');
                    let oldSectionPrice = +split[split.length - 2] * 0.85;

                    div.children[1].textContent = `Buy it only for ${oldSectionPrice.toFixed(2)} BGN`;
                    div.removeChild(btnMoveToOld);
                    oldBooks.appendChild(div);

                    e.target.parentNode.parentNode.removeChild(e.target.parentNode);
                }

                newBooks.appendChild(div);
            } else {
                let btnBuyOldBook = document.createElement('button');
                let oldSectionPrice = bookPrice.value * 0.85;
                btnBuyOldBook.textContent = `Buy it only for ${oldSectionPrice.toFixed(2)} BGN`;
                div.appendChild(btnBuyOldBook);

                btnBuyOldBook.addEventListener('click', buyNewBook);
                function buyNewBook(e) {
                    let split = e.target.textContent.split(' ');
                    sum += +split[split.length - 2];
                    profit.textContent = `Total Store Profit: ${sum.toFixed(2)} BGN`;

                    e.target.parentNode.parentNode.removeChild(e.target.parentNode);                    
                }

                oldBooks.appendChild(div);
            }
        }
    }
}