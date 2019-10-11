function solve(arr, sorting) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (const line of arr) {
        let part = line.split('|');
        let ticket = new Ticket(part[0], Number(part[1]), part[2]);
        tickets.push(ticket);
    }

    let sort = [];

    if (sorting === 'destination') {
        sort = tickets.sort((a, b) => {
            return a.destination.localeCompare(b.destination);
        });
    } else if (sorting === 'price') {
        sort = tickets.sort((a, b) => {
            return a.price - b.price;
        });
    } else if (sorting === 'status') {
        sort = tickets.sort((a, b) => {
            return a.status.localeCompare(b.status);
        });
    }

    return sort;
}

solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
);