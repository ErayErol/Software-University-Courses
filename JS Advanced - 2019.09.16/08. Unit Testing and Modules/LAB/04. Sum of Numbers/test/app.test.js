const assert = require('chai').assert;
let createCalculator = require("../app");

describe('Add or Subtract Tests', function () {
    let calculator;

    beforeEach(function () {
        calculator = createCalculator();
    });

    it('should return an object with add, subtract and get properties', function () {
        assert.property(calculator, 'add');
        assert.property(calculator, 'subtract');
        assert.property(calculator, 'get');
    });

    it('should have closure with internal sum 0', function () {
        const expected = 0;
        const actual = calculator.get();

        assert.equal(actual, expected);
    });

    it('should not be able to modify the internal sum', function () {
        calculator.value -= 1;

        const expected = 0;
        const actual = calculator.get();

        assert.equal(actual, expected);
    });

    it('function add should take parsable argument', function () {
        assert.doesNotThrow(() => calculator.add(5));
        assert.doesNotThrow(() => calculator.add('5'));
    });

    it('function add should add the value', function () {
        calculator.add(5);

        const expected = 5;
        const actual = calculator.get();

        assert.equal(actual, expected);
    });

    it('function add should return NaN when not containing a number string is given', function () {
        calculator.add('ten');

        const actual = calculator.get();

        assert.isNaN(actual);
    });

    it('function subtract should take parsable argument', function () {
        assert.doesNotThrow(() => calculator.subtract(5));
        assert.doesNotThrow(() => calculator.subtract('5'));
    });

    it('function subtract should subtract the value', function () {
        calculator.subtract(10);

        const expected = -10;
        const actual = calculator.get();

        assert.equal(actual, expected);
    });

    it('function subtract should return NaN when not containing a number string is given', function () {
        calculator.subtract('ten');

        const actual = calculator.get();

        assert.isNaN(actual);
    });

    it('should do proper calculations with given numbers and numbers as strings', function () {
        calculator.add(4);
        calculator.add('3');
        calculator.subtract(3);
        calculator.subtract('2');

        const expected = 2;
        const actual = calculator.get();

        assert.equal(actual, expected);
    });
});