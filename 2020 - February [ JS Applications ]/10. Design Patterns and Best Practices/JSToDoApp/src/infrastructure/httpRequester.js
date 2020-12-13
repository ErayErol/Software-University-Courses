export default class HttpRequester {
    constructor(baseUrl){
        this.baseUrl = baseUrl || '';
        let urlLength = this.baseUrl.length;

        if (urlLength > 0 && this.baseUrl[urlLength - 1] !== '/') {
            throw new TypeError('Base URL must be empty or end with trailing slash');
        }
    }

    async get(url, data){
        let currentUrl = this.baseUrl + url;
        let params = '';

        if (data && typeof(data) === 'object') {
            Object.entries(data).forEach(function(param){
                params += `${param[0]}=${param[1]}&`;
            });
        }

        if (params.length > 0) {
            currentUrl += `?${params.substring(0, params.length - 1)}`;
        }

        const response = await fetch(currentUrl);
        if (response.status >= 400) {
            throw new Error(response);
        }
        
        return response.json();
    }

    async post(url, data) {
        return this.send(url, 'POST', data);
    }

    async put(url, data) {
        return this.send(url, 'PUT', data);
    }

    async patch(url, data) {
        return this.send(url, 'PATCH', data);
    }

    async delete(url) {
        return this.send(url, 'DELETE');
    }

    async send(url, method, data) {
        let currentUrl = this.baseUrl + url;
        let settings = {
            method: method,
            cache: 'no-cache'
        }

        if (data) {
            settings.headers = {
                'Content-Type': 'application/json'
            };

            settings.body = JSON.stringify(data);
        }
        
        const response = await fetch(currentUrl, settings);
        if (response.status >= 400) {
            throw new Error(response);
        }
        
        return response.json();
    }
} 