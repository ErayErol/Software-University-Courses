const assert = require('chai').assert;
let Parser = require('../solution');

describe('ChristmasMovies', function () {
    let res;
    this.beforeEach(function () {
        res = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
    });

    it('should have the correct function properties', function () {
        assert.isFunction(Parser.prototype.print);
        assert.isFunction(Parser.prototype.addEntries);
        assert.isFunction(Parser.prototype.removeEntry);
        assert.isFunction(Parser.prototype._addToLogInitial);
    });

    // it('throws', function () {
    //     let actual = function () {
    //         res.buyMovie('Home Alone', 55);
    //     };

    //     let expected = 'Invalid input';

    //     assert.throws(actual, expected);
    // });

    // it('throws1', function () {
    //     let actual = function () {
    //         res.mostStarredActor();
    //     };

    //     let expected = 'You have not watched a movie yet this year!';

    //     assert.throws(actual, expected);
    // });

    it('throws2', function () {
        res.addEntries("Steven:tech-support Edd:administrator")

        let actual = function () {
            res.removeEntry("JS");
        };

        let expected = 'There is no such entry!';

        assert.throws(actual, expected);
    });

    // it('throws3', function () {
    //     res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
    //     res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
    //     res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
    //     res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);

    //     let actual = function () {
    //         res.watchMovie('JS');
    //     };

    //     let expected = 'No such movie in your collection!';

    //     assert.throws(actual, expected);
    // });

    // it('throws4', function () {
    //     res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);

    //     let actual = function () {
    //         res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
    //     };

    //     let expected = 'You already own Home Alone in your collection!';

    //     assert.throws(actual, expected);
    // });

    // it('throws5', function () {
    //     res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
    //     res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
    //     res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
    //     res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);

    //     let actual = function () {
    //         res.favouriteMovie();
    //     };

    //     let expected = 'You have not watched a movie yet this year!';

    //     assert.throws(actual, expected);
    // });

    it('1', function () {
        let actual = res.addEntries("Steven:tech-support Edd:administrator");
        let expected = 'Entries added!';

        assert.deepEqual(actual, expected);
    });

    it('2', function () {
        res.addEntries("Steven:tech-support Edd:administrator");

        let actual = res.data;
        let expected = [
            { Nancy: 'architect' },
            { John: 'developer' },
            { Kate: 'HR' },
            { Steven: 'tech-support' },
            { Edd: 'administrator' }
        ];

        assert.deepEqual(actual, expected);
    });

    it('3', function () {
        res.addEntries("Steven:tech-support Edd:administrator");

        let actual = res.removeEntry("Kate");
        let expected = "Removed correctly!";

        assert.deepEqual(actual, expected);
    });

    it('4', function () {
        res.addEntries("Steven:tech-support Edd:administrator");
        res.removeEntry("Kate");

        let actual = res.data;
        let expected = [
            { Nancy: 'architect' },
            { John: 'developer' },
            { Steven: 'tech-support' },
            { Edd: 'administrator' }
        ];

        assert.deepEqual(actual, expected);
    });

    it('5', function () {
        res.addEntries("Steven:tech-support Edd:administrator");
        res.removeEntry("Kate");

        let actual = res.print();
        let expected = "id|name|position\n0|Nancy|architect\n1|John|developer\n2|Steven|tech-support\n3|Edd|administrator";

        assert.deepEqual(actual, expected);
    });

    // it('6', function () {
    //     res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
    //     res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
    //     res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
    //     res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
    //     res.watchMovie('Home Alone');
    //     res.watchMovie('Home Alone');
    //     res.watchMovie('Home Alone');
    //     res.watchMovie('Home Alone 2');
    //     res.watchMovie('The Grinch');
    //     res.watchMovie('Last Christmas');
    //     res.watchMovie('Home Alone 2');
    //     res.watchMovie('Last Christmas');
    //     res.discardMovie('The Grinch');

    //     let actual = res.movieCollection;
    //     let expected = [
    //         {
    //             name: 'Home Alone',
    //             actors: ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']
    //         },
    //         { name: 'Home Alone 2', actors: ['Macaulay Culkin'] },
    //         {
    //             name: 'Last Christmas',
    //             actors: ['Emilia Clarke', 'Henry Golding']
    //         }
    //     ];

    //     assert.deepEqual(actual, expected);
    // });
});