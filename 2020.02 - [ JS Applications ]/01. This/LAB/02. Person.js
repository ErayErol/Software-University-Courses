const _nameLength = 3;
const _fullNameSplitLength = 2;

class Person {
    constructor(first, last) {
        this.first = first;
        this.last = last;
    }

    get first() {
        return this._first;
    }

    set first(value) {
        if (value.length < _nameLength) {
            this.InvalidName('First');
        }

        this._first = value;
    }

    get last() {
        return this._last;
    }

    set last(value) {
        if (value.length < _nameLength) {
            this.InvalidName('Last');
        }

        this._last = value;
    }

    get firstName() {
        return this.first;
    }

    set firstName(value) {
        if (value.length < _nameLength) {
            this.InvalidName('First');
        }

        this.first = value;
    }

    get lastName() {
        return this.last;
    }

    set lastName(value) {
        if (value.length < _nameLength) {
            this.InvalidName('Last');
        }

        this.last = value;
    }

    InvalidName(name) {
        throw new Error(`${name} name length must be more than two!`);
    }

    get fullName() {
        return `${this.firstName} ${this.lastName}`;
    }

    set fullName(value) {
        let parts = value.split(' ');

        if (parts.length !== _fullNameSplitLength) {
            throw new Error('Parts length must be two!');
        }

        if (parts[0].length < _nameLength) {
            this.InvalidName('First');
        }

        if (parts[1].length < _nameLength) {
            this.InvalidName('Last');
        }

        this.first = parts[0];
        this.last = parts[1];
    }
}

try {
    let person = new Person("Peter", "Ivanov");
    console.log(person.fullName); // Peter Ivanov
    person.firstName = "George";
    console.log(person.fullName); // George Ivanov
    person.lastName = "Peterson";
    console.log(person.fullName); // George Peterson
    person.fullName = "Nikola";
    console.log(person.firstName); // Nikola
    console.log(person.lastName); // Tesla
} catch (error) {
    console.log(error);
}