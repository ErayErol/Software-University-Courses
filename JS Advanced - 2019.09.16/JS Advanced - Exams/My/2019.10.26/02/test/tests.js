const assert = require('chai').assert;
let SkiResort = require('../solution');

describe('SkiResort', function () {
    let res;
    this.beforeEach(function () {
        res = new SkiResort('Some');
    });

    it('should have the correct function properties', function () {
        assert.isFunction(SkiResort.prototype.build);
        assert.isFunction(SkiResort.prototype.book);
        assert.isFunction(SkiResort.prototype.leave);
        assert.isFunction(SkiResort.prototype.averageGrade);
    });

    it('throws', function () {
        let actual = function () {
            res.build('JS', -5);
        };

        let expected = 'Invalid input';

        assert.throws(actual, expected);
    });

    it('throws2', function () {
        let actual = function () {
            res.leave('JSss', 3, 2);
        };

        let expected = 'There is no such hotel';

        assert.throws(actual, expected);
    });

    it('throws3', function () {
        let actual = function () {
            res.book('JSsssssss', 4);
        };

        let expected = 'There is no such hotel';

        assert.throws(actual, expected);
    });

    it('throws4', function () {
        let actual = function () {
            res.book('JS', -5);
        };

        let expected = 'Invalid input';

        assert.throws(actual, expected);
    });

    it('throws4', function () {
        res.build("Sun", 10);

        let actual = function () {
            res.book('Sun', 15);
        };

        let expected = 'There is no free space';

        assert.throws(actual, expected);
    });

    it('throws5', function () {
        let actual = function () {
            res.leave('', 3, 2);
        };

        let expected = 'Invalid input';

        assert.throws(actual, expected);
    });

    it('1', function () {
        let actual = res.build("Sun", 10);
        let expected = 'Successfully built new hotel - Sun';

        assert.deepEqual(actual, expected);
    });

    it('2', function () {
        res.build("Sun", 10);
        res.build('Avenue', 5);
        res.book('Sun', 5);

        let actual = res.book('Sun', 5);
        let expected = 'Successfully booked';

        assert.deepEqual(actual, expected);
    });

    it('3', function () {
        res.build("Sun", 10);
        res.build('Avenue', 5);
        res.book('Sun', 5);
        res.book('Avenue', 5);

        let actual = res.leave('Sun', 3, 2);
        let expected = '3 people left Sun hotel';

        assert.deepEqual(actual, expected);
    });

    it('4', function () {
        res.build("Sun", 10);
        res.build('Avenue', 5);
        res.book('Sun', 5);
        res.book('Avenue', 5);
        res.leave('Sun', 3, 2);
        res.leave('Avenue', 3, 3);
        res.book('Avenue', 3);
        res.leave('Avenue', 3, 0.5);

        let actual = res.averageGrade()
        let expected = 'Average grade: 1.83';

        assert.deepEqual(actual, expected);
    });

    it('5', function () {
        res.build("Sun", 10);
        res.build('Avenue', 5);
        res.book('Sun', 5);
        res.book('Avenue', 5);
        res.leave('Sun', 3, 2);
        res.leave('Avenue', 3, 3);
        res.book('Avenue', 3);
        res.leave('Avenue', 3, 0.5);

        let actual = res.bestHotel;
        let expected = 'Best hotel is Avenue with grade 10.5. Available beds: 3';

        assert.deepEqual(actual, expected);
    });

    it('6', function () {
        let r = new SkiResort("a");
        let actual = r.bestHotel;
        let expected = 'No votes yet';

        assert.deepEqual(actual, expected);
    });
});
