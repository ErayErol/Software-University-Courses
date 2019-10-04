let expect = require("chai").expect;
let sum = require("../app");

describe('sum', function () {
    
    it("Expect correct sum.", () => {
        let expected = 6;
        let actual = sum([1, 2, 3]);

        expect(actual).to.equal(expected);
    });

    it("Expect 0 when array is empty.", () => {
        let expected = 0;
        let actual = sum([]);

        expect(actual).to.equal(expected);
    });

    it("Expect NaN when some element of array is string.", () => {
        const inputArray = [1, 'two', 3];
        const actual = sum(inputArray);

        expect(actual).to.be.NaN;
    });
});