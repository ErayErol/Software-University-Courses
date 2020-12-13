import serialize from 'form-serialize';

export default class Router {
    constructor(controllers) {
        this.controllers = controllers;
        this.currentPath = '';
        this.currentQuerystring = '';
        this.currentState = {};
        this.forceReroute = false;
    }

    initialize() {
        history.pushState({}, '', '/');
        setInterval(this.listen.bind(this), 50);
        document.addEventListener('click', this.clickHandler.bind(this));
        document.addEventListener('submit', this.submitFormHandler.bind(this));
    }

    clickHandler(e) {
        if (e.target.href && e.target.origin === document.location.origin) {
            e.preventDefault();
            e.stopPropagation();
            this.forceReroute = true;
            history.pushState({}, '', e.target.href);
            
            return false;
        }
    }

    submitFormHandler(e) {
        if (e.target.action) {
            e.preventDefault();
            e.stopPropagation();
            this.forceReroute = true;
            let data = serialize(e.target, {
                hash: true
            });
            history.pushState(data, '', e.target.action);

            return false
        }
    }

    listen() {
        if (this.forceReroute || this.currentPath !== decodeURIComponent(document.location.pathname) ||
            this.currentQuerystring !== decodeURIComponent(document.location.search)) {
            this.forceReroute = false;
            this.currentPath = decodeURIComponent(document.location.pathname);
            this.currentQuerystring = decodeURIComponent(document.location.search) || '';
            if (this.currentQuerystring !== '') {
                this.currentState = this.currentQuerystring
                    .match(/[A-ZА-Я0-9]+=[A-ZА-Я0-9\-\+]+/gi)
                    .map((el) => el.split('='))
                    .reduce((acc, el) => {
                        if (Array.isArray(el) && el.length === 2) {
                            acc[el[0]] = el[1];
                        }

                        return acc;
                    }, {});
            } else {
                this.currentState = history.state;
            }

            this.loadUrl();
        }
    }

    async loadUrl() {
        let route = this.currentPath
            .split('/')
            .filter((el) => !!el);

        try {
            if (route.length >= 2 && this.controllers.hasOwnProperty(route[0]) &&
                typeof (this.controllers[route[0]][route[1]]) === 'function') {
                await this.redirect(route);
            } else if (route.length === 0) {
                route = ['home', 'index'];
                await this.redirect(route);
            } else {
                route = ['home', 'notFound'];
                this.currentState = {
                    path: this.currentPath,
                    querystring: this.currentQuerystring
                };

                await this.redirect(route);
            }
        } catch (error) {
            route = ['home', 'logError'];
            this.currentState = {};
            this.currentState.error = error;
            await this.redirect(route);
        }
    }

    async redirect(route) {
        if (this.controllers[route[0]].mustAuthenticate && 
            this.controllers[route[0]].currentUser === null) {
            await this.controllers.account.login(this.currentPath, this.currentState);
        } else {
            await this.controllers[route[0]][route[1]](this.currentState);
        }
    }
}