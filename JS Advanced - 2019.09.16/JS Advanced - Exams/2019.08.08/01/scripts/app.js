function solve() {
    let [oldBooks, newBooks] = Array.from(document.getElementsByClassName("bookShelf"));
    let [bookTitle, bookYear, bookPrice] = Array.from(document.getElementsByTagName("input"));
    let addBtn = document.getElementsByTagName("button")[0];
    let h1 = document.getElementsByTagName("h1")[1];
    let buyBtn = "";

    addBtn.addEventListener("click", addFunc);
    function addFunc(e) {
        if (bookTitle.value !== "" && Number(bookYear.value) > 0 && Number(bookPrice.value) > 0) {
            e.preventDefault();
            let calculatePrice = (bookYear.value < 2000) ? bookPrice.value * 0.85 : bookPrice.value * 1.00;
            let { div, p, buyBtn } = createDiv(calculatePrice);
            addingBook(div, p, buyBtn, calculatePrice);
            buyBtn.addEventListener("click", buyFunc);
        }

        function addingBook(div, p, buyBtn, calculatePrice) {
            if (bookYear.value < 2000) {
                addOldBook(div, p, buyBtn);
            }
            else {
                addNewBook(div, p, buyBtn, calculatePrice);
            }
        }

        function buyFunc(event) {
            const currentPrice = event.target.textContent.split(" ")[4];
            const sumSoFar = h1.textContent.split(" ")[3];
            const total = Number(currentPrice) + Number(sumSoFar);
            h1.textContent = `Total Store Profit: ${total.toFixed(2)} BGN`;
            event.target.parentNode.remove();
        }

        function addNewBook(div, p, buyBtn, currPrice) {
            const moveBookBtn = createElement("button", "Move to old section");
            appendChildToParent(div, [p, buyBtn, moveBookBtn]);
            moveBookBtn.addEventListener("click", moveFunc);
            newBooks.appendChild(div);

            function moveFunc(){
                moveBookBtn.remove();
                buyBtn.textContent = `Buy it only for ${(currPrice * 0.85).toFixed(2)} BGN`;
                oldBooks.appendChild(div);
            }
        }

        function addOldBook(div, p, buyBtn) {
            appendChildToParent(div, [p, buyBtn]);
            oldBooks.appendChild(div);
        }

        function createDiv(currPrice) {
            const div = createElement("div", "", "book");
            const p = createElement("p", `${bookTitle.value} [${bookYear.value}]`);
            buyBtn = createElement("button", `Buy it only for ${currPrice.toFixed(2)} BGN`);
            return { div, p, buyBtn };
        }

        function createElement(tagName, textContent, className) {
            const element = document.createElement(tagName);
            if (textContent) {
                element.textContent = textContent;
            }
            if (className) {
                element.className = className;
            }
            return element;
        }

        function appendChildToParent(parent, childs) {
            Array.from(childs).forEach(child => parent.appendChild(child));
        }
    }
}