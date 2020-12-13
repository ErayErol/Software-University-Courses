export default class LoginModel {
    constructor(returnUrl, state) {
        this.returnUrl = returnUrl;
        this.username = '';
        this.password = '';
        this.errorMessage = ''

        if (Object.keys(state).length > 0) {
            let queryString = Array.from(Object.entries(state))
                .reduce((acc, el) => {
                    acc += `${el[0]}=${el[1]}&`; 
                    return acc;
                }, '?');

            this.returnUrl += queryString.substring(0, queryString.length - 1);
        }
    }
}