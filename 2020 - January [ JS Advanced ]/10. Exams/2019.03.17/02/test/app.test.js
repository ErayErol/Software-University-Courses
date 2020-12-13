const assert = require('chai').assert;
const FilmStudio = require('../filmStudio');

describe('AutoService', function () {

    let filmStudio;
    this.beforeEach(function () {
        filmStudio = new FilmStudio('SU-Studio');
    });

    // it('should have the correct function properties', function () {
    //     assert.isFunction(FilmStudio.prototype.casting);
    //     assert.isFunction(FilmStudio.prototype.makeMovie);
    //     assert.isFunction(FilmStudio.prototype.lookForProducer);
    // });

    it('1', function () {
        filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Hulk', 'Arrow guy', 'Ant-man']);
        filmStudio.makeMovie('The New Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy', 'Black Panther']);

        let actual = filmStudio.lookForProducer('The Avengers');
        let expected = 'Film name: The Avengers\nCast:\nfalse as Iron-Man\nfalse as Hulk\nfalse as Arrow guy\nfalse as Ant-man\n';

        assert.deepEqual(actual, expected);
    });

    it('2', function () {
        let actual = filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
        let expected = {
            filmName: 'The Avengers',
            filmRoles: [
                { role: 'Iron-Man', actor: false },
                { role: 'Thor', actor: false },
                { role: 'Hulk', actor: false },
                { role: 'Arrow guy', actor: false }
            ]
        };

        assert.deepEqual(actual, expected);
    });

    it('3', function () {
        let actual = (filmStudio.casting('Eray', 'Batman'));
        let expected = 'There are no films yet in SU-Studio.';

        assert.deepEqual(actual, expected);
    });

    it('4', function () {
        filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);

        let actual = (filmStudio.casting('Eray', 'Hulk'));
        let expected = 'You got the job! Mr. Eray you are next Hulk in the The Avengers. Congratz!';

        assert.deepEqual(actual, expected);
    });

    it('5', function () {
        filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
        filmStudio.casting('Eray', 'Hulk')

        let actual = filmStudio.casting('Eray', 'Batman');
        let expected = 'Eray, we cannot find a Batman role...';

        assert.deepEqual(actual, expected);
    });

    it('6', function () {
        let actual = function () {
            filmStudio.makeMovie('The Avengers', 'Batman');
        };

        let expected = 'Invalid arguments';

        assert.throws(actual, expected);
    });

    it('7', function () {
        let actual = function () {
            filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Hulk', 'Arrow guy', 'Ant-man'], 'JS');
        };

        let expected = 'Invalid arguments count';

        assert.throws(actual, expected);
    });

    it('8', function () {
        filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Hulk', 'Arrow guy', 'Ant-man']);
        filmStudio.makeMovie('The New Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy', 'Black Panther']);

        let actual = function () {
            filmStudio.lookForProducer('Hulk');
        };

        let expected = 'Hulk do not exist yet, but we need the money...';

        assert.throws(actual, expected);
    });
});