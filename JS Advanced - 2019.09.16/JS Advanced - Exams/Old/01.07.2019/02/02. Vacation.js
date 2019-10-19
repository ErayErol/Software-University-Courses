class Vacation {
    constructor(organizer, destination, budget) {
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }

    get numberOfChildren() {
        this._numberOfChildren = 0;

        for (const grade in this.kids) {
            this._numberOfChildren += this.kids[grade].length;
        }

        return this._numberOfChildren;
    }

    registerChild(name, grade, budget) {
        if (budget < this.budget) {
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }

        if (this.kids.hasOwnProperty(grade) == false) {
            this.kids[grade] = [];
        }

        const index = this.kids[grade].findIndex(k => k.startsWith(name));

        if (index > -1) {
            return `${name} is already in the list for this ${this.destination} vacation.`;
        }

        this.kids[grade].push(`${name}-${budget}`);
        return this.kids[grade];
    }

    removeChild(name, grade) {
        if (this.kids.hasOwnProperty(grade)) {
            const index = this.kids[grade].findIndex(k => k.startsWith(name));

            if (index > -1) {
                this.kids[grade].splice(index, 1);
                return this.kids[grade];
            }
        }

        return `We couldn't find ${name} in ${grade} grade.`;
    }

    toString() {
        let result = '';

        if (this.numberOfChildren > 0) {
            result += `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;

            for (const grade in this.kids) {
                result += `Grade: ${grade}\n`;

                for (let i = 0; i < this.kids[grade].length; i++) {
                    result += `${i + 1}. ${this.kids[grade][i]}\n`;
                }
            }

        } else {
            result = `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`
        }

        return result;
    }
}

let vacation = new Vacation('Miss. Elizabeth', 'The bahamas', 400);

vacation.registerChild('Skaro', 11, 400);
vacation.registerChild('Pesho', 12, 400);
vacation.registerChild('Gosho', 11, 3444);
vacation.registerChild('Pesho', 12, 400);
vacation.registerChild('Gosho', 1, 3400);

let output = vacation.toString();
console.log(output);
