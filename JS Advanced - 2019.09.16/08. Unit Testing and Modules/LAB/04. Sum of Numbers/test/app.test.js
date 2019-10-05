let expect = require('chai').expect;
const isOddOrEven = require('../app');

describe('isOddOrEven', function () {

   it('test with number parameter, should return undefined', function () {
      let actual = isOddOrEven(6); // number
      let expected = undefined;

      expect(actual).to.equal(expected);
   });

   it('test with object parameter, should return undefined', function () {
      let actual = isOddOrEven({ foo: 'bar' }); // object
      let expected = undefined;

      expect(actual).to.equal(expected);
   });

   it('test with string parameter, should return odd', function () {
      let actual = isOddOrEven('foo');
      let expected = 'odd';

      expect(actual).to.equal(expected);
   });

   it('test with string parameter, should return even', function () {
      let actual = isOddOrEven('javascript');
      let expected = 'even';

      expect(actual).to.equal(expected);
   });

});