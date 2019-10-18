const assert = require('chai').assert;
const SoftUniFy = require('../../03/03. Softunify_Ресурси');

describe('SoftUniFy', function () {

    beforeEach(function () {
        su = new SoftUniFy();
    });

    it('should return empty allSongs', function () {
        let actual = su.allSongs;
        let expected = {};

        assert.deepEqual(actual, expected);
    });

    it('should return \'error\' when artist is not in artist list', function () {
        let actual = su.rateArtist('Eminem');
        let expected = 'The Eminem is not on your artist list.';

        assert.deepEqual(actual, expected);
    });

    it('should return \'error\' when song is not downloaded', function () {
        su.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
        su.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
        su.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ');

        let actual = su.playSong('Candy Shop');
        let expected = 'You have not downloaded a Candy Shop song yet. Use SoftUniFy\'s function downloadSong() to change that!';

        assert.equal(actual, expected);
    });
});