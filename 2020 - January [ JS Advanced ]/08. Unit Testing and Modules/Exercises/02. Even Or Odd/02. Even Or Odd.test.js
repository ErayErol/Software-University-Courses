const isOddOrEven = require('./02. Even Or Odd');
const assert = require('chai').assert;

describe('isOddOrEven Tests', function () {
    it('should return undefined if input is not a string', function () {
        assert.isUndefined(isOddOrEven(true));
        assert.isUndefined(isOddOrEven(3));
        assert.isUndefined(isOddOrEven([]));
        assert.isUndefined(isOddOrEven({}));
    });

    it('should return even if string length is even', function () {
        const expected = 'even';
        const actual = isOddOrEven('even');

        assert.equal(actual, expected);
    });

    it('should return odd if string length is odd', function () {
        const expected = 'odd';
        const actual = isOddOrEven('odd');

        assert.equal(actual, expected);
    });
});