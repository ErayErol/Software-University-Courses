class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        let { firstName, lastName, personalId } = customer;
        let currCustomer = this.allCustomers.find(c => c.personalId === personalId);
        if (currCustomer) {
            throw new Error(`${firstName} ${lastName} is already our customer!`);
        }
        let newCustomer = {
            firstName,
            lastName,
            personalId,
        };
        this.allCustomers.push(newCustomer);
        return newCustomer;
    }

    depositMoney (personalId, amount){
        let currCustomer = this.allCustomers.find(c => c.personalId === personalId);
        if (!currCustomer) {
            throw new Error(`We have no customer with this ID!`);
        }
        if (currCustomer.hasOwnProperty("totalMoney") === false) {
            currCustomer.totalMoney = 0;    
        }
        currCustomer.totalMoney += amount;
        if (currCustomer.hasOwnProperty("transactions") === false) {
            currCustomer.transactions = [];    
            currCustomer.tNum = 1;
        }
        let newTransaction = `${currCustomer.tNum++}. ${currCustomer.firstName} ${currCustomer.lastName} made depostit of ${amount}$!`;
        currCustomer.transactions.unshift(newTransaction);
        return `${currCustomer.totalMoney}$`;
    }

    withdrawMoney (personalId, amount){
        let currCustomer = this.allCustomers.find(c => c.personalId === personalId);
        if (!currCustomer) {
            throw new Error(`We have no customer with this ID!`);
        }
        if (currCustomer.totalMoney >= amount) { // check
            currCustomer.totalMoney -= amount;
            let newTransaction = `${currCustomer.tNum++}. ${currCustomer.firstName} ${currCustomer.lastName} withdrew ${amount}$!`;
            currCustomer.transactions.unshift(newTransaction);
            return `${currCustomer.totalMoney}$`;
        }
        
        throw new Error(`${currCustomer.firstName} ${currCustomer.lastName} does not have enough money to withdraw that amount!`);
    }

    customerInfo (personalId){
        let customer = this.allCustomers.find(c => c.personalId === personalId);
        if (!customer) {
            throw new Error(`We have no customer with this ID!`);
        }

        let x = [];
        x.push(`Bank name: ${this._bankName}`);
        x.push(`Customer name: ${customer.firstName} ${customer.lastName}`);
        x.push(`Customer ID: ${customer.personalId}`);
        x.push(`Total Money: ${customer.totalMoney}$`);
        x.push(`Transactions:`);

        customer.transactions.forEach((transaction) => {
            x.push(transaction);
        });

        return x.join("\n");
    }
}


let bank = new Bank("SoftUni Bank");
console.log(bank.newCustomer({ firstName: "Svetlin", lastName: "Nakov", personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: "Mihaela", lastName: "Mileva", personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));


// { firstName: ‘Svetlin", lastName: ‘Nakov", personalId: 6233267 } 
// { firstName: ‘Mihaela", lastName: ‘Mileva", personalId: 4151596 }
// 500$
// 375$
// Bank name: SoftUni Bank
// Customer name: Svetlin Nakov
// Customer ID: 6233267
// Total Money: 375$
// Transactions:
// 3. Svetlin Nakov withdrew 125$!
// 2. Svetlin Nakov made depostit of 250$!
// 1. Svetlin Nakov made depostit of 250$!
