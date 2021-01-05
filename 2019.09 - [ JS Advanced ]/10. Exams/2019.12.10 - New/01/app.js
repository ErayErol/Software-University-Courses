function solution() {
    let [list, sent, discard] = Array.from(document.getElementsByTagName("ul"));
    let giftNameInput = document.getElementsByTagName("input")[0];
    let addGiftBtn = document.getElementsByTagName("button")[0];

    addGiftBtn.addEventListener("click", addFunc);
    function addFunc() {
        let { li, sendBtn, discardBtn } = createGift();
        clickButton(sendBtn, sent);
        clickButton(discardBtn, discard);
        appendChildsToParent(li, [sendBtn, discardBtn]);
        appendChildsToParent(list, [li]);
        sortList();
        giftNameInput.value = "";

        function createGift() {
            let li = crLi(`${giftNameInput.value}`, "gift");
            let sendBtn = crBtn("Send", "sendButton");
            let discardBtn = crBtn("Discard", "discardButton");
            return { li, sendBtn, discardBtn };
        }

        function clickButton(btn, ul) {
            btn.addEventListener("click", (e) => {
                let target = e.target.parentNode.childNodes[0].textContent;
                let li = crLi(target, "gift");
                appendChildsToParent(ul, [li]);
                e.target.parentNode.remove();
            });
        }
    }

    function sortList() {
        Array.from(list.getElementsByTagName("LI"))
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(li => list.appendChild(li));
    }

    function crLi(textContent, className) {
        let el = document.createElement("li");
        el.textContent = textContent;
        el.className = className;
        return el;
    }

    function crBtn(textContent, id) {
        let el = document.createElement("button");
        el.textContent = textContent;
        el.id = id;
        return el;
    }

    function appendChildsToParent(parent, childs) {
        Array.from(childs).forEach(child => parent.appendChild(child));
    }
}