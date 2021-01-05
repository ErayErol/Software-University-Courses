function attachEvents() {
    const messages = document.getElementById('messages');
    const authorInput = document.getElementById('author');
    const contentInput = document.getElementById('content');
    const refreshBtn = document.getElementById('refresh');
    const sendBtn = document.getElementById('submit');

    refreshBtn.addEventListener('click', refresh);
    sendBtn.addEventListener('click', send);

    function refresh() {
        fetch('https://rest-messanger.firebaseio.com/messanger.json')
            .then((res) => res.json())
            .then(cleanerTextArea())
            .then(cleanerInput())
            .then((data) => createMessage(data))
            .catch(console.error);
    }

    function send() {
        const headers = {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({ author: authorInput.value, content: contentInput.value }),
        };

        fetch('https://rest-messanger.firebaseio.com/messanger.json', headers)
            .then(checkValidInput())
            .then((res) => res.json())
            .then(sendMessages())
            .then(cleanerInput())
            .catch(console.error);
    }

    function createMessage(data) {
        Object.entries(data).forEach(([contactID, contact]) => {
            const { author, content } = contact;
            const div = document.createElement('div');
            div.setAttribute('data-id', contactID);
            div.textContent = `${author}: ${content}`;
            messages.value += div.textContent + '\n';
        });
    }

    function sendMessages() {
        const div = document.createElement('div');
        div.textContent = `${authorInput.value}: ${contentInput.value}`;
        messages.value += div.textContent + '\n';
    }

    function cleanerTextArea() {
        messages.value = '';
    }

    function cleanerInput() {
        authorInput.value = '';
        contentInput.value = '';
    }

    function checkValidInput() {
        if (!authorInput.value && !contentInput.value) {
            alert('Please fill input fields!');
            Environment.Exit(0);
        }
    }
}

attachEvents();