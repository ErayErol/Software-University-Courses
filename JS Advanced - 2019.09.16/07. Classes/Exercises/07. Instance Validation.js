class CheckingAccount {
    _clientId;
    _email;
    _firstName;
    _lastName;

    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }

    set clientId(value) {
        let pattern = new RegExp(/^\d{6}$/gm);

        if (value.match(pattern)) {
            this._clientId = value;
        }
        else {
            throw new TypeError('Client ID must be a 6-digit number');
        }
    }

    get email() {
        return this._email;
    }

    set email(value) {
        let pattern = new RegExp(/^[a-zA-Z]+@[a-zA-Z]+/gm);

        if (value.match(pattern)) {
            this._email = value;
        }
        else {
            throw new TypeError('Invalid e-mail');
        }
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        let pattern = new RegExp(/^[a-zA-Z]+$/gm);

        if (value.length < 3 || value.length > 20) {
            throw new TypeError('First name must be between 3 and 20 characters long');
        } else if (!value.match(pattern)) {
            throw new TypeError('First name must contain only Latin characters');
        } else {
            this._firstName = value;
        }
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(value) {
        let pattern = new RegExp(/^[a-zA-Z]+$/gm);

        if (value.length < 3 || value.length > 20) {
            throw new TypeError('Last name must be between 3 and 20 characters long');
        } else if (!value.match(pattern)) {
            throw new TypeError('Last name must contain only Latin characters');
        } else {
            this._lastName = value;
        }
    }
}

try {
    let acc = new CheckingAccount('131455', 'ivan@some.com', 'Iass', 'Pv');
} catch (error) {
    console.log(error);
}