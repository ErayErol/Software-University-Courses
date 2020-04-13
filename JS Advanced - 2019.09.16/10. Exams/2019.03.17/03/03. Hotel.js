class Hotel {
    constructor(name, capacity) {
        this.name = name;
        if (capacity >= 10) {
            this.capacity = Number(capacity);
        }
        this.bookings = [];
        this.currentBookingNumber = 1;
        this.roomsCapacity = {
            single: Number(50 / 100 * this.capacity),
            double: Number(30 / 100 * this.capacity),
            maisonette: Number(20 / 100 * this.capacity),
        };
    }

    get roomsPricing() {
        return {
            single: 50,
            double: 90,
            maisonette: 135
        };
    }

    get servicesPricing() {
        return {
            food: 10,
            drink: 15,
            housekeeping: 25
        };
    }

    rentARoom(clientName, roomType, nights) {
        let roomNumber = this.roomsCapacity[roomType];

        if (roomNumber > 0) {
            let bookingNumber = this.currentBookingNumber;
            let clientBooking = {
                clientName,
                roomType,
                nights,
                bookingNumber
            };

            this.bookings.push(clientBooking);

            (this.roomsCapacity[roomType] === 0)
                ? this.roomsCapacity[roomType] = 1
                : this.roomsCapacity[roomType]--;

            return `Enjoy your time here Mr./Mrs. ${clientName}. Your booking is ${this.currentBookingNumber++}.`;
        }

        let result = `No ${roomType} rooms available!`;

        let roomsCapacity = this.roomsCapacity;
        Object.keys(roomsCapacity).forEach(function (key) {
            let rooms = roomsCapacity[key];
            if (rooms > 0) {
                result += ` Available ${key} rooms: ${rooms}.`;
            }
        });

        return result;
    }

    roomService(currentBookingNumber, serviceType) {
        let currentRoom = this.bookings
        .filter(x => x.bookingNumber === currentBookingNumber);

        if (currentRoom.length === 0) {
            return `The booking ${currentBookingNumber} is invalid.`;
        }

        if (this.servicesPricing[serviceType]) {
            let client = this.bookings.find(c => c.bookingNumber == currentBookingNumber);
            if (client.hasOwnProperty('services') == false) {
                client.services = [];
            }

            client.services.push(serviceType);

            return `Mr./Mrs. ${client.clientName}, Your order for ${serviceType} service has been successful.`;
        }

        return `We do not offer ${serviceType} service.`;
    }

    checkOut(currentBookingNumber) {
        let client = this.bookings.find(c => c.bookingNumber == currentBookingNumber);

        if (client) {
            this.roomsCapacity[client.bookingNumber]++;

            let totalMoney = this.roomsPricing[client.roomType] * Number(client.nights);

            if (client.services) {
                let totalServiceMoney = 0;

                client.services.forEach(x => totalServiceMoney += this.servicesPricing[x]);

                return `We hope you enjoyed your time here, Mr./Mrs. ${client.clientName}. The total amount of money you have to pay is ${totalMoney + totalServiceMoney} BGN. You have used additional room services, costing ${totalServiceMoney} BGN.`;
            }

            return `We hope you enjoyed your time here, Mr./Mrs. ${client.clientName}. The total amount of money you have to pay is ${totalMoney} BGN.`;
        }

        return `The booking ${currentBookingNumber} is invalid.`;
    }

    report() {
        if (this.bookings.length === 0) {
            return `${this.name.toUpperCase()} DATABASE:\n--------------------\nThere are currently no bookings.`;
        }

        let output = [];

        this.bookings.forEach((c) => {
            let x = [];
            x.push(`bookingNumber - ${c.bookingNumber}`);
            x.push(`clientName - ${c.clientName}`);
            x.push(`roomType - ${c.roomType}`);
            x.push(`nights - ${c.nights}`);

            if (c.services) {
                x.push(`services: ${c.services.join(', ')}`);
            }

            output.push(x.join('\n'));
        });

        return `${this.name.toUpperCase()} DATABASE:\n--------------------\n` + output.join('\n----------\n');
    }
}

let hotel = new Hotel('HotUni', 10);

hotel.rentARoom('Peter', 'single', 4);
hotel.rentARoom('Robert', 'double', 4);
hotel.rentARoom('Geroge', 'maisonette', 6);

hotel.roomService(3, 'housekeeping');
hotel.roomService(3, 'drink');
hotel.roomService(2, 'room');

console.log(hotel.report());