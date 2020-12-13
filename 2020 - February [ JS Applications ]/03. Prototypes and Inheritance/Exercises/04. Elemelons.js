function solve() {
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new Error('Abstract class cannot be instantiated directly');
            }
            this.weight = weight;
            this.melonSort = melonSort;
            this.element = this.constructor.name.slice(0, -5);
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }

        toString() {
            return `Element: ${this.element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }

    class Melolemonmelon extends Watermelon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = Watermelon.name.slice(0, -5);
            this.elements = ['Fire', 'Earth', 'Air', 'Water'];
        }

        morph() {
            let element = this.elements.shift();
            this.element = element;
            this.elements.push(element);
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Earthmelon,
        Airmelon,
        Melolemonmelon,
    };
}

let create = solve();

let water = new create.Watermelon(869.75, 'Shark');
console.log(water.toString());

let fire = new create.Firemelon(9999999.99, 'Dragon');
console.log(fire.toString());

let earth = new create.Earthmelon(37.42, 'Wolf');
console.log(water.toString());

let air = new create.Airmelon(0.35, 'Football Ball');
console.log(water.toString());

let melolemon = new create.Melolemonmelon(12.5, "Kingsize");
console.log(melolemon.toString());

melolemon.morph();
console.log(melolemon.toString());