class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: Number(libraryName.length),
            special: Number(libraryName.length) * 2,
            vip: Number.MAX_SAFE_INTEGER
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
                name: name,
                type: type,
                books: []
            };
 
            this.subscribers.push(subscriber);
        }  
       
        return subscriber;
    }
 
    unsubscribe(name){
        let subscriber = this.subscribers.find(s => s.name === name);
 
        if (subscriber == undefined) {
            throw new Error(`There is no such subscriber as ${name}`)
        }
 
        this.subscribers = this.subscribers.filter(s => s.name !== name);
 
        return this.subscribers;
    }
 
    receiveBook(name, bookTitle, bookAuthor){
        let subscriber = this.subscribers.find(s => s.name === name);
 
        if (subscriber == undefined) {
            throw new Error(`There is no such subscriber as ${name}`)
        }
 
        let limit = this.subscriptionTypes[subscriber.type];
 
        if (limit === subscriber.books.length) {
            throw new Error(`You have reached your subscription limit ${limit}!`);
        }
 
        let book = {
            title: bookTitle,
            author: bookAuthor
        };
 
        subscriber.books.push(book);
 
        return subscriber;
    }
 
    showInfo (){
        if (this.subscribers.length === 0) {
            return `${this.libraryName} has no information about any subscribers`;
        }
 
        let result = "";
 
        for(const subscriber of this.subscribers){
            result += `Subscriber: ${subscriber.name}, Type: ${subscriber.type}\n`;
 
            let subscriberBooks = [];
            for(const book of subscriber.books){
                subscriberBooks.push(`${book.title} by ${book.author}`);
            }
 
            result += `Received books: ${subscriberBooks.join(', ')}\n`;          
        }
       
        return result;
    }
}