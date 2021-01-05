let baseURL = "https://projectId.firebaseio.com";

function makeHeaders(httpMethod, data) {
    const headers = {
        method: httpMethod,
        headers: {
            "Content-Type": "application/json",
        }
    };

    if (httpMethod === "POST" || httpMethod === "PUT") {
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

function fetchData(startUrl, collection, headers, id) {
    let url = `${startUrl}/${collection}`;

    (id) ? url += `/${id}.json` : url += ".json";

    return fetch(url, headers)
        .then(handleError)
        .then(serializeData);
}

export function get(projectId, collection) {
    let startUrl = baseURL.replace("projectId", projectId);
    const headers = makeHeaders('GET');

    return fetchData(startUrl, collection, headers);
}

export function post(projectId, collection, data) {
    let startUrl = baseURL.replace("projectId", projectId);
    const headers = makeHeaders('POST', data);

    return fetchData(startUrl, collection, headers);
}

export function put(projectId, collection, data, id) {
    let startUrl = baseURL.replace("projectId", projectId);
    const headers = makeHeaders('PUT', data);

    return fetchData(startUrl, collection, headers, id);
}

export function del(projectId, collection, id) {
    let startUrl = baseURL.replace("projectId", projectId);
    const headers = makeHeaders('DELETE');

    fetchData(startUrl, collection, headers, id);
}