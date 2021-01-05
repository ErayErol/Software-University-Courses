const lookupChar = require('./03. Char Lookup');
const assert = require('chai').assert;

describe('lookupChar Tests', function () {
    it('should return undefined if the first parameter is not a string', function () {
        assert.isUndefined(lookupChar([], 1));
    });

    it('should return undefined if the second parameter is not a number', function () {
        assert.isUndefined(lookupChar('text', true));
    });

    it('should return the correct string if the second parameter is not integer', function () {
        assert.isUndefined(lookupChar('text', 3.5));
    });

    it('should return the correct string if the index is equal or bigger than the string length', function () {
        const expected = 'Incorrect index';
        const actual = lookupChar('text', 4);

        assert.equal(actual, expected);
    });

    it('should return the correct string if the index is negative', function () {
        const expected = 'Incorrect index';
        const actual = lookupChar('text', -1);

        assert.equal(actual, expected);
    });

    it('should return the correct character if both parameters are valid', function () {
        const expected = 'e';
        const actual = lookupChar('text', 1);

        assert.equal(actual, expected);
    });
});