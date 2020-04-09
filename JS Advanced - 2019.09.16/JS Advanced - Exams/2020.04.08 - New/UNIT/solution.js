class Repository {
    constructor(props) {
        this.props = props;
        this.data = new Map();

        let id = 0;
        this.nextId = function () {
            return id++;
        }
    }

    get count() {
        return this.data.size;
    }

    add(entity) {
        this._validate(entity);
        let id = this.nextId();
        this.data.set(id, entity);
        return id;
    }

    getId(id) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        return this.data.get(id);
    }

    update(id, newEntity) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        this._validate(newEntity);
        this.data.set(id, newEntity);
    }

    del(id) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        this.data.delete(id);
    }

    _validate(entity) {
        //Validate existing property
        for (let propName in this.props) {
            if (!entity.hasOwnProperty(propName)) {
                throw new Error(`Property ${propName} is missing from the entity!`);
            }
        }

        //Validate property type
        for (let propName in entity) {
            let val = entity[propName];
            if (typeof val !== this.props[propName]) {
                throw new TypeError(`Property ${propName} is not of correct type!`);
            }
        }
    }
}

module.exports = { Repository };

// Initialize props object
let properties = {
    name: "string",
    age: "number",
    birthday: "object"
};
//Initialize the repository
let res = new Repository(properties);

// Add two entities
let entity = {
    name: "Pesho",
    age: 22,
    birthday: new Date(1998, 0, 7)
};
res.add(entity); // Returns 0
console.log(res);

res.add(entity); // Returns 1
console.log(res.getId(0));
// {"name":"Pesho","age":22,"birthday":"1998-01-06T22:00:00.000Z"}
console.log(res.getId(1));
// {"name":"Pesho","age":22,"birthday":"1998-01-06T22:00:00.000Z"}
//Update an entity
entity = {
    name: 123,
    age: 22,
    birthday: new Date(1998, 0, 7)
};
// res.update(1, entity);
console.log(res.getId(1));
// {"name":"Gosho","age":22,"birthday":"1998-01-06T22:00:00.000Z"}
// Delete an entity
console.log(res.del(0),);
console.log(res.count); // Returns 1
let anotherEntity = {
    name1: 'Stamat',
    age: 29,
    birthday: new Date(1991, 0, 21)
};
// res.add(anotherEntity); // should throw an Error
anotherEntity = {
    name: 'Stamat',
    age: 29,
    birthday: 1991
};
// res.add(anotherEntity); // should throw a TypeError
// res.del(-1); // should throw Error for invalid id