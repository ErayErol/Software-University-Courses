class Rat {
    constructor(name) {
        this.name = name;
        this.unitedRats = [];
    }

    getRats() {
        return this.unitedRats;
    }

    unite(rat) {
        if (typeof rat === "object") {
            this.unitedRats.push(rat);
        }
    }

    toString() {
        let result = this.name;
        if (this.unitedRats.length !== 0) {
            let x = [];
            for (const unitedRat of this.unitedRats) {
                x.push(`##${unitedRat}`);
            }

            return result + '\n' + x.join('\n');
        }

        return result;
    }
}

let firstRat = new Rat("Peter");
console.log(firstRat.toString()); // Peter
 
console.log(firstRat.getRats()); // []

firstRat.unite(new Rat("George"));
firstRat.unite(new Rat("Alex"));
console.log(firstRat.getRats());
// [ Rat { name: 'George', unitedRats: [] },
//  Rat { name: 'Alex', unitedRats: [] } ]

console.log(firstRat.toString());
// Peter
// ##George
// ##Alex

