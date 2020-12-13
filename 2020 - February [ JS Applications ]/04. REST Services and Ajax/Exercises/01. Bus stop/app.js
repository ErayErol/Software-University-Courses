function getInfo() {
    const stopId = document.getElementById('stopId');
    const url = `https://judgetests.firebaseio.com/businfo/${stopId.value}.json `;
    const stopName = document.getElementById('stopName');
    const busesId = document.getElementById('buses');

    fetch(url)
        .then((response) => response.json())
        .then((data) => displeyBuses(data))
        .then(cleared())
        .catch((error) => displeyError(error));

    function displeyBuses(data) {
        debugger;
        stopName.textContent = data.name;
        const buses = Object.entries(data.buses);

        for (const [busNumber, busTime] of buses) {
            const li = document.createElement('li');
            li.textContent = `Bus ${busNumber} arrives in ${busTime}`;
            busesId.appendChild(li);
        }
    }

    function displeyError(error) {
        stopName.textContent = 'Error';
    }

    function cleared() {
        stopId.value = '';
        busesId.innerHTML = '';
    }
}