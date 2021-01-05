const username = 'eray';
const password = 'eray';

const baseURL = 'https://baas.kinvey.com';
const appKey = 'kid_ryG8w7WVU';
const appSecret = '12da73b5ad2044b39335d4bd028563c6';

function makeHeaders(httpMethod, data) {
    const headers = {
        method: httpMethod,
        headers: {
            'Authorization': `Basic ${btoa(`${username}:${password}`)}`,
            'Content-Type': 'application/json',
        }
    };

    if (httpMethod === 'POST' || httpMethod === 'PUT') {
        headers.body = JSON.stringify(data);
    }

    return headers;
}

function serializeData(x) {
    return x.json();
}

function handleError(e) {
    if (!e.ok) {
        throw new Error(e.statusText);
    }
    return e;
}

function fetchData(kinveyModule, endpoint, headers) {
    const url = `${baseURL}/${kinveyModule}/${appKey}/${endpoint}`;

    return fetch(url, headers)
        .then(handleError)
        .then(serializeData);
}

export function get(kinveyModule, endpoint) {
    const headers = makeHeaders('GET');

    return fetchData(kinveyModule, endpoint, headers);
}

export function post(kinveyModule, endpoint, data) {
    const headers = makeHeaders('POST', data);

    return fetchData(kinveyModule, endpoint, headers);
}

export function put(kinveyModule, endpoint, data) {
    const headers = makeHeaders('PUT', data);

    return fetchData(kinveyModule, endpoint, headers);
}

export function del(kinveyModule, endpoint) {
    const headers = makeHeaders('DELETE');

    fetchData(kinveyModule, endpoint, headers);
}