const StringBuilder = require('./05. String Builder');
const assert = require('chai').assert;

describe('StringBuilder', function () {
    
    let sb;
    beforeEach(function () {
        sb = new StringBuilder();
    });

    it('should have the correct function properties', function () {
        assert.isFunction(StringBuilder.prototype.append);
        assert.isFunction(StringBuilder.prototype.prepend);
        assert.isFunction(StringBuilder.prototype.insertAt);
        assert.isFunction(StringBuilder.prototype.remove);
        assert.isFunction(StringBuilder.prototype.toString);
    });

    describe('constructor tests', function(){
        it('should initialized without parameters', function(){
            let actual = '';
            let expected = sb.toString();

            assert.equal(actual, expected);
        });

        it('should initialized with correct parameters', function(){
            let actual = new StringBuilder('JS');
            let expected = 'JS';

            assert.equal(actual, expected);
        });
    });

    describe('append tests', function(){
        it('should append with correct parameters', function(){
            sb.append('JS');
            let actual = 'JS';
            let expected = sb.toString();

            assert.equal(actual, expected);
        });

        it('should throw error with incorrect parameters', function(){
            let actual = function () {
                sb.append({JS:'CSS'});
            };
            let expected = 'Argument must be string';

            assert.throws(actual, expected);
        });
    });

    describe('prepend tests', function(){
        it('should throw error with incorrect parameters', function(){
            let actual = function () {
                sb.prepend({JS:'CSS'});
            };
            let expected = 'Argument must be string';

            assert.throws(actual, expected);
        });
    });

    describe('insertAt tests', function(){
    });

    describe('remove tests', function(){
    });

    describe('several tests', function(){
        it('should insertAt with correct parameters', function(){
            sb.append('JS');
            sb.prepend('CSS');
            sb.insertAt(' HTML ', 3);
            sb.remove(4, 5);
            let actual = 'CSS JS';
            let expected = sb.toString();

            assert.equal(actual, expected);
        });
    });
});