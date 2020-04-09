const assert = require('chai').assert;
let { Repository } = require('../solution');

describe('Repository', function () {
    let res;
    this.beforeEach(function () {
        //Initialize the repository
        let properties = {
            name: "string",
            age: "number",
            birthday: "object"
        };
        res = new Repository(properties);
    });

    it('should have the correct function properties', function () {
        assert.isFunction(Repository.prototype.add);
        assert.isFunction(Repository.prototype.getId);
        assert.isFunction(Repository.prototype.update);
        assert.isFunction(Repository.prototype.del);
        assert.isFunction(Repository.prototype._validate);
    });

    it('throws1', function () {
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1

        let actual = function () {
            res.getId(4);
        };

        let expected = `Entity with id: ${4} does not exist!`;

        assert.throws(actual, expected);
    });

    it('throws2', function () {
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1

        let actual = function () {
            res.update(5, entity);
        };

        let expected = `Entity with id: ${5} does not exist!`;

        assert.throws(actual, expected);
    });

    it('throws3', function () {
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1

        let actual = function () {
            res.del(6);
        };

        let expected = `Entity with id: ${6} does not exist!`;

        assert.throws(actual, expected);
    });

    it('throws4', function () {
        let entity = {
            name: "Pesho",
            age: "22",
            birthday: new Date(1998, 0, 7)
        };

        let actual = function () {
            res._validate(entity)
        };

        let expected = `Property age is not of correct type!`;

        assert.throws(actual, expected);
    });

    it('throws4', function () {
        let actual = function () {
            res.del(-1)
        };

        let expected = `Entity with id: -1 does not exist!`;

        assert.throws(actual, expected);
    });

    it('throws5', function () {
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1
        //Update an entity
        entity = {
            name: 123,
            age: 22,
            birthday: new Date(1998, 0, 7)
        };

        let actual = function () {
            res.update(1, entity);
        };

        let expected = `Property name is not of correct type!`;

        assert.throws(actual, expected);
    });

    it('throws6', function () { //
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1

        let actual = function () {
            res.getId("erol");
        };

        let expected = `Entity with id: erol does not exist!`;

        assert.throws(actual, expected);
    });

    it('throws7', function () { 
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1
        entity = {
            name: 123,
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.del(0);
        let anotherEntity = {
            name1: 'Stamat',
            age: 29,
            birthday: new Date(1991, 0, 21)
        };

        let actual = function () {
            res.add(anotherEntity);
        };

        let expected = `Property name is missing from the entity!`;

        assert.throws(actual, expected);
    });

    it('throws77', function () { 
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1
        entity = {
            name: 123,
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.del(0);
        let anotherEntity = {
            name: 'Stamat',
            age2: 29,
            birthday: new Date(1991, 0, 21)
        };

        let actual = function () {
            res.add(anotherEntity);
        };

        let expected = `Property age is missing from the entity!`;

        assert.throws(actual, expected);
    });

    it('throws8', function () { 
        anotherEntity = {
            name: 'Stamat',
            age: 29,
            birthday: 1991
        };
        
        let actual = function () {
            res.add(anotherEntity);
        };

        let expected = `Property birthday is not of correct type!`;

        assert.throws(actual, expected);
    });

    it('throws8', function () { 
        anotherEntity = {
            name: 'Stamat',
            age: 29,
            birthday: 1991
        };
        
        let actual = function () {
            res.add(anotherEntity);
        };

        let expected = `Property birthday is not of correct type!`;

        assert.throws(actual, expected);
    });

    it('0', function () {
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1
        entity = {
            name: 123,
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        // Delete an entity
        res.del(0);
        let actual = res.data.size;
        let expected = 1;

        assert.deepEqual(actual, expected);
    });

    it('1', function () {
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1

        let actual = res.getId(0);
        let expected = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };

        assert.deepEqual(actual, expected);
    });

    it('2', function () {
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1
        entity = {
            name: 'Gosho',
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        res.update(1, entity);
        res.del(0)
        let actual = res.count;
        let expected = 1;

        assert.deepEqual(actual, expected);
    });

    it('3', function () {
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1

        let actual = res._validate(res.getId(1));
        let expected = undefined;

        assert.deepEqual(actual, expected);
    });

    it('3', function () {
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        
        res.add(entity); // Returns 0
        res.add(entity); // Returns 1

        let actual = res.del(0);
        let expected = undefined;

        assert.deepEqual(actual, expected);
    });
});