function attachEvents() {
    const elements = {
        $catches: () => document.getElementById('catches'),
        $addForm: () => document.getElementById('addForm'),
        $deleteBtn: () => document.querySelector('button.delete'),
        $updateBtn: () => document.querySelector('button.update'),
        $loadBtn: () => document.querySelector('button.load'),
        $createBtn: () => document.querySelector('button.add'),
    };

    elements.$loadBtn().addEventListener('click', loadCatches);
    elements.$createBtn().addEventListener('click', createCatch);

    async function createCatch() {
        const response = await createResponse(elements.$addForm().children, 'POST', 'https://fisher-game.firebaseio.com/catches.json');
        handler(response);
        loadCatches();
        clearAddForm();

        function clearAddForm() {
            Array.from(elements.$addForm().children)
                .filter(e => e.tagName === 'INPUT')
                .map(x => x.value = '');
        }
    }

    async function updateCatch(event) {
        const catchId = event.currentTarget.parentNode.getAttribute('data-id');
        const currentCatch = event.currentTarget.parentNode;
        const response = await createResponse(currentCatch.children, 'PUT', `https://fisher-game.firebaseio.com/catches/${catchId}.json`);
        handler(response);
        loadCatches();
    }

    async function deleteCatch(event) {
        const headers = { method: 'DELETE' };
        const catchId = event.currentTarget.parentNode.getAttribute('data-id');
        const response = await fetch(`https://fisher-game.firebaseio.com/catches/${catchId}.json`, headers);
        handler(response);
        loadCatches();
    }

    async function loadCatches() {
        try {
            cleaner();
            const response = await fetch('https://fisher-game.firebaseio.com/catches.json');
            const catches = await handler(response);
            getCatches(catches);
        }
        catch (err) {
            alert('No catches in the list!');
        }

        function getCatches(catches) {
            Object.entries(catches).forEach(([id, details]) => {
                const idDiv = createElement('div', 'catch');
                idDiv.setAttribute('data-id', id);
                const { angler, bait, captureTime, location, species, weight } = details;
                addingToDiv('Angler', ['input', 'angler', 'text', angler], idDiv);
                addingToDiv('Weight', ['input', 'weight', 'number', weight], idDiv);
                addingToDiv('Species', ['input', 'species', 'text', species], idDiv);
                addingToDiv('Location', ['input', 'location', 'text', location], idDiv);
                addingToDiv('Bait', ['input', 'bait', 'text', bait], idDiv);
                addingToDiv('Capture Time', ['input', 'captureTime', 'number', captureTime], idDiv);
                const updateBtn = createButtonElement('update', 'Update');
                const deleteBtn = createButtonElement('delete', 'Delete');
                idDiv.append(updateBtn, deleteBtn);
                elements.$catches().append(idDiv);
            });
        }

        function addingToDiv(name, inputDetails, idDiv) {
            const label = createLabelElement(name);
            const input = createElement(inputDetails[0], inputDetails[1], inputDetails[2], inputDetails[3]);
            const hr = createElement('hr');
            idDiv.append(label, input, hr);
        }

        function createLabelElement(textContent) {
            const label = document.createElement('label');
            label.textContent = textContent;
            return label;
        }

        function createButtonElement(className, textContent) {
            const button = document.createElement('button');
            button.textContent = textContent;
            button.className = className;
            button.className === 'update' ? button.addEventListener('click', updateCatch) : button.addEventListener('click', deleteCatch);
            return button;
        }

        function createElement(tagName, className, type, value) {
            const element = document.createElement(tagName);
            if (className) {
                element.className = className;
            }
            element.type = type;
            element.value = value;
            return element;
        }
    }

    async function createResponse(children, method, url) {
        const data = Array.from(children)
            .filter(e => e.tagName === 'INPUT')
            .reduce((acc, curr) => {
                const prop = curr.className;
                acc[prop] = curr.value;
                return acc;
            }, {});
        const headers = {
            method,
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data)
        };

        return await fetch(url, headers);
    }

    function handler(response) {
        if (!response.ok) {
            alert('Try again, please...');
            throw new Error('Something wrong');
        }
        return response.json();
    }

    function cleaner() {
        while (elements.$catches().children.length > 0) {
            elements.$catches().removeChild(elements.$catches().children[0]);
        }
    }
}

attachEvents();