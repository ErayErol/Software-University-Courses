class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: Number(libraryName.length),
            special: Number(libraryName.length * 2),
            vip: Number.MAX_SAFE_INTEGER,
        };
    }

    subscribe(name, type) {
        if (this.subscriptionTypes.hasOwnProperty(type) == false) {
            throw new Error(`The type ${type} is invalid`);
        }

        let subscriber = this.subscribers.find(s => s.name === name);
 
        if (subscriber) {
            subscriber.type = type;
        }else {
                subscriber = {
                name,
                type,
                books: []
            };
 
            this.subscribers.push(subscriber);
        }  
       
        return subscriber;
    }

    unsubscribe(name) {
        let subsIndex = this.subscribers.findIndex(s => s.name === name);

        if (subsIndex === -1) {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        this.subscribers.splice(subsIndex, 1);
        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {

        let subsIndex = this.subscribers.findIndex(s => s.name === subscriberName);

        if (subsIndex === -1) {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        let currSubs = this.subscribers[subsIndex];
        let subTypeLimit = this.subscriptionTypes[`${currSubs.type}`]

        if (subTypeLimit < currSubs.books.length) {
            throw new Error(`You have reached your subscription limit ${subTypeLimit}!`);
        }

        currSubs.books.push({ title: bookTitle, author: bookAuthor });

        return currSubs;
    }

    showInfo() {
        let result = '';
        if (this.subscribers.length === 0) {
            result += `${this.libraryName} has no information about any subscribers`;
        }

        for (const subsriber of this.subscribers) {
            result += `Subscriber: ${subsriber.name}, Type: ${subsriber.type}\n`;

            let books = [];
            for (const book of subsriber.books) {
                books.push(`${book.title} by ${book.author}`);
            }

            result += `Received books: ${books.join(', ')}\n`;
        }

        result.trim();
       
        return result;
    }
}