function attachEvents() {
    const phone = document.querySelector('#phone');
    const person = document.querySelector('#person');
    const btnLoad = document.querySelector('#btnLoad');
    const btnCreate = document.querySelector('#btnCreate');
    const phonebookList = document.querySelector('#phonebook');
    const url = (id = '') => `https://phonebook-ef107.firebaseio.com/phonebook/${id}.json`;

    btnLoad.addEventListener('click', loadContacts);
    btnCreate.addEventListener('click', createContact);

    function loadContacts() {
        cleaner();

        fetch(url())
            .then(handlerError)
            .then(res => res.json())
            .then(loadHTML)
            .catch(console.error);
    }

    function createContact() {
        const headers = {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({ person: person.value, phone: phone.value }),
        };

        fetch(url(), headers)
            .then(checkValidInput())
            .then(handlerError)
            .then(loadContacts)
            .catch(console.error);
    }

    function deleteContact() {
        const headers = { method: 'DELETE' };
        const id = this.getAttribute('data-id');

        fetch(url(id), headers)
            .then(handlerError)
            .then(loadContacts)
            .catch(console.error);
    }

    function loadHTML(data) {
        Object.entries(data).forEach(([contactID, contact]) => {
            const { person, phone } = contact;
            const li = document.createElement('li');
            const span = document.createElement('span');
            const btnDelete = document.createElement('button');
            btnDelete.textContent = 'Delete';
            btnDelete.setAttribute('data-id', contactID);
            span.textContent = `${person}: ${phone}`;
            li.appendChild(span);
            li.appendChild(btnDelete);
            phonebookList.appendChild(li);
            btnDelete.addEventListener('click', deleteContact);
        });
    }

    function cleaner() {
        person.value = '';
        phone.value = '';
        phonebookList.innerHTML = '';
    }

    function checkValidInput() {
        if (!person.value || !phone.value) {
            alert('Please fill input fields!');
            Environment.Exit(0);
        }
    }

    function handlerError(res) {
        if (!res.ok) {
            throw new Error(`Something went wrong! Status: ${res.status}, Status text: ${res.statusText}`);
        }
        return res;
    }
}

attachEvents();