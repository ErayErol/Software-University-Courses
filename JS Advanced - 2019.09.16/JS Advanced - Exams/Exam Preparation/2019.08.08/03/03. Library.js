class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: +libraryName.length,
            special: +libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        };
    }

    subscribe(name, type) {
        if (!this.subscriptionTypes[type]) {
            throw new Error(`The type ${type} is invalid`);
        }

        let person = this.subscribers.find(s => s.name === name);
        if (person) {
            person.type = type;
            return person;
        }

        let newPerson = {
            name: name,
            type: type,
            books: []
        };

        this.subscribers.push(newPerson);
        return newPerson;
    }

    unsubscribe(name) {
        let person = this.subscribers.find(p => p.name === name);
        if (!person) {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        this.subscribers = this.subscribers.filter(s => s.name !== name);
        return this.subscribers;
    }

    receiveBook(name, title, author) { // org : receiveBook(subscriberName, bookTitle, bookAuthor)
        let person = this.subscribers.find(p => p.name === name);
        if (!person) {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        let limit = this.subscriptionTypes[person.type];
        if (limit === person.books.length) {
            throw new Error(`You have reached your subscription limit ${limit}!`);
        }

        let book = {
            title,
            author
        };

        person.books.push(book);
        return person;
    }

    showInfo() {
        let res = (this.subscribers.length === 0)
            ? `${this.libraryName} has no information about any subscribers`
            : this.subscribers
                .map(s => `Subscriber: ${s.name}, Type: ${s.type}\nReceived books: ${s.books
                    .map(b => `${b.title} by ${b.author}`)
                    .join(', ')}`)
                .join('\n');

        return res;
    }
}

let lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');

console.log(lib.showInfo());