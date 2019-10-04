let expect = require("chai").expect;
let isSymmetric = require("../app");

describe('isSymmetric', function () {
    
    it('Return true when input is array and symmetric.', () => {
        let actual = isSymmetric([1, 2, 'symmetric', 2, 1]);
        expect(actual).to.equal(true);
    });

    it('Return false when input is not array.', () => {
        let actual = isSymmetric({ foo: 'bar' });
        expect(actual).to.equal(false);
    });

    it('Return false when input array is not symmetric.', () => {
        let actual = isSymmetric([1, 2, 3, 4, 5]);
        expect(actual).to.equal(false);
    });

    it('Return true with array of undefined and null.', () => {
        let actual = isSymmetric([undefined, null]);
        expect(actual).to.be.true;
    });

    it('Return false with array of number 1 and string 1.', () => {
        let expected = false;
        let actual = isSymmetric([1, '1']);

        expect(actual).to.equal(expected);
    });
});