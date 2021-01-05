const assert = require('chai').assert;
let ChristmasMovies = require('../solution');

describe('ChristmasMovies', function () {
    let res;
    this.beforeEach(function () {
        res = new ChristmasMovies('Some');
    });

    it('should have the correct function properties', function () {
        assert.isFunction(ChristmasMovies.prototype.buyMovie);
        assert.isFunction(ChristmasMovies.prototype.discardMovie);
        assert.isFunction(ChristmasMovies.prototype.watchMovie);
        assert.isFunction(ChristmasMovies.prototype.favouriteMovie);
        assert.isFunction(ChristmasMovies.prototype.mostStarredActor);
    });

    // it('throws', function () {
    //     let actual = function () {
    //         res.buyMovie('Home Alone', 55);
    //     };

    //     let expected = 'Invalid input';

    //     assert.throws(actual, expected);
    // });

    it('throws1', function () {
        let actual = function () {
            res.mostStarredActor();
        };

        let expected = 'You have not watched a movie yet this year!';

        assert.throws(actual, expected);
    });

    it('throws2', function () {
        res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
        res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
        res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone 2');
        res.watchMovie('The Grinch');
        res.watchMovie('Home Alone 2');

        let actual = function () {
            res.discardMovie('Last Christmas');
        };

        let expected = 'Last Christmas is not watched!';

        assert.throws(actual, expected);
    });

    it('throws3', function () {
        res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
        res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
        res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);

        let actual = function () {
            res.watchMovie('JS');
        };

        let expected = 'No such movie in your collection!';

        assert.throws(actual, expected);
    });

    it('throws4', function () {
        res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);

        let actual = function () {
            res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        };

        let expected = 'You already own Home Alone in your collection!';

        assert.throws(actual, expected);
    });

    it('throws5', function () {
        res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
        res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
        res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);

        let actual = function () {
            res.favouriteMovie();
        };

        let expected = 'You have not watched a movie yet this year!';

        assert.throws(actual, expected);
    });

    it('1', function () {
        let actual = res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        let expected = 'You just got Home Alone to your collection in which Macaulay Culkin, Joe Pesci, Daniel Stern are taking part!';

        assert.deepEqual(actual, expected);
    });

    it('2', function () {
        res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
        res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
        res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
        res.watchMovie('Home Alone');

        let actual = res.watched;
        let expected = { 'Home Alone': 1 };

        assert.deepEqual(actual, expected);
    });

    it('3', function () {
        res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
        res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
        res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone 2');
        res.watchMovie('The Grinch');
        res.watchMovie('Last Christmas');
        res.watchMovie('Home Alone 2');
        res.watchMovie('Last Christmas');

        let actual = res.discardMovie('The Grinch');
        let expected = "You just threw away The Grinch!";

        assert.deepEqual(actual, expected);
    });

    it('4', function () {
        res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
        res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
        res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone 2');
        res.watchMovie('The Grinch');
        res.watchMovie('Last Christmas');
        res.watchMovie('Home Alone 2');
        res.watchMovie('Last Christmas');

        res.discardMovie('The Grinch');

        let actual = res.favouriteMovie();
        let expected = 'Your favourite movie is Home Alone and you have watched it 3 times!';

        assert.deepEqual(actual, expected);
    });

    it('5', function () {
        res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
        res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
        res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone 2');
        res.watchMovie('The Grinch');
        res.watchMovie('Last Christmas');
        res.watchMovie('Home Alone 2');
        res.watchMovie('Last Christmas');

        res.discardMovie('The Grinch');
        res.favouriteMovie();

        let actual = res.mostStarredActor();
        let expected = 'The most starred actor is Macaulay Culkin and starred in 2 movies!';

        assert.deepEqual(actual, expected);
    });

    it('6', function () {
        res.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        res.buyMovie('Home Alone 2', ['Macaulay Culkin']);
        res.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
        res.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone');
        res.watchMovie('Home Alone 2');
        res.watchMovie('The Grinch');
        res.watchMovie('Last Christmas');
        res.watchMovie('Home Alone 2');
        res.watchMovie('Last Christmas');
        res.discardMovie('The Grinch');

        let actual = res.movieCollection;
        let expected = [
            {
                name: 'Home Alone',
                actors: ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']
            },
            { name: 'Home Alone 2', actors: ['Macaulay Culkin'] },
            {
                name: 'Last Christmas',
                actors: ['Emilia Clarke', 'Henry Golding']
            }
        ];

        assert.deepEqual(actual, expected);
    });
});