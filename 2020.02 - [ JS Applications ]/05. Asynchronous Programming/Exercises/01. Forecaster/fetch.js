export function weather() {
    const baseURL = 'https://judgetests.firebaseio.com/';

    return {
        locations: () => fetch(baseURL + 'locations.json').then(r => r.json()),
        today: (code) => fetch(baseURL + `forecast/today/${code}.json `).then(r => r.json()),
        upcoming: (code) => fetch(baseURL + `forecast/upcoming/${code}.json `).then(r => r.json())
    };
}