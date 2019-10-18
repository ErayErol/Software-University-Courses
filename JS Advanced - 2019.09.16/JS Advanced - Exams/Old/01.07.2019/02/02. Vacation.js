class Vacation {
    constructor(organizer, destination, budget) {
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }
    
    registerChild(name, grade, budget) {
        if (budget < this.budget) {
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }
        
        let names = [];
        Object.values(this.kids).forEach(function (key, value) {
            for (let i = 0; i < key.length; i++) {
                let split = key[i].split('-');
                let currName = split[0];
                names.push(currName);
            }
        });
        
        if (names.includes(name)) { // has name
            if (this.kids.hasOwnProperty(grade)) { // has grade
                return `${name} is already in the list for this ${this.destination} vacation.`;
            } else { // has name && hasn't grade
                this.kids[grade] = [];
                this.kids[grade].push(`${name}-${budget}`);
            }
        } else {
            if (this.kids.hasOwnProperty(grade)) { // has grade && hasn't name
                this.kids[grade].push(`${name}-${budget}`);
            } else { // hasn't grade && hasn't name
                this.kids[grade] = [];
                this.kids[grade].push(`${name}-${budget}`);
            }
        }
        
        return `[ ${this.kids[grade].join(', ')} ]`;
    }

    removeChild(name, grade){
        let names = [];
        Object.values(this.kids).forEach(function (key, value) {
            for (let i = 0; i < key.length; i++) {
                let split = key[i].split('-');
                let currName = split[0];
                names.push(currName);
            }
        });

        if (names.includes(name) == false) {
            return `We couldn't find ${name} in ${grade} grade.`;
        }else {
            if (this.kids.hasOwnProperty(grade) == false) {
                return `We couldn't find ${name} in ${grade} grade.`;
            }

            for (let i = 0; i < this.kids[grade].length; i++) {
                let student = this.kids[grade][i];
                let split = student.split('-');
                let studentName = split[0];

                if (studentName === name) {
                    this.kids[grade].splice(i, 1);
                    return `[ ${this.kids[grade].join(', ')} ]`;
                }
                
            }
        }
    }
}

let vacation = new Vacation('Mr Pesho', 'San diego', 2000);
vacation.registerChild('Gosho', 5, 2000);
vacation.registerChild('Lilly', 6, 2100);

console.log(vacation.removeChild('Gosho', 9));

vacation.registerChild('Pesho', 6, 2400);
vacation.registerChild('Gosho', 5, 2000);

console.log(vacation.removeChild('Lilly', 6));
console.log(vacation.registerChild('Tanya', 5, 6000))


// We couldn't find Gosho in 9 grade.
// [ 'Pesho-2400' ]
// [ 'Gosho-2000', 'Tanya-6000' ]