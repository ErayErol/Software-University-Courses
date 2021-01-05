function handleError(x) {
    if (!x.ok)
        throw new Error(JSON.stringify({
            status: x.status,
            statusText: x.statusText
        }));
    return x;
}

function deserializeData(x) { return x.json(); }

export function fetchData(hError = handleError, dData = deserializeData, url) {
    return fetch(url)
        .then(hError)
        .then(dData)
}
