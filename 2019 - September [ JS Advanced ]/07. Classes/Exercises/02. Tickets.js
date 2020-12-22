class Ticket {
    constructor(destination, price, status) {
        this.destination = destination;
        this.price = Number(price);
        this.status = status;
    }

    static sortTickets(tickets, prop) {
        return [...tickets]
            .sort((a, b) => {
                if(typeof a[prop] === 'string') {
                    return a[prop].localeCompare(b[prop]);
                } else {
                    return a[prop] - b[prop];
                }
            })
    }
}

function solve(input, prop) {
    const tickets =  input
        .reduce((prev, line) => {
            let [destination, price, status] = line.split('|');
            let ticket = new Ticket(destination, price, status);
            prev.push(ticket);
            return prev;
        }, []);

    return Ticket.sortTickets(tickets, prop);
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'));