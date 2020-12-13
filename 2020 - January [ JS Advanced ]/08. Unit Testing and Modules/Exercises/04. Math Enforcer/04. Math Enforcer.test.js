const mathEnforcer = require('./04. Math Enforcer');
const assert = require('chai').assert;

describe('mathEnforcer Tests', function () {
    describe('addFive Тests', function () {
        it('addFive function should return undefined if the parameter is not a number', function () {
            assert.isUndefined(mathEnforcer.addFive('2'));
            assert.isUndefined(mathEnforcer.addFive(true));
            assert.isUndefined(mathEnforcer.addFive([]));
            assert.isUndefined(mathEnforcer.addFive({}));
        });

        it('addFive function should add 5 to positive numbers', function () {
            const number = 5;

            const expected = number + 5;
            const actual = mathEnforcer.addFive(number);

            assert.equal(actual, expected);
        });

        it('addFive function should add 5 to negative numbers', function () {
            const number = -10;

            const expected = number + 5;
            const actual = mathEnforcer.addFive(number);

            assert.equal(actual, expected);
        });

        it('addFive function should add 5 to decimal numbers', function () {
            const number = 3.5;

            const expected = number + 5;
            const actual = mathEnforcer.addFive(number);

            assert.closeTo(actual, expected, 0.01);
        });
    });

    describe('subtractTen Тests', function () {
        it('subtractTen function should return undefined if the parameter is not a number', function () {
            assert.isUndefined(mathEnforcer.subtractTen('2'));
            assert.isUndefined(mathEnforcer.subtractTen(true));
            assert.isUndefined(mathEnforcer.subtractTen([]));
            assert.isUndefined(mathEnforcer.subtractTen({}));
        });

        it('subtractTen function should subtract 10 from positive numbers', function () {
            const number = 15;

            const expected = number - 10;
            const actual = mathEnforcer.subtractTen(number);

            assert.equal(actual, expected);
        });

        it('subtractTen function should subtract 10 from negative numbers', function () {
            const number = -10;

            const expected = number - 10;
            const actual = mathEnforcer.subtractTen(number);

            assert.equal(actual, expected);
        });

        it('subtractTen function should subtract 10 from decimal numbers', function () {
            const number = 5.5;

            const expected = number - 10;
            const actual = mathEnforcer.subtractTen(number);

            assert.closeTo(actual, expected, 0.01);
        });
    });

    describe('sum Тests', function () {
        it('subtractTen function should return undefined if some of the parameters is not a number', function () {
            assert.isUndefined(mathEnforcer.sum('2', 3));
            assert.isUndefined(mathEnforcer.sum(3, true));
            assert.isUndefined(mathEnforcer.sum([], {}));
        });

        it('sum function should sum positive numbers', function () {
            const firstNumber = 5;
            const secondNumber = 10;

            const expected = firstNumber + secondNumber;
            const actual = mathEnforcer.sum(firstNumber, secondNumber);

            assert.equal(actual, expected);
        });

        it('sum function should sum negative numbers', function () {
            const firstNumber = -5;
            const secondNumber = -3;

            const expected = firstNumber + secondNumber;
            const actual = mathEnforcer.sum(firstNumber, secondNumber);

            assert.equal(actual, expected);
        });

        it('sum function should sum decimal numbers', function () {
            const firstNumber = 5.5;
            const secondNumber = 4.5;

            const expected = firstNumber + secondNumber;
            const actual = mathEnforcer.sum(firstNumber, secondNumber);

            assert.closeTo(actual, expected, 0.01);
        });
    });
});