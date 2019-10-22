function solve() {
    let title = document.querySelector('body > form > input[type=text]:nth-child(2)');
    let year = document.querySelector('body > form > input[type=number]:nth-child(4)');
    let price = document.querySelector('body > form > input[type=number]:nth-child(6)');

    let addNewBookBtn = document.querySelector('body > form > button');
    let bookDivOld = document.querySelector('#outputs > section:nth-child(1) > div');
    let bookDivNew = document.querySelector('#outputs > section:nth-child(2) > div');

    let sum = 0;

    addNewBookBtn.addEventListener('click', event);
    function event() {
        if (title.value !== '' && year.value > 0 && price.value > 0) {
            let createPElement = document.createElement('p');
            createPElement.textContent = `${title.value} [${year.value}]`;
            let btnBuy = document.createElement('button');

            if (year.value >= 2000) {
                let { btnMove, createDivElement } = addNewBook(btnBuy, createPElement);
                fromNewToOldBook(btnMove, createDivElement, btnBuy, createPElement);
            } else {
                addOldBook(btnBuy, createPElement);
            }
            
            buyBook(btnBuy);
        }

        function buyBook(btnBuy) {
            btnBuy.addEventListener('click', (e) => {
                sum += Number(e.target.textContent.split(' ')[4]);

                let parent = e.target.parentNode.parentNode;
                let child = e.target.parentNode;
                parent.removeChild(child);

                let totalSum = document.querySelector('body > h1:nth-child(3)');
                totalSum.textContent = `Total Store Profit: ${sum.toFixed(2)} BGN`;
            });
        }

        function fromNewToOldBook(btnMove, createDivElement, btnBuy, createPElement) {
            btnMove.addEventListener('click', (e) => {
                bookDivNew.removeChild(createDivElement);
                addOldBook(btnBuy, createPElement);
            });
        }

        function addOldBook(btnBuy, createPElement) {
            btnBuy.textContent = `Buy it only for ${Number(price.value * 0.85).toFixed(2)} BGN`;

            let createDivElement = document.createElement('div');
            createDivElement.className = 'book';
            createDivElement.appendChild(createPElement);
            createDivElement.appendChild(btnBuy);

            bookDivOld.appendChild(createDivElement);
        }

        function addNewBook(btnBuy, createPElement) {
            btnBuy.textContent = `Buy it only for ${Number(price.value).toFixed(2)} BGN`;

            let btnMove = document.createElement('button');
            btnMove.textContent = `Move to old section`;

            let createDivElement = document.createElement('div');
            createDivElement.className = 'book';
            createDivElement.appendChild(createPElement);
            createDivElement.appendChild(btnBuy);
            createDivElement.appendChild(btnMove);

            bookDivNew.appendChild(createDivElement);
            return { btnMove, createDivElement };
        }
    }
}