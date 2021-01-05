function solve() {
    const info = document.querySelector('#info > span');
    const btnDepart = document.querySelector('#depart');
    const btnArrive = document.querySelector('#arrive');

    let currentName;
    let currentId = 'depot';

    function depart() {
        fetch(`https://judgetests.firebaseio.com/schedule/${currentId}.json`)
            .then(res => res.json())
            .then(data => schedule(data))
            .catch(error => errorMessage(error));
    }

    function arrive() {
        btnArrive.disabled = true;
        btnDepart.disabled = false;
        info.textContent = `Arriving at ${currentName}`;
    }

    function schedule(data) {
        errorMessage(data);
        const { name, next } = data;
        currentId = next;
        currentName = name;
        btnDepart.disabled = true;
        btnArrive.disabled = false;
        info.textContent = `Next stop ${currentName}`;
    }

    function errorMessage(data) {
        if (!data) {
            info.textContent = 'Error';
            btnDepart.disabled = true;
            btnArrive.disabled = true;
            alert('Wrong Id !');
        }
    }

    return {
        depart,
        arrive,
    };
}

const result = solve();