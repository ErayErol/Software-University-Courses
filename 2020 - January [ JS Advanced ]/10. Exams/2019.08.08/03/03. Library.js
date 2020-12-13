class Library {
    constructor(libraryName) {
        this.libraryName = String(libraryName);
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: Number(libraryName.length),
            special: Number(libraryName.length * 2),
            vip: Number.MAX_SAFE_INTEGER
        };
    }

    subscribe(name, type) {
        if (!this.subscriptionTypes[type]) {
            throw new Error(`The type ${type} is invalid`);
        }
        let person = this.subscribers.find(s => s.name === name);
        if (!person) {
            let newPerson = { name, type, books: [] };
            this.subscribers.push(newPerson);
            return newPerson;
        } else {
            person.type = type;
            return person;
        }
    }

    unsubscribe(name) {
        const subscriber = this.subscribers.find(s => s.name === name);
        if (!subscriber) {
            throw new Error(`There is no such subscriber as ${name}`);
        }
        this.subscribers = this.subscribers.filter(s => s.name !== name);
        return this.subscribers;
    }

    receiveBook(name, bookTitle, bookAuthor) { // org : receiveBook(subscriberName, bookTitle, bookAuthor) -> SoftUni mistake
        let subscriber = this.subscribers.find(s => s.name === name);
        if (!subscriber) {
            throw new Error(`There is no such subscriber as ${name}`);
        }
        const limit = this.subscriptionTypes[subscriber.type];
        if (limit === subscriber.books.length) {
            throw new Error(`You have reached your subscription limit ${limit}!`);
        }
        const book = { title: bookTitle, author: bookAuthor };
        subscriber.books.push(book);
        return subscriber;
    }

    showInfo() {
        if (this.subscribers.length === 0) {
            return `${this.libraryName} has no information about any subscribers`;
        }
        return this.subscribers
            .map(({ name, type, books }) => `Subscriber: ${name}, Type: ${type}\nReceived books: ${books
                .map(({ title, author }) => `${title} by ${author}`)
                .join(", ")}`)
            .join("\n") + '\n';
    }
}